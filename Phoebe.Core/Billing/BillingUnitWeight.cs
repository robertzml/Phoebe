using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.Billing
{
    /// <summary>
    /// 件重计费
    /// </summary>
    public class BillingUnitWeight : IBillingProcess
    {
        #region Override
        public decimal CalculatePeriodFee(decimal totalMeter, decimal unitPrice, int days)
        {
            throw new NotImplementedException();
        }
        #endregion //Override
    }
}
