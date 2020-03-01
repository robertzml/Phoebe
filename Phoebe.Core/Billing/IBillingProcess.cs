using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.Billing
{
    /// <summary>
    /// 计费处理接口
    /// </summary>
    public interface IBillingProcess
    {
        /// <summary>
        /// 计算库存周期冷藏费
        /// </summary>
        /// <param name="totalMeter">日总计量</param>
        /// <param name="unitPrice">单价</param>
        /// <param name="days">天数</param>
        /// <returns></returns>
        decimal CalculatePeriodFee(decimal totalMeter, decimal unitPrice, int days);
    }
}
