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
        /// 获取费用结算
        /// </summary>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public List<Settlement> GetByStatus(EntityStatus status)
        {
            return this.context.Settlements.Where(r => r.Status == (int)status).ToList();
        }

        /// <summary>
        /// 按客户获取结算
        /// </summary>
        /// <param name="customerType">客户类型</param>
        /// <param name="customerID">客户ID</param>
        /// <returns></returns>
        public List<Settlement> Get(int customerType, int customerID)
        {
            return this.context.Settlements.Where(r => r.CustomerType == customerType && r.CustomerID == customerID).ToList();
        }

        /// <summary>
        /// 获取费用结算
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public Settlement Get(string id)
        {
            Guid gid;
            if (!Guid.TryParse(id, out gid))
                return null;

            return this.context.Settlements.Find(gid);
        }

        /// <summary>
        /// 处理基本费用结算
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
        /// 处理冷藏费用结算
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

        /// <summary>
        /// 结算审核
        /// </summary>
        /// <param name="id">结算ID</param>
        /// <param name="paidPrice">付款</param>
        /// <param name="confirmTime">确认时间</param>
        /// <param name="remark">备注</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public ErrorCode Audit(string id, decimal paidPrice, DateTime confirmTime, string remark, EntityStatus status)
        {
            try
            {
                Guid gid;
                if (!Guid.TryParse(id, out gid))
                    return ErrorCode.ObjectNotFound;

                Settlement settle = this.context.Settlements.Find(gid);
                if (settle == null)
                    return ErrorCode.ObjectNotFound;

                settle.PaidPrice = paidPrice;
                settle.ConfirmTime = confirmTime;
                settle.Remark = remark;
                settle.Status = (int)status;

                foreach (var item in settle.SettlementDetails)
                {
                    item.Status = (int)status;

                    if (item.ExpenseType == (int)ExpenseType.Base)
                    {
                        var billing = this.context.Billings.Find(item.CargoID);
                        if (status == EntityStatus.SettlePaid)
                        {
                            billing.Status = (int)EntityStatus.BillingPaid;
                        }
                        else
                        {
                            billing.Status = (int)EntityStatus.BillingUnsettle;
                        }
                    }
                }

                if (status == EntityStatus.SettleCancel)
                    settle.PaidPrice = null;

                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }
        #endregion //Settlement

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
