using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.Billing
{
    using SqlSugar;
    using Phoebe.Core.Model;

    /// <summary>
    /// 合同接口
    /// </summary>
    public interface IContract
    {
        /// <summary>
        /// 获取合同冷藏费记录 
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        List<DailyColdRecord> GetColdRecord(int contractId, DateTime startTime, DateTime endTime, SqlSugarClient db);

        /// <summary>
        /// 获取库存冷藏费用
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="storeMeter">库存计量</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <param name="isOut">是否出库</param>
        /// <returns></returns>
        ColdSettlement GetStoreColdFee(int contractId, decimal storeMeter, DateTime start, DateTime end, bool isOut, SqlSugarClient db);
    }
}
