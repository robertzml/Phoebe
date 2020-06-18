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
        /// <param name="task">出库任务</param>
        /// <returns></returns>
        decimal GetFlowMeter(StockOutTaskView task);

        /// <summary>
        /// 获取入库单位计量
        /// </summary>
        /// <param name="task">入库任务</param>
        /// <returns></returns>
        decimal GetUnitMeter(StockInTaskView task);

        /// <summary>
        /// 获取出库单位计量
        /// </summary>
        /// <param name="task">出库任务</param>
        /// <returns></returns>
        decimal GetUnitMeter(StockOutTaskView task);

        /// <summary>
        /// 获取在库总计量
        /// </summary>
        /// <param name="storeViews">库存列表</param>
        /// <returns></returns>
        decimal GetTotalMeter(List<StoreView> storeViews);

        /// <summary>
        /// 获取在库总计量
        /// </summary>
        /// <param name="normalStoreViews">普通库存列表</param>
        /// <returns></returns>
        decimal GetTotalMeter(List<NormalStoreView> normalStoreViews);

        /// <summary>
        /// 获取库存计量
        /// </summary>
        /// <param name="storeView">库存记录</param>
        decimal GetStoreMeter(StoreView storeView);

        /// <summary>
        /// 获取库存计量
        /// </summary>
        /// <param name="normalStoreView">普通库存记录</param>
        decimal GetStoreMeter(NormalStoreView normalStoreView);

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

        /// <summary>
        /// 计算库存周期冷藏费
        /// </summary>
        /// <param name="totalMeter">日总计量</param>
        /// <param name="unitPrice">单价</param>
        /// <param name="days">天数</param>
        /// <returns></returns>
        decimal CalculatePeriodFee(decimal totalMeter, decimal unitPrice, int days);

        /// <summary>
        /// 计算库存周期冷藏费
        /// </summary>
        /// <param name="storeView">仓位库库存</param>
        /// <param name="unitPrice">单价</param>
        /// <param name="startTime">开始日期</param>
        /// <param name="endTime">结束日期</param>
        /// <returns></returns>
        decimal CalculatePeriodColdFee(StoreView storeView, decimal unitPrice, DateTime startTime, DateTime endTime);

        /// <summary>
        /// 计算库存周期冷藏费
        /// </summary>
        /// <param name="storeView">普通库库存</param>
        /// <param name="unitPrice">单价</param>
        /// <param name="startTime">开始日期</param>
        /// <param name="endTime">结束日期</param>
        /// <returns></returns>
        decimal CalculatePeriodColdFee(NormalStoreView storeView, decimal unitPrice, DateTime startTime, DateTime endTime);
    }
}
