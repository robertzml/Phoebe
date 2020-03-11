﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Core.Billing
{
    using Phoebe.Core.View;

    /// <summary>
    /// 件重计费
    /// </summary>
    public class BillingUnitWeight : IBillingProcess
    {
        #region Override
        /// <summary>
        /// 获取入库流水数量
        /// </summary>
        /// <param name="task">入库任务</param>
        /// <returns></returns>
        public decimal GetFlowMeter(StockInTaskView task)
        {
            return task.InWeight;
        }

        /// <summary>
        /// 获取出库流水计量
        /// </summary>
        /// <param name="task">入库任务</param>
        /// <returns></returns>
        public decimal GetFlowMeter(StockOutTaskView task)
        {
            return task.OutWeight;
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
            return totalMeter * unitPrice * days;
        }

        /// <summary>
        /// 获取在库总计量
        /// </summary>
        /// <param name="storeViews">库存列表</param>
        /// <returns></returns>
        public decimal GetTotalMeter(List<StoreView> storeViews)
        {
            return storeViews.Sum(r => r.StoreWeight);
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
            return totalMeter * unitPrice;
        }
        #endregion //Override
    }
}
