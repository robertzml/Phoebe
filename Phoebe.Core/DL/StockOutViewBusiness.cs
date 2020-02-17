using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.DL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.View;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 出库视图业务类
    /// </summary>
    public class StockOutViewBusiness : AbstractBusiness<StockOutView, string>, IBaseBL<StockOutView, string>
    {
        #region Method
        /// <summary>
        /// 获取出库月份分组
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 用于树形导航分组
        /// </remarks>
        public string[] GetMonthGroup()
        {
            var db = GetInstance();
            var data = db.Queryable<StockOutView>()
                .GroupBy(r => new { r.MonthTime })
                .OrderBy(r => r.MonthTime, OrderByType.Desc)
                .Select(r => r.MonthTime)
                .ToList();

            return data.ToArray();
        }

        /// <summary>
        /// 按月度获取出库单
        /// </summary>
        /// <param name="monthTime">月份</param>
        /// <returns></returns>
        public List<StockOutView> FindByMonth(string monthTime)
        {
            var db = GetInstance();
            return db.Queryable<StockOutView>()
                .Where(r => r.MonthTime == monthTime)
                .OrderBy(r => r.FlowNumber, OrderByType.Desc)
                .ToList();
        }

        /// <summary>
        /// 按出库日期获取出库单
        /// </summary>
        /// <param name="outTime">出库日期</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public List<StockOutView> FindByTime(DateTime outTime, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            return db.Queryable<StockOutView>()
                .Where(r => r.OutTime == outTime.Date)
                .OrderBy(r => r.FlowNumber, OrderByType.Desc)
                .ToList();
        }
        #endregion //Method
    }
}
