using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 结算业务类
    /// </summary>
    public class SettleBusiness
    {
        #region Field
        private PhoebeContext context;
        #endregion //Field

        #region Constructor
        public SettleBusiness()
        {
            this.context = new PhoebeContext();
        }
        #endregion //Constructor

        #region Method
        #region Base Settlement
        /// <summary>
        /// 获取基本费用结算
        /// </summary>
        /// <returns></returns>
        public List<BaseSettlement> GetBase()
        {
            var data = this.context.BaseSettlements.OrderByDescending(r => r.ConfirmTime);
            return data.ToList();
        }

        /// <summary>
        /// 获取基本费用结算
        /// </summary>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public List<BaseSettlement> GetBase(EntityStatus status)
        {
            var data = this.context.BaseSettlements.Where(r => r.Status == (int)status);
            return data.ToList();
        }

        /// <summary>
        /// 获取基本费用结算
        /// </summary>
        /// <param name="id">结算ID</param>
        /// <returns></returns>
        public BaseSettlement GetBase(string id)
        {
            Guid gid;
            if (!Guid.TryParse(id, out gid))
                return null;

            return this.context.BaseSettlements.Find(gid);
        }

        /// <summary>
        /// 添加基本结算信息
        /// </summary>
        /// <param name="data">基本结算数据</param>
        /// <returns></returns>
        public ErrorCode BaseCreate(BaseSettlement data)
        {
            try
            {
                data.ID = Guid.NewGuid();
                data.Status = (int)EntityStatus.SettleUnpaid;

                this.context.BaseSettlements.Add(data);

                //edit cargo billing
                var billing = this.context.Billings.Find(data.CargoID);
                if (billing.Status != (int)EntityStatus.BillingUnsettle)
                {
                    return ErrorCode.CargoCannotSettled;
                }

                billing.Status = (int)EntityStatus.BillingSettle;

                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 基本结算审核
        /// </summary>
        /// <param name="id">结算ID</param>
        /// <param name="paidPrice">付款</param>
        /// <param name="confirmTime">确认时间</param>
        /// <param name="remark">备注</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public ErrorCode BaseAudit(string id, decimal paidPrice, DateTime confirmTime, string remark, EntityStatus status)
        {
            try
            {
                Guid gid;
                if (!Guid.TryParse(id, out gid))
                    return ErrorCode.ObjectNotFound;

                BaseSettlement baseSettle = this.context.BaseSettlements.Find(gid);
                if (baseSettle == null)
                    return ErrorCode.ObjectNotFound;

                baseSettle.PaidPrice = paidPrice;
                baseSettle.ConfirmTime = confirmTime;
                baseSettle.Remark = remark;
                baseSettle.Status = (int)status;

                BillingBusiness billingBusiness = new BillingBusiness();
                var billing = this.context.Billings.Find(baseSettle.CargoID);

                if (status == EntityStatus.SettlePaid)
                {
                    billing.Status = (int)EntityStatus.BillingPaid;
                }
                else
                {
                    baseSettle.PaidPrice = null;
                    billing.Status = (int)EntityStatus.BillingUnsettle;
                }

                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }
        #endregion //BaseSettlement

        #region ColdSettlement
        /// <summary>
        /// 获取冷藏费用结算
        /// </summary>
        /// <returns></returns>
        public List<ColdSettlement> GetCold()
        {
            var data = this.context.ColdSettlements.OrderByDescending(r => r.ConfirmTime);
            return data.ToList();
        }

        /// <summary>
        /// 获取冷藏费用结算
        /// </summary>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public List<ColdSettlement> GetCold(EntityStatus status)
        {
            var data = this.context.ColdSettlements.Where(r => r.Status == (int)status);
            return data.ToList();
        }

        /// <summary>
        /// 获取冷藏费用结算
        /// </summary>
        /// <param name="id">结算ID</param>
        /// <returns></returns>
        public ColdSettlement GetCold(string id)
        {
            Guid gid;
            if (!Guid.TryParse(id, out gid))
                return null;

            return this.context.ColdSettlements.Find(gid);
        }

        /// <summary>
        /// 处理日冷藏费
        /// </summary>
        /// <param name="contractID">合同ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public List<DailyColdRecord> ProcessDailyCold(int contractID, DateTime start, DateTime end)
        {
            List<DailyColdRecord> records = new List<DailyColdRecord>();
            BillingBusiness billingBusiness = new BillingBusiness();

            decimal totalFee = 0;
            for (DateTime step = start.Date; step <= end; step = step.AddDays(1))
            {
                var nextDay = step.AddDays(1);

                var record = billingBusiness.GetDailyColdRecord(contractID, step);
                var last = record.Last();

                totalFee += last.DailyFee;
                last.TotalFee = totalFee;

                records.AddRange(record);
            }

            return records;
        }

        /// <summary>
        /// 添加冷藏费结算
        /// </summary>
        /// <param name="data">冷藏费数据</param>
        /// <returns></returns>
        public ErrorCode ColdCreate(ColdSettlement data)
        {
            try
            {
                data.ID = Guid.NewGuid();
                data.Status = (int)EntityStatus.SettleUnpaid;
                this.context.ColdSettlements.Add(data);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 冷藏费用审核
        /// </summary>
        /// <param name="id">结算ID</param>
        /// <param name="paidPrice">付款</param>
        /// <param name="confirmTime">确认时间</param>
        /// <param name="remark">备注</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public ErrorCode ColdAudit(string id, decimal paidPrice, DateTime confirmTime, string remark, EntityStatus status)
        {
            try
            {
                Guid gid;
                if (!Guid.TryParse(id, out gid))
                    return ErrorCode.ObjectNotFound;

                ColdSettlement coldSettle = this.context.ColdSettlements.Find(gid);
                if (coldSettle == null)
                    return ErrorCode.ObjectNotFound;

                coldSettle.PaidPrice = paidPrice;
                coldSettle.ConfirmTime = confirmTime;
                coldSettle.Remark = remark;
                coldSettle.Status = (int)status;

                this.context.SaveChanges();

            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }
        #endregion //ColdSettlement
        #endregion //Method
    }
}
