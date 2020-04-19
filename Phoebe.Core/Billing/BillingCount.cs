using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Core.Billing
{
    using Phoebe.Core.View;

    /// <summary>
    /// 计数计费
    /// </summary>
    public class BillingCount : IBillingProcess
    {
        #region Override
        /// <summary>
        /// 获取入库流水数量
        /// </summary>
        /// <param name="task">入库任务</param>
        /// <returns></returns>
        public decimal GetFlowMeter(StockInTaskView task)
        {
            return task.InCount;
        }

        /// <summary>
        /// 获取出库流水计量
        /// </summary>
        /// <param name="task">入库任务</param>
        /// <returns></returns>
        public decimal GetFlowMeter(StockOutTaskView task)
        {
            return task.OutCount;
        }

        /// <summary>
        /// 获取入库单位计量
        /// </summary>
        /// <param name="task">入库任务</param>
        /// <returns></returns>
        public decimal GetUnitMeter(StockInTaskView task)
        {
            return 1;
        }

        /// <summary>
        /// 获取出库单位计量
        /// </summary>
        /// <param name="task">出库任务</param>
        /// <returns></returns>
        public decimal GetUnitMeter(StockOutTaskView task)
        {
            return 1;
        }

        /// <summary>
        /// 获取在库总计量
        /// </summary>
        /// <param name="storeViews">库存列表</param>
        /// <returns></returns>
        public decimal GetTotalMeter(List<StoreView> storeViews)
        {
            return storeViews.Sum(r => r.StoreCount);
        }

        /// <summary>
        /// 获取在库总计量
        /// </summary>
        /// <param name="normalStoreViews">普通库存列表</param>
        /// <returns></returns>
        public decimal GetTotalMeter(List<NormalStoreView> normalStoreViews)
        {
            return normalStoreViews.Sum(r => r.StoreCount);
        }

        /// <summary>
        /// 获取库存计量
        /// </summary>
        /// <param name="storeView">库存记录</param>
        public decimal GetStoreMeter(StoreView storeView)
        {
            return storeView.StoreCount;
        }

        /// <summary>
        /// 获取库存计量
        /// </summary>
        /// <param name="normalStoreView">普通库存记录</param>
        public decimal GetStoreMeter(NormalStoreView normalStoreView)
        {
            return normalStoreView.StoreCount;
        }

        /// <summary>
        /// 计算库存的日冷藏费
        /// </summary>
        /// <param name="totalMeter">在库总计量</param>
        /// <param name="unitPrice">冷藏费单价</param>
        /// <returns></returns>
        /// <remarks>
        /// 需同一合同内的库存
        /// </remarks>
        public decimal CalculateDailyFee(decimal totalMeter, decimal unitPrice)
        {
            return Math.Round(totalMeter * unitPrice, 3);
        }

        /// <summary>
        /// 计算货品周期冷藏费
        /// </summary>
        /// <param name="totalMeter">日总计量</param>
        /// <param name="unitPrice">单价</param>
        /// <param name="days">天数</param>
        /// <returns></returns>
        public decimal CalculatePeriodFee(decimal totalMeter, decimal unitPrice, int days)
        {
            return Math.Round(totalMeter * unitPrice * days, 3);
        }
        #endregion //Override
    }
}
