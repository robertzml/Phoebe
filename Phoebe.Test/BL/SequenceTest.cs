using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Phoebe.Core.BL;
using Phoebe.Core.Entity;

namespace Phoebe.Test.BL
{
    public class SequenceTest
    {
        private SequenceRecordBusiness sequenceRecordBusiness;

        [SetUp]
        public void Setup()
        {
            this.sequenceRecordBusiness = new SequenceRecordBusiness();
        }

        [TestCase(9)]
        [Test]
        public void TestFindId(int id)
        {
            var seq = this.sequenceRecordBusiness.GetNextSequence("Contract", new DateTime(2019, 1, 1), null);
            Assert.AreEqual("HT-2019-0001", seq);
        }
    }
}
