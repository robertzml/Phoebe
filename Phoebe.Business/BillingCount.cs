using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 计数计费
    /// </summary>
    public class BillingCount : IBillingProcess
    {
        #region Field
        private PhoebeContext context;
        #endregion //Field

        #region Constructor
        public BillingCount()
        {
            this.context = new PhoebeContext();
        }
        #endregion //Constructor

        #region Method
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
        #endregion //Method
    }
}
