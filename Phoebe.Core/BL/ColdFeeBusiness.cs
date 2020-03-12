using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.BL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.Entity;
    using Phoebe.Core.View;
    using Phoebe.Core.Billing;

    /// <summary>
    /// 冷藏费业务类
    /// </summary>
    public class ColdFeeBusiness : AbstractBusiness<ColdFee, string>, IBaseBL<ColdFee, string>
    {
        #region Method
        /// <summary>
        /// 获取库存冷藏费
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public ColdFee FindByStore(string storeId, DateTime current, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<ColdFee>().Single(r => r.StoreId == storeId);
            if (current > data.EndDate)
            {
                return data;
            }
            else
            {
                IBillingProcess billingProcess = new BillingUnitWeight();
                data.Days = current.Subtract(data.StartDate).Days;
                data.Amount = billingProcess.CalculatePeriodFee(data.Count, data.UnitPrice, data.Days);

                return data;
            }
        }
        #endregion //Method
    }
}
