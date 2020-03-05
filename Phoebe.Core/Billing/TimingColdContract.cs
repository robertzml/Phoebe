using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Core.Billing
{
    using SqlSugar;
    using Phoebe.Core.Model;
    using Phoebe.Core.Entity;
    using Phoebe.Core.View;

    /// <summary>
    /// 计时冷藏合同
    /// </summary>
    public class TimingColdContract : IContract
    {
        #region Function
        private DailyColdRecord coldFeeToDaily(List<ColdFee> data, DateTime date)
        {
            DailyColdRecord record = new DailyColdRecord();
            record.RecordDate = date;

            record.TotalMeter = data.Sum(r => r.Count);


            return record;
        }
        #endregion //Function

        #region Override
        /// <summary>
        /// 获取合同日冷藏费记录 
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public List<DailyColdRecord> GetDailyColdRecord(int contractId, DateTime startTime, DateTime endTime, SqlSugarClient db)
        {
            List<DailyColdRecord> records = new List<DailyColdRecord>();

            var contract = db.Queryable<ContractView>().In(contractId);

            var coldRecords = db.Queryable<ColdFee>()
                .Where(r => r.ContractId == contractId && r.StartDate <= startTime && (r.EndDate == null || r.EndDate >= endTime))
                .ToList();

            decimal totalFee = 0;
            for (DateTime step = startTime.Date; step <= endTime.Date; step = step.AddDays(1))
            {
                var todayRecords = coldRecords.Where(r => r.StartDate <= step && (r.EndDate == null || r.EndDate >= step)).ToList();

                foreach(var item in todayRecords)
                {

                }
            }

                return records;
        }

        /// <summary>
        /// 获取冷藏费用
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public ColdSettlement GetColdFee(int contractId, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
        #endregion //Override
    }
}
