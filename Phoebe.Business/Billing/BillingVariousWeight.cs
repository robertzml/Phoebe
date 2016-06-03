using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 非等重计费
    /// </summary>
    public class BillingVariousWeight : IBillingProcess
    {
        #region Method
        /// <summary>
        /// 获取单位重量
        /// </summary>
        /// <param name="cargo">货品</param>
        /// <returns></returns>
        public decimal GetUnitMeter(Cargo cargo)
        {
            return 1;
        }

        /// <summary>
        /// 获取单位计量
        /// </summary>
        /// <param name="flow">流水记录</param>
        /// <returns></returns>
        public decimal GetUnitMeter(StockFlow flow)
        {
            return 1;
        }

        /// <summary>
        /// 获取单位计量
        /// </summary>
        /// <param name="storage">库存记录</param>
        /// <returns></returns>
        public decimal GetUnitMeter(Storage storage)
        {
            return 1;
        }

        /// <summary>
        /// 获取流水重量(t)
        /// </summary>
        /// <param name="flow">流水记录</param>
        /// <returns></returns>
        public decimal GetFlowMeter(StockFlow flow)
        {
            if (flow.Type == StockFlowType.StockOut || flow.Type == StockFlowType.StockMoveOut)
                return -flow.FlowWeight;
            else
                return flow.FlowWeight;
        }

        /// <summary>
        /// 获取在库重量(t)
        /// </summary>
        /// <param name="storage">库存记录</param>
        /// <returns></returns>
        public decimal GetStoreMeter(Storage storage)
        {
            return storage.StoreWeight;
        }

        /// <summary>
        /// 计算日冷藏费
        /// </summary>
        /// <param name="totalMeter">总重量</param>
        /// <param name="unitPrice">单价</param>
        /// <returns></returns>
        public decimal CalculateDailyFee(decimal totalMeter, decimal unitPrice)
        {
            return totalMeter * unitPrice;
        }
        #endregion //Method
    }
}
