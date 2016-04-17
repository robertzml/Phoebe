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
                           where r.InTime >= start && r.InTime <= end && r.Status == 0 &&
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
            return this.context.Settlements.Where(r => r.CustomerID == customerID).OrderByDescending(r => r.StartTime).ToList();
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
        /// 获取客户上次结算
        /// </summary>
        /// <param name="customerID">客户ID</param>
        /// <returns></returns>
        public Settlement GetLast(int customerID)
        {
            var settles = this.context.Settlements.Where(r => r.CustomerID == customerID).OrderByDescending(r => r.EndTime);
            if (settles.Count() == 0)
                return null;
            else
                return settles.First();
        }

        /// <summary>
        /// 获取实时结算
        /// </summary>
        /// <param name="customerID">客户ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public Receipt GetRealTime(int customerID, DateTime start, DateTime end)
        {
            Receipt receipt = new Receipt();

            var customer = this.context.Customers.Find(customerID);
            if (customer == null)
                return null;

            receipt.CustomerID = customerID;
            receipt.CustomerName = customer.Name;
            receipt.SettleFee = 0;
            receipt.RealFee = 0;

            var settles = this.context.Settlements.Where(r => r.CustomerID == customerID).OrderByDescending(r => r.EndTime);
            if (settles.Count() != 0)
            {
                receipt.SettleFee = settles.Sum(r => r.DueFee);

                var last = settles.First();
                start = last.EndTime.AddDays(1);
            }

            var contracts = this.context.Contracts.Where(r => r.CustomerID == customerID);

            // get base fee
            var billings = from r in this.context.Billings
                           where r.InTime >= start && r.InTime <= end && r.Status == 0 && 
                                contracts.Select(s => s.ID).Contains(r.ContractID)
                           select r;

            if (billings.Count() > 0)
                receipt.RealFee = billings.Sum(r => r.TotalPrice);

            // get cold fee
            BillingBusiness billingBusiness = new BillingBusiness();

            foreach (var contract in contracts)
            {
                receipt.RealFee += billingBusiness.CalculateContractColdPrice(contract.ID, start, end);
            }

            // get paid fee
            var payments = this.context.Payments.Where(r => r.CustomerID == customerID);
            if (payments.Count() != 0)
                receipt.PaidFee = payments.Sum(r => r.PaidFee);

            receipt.Difference = receipt.SettleFee + receipt.RealFee - receipt.PaidFee;

            return receipt;
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
                this.context.Settlements.Add(data);

                foreach (var item in details)
                {
                    if (item.SumFee == 0)
                        continue;

                    if (item.ExpenseType == (int)ExpenseType.Base)
                    {
                        var billing = this.context.Billings.Find(item.StockInID);
                        billing.Status = (int)EntityStatus.Normal;
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
        /// 删除结算
        /// </summary>
        /// <param name="data">结算数据</param>
        /// <returns></returns>
        public ErrorCode Delete(Settlement data)
        {
            try
            {
                this.context.Settlements.Remove(data);
                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }
        #endregion //Method
    }
}
