using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Phoebe.Core.DL;
using Phoebe.Core.Service;
using Phoebe.Core.Entity;
using Phoebe.Common;

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
            this.startTime = new DateTime(2020, 5, 1);
            this.endTime = new DateTime(2020, 6, 15);

            this.expenseService = new ExpenseService();
        }

        [Test]
        public void TestGetDailyColdFee()
        {
            var result = expenseService.GetDailyColdFee(customerId, contractId, startTime, endTime);
            Assert.IsTrue(result.success);
        }

        [Test]
        public void TestGetPeriodColdFee()
        {
            ContractViewBusiness contractViewBusiness = new ContractViewBusiness();
            var contractView = contractViewBusiness.FindById(contractId);

            var data = expenseService.GetPeriodColdFee(contractView, startTime, endTime);
            Assert.IsTrue(data.ColdFee > 0);
        }

        [Test]
        public void TestGetPeriodColdFeeByCustomer()
        {
            var data = expenseService.GetPeriodColdFeeByCustomer(customerId, startTime, endTime);
            Assert.IsTrue(data.Count > 0);
        }

        [Test]
        public void TestGetDebt()
        {
            var data = expenseService.GetDebt(customerId);
            Assert.IsTrue(data.DebtFee > 0);
        }
    }
}
