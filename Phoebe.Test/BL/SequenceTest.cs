using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
        
        [Test]
        public void TestGetNextSequence()
        {
            var seq = this.sequenceRecordBusiness.GetNextSequence("Contract", new DateTime(2019, 1, 1), null);
            Assert.AreEqual("HT-2019-0003", seq.number);
        }

        [Test]
        public void TestFormatSequence()
        {
            string format = "HT-{1:yyyyMMdd}-{0:0000}-{2}";
            int seq = 1;
            DateTime year = new DateTime(2019, 2, 1);
            string p1 = "zml";

            var str = this.sequenceRecordBusiness.FormatSequence(format, seq, year, p1);
            Assert.AreEqual("HT-20190201-0001-zml", str);
        }

        [Test]
        public void TestRegex()
        {
            string pattern = @"\{1:.+?\}";
            string input = "HT-{1:yyyyMM}-{0:000}-abc";

            var match = Regex.Match(input, pattern);
            if (match.Success)
            {
                string format = Regex.Replace(match.Value, "1", "0");
                var dateStr = string.Format(format, DateTime.Now);
                Console.WriteLine(dateStr);
            }
        }
    }
}
