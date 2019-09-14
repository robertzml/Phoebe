using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.BL
{
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.View;

    public class StockInTaskViewBusiness : AbstractBusiness<StockInTaskView, string>, IBaseBL<StockInTaskView, string>
    {
        #region Method
        /// <summary>
        /// 获取入库任务列表
        /// </summary>
        /// <param name="stockInId">入库单ID</param>
        /// <returns></returns>
        public List<StockInTaskView> FindList(string stockInId)
        {
            var db = GetInstance();
            return db.Queryable<StockInTaskView>().Where(r => r.StockInId == stockInId).ToList();
        }
        #endregion //Method
    }
}
