﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.BL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.View;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 入库视图业务类
    /// </summary>
    public class StockInViewBusiness : AbstractBusiness<StockInView, string>, IBaseBL<StockInView, string>
    {
        #region Method
        /// <summary>
        /// 获取入库月份分组
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 用于树形导航分组
        /// </remarks>
        public string[] GetMonthGroup()
        {
            var db = GetInstance();
            var data = db.Queryable<StockInView>()
                .GroupBy(r => new { r.MonthTime })
                .OrderBy(r => r.MonthTime, OrderByType.Desc)
                .Select(r => r.MonthTime)                
                .ToList();

            return data.ToArray();
        }

        /// <summary>
        /// 按月度获取入库记录
        /// </summary>
        /// <param name="monthTime">月份</param>
        /// <returns></returns>
        public List<StockInView> FindByMonth(string monthTime)
        {
            var db = GetInstance();
            return db.Queryable<StockInView>()
                .Where(r => r.MonthTime == monthTime)
                .OrderBy(r => r.FlowNumber, OrderByType.Desc)
                .ToList();
        }
        #endregion //Method
    }
}
