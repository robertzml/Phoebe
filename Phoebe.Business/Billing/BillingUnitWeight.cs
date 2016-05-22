using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 件重计费
    /// </summary>
    public class BillingUnitWeight : IBillingProcess
    {
        public decimal GetUnitMeter(Cargo cargo)
        {
            return cargo.UnitWeight;
        }


        public decimal GetFlowMeter(StockFlow flow, decimal unitMeter)
        {
            if (flow.Type == StockFlowType.StockOut || flow.Type == StockFlowType.StockMoveOut)
                return -flow.FlowWeight;
            else
                return flow.FlowWeight;
        }

        public decimal GetStoreMeter(Storage storage, decimal unitMeter)
        {
            return storage.StoreWeight;
        }

      
        public decimal CalculateDailyFee(decimal totalMeter, decimal unitPrice)
        {
            return totalMeter * unitPrice;
        }

    }
}
