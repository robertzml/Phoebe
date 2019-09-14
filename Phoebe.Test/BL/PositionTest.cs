using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Phoebe.Core.BL;
using Phoebe.Core.Entity;
using Phoebe.Core.View;


namespace Phoebe.Test.BL
{
    public class PositionTest
    {
        private PositionBusiness positionBusiness;

        [SetUp]
        public void Setup()
        {
            this.positionBusiness = new PositionBusiness();
        }

        [Test]
        public void TestUpdateShelfCode()
        {
            var positions = positionBusiness.FindAll();

            foreach(var item in positions)
            {
                item.ShelfCode = item.Number.Substring(0, 12);

                if (!string.IsNullOrEmpty(item.ViceNumber))
                {
                    item.ViceShelfCode = item.ViceNumber.Substring(0, 12);
                }

                var result = positionBusiness.Update(item);

                Assert.IsTrue(result.success);
            }
        }
    }
}
