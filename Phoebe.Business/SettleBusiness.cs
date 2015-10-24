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
        #endregion //ColdSettlement
        #endregion //Method
    }
}
