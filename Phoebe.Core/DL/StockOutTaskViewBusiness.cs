using System;
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

        /// <summary>
        /// 按日期获取出库任务
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="date">日期</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public List<StockOutTaskView> FindByDate(int contractId, DateTime date, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<StockOutTaskView>()
                .Where(r => r.ContractId == contractId && r.OutTime == date.Date && r.Status == (int)EntityStatus.StockOutFinish)
                .ToList();

            return data;
        }
        #endregion //Method
    }
}
