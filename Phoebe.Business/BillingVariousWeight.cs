using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 非等重计费
    /// </summary>
    public class BillingVariousWeight : IBillingProcess
    {
        public decimal CalculateColdPrice(Cargo cargo, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public decimal CalculateContractColdPrice(Contract contract, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public decimal CalculateDailyFee(decimal totalMeter, decimal unitPrice)
        {
            throw new NotImplementedException();
        }

        public decimal GetFlowMeter(StockFlow flow, decimal unitMeter)
        {
            throw new NotImplementedException();
        }

        public decimal GetStoreMeter(Storage storage, decimal unitMeter)
        {
            throw new NotImplementedException();
        }

        public decimal GetUnitMeter(Cargo cargo)
        {
            throw new NotImplementedException();
        }
    }
}
