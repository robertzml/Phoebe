using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.BL
{
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.View;

    public class CarryInTaskViewBusiness : AbstractBusiness<CarryInTaskView, string>, IBaseBL<CarryInTaskView, string>
    {
        #region Method
        /// <summary>
        /// 根据托盘码查找任务
        /// </summary>
        /// <param name="trayCode">托盘码</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public List<CarryInTaskView> FindByTray(string trayCode, EntityStatus status)
        {
            var db = GetInstance();

            var data = db.Queryable<CarryInTaskView>().Where(r => r.TrayCode == trayCode && r.Status == (int)status);

            return data.ToList();
        }

        /// <summary>
        /// 根据入库任务查找
        /// </summary>
        /// <param name="stockInTaskId"></param>
        /// <returns></returns>
        public List<CarryInTaskView> FindByStockInTask(string stockInTaskId)
        {
            var db = GetInstance();
            var data = db.Queryable<CarryInTaskView>().Where(r => r.StockInTaskId == stockInTaskId);
            return data.ToList();
        }

        /// <summary>
        /// 根据出库任务查找
        /// </summary>
        /// <param name="stockOutTaskId"></param>
        /// <returns></returns>
        public List<CarryInTaskView> FindByStockOutTask(string stockOutTaskId)
        {
            var db = GetInstance();
            var data = db.Queryable<CarryInTaskView>().Where(r => r.StockOutTaskId == stockOutTaskId);
            return data.ToList();
        }

        /// <summary>
        /// 获取用户当前接单任务
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public List<CarryInTaskView> FindCurrentReceive(int userId)
        {
            var db = GetInstance();

            var data = db.Queryable<CarryInTaskView>().Where(r => r.ReceiveUserId == userId && r.Status == (int)EntityStatus.StockInReceive);

            return data.ToList();
        }
        #endregion //Method
    }
}
