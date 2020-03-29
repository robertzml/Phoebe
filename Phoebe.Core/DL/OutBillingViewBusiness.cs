using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.DL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.View;

    /// <summary>
    /// 出库计费视图业务类
    /// </summary>
    public class OutBillingViewBusiness : AbstractBusiness<OutBillingView, string>, IBaseBL<OutBillingView, string>
    {
        #region Method
        /// <summary>
        /// 查找出库单对应计费
        /// </summary>
        /// <param name="stockOutId"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public List<OutBillingView> FindByStockOut(string stockOutId, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            return db.Queryable<OutBillingView>().Where(r => r.StockOutId == stockOutId).ToList();
        }
        #endregion //Method
    }
}
