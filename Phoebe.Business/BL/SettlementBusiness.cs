using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Phoebe.Business
{
    using Phoebe.Base;
    using Phoebe.Model;
    using Phoebe.Business.DAL;

    /// <summary>
    /// 结算业务类
    /// </summary>
    public class SettlementBusiness : BaseBusiness<Settlement>
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IBaseDataAccess<Settlement> dal;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 结算业务类
        /// </summary>
        public SettlementBusiness() : base()
        {
            this.dal = RepositoryFactory<SettlementRepository>.Instance;
            base.Init(this.dal);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 获取最新流水单号
        /// </summary>
        /// <param name="settleTime">结算时间</param>
        /// <returns></returns>
        private string GetLastFlowNumber(DateTime settleTime)
        {
            Expression<Func<Settlement, bool>> predicate = r => r.SettleTime == settleTime;
            var data = this.dal.Find(predicate).OrderByDescending(r => r.Number);

            if (data.Count() == 0)
                return string.Format("{0}{1}{2}0001",
                    settleTime.Year, settleTime.Month.ToString().PadLeft(2, '0'), settleTime.Day.ToString().PadLeft(2, '0'));
            else
            {
                int newNumber = Convert.ToInt32(data.First().Number.Substring(8)) + 1;
                return string.Format("{0}{1}{2}{3}", settleTime.Year, settleTime.Month.ToString().PadLeft(2, '0'),
                    settleTime.Day.ToString().PadLeft(2, '0'), newNumber.ToString().PadLeft(4, '0'));
            }
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 获取客户上次结算
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <returns></returns>
        public Settlement GetLast(int customerId)
        {
            var settles = this.dal.FindAll().Where(r => r.CustomerId == customerId).OrderByDescending(r => r.EndTime);
            if (settles.Count() == 0)
                return null;
            else
                return settles.First();
        }

        /// <summary>
        /// 获取客户结算记录
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <returns></returns>
        public List<Settlement> GetByCustomer(int customerId)
        {
            var settles = this.dal.Find(r => r.CustomerId == customerId);
            return settles.ToList();
        }

        /// <summary>
        /// 添加结算
        /// </summary>
        /// <param name="settlement">结算信息</param>
        /// <param name="details">详细记录</param>
        /// <returns></returns>
        public ErrorCode Create(Settlement settlement, List<SettlementDetail> details)
        {
            settlement.Number = GetLastFlowNumber(settlement.SettleTime);

            TransactionRepository trans = new TransactionRepository();
            return trans.SettlementAddTrans(settlement, details);
        }

        /// <summary>
        /// 获取客户欠款信息
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public Receipt GetDebt(int customerId, DateTime start, DateTime end)
        {
            Receipt receipt = new Receipt();

            var customer = BusinessFactory<CustomerBusiness>.Instance.FindById(customerId);
            if (customer == null)
                return null;

            receipt.CustomerId = customerId;
            receipt.CustomerName = customer.Name;
            receipt.SettleFee = 0;
            receipt.UnSettleFee = 0;

            var settles = this.dal.Find(r => r.CustomerId == customerId).OrderByDescending(r => r.EndTime);
            if (settles.Count() != 0)
            {
                receipt.SettleFee = settles.Sum(r => r.DueFee);

                var last = settles.First();
                start = last.EndTime.AddDays(1);
            }

            // get base fee
            var billings = BusinessFactory<BillingBusiness>.Instance.GetByCustomer(customerId, start, end);
            if (billings.Count() > 0)
                receipt.UnSettleFee = billings.Sum(r => r.TotalPrice);

            // get cold fee         
            var colds = BusinessFactory<BillingBusiness>.Instance.CalculateColdFee(customerId, start, end);
            if (colds.Count > 0)
                receipt.UnSettleFee += colds.Sum(r => r.ColdFee);

            // get paid fee
            var payments = BusinessFactory<PaymentBusiness>.Instance.GetByCustomer(customerId);
            if (payments.Count() != 0)
                receipt.PaidFee = payments.Sum(r => r.PaidFee);


            receipt.DebtFee = receipt.SettleFee + receipt.UnSettleFee - receipt.PaidFee;

            return receipt;
        }
        #endregion //Method
    }
}
