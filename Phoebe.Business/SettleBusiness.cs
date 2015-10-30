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
        #region Settlement
        /// <summary>
        /// 获取费用结算
        /// </summary>
        /// <returns></returns>
        public List<Settlement> Get()
        {
            var data = this.context.Settlements.OrderByDescending(r => r.StartTime);
            return data.ToList();
        }

        /// <summary>
        /// 获取基本费用结算
        /// </summary>
        /// <param name="customerType">客户类型</param>
        /// <param name="customerID">客户ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public List<Billing> BaseProcess(int customerType, int customerID, DateTime start, DateTime end)
        {
            var contracts = this.context.Contracts.Where(r => r.CustomerID == customerID && r.CustomerType == customerType && r.SignDate <= end);

            var cargos = from r in this.context.Cargoes
                         where r.Status != (int)EntityStatus.CargoNotIn && r.Status != (int)EntityStatus.CargoStockInReady &&
                            contracts.Select(s => s.ID).Contains(r.ContractID)
                         select r;

            var billings = from r in this.context.Billings
                           where r.Status != (int)EntityStatus.BillingPaid && cargos.Select(s => s.ID).Contains(r.CargoID)
                           select r;

            return billings.ToList();
        }

        /// <summary>
        /// 获取冷藏费用结算
        /// </summary>
        /// <param name="customerType">客户类型</param>
        /// <param name="customerID">客户ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public List<ColdSettlement> ColdProcess(int customerType, int customerID, DateTime start, DateTime end)
        {
            List<ColdSettlement> data = new List<ColdSettlement>();

            var contracts = this.context.Contracts.Where(r => r.CustomerID == customerID && r.CustomerType == customerType && r.SignDate <= end);

            BillingBusiness billingBusiness = new BillingBusiness();

            foreach (var contract in contracts)
            {
                ColdSettlement settle = new ColdSettlement();
                settle.StartTime = start;
                settle.EndTime = end;
                settle.ContractID = contract.ID;
                settle.ContractName = contract.Name;
                settle.ColdPrice = billingBusiness.CalculateContractColdPrice(contract.ID, start, end);

                data.Add(settle);
            }

            return data;
        }

        /// <summary>
        /// 添加结算
        /// </summary>
        /// <param name="data">结算数据</param>
        /// <param name="details">详细数据</param>
        /// <returns></returns>
        public ErrorCode Create(Settlement data, List<SettlementDetail> details)
        {
            try
            {
                data.ID = Guid.NewGuid();
                data.Status = (int)EntityStatus.SettleUnpaid;

                this.context.Settlements.Add(data);

                foreach (var item in details)
                {
                    item.SettlementID = data.ID;
                    item.Status = (int)EntityStatus.SettleUnpaid;

                    if (item.CargoID != null)
                    {
                        var billing = this.context.Billings.Find(item.CargoID);
                        billing.Status = (int)EntityStatus.BillingSettle;
                    }

                    this.context.SettlementDetails.Add(item);
                }

                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }
        #endregion //Settlement

        #region Base Settlement
        ///// <summary>
        ///// 获取基本费用结算
        ///// </summary>
        ///// <returns></returns>
        //public List<BaseSettlement> GetBase()
        //{
        //    var data = this.context.BaseSettlements.OrderByDescending(r => r.ConfirmTime);
        //    return data.ToList();
        //}

        ///// <summary>
        ///// 获取基本费用结算
        ///// </summary>
        ///// <param name="status">状态</param>
        ///// <returns></returns>
        //public List<BaseSettlement> GetBase(EntityStatus status)
        //{
        //    var data = this.context.BaseSettlements.Where(r => r.Status == (int)status);
        //    return data.ToList();
        //}

        ///// <summary>
        ///// 获取基本费用结算
        ///// </summary>
        ///// <param name="id">结算ID</param>
        ///// <returns></returns>
        //public BaseSettlement GetBase(string id)
        //{
        //    Guid gid;
        //    if (!Guid.TryParse(id, out gid))
        //        return null;

        //    return this.context.BaseSettlements.Find(gid);
        //}

        ///// <summary>
        ///// 获取合同基本费用结算
        ///// </summary>
        ///// <param name="ContractID">合同ID</param>
        ///// <returns></returns>
        //public List<BaseSettlement> GetBaseByContract(int ContractID)
        //{
        //    var data = from r in this.context.BaseSettlements
        //               where (from s in this.context.Cargoes
        //                      where s.ContractID == ContractID && s.Status != (int)EntityStatus.CargoNotIn
        //                      select s.ID).Contains(r.CargoID)
        //               select r;

        //    return data.ToList();
        //}

        ///// <summary>
        ///// 添加基本结算信息
        ///// </summary>
        ///// <param name="data">基本结算数据</param>
        ///// <returns></returns>
        //public ErrorCode BaseCreate(BaseSettlement data)
        //{
        //    try
        //    {
        //        data.ID = Guid.NewGuid();
        //        data.Status = (int)EntityStatus.SettleUnpaid;

        //        this.context.BaseSettlements.Add(data);

        //        //edit cargo billing
        //        var billing = this.context.Billings.Find(data.CargoID);
        //        if (billing.Status != (int)EntityStatus.BillingUnsettle)
        //        {
        //            return ErrorCode.CargoCannotSettled;
        //        }

        //        billing.Status = (int)EntityStatus.BillingSettle;

        //        this.context.SaveChanges();
        //    }
        //    catch (Exception)
        //    {
        //        return ErrorCode.Exception;
        //    }

        //    return ErrorCode.Success;
        //}

        ///// <summary>
        ///// 基本结算审核
        ///// </summary>
        ///// <param name="id">结算ID</param>
        ///// <param name="paidPrice">付款</param>
        ///// <param name="confirmTime">确认时间</param>
        ///// <param name="remark">备注</param>
        ///// <param name="status">状态</param>
        ///// <returns></returns>
        //public ErrorCode BaseAudit(string id, decimal paidPrice, DateTime confirmTime, string remark, EntityStatus status)
        //{
        //    try
        //    {
        //        Guid gid;
        //        if (!Guid.TryParse(id, out gid))
        //            return ErrorCode.ObjectNotFound;

        //        BaseSettlement baseSettle = this.context.BaseSettlements.Find(gid);
        //        if (baseSettle == null)
        //            return ErrorCode.ObjectNotFound;

        //        baseSettle.PaidPrice = paidPrice;
        //        baseSettle.ConfirmTime = confirmTime;
        //        baseSettle.Remark = remark;
        //        baseSettle.Status = (int)status;

        //        BillingBusiness billingBusiness = new BillingBusiness();
        //        var billing = this.context.Billings.Find(baseSettle.CargoID);

        //        if (status == EntityStatus.SettlePaid)
        //        {
        //            billing.Status = (int)EntityStatus.BillingPaid;
        //        }
        //        else
        //        {
        //            baseSettle.PaidPrice = null;
        //            billing.Status = (int)EntityStatus.BillingUnsettle;
        //        }

        //        this.context.SaveChanges();
        //    }
        //    catch (Exception)
        //    {
        //        return ErrorCode.Exception;
        //    }

        //    return ErrorCode.Success;
        //}
        #endregion //BaseSettlement

        #region ColdSettlement
        /// <summary>
        /// 处理货品日冷藏费
        /// </summary>
        /// <param name="cargoID">货品ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <remarks>
        /// 非计时货品无冷藏费
        /// </remarks>
        /// <returns></returns>
        public List<DailyColdRecord> ProcessDailyCold(string cargoID, DateTime start, DateTime end)
        {
            Guid cid;
            if (!Guid.TryParse(cargoID, out cid))
                return null;

            BillingBusiness billingBusiness = new BillingBusiness();
            var records = billingBusiness.GetCargoColdRecord(cid, start, end);

            return records;
        }

        /// <summary>
        /// 处理合同日冷藏费
        /// </summary>
        /// <param name="contractID">合同ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <remarks>
        /// 非计时合同无冷藏费
        /// </remarks>
        /// <returns></returns>
        public List<DailyColdRecord> ProcessDailyCold(int contractID, DateTime start, DateTime end)
        {
            BillingBusiness billingBusiness = new BillingBusiness();
            var records = billingBusiness.GetContractColdRecord(contractID, start, end);

            return records;
        }
        #endregion //ColdSettlement
        #endregion //Method
    }
}
