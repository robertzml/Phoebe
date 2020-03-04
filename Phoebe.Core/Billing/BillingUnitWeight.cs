using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.Billing
{
    /// <summary>
    /// 件重计费
    /// </summary>
    public class BillingUnitWeight : IBillingProcess
    {
        #region Override
        /// <summary>
        /// 计算货品周期冷藏费
        /// </summary>
        /// <param name="totalMeter">日总计量</param>
        /// <param name="unitPrice">单价</param>
        /// <param name="days">天数</param>
        /// <returns></returns>
        public decimal CalculatePeriodFee(decimal totalMeter, decimal unitPrice, int days)
        {
            return totalMeter * unitPrice * days;
        }
        #endregion //Override
    }
}
