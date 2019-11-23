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

        /// <summary>
        /// 根据托盘码查找任务
        /// </summary>
        /// <param name="trayCode">托盘码</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public List<StockInTaskView> FindByTray(string trayCode, EntityStatus status)
        {
            var db = GetInstance();

            var data = db.Queryable<StockInTaskView>().Where(r => r.TrayCode == trayCode && r.Status == (int)status);

            return data.ToList();
        }
        #endregion //Method
    }
}
