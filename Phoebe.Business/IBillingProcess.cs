using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 计费方法
    /// </summary>
    public interface IBillingProcess
    {
        /// <summary>
        /// 货品冷藏费计算
        /// </summary>
        /// <param name="cargoID">货品ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        decimal CalculateColdPrice(Guid cargoID, DateTime start, DateTime end);

        /// <summary>
        /// 计算货品总计量
        /// </summary>
        /// <param name="unitMeter">单位计量</param>
        /// <param name="count">数量</param>
        /// <returns></returns>
        decimal CalculateTotalMeter(decimal unitMeter, decimal count);

        decimal CalculateDailyFee(decimal totalMeter, decimal unitPrice);
    }
}
