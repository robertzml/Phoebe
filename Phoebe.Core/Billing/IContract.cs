﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.Billing
{
    using Phoebe.Core.Model;

    /// <summary>
    /// 合同接口
    /// </summary>
    public interface IContract
    {
        /// <summary>
        /// 获取冷藏费用
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        ColdSettlement GetColdFee(int contractId, DateTime start, DateTime end);
    }
}
