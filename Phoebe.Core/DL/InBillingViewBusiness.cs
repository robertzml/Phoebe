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
    /// 入库计费视图业务类
    /// </summary>
    public class InBillingViewBusiness : AbstractBusiness<InBillingView, string>, IBaseBL<InBillingView, string>
    {
        #region Method
        /// <summary>
        /// 查找入库单对应计费
        /// </summary>
        /// <param name="stockInId"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public List<InBillingView> FindByStockIn(string stockInId, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            return db.Queryable<InBillingView>().Where(r => r.StockInId == stockInId).ToList();
        }
        #endregion //Method
    }
}
