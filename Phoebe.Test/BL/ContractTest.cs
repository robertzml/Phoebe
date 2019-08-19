using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Phoebe.Core.BL;
using Phoebe.Core.Entity;
using Phoebe.Core.View;

namespace Phoebe.Test.BL
{
    public class ContractTest
    {
        private ContractViewBusiness contractViewBusiness;

        [SetUp]
        public void Setup()
        {
            this.contractViewBusiness = new ContractViewBusiness();
        }

        [TestCase(9)]
        [Test]
        public void TestFindId(int id)
        {
            var contract = this.contractViewBusiness.FindById(id);
            Assert.AreEqual("09002", contract.CustomerNumber);
        }
    }
}
