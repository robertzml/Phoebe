using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.Billing
{
    using Phoebe.Core.View;

    /// <summary>
    /// 计费处理接口
    /// </summary>
    public interface IBillingProcess
    {
        /// <summary>
        /// 获取入库流水计量
        /// </summary>
        /// <param name="task">入库任务</param>
        /// <returns></returns>
        decimal GetFlowMeter(StockInTaskView task);

        /// <summary>
        /// 获取出库流水计量
        /// </summary>
        /// <param name="task">入库任务</param>
        /// <returns></returns>
        decimal GetFlowMeter(StockOutTaskView task);

        /// <summary>
        /// 获取在库总计量
        /// </summary>
        /// <param name="storeViews">库存列表</param>
        /// <returns></returns>
        decimal GetTotalMeter(List<StoreView> storeViews);

        /// <summary>
        /// 计算库存周期冷藏费
        /// </summary>
        /// <param name="totalMeter">日总计量</param>
        /// <param name="unitPrice">单价</param>
        /// <param name="days">天数</param>
        /// <returns></returns>
        decimal CalculatePeriodFee(decimal totalMeter, decimal unitPrice, int days);

        /// <summary>
        /// 计算库存的日冷藏费
        /// </summary>
        /// <param name="totalMeter">在库总计量</param>
        /// <param name="unitPrice">冷藏费单价</param>
        /// <returns></returns>
        /// <remarks>
        /// 需同一合同内的库存
        /// </remarks>
        decimal CalculateDailyFee(decimal totalMeter, decimal unitPrice);
    }
}
