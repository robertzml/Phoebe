using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Phoebe.Core.BL;
using Phoebe.Core.DL;
using Phoebe.Core.Service;
using Phoebe.Core.Entity;
using Phoebe.Common;
using System.Linq;

namespace Phoebe.Test.Service
{
    public class ExpenseTest
    {
        private ExpenseService expenseService;
        private int customerId;
        private int contractId;
        private DateTime startTime;
        private DateTime endTime;

        [SetUp]
        public void Setup()
        {
            Cache.Instance.Add("ConnectionString", "Server=localhost;Database=phoebe4;User=uphoebe;Password=uphoebe123456;");

            this.customerId = 37;
            this.contractId = 1;
            this.startTime = new DateTime(2019, 6, 1);
            this.endTime = new DateTime(2020, 6, 22);

            this.expenseService = new ExpenseService();
        }

        /// <summary>
        /// 测试库存冷藏费
        /// </summary>
        [Test(Description = "测试库存冷藏费")]
        public void TestGetStoreColdFee()
        {
            string storeId = "e6c4c081-9a40-4bae-a92a-0036d84f2971";
            DateTime current = new DateTime(2020, 6, 18);
            int storeType = 2;

            var cold = this.expenseService.GetStoreColdFee(storeId, current, storeType);
            Assert.AreEqual(560, cold.ColdFee);
        }

        [Test]
        public void TestGetDailyColdFee()
        {
            var result = expenseService.GetDailyColdFee(customerId, contractId, startTime, endTime);
            Assert.IsTrue(result.success);
        }

        [Test(Description = "测试计算周期冷藏费")]
        public void TestGetPeriodColdFee()
        {
            ContractViewBusiness contractViewBusiness = new ContractViewBusiness();
            var contractView = contractViewBusiness.FindById(2110);

            var data1 = expenseService.GetPeriodColdFee(contractView, startTime, endTime);

            Console.WriteLine(data1.ColdFee);

            var data2 = expenseService.GetPeriodColdFeeMulti(contractView, startTime, endTime);

            Assert.AreEqual(data1.ColdFee, data2.ColdFee);
        }

        [Test(Description = "测试计算客户周期冷藏费")]
        public void TestGetPeriodColdFeeByCustomer()
        {
            int customerId = 37;
            var startTime = new DateTime(2020, 6, 1);
            var endTime = new DateTime(2020, 6, 20);

            var data1 = expenseService.GetPeriodColdFeeByCustomer(customerId, startTime, endTime);

            Console.WriteLine(data1.Sum(r => r.ColdFee));

            var data2 = expenseService.GetPeriodColdFeeMultiByCustomer(customerId, startTime, endTime);
            Console.WriteLine(data1.Sum(r => r.ColdFee));

            Assert.AreEqual(data1.Sum(r => r.ColdFee), data2.Sum(r => r.ColdFee));
        }

        [Test(Description = "测试计算客户周期冷藏费，测算耗时")]
        public void TestGetPeriodColdFeeByCustomerForTime()
        {
            var data2 = expenseService.GetPeriodColdFeeByCustomer(customerId, startTime, endTime);
            Console.WriteLine(data2.Sum(r => r.ColdFee));

            Assert.Pass();
        }

        [Test(Description = "测试计算客户周期冷藏费，测算耗时")]
        public void TestGetPeriodColdFeeByCustomerMultiForTime()
        {
            var data2 = expenseService.GetPeriodColdFeeMultiByCustomer(customerId, startTime, endTime);
            Console.WriteLine(data2.Sum(r => r.ColdFee));

            Assert.Pass();
        }

        [Test(Description = "测试所有客户周期冷藏费")]
        public void TestGetAllColdFee()
        {
            CustomerBusiness customerBusiness = new CustomerBusiness();
            var customers = customerBusiness.FindAll();        

            foreach(var customer in customers)
            {
                var data = expenseService.GetPeriodColdFeeMultiByCustomer(customer.Id, startTime, endTime);
            }

            Assert.Pass();
        }

        [Test]
        public void TestGetDebt()
        {
            var data = expenseService.GetDebt(customerId);
            Assert.IsTrue(data.DebtFee > 0);
        }
    }
}
