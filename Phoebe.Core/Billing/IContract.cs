using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.Billing
{
    using SqlSugar;
    using Phoebe.Core.Model;
    using Phoebe.Core.Entity;
    using Phoebe.Core.View;

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

        /// <summary>
        /// 获取冷藏费差价
        /// </summary>
        /// <param name="contract">合同</param>
        /// <param name="store">库存记录</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <param name="db"></param>
        /// <returns></returns>
        (int days, decimal count, decimal fee) CalculateDiffColdFee(Contract contract, NormalStoreView store, DateTime start, DateTime end, SqlSugarClient db);
    }
}
