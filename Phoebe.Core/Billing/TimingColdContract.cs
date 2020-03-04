using Phoebe.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.Billing
{
    using SqlSugar;
    using Phoebe.Core.Entity;
    using Phoebe.Core.View;

    /// <summary>
    /// 计时冷藏合同
    /// </summary>
    public class TimingColdContract : IContract
    {
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
