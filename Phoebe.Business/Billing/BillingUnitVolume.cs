using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Business
{
    using Phoebe.Base;
    using Phoebe.Business.DAL;
    using Phoebe.Model;

    /// <summary>
    /// 件体积计费
    /// </summary>
    public class BillingUnitVolume : IBillingProcess
    {
        #region Method
        /// <summary>
        /// 获取单位体积(立方)
        /// </summary>
        /// <param name="cargo">货品</param>
        /// <returns></returns>
        public decimal GetUnitMeter(Cargo cargo)
        {
            return cargo.UnitVolume;
        }

        /// <summary>
        /// 获取出入库体积(立方)
        /// </summary>
        /// <param name="flow">流水记录</param>
        /// <returns></returns>
        public decimal GetFlowMeter(StockFlow flow)
        {
            if (flow.Type == StockFlowType.StockOut || flow.Type == StockFlowType.StockMoveOut)
                return -flow.FlowVolume;
            else
                return flow.FlowVolume;
        }

        /// <summary>
        /// 获取在库体积(立方)
        /// </summary>
        /// <param name="storage">库存记录</param>
        /// <returns></returns>
        public decimal GetStoreMeter(Storage storage)
        {
            return storage.StoreVolume;
        }

        /// <summary>
        /// 计算日冷藏费
        /// </summary>
        /// <param name="totalMeter">总体积</param>
        /// <param name="unitPrice">单价</param>
        /// <returns></returns>
        public decimal CalculateDailyFee(decimal totalMeter, decimal unitPrice)
        {
            return totalMeter * unitPrice;
        }
        #endregion //Method
    }
}
