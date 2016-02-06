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
        #region Field
        private PhoebeContext context;
        #endregion //Field

        #region Constructor
        public BillingUnitWeight()
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

        /// <summary>
        /// 获取单位重量
        /// </summary>
        /// <param name="cargo">货品</param>
        /// <returns></returns>
        public decimal GetUnitMeter(Cargo cargo)
        {
            return Convert.ToDecimal(cargo.UnitWeight);
        }

        /// <summary>
        /// 计算货品总重量
        /// </summary>
        /// <param name="unitMeter">单位重量(kg)</param>
        /// <param name="count">数量</param>
        /// <returns>总重量(t)</returns>
        public decimal CalculateTotalMeter(decimal unitMeter, int count)
        {
            return unitMeter * count / 1000;
        }

        /// <summary>
        /// 计算货品日冷藏费
        /// </summary>
        /// <param name="totalMeter">总重量(t)</param>
        /// <param name="unitPrice">单价(元/t)</param>
        /// <returns></returns>
        public decimal CalculateDailyFee(decimal totalMeter, decimal unitPrice)
        {
            return totalMeter * unitPrice;
        }
        #endregion //Method
    }
}
