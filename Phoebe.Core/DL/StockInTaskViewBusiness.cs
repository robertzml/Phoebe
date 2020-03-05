using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.DL
{
    using SqlSugar;
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
        public List<StockInTaskView> FindList(string stockInId, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();
            return db.Queryable<StockInTaskView>().Where(r => r.StockInId == stockInId).ToList();
        }

        /// <summary>
        /// 按日期获取入库任务
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="date">日期</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public List<StockInTaskView> FindByDate(int contractId, DateTime date, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<StockInTaskView>()
                .Where(r => r.ContractId == contractId && r.InTime == date.Date && r.Status == (int)EntityStatus.StockInFinish)
                .ToList();

            return data;
        }
        #endregion //Method
    }
}
