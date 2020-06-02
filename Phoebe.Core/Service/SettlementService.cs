using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Core.Service
{
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.Billing;
    using Phoebe.Core.BL;
    using Phoebe.Core.DL;
    using Phoebe.Core.Entity;
    using Phoebe.Core.View;
    using Phoebe.Core.Model;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 结算服务类
    /// </summary>
    public class SettlementService : AbstractService
    {
        #region Method
        /// <summary>
        /// 获取客户欠款信息
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public Debt GetDebt(int customerId, DateTime start, DateTime end)
        {
            try
            {
                var db = GetInstance();

                CustomerBusiness customerBusiness = new CustomerBusiness();
                var customer = customerBusiness.FindById(customerId, db);

                Debt debt = new Debt();
                debt.CustomerId = customerId;
                debt.CustomerNumber = customer.Number;
                debt.CustomerName = customer.Name;
                debt.StartTime = start;
                debt.EndTime = end;
                debt.SettleFee = 0;
                debt.UnSettleFee = 0;

                // 获取已结算记录
                SettlementBusiness settlementBusiness = new SettlementBusiness();
                var settles = settlementBusiness.Query(r => r.CustomerId == customerId && r.EndTime <= end, db).OrderByDescending(r => r.EndTime);
                if (settles.Count() != 0)
                {
                    debt.SettleFee = settles.Sum(r => r.DueFee);

                    var last = settles.First();
                    start = last.EndTime.AddDays(1);
                }

                // 获取合同信息
                ContractViewBusiness contractViewBusiness = new ContractViewBusiness();
                var contracts = contractViewBusiness.Query(r => r.CustomerId == customerId, db);

                ExpenseService expenseService = new ExpenseService();

                if (start < end)
                {
                    // 获取冷藏费用
                    foreach (var contract in contracts)
                    {
                        var cold = expenseService.GetPeriodColdFee(contract, start, end);
                        debt.UnSettleFee += cold.ColdFee;
                    }

                    // 获取入库费用
                    var inBillings = expenseService.GetPeriodInBilling(customerId, start, end);
                    debt.UnSettleFee += inBillings.Sum(r => r.Amount);

                    // 获取出库费用
                    var outBillings = expenseService.GetPeriodOutBilling(customerId, start, end);
                    debt.UnSettleFee += outBillings.Sum(r => r.Amount);
                }

                // 获取付款数据
                PaymentBusiness paymentBusiness = new PaymentBusiness();
                var payments = paymentBusiness.Query(r => r.CustomerId == customerId && r.PaidTime <= end);
                if (payments.Count() != 0)
                    debt.PaidFee = payments.Sum(r => r.PaidFee);

                debt.SumFee = debt.SettleFee + debt.UnSettleFee;
                debt.DebtFee = debt.SumFee - debt.PaidFee;

                return debt;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion //Method
    }
} 