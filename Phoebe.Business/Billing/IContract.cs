using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Business
{
    using Phoebe.Base;
    using Phoebe.Model;

    /// <summary>
    /// 合同接口
    /// </summary>
    public interface IContract
    {
        /// <summary>
        /// 获取基本费用
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        List<BaseSettlement> GetBaseFee(int contractId, DateTime start, DateTime end);

        /// <summary>
        /// 获取冷藏费用
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        ColdSettlement GetColdFee(int contractId, DateTime start, DateTime end);

        /// <summary>
        /// 获取杂项费用
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        MiscSettlement GetMisc(int contractId, DateTime start, DateTime end);

        /// <summary>
        /// 获取合同日冷藏费记录 
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        List<DailyColdRecord> GetColdRecord(int contractId, DateTime start, DateTime end);
    }
}
