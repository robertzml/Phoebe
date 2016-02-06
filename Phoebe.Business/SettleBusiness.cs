using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 结算业务类
    /// </summary>
    public class SettleBusiness
    {
        #region Field
        private PhoebeContext context;
        #endregion //Field

        #region Constructor
        public SettleBusiness()
        {
            this.context = new PhoebeContext();
        }
        #endregion //Constructor

        #region Cold Settlement
        /// <summary>
        /// 处理货品日冷藏费
        /// </summary>
        /// <param name="cargoID">货品ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <remarks>
        /// 非计时货品无冷藏费
        /// </remarks>
        /// <returns></returns>
        public List<DailyColdRecord> ProcessDailyCold(Guid cargoID, DateTime start, DateTime end)
        {
            BillingBusiness billingBusiness = new BillingBusiness();
            var records = billingBusiness.GetCargoColdRecord(cargoID, start, end);

            return records;
        }
        #endregion //Cold Settlment
    }
}
