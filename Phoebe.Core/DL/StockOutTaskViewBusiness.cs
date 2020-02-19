﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.DL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.View;

    public class StockOutTaskViewBusiness : AbstractBusiness<StockOutTaskView, string>, IBaseBL<StockOutTaskView, string>
    {
        #region Method
        /// <summary>
        /// 获取出库任务列表
        /// </summary>
        /// <param name="stockOutId">出库单ID</param>
        /// <returns></returns>
        public List<StockOutTaskView> FindList(string stockOutId, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();
            return db.Queryable<StockOutTaskView>().Where(r => r.StockOutId == stockOutId).ToList();
        }
        #endregion //Method
    }
}
