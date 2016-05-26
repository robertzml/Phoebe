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
    /// 件重计费
    /// </summary>
    public class BillingUnitWeight : IBillingProcess
    {
        #region Method
        /// <summary>
        /// 获取单位重量(kg)
        /// </summary>
        /// <param name="cargo">货品</param>
        /// <returns></returns>
        public decimal GetUnitMeter(Cargo cargo)
        {
            return cargo.UnitWeight;
        }

        /// <summary>
        /// 获取流水重量(t)
        /// </summary>
        /// <param name="flow">流水重量</param>
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
        /// <param name="storage">库存计量</param>
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
