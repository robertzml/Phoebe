using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Business
{
    using Phoebe.Base;
    using Phoebe.Model;
    using Phoebe.Business.DAL;

    /// <summary>
    /// 统计业务类
    /// </summary>
    public class StatisticBusiness
    {
        #region Method
        /// <summary>
        /// 获取费用日报表
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public List<DailyFee> GetDailyFee(DateTime date)
        {
            List<DailyFee> data = new List<DailyFee>();

            var customers = BusinessFactory<CustomerBusiness>.Instance.FindAll();

            foreach (var customer in customers)
            {
                var dailyFee = GetCustomerDailyFee(customer.Id, date);

                if (dailyFee.TotalFee == 0)
                    continue;

                data.Add(dailyFee);
            }

            return data;
        }

        /// <summary>
        /// 获取客户费用日报表
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public DailyFee GetCustomerDailyFee(int customerId, DateTime date)
        {
            DailyFee data = new DailyFee();

            var customer = BusinessFactory<CustomerBusiness>.Instance.FindById(customerId);

            data.CustomerId = customerId;
            data.CustomerNumber = customer.Number;
            data.CustomerName = customer.Name;
            data.Date = date;
            data.BaseFee = 0;
            data.ColdFee = 0;
            data.MiscFee = 0;

            var contracts = BusinessFactory<ContractBusiness>.Instance.GetByCustomer(customerId);

            foreach (var contract in contracts)
            {
                var contractBill = ContractFactory.Create((ContractType)contract.Type);

                var baseSettle = contractBill.GetBaseFee(contract.Id, date, date);
                if (baseSettle != null)
                    data.BaseFee += baseSettle.Sum(r => r.TotalPrice);

                var coldSettle = contractBill.GetColdFee(contract.Id, date, date);
                if (coldSettle != null)
                    data.ColdFee += coldSettle.ColdFee;

                var miscSettle = contractBill.GetMiscFee(contract.Id, date, date);
                if (miscSettle != null)
                    data.MiscFee += miscSettle.TotalFee;
            }

            data.TotalFee = data.BaseFee + data.ColdFee + data.MiscFee;

            return data;
        }
        #endregion //Method
    }
}
