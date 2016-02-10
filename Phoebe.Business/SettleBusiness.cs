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

        #region Base Settlement
        /// <summary>
        /// 处理基本费用结算
        /// </summary>
        /// <param name="customerType">客户类型</param>
        /// <param name="customerID">客户ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public List<Billing> BaseProcess(int customerID, DateTime start, DateTime end)
        {
            var contracts = this.context.Contracts.Where(r => r.CustomerID == customerID);

            var billings = from r in this.context.Billings
                           where r.Status == (int)EntityStatus.BillingUnsettle && r.InTime >= start && r.InTime <= end &&
                                contracts.Select(s => s.ID).Contains(r.ContractID)
                           select r;

            return billings.ToList();
        }
        #endregion //Base Settlement

        #region Cold Settlement
        /// <summary>
        /// 处理冷藏费用结算
        /// </summary>
        /// <param name="customerID">客户ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public List<ColdSettlement> ColdProcess(int customerID, DateTime start, DateTime end)
        {
            List<ColdSettlement> data = new List<ColdSettlement>();

            var contracts = this.context.Contracts.Where(r => r.CustomerID == customerID);

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
        #endregion //Cold Settlment

        #region Method
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
        /// 按客户获取结算
        /// </summary>
        /// <param name="customerID">客户ID</param>
        /// <returns></returns>
        public List<Settlement> Get(int customerID)
        {
            return this.context.Settlements.Where(r => r.CustomerID == customerID).ToList();
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
                data.Status = (int)EntityStatus.Settled;

                this.context.Settlements.Add(data);

                foreach (var item in details)
                {
                    item.SettlementID = data.ID;
                    item.Status = (int)EntityStatus.Settled;

                    if (item.ExpenseType == (int)ExpenseType.Base)
                    {
                        var billing = this.context.Billings.Find(item.StockInID);
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
        #endregion //Method
    }
}
