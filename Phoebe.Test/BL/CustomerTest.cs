using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Phoebe.Core.BL;
using Phoebe.Core.Entity;

namespace Phoebe.Test.BL
{
    public class CustomerTest
    {
        private CustomerBusiness customerBusiness;

        [SetUp]
        public void Setup()
        {
            this.customerBusiness = new CustomerBusiness();
        }

        [Test]
        public void TestFindAll()
        {
            var count = this.customerBusiness.FindAll().Count;
            Assert.AreEqual(274, count);            
        }

        [TestCase(1)]
        [Test]
        public void TestFindId(int id)
        {
            var cus = this.customerBusiness.FindById(id);
            Assert.AreEqual("02001", cus.Number);
        }
    }
}
