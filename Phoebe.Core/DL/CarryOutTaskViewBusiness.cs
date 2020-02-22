using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Core.DL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.View;

    public class CarryOutTaskViewBusiness : AbstractBusiness<CarryOutTaskView, string>, IBaseBL<CarryOutTaskView, string>
    {
        #region Method
        /// <summary>
        /// 根据出库任务查找
        /// </summary>
        /// <param name="stockOutTaskId"></param>
        /// <returns></returns>
        public List<CarryOutTaskView> FindByStockOutTask(string stockOutTaskId)
        {
            var db = GetInstance();
            var data = db.Queryable<CarryOutTaskView>().Where(r => r.StockOutTaskId == stockOutTaskId);
            return data.ToList();
        }

        /// <summary>
        /// 根据入库任务查找
        /// </summary>
        /// <param name="stockInTaskId"></param>
        /// <returns></returns>
        public List<CarryOutTaskView> FindByStockInTask(string stockInTaskId)
        {
            var db = GetInstance();
            var data = db.Queryable<CarryOutTaskView>().Where(r => r.StockInTaskId == stockInTaskId);
            return data.ToList();
        }

        /// <summary>
        /// 获取待办出库搬运任务
        /// </summary>
        /// <returns>
        /// 待出库的仓位码
        /// </returns>
        public List<string> ListToOut()
        {
            var db = GetInstance();
            var data = db.Queryable<CarryOutTaskView>().Where(r => r.Status == (int)EntityStatus.StockOutReady).ToList();

            var positionNumbers = data.Select(r => r.PositionNumber).Distinct().ToList();
            return positionNumbers;
        }

        /// <summary>
        /// 获取待办出库搬运任务
        /// </summary>
        /// <param name="positionNumber">仓位码</param>
        /// <returns></returns>
        public List<CarryOutTaskView> FindByPosition(string positionNumber)
        {
            var db = GetInstance();
            var data = db.Queryable<CarryOutTaskView>().Where(r => r.PositionNumber == positionNumber && r.Status == (int)EntityStatus.StockOutReady).ToList();
            return data;
        }

        /// <summary>
        /// 根据托盘码获取当前搬运出库任务
        /// </summary>
        /// <param name="trayCode">托盘码</param>
        /// <returns></returns>
        public List<CarryOutTaskView> FindByTray(string trayCode, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<CarryOutTaskView>().Where(r => r.TrayCode == trayCode && r.Status == (int)EntityStatus.StockOutLeave);
            return data.ToList();
        }
        #endregion //Method
    }
}
