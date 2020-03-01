using Phoebe.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.Billing
{
    /// <summary>
    /// 计时冷藏合同
    /// </summary>
    public class TimingColdContract : IContract
    {
        #region Override
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
