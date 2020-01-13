using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Core.BL
{
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
        /// 获取待办出库搬运任务
        /// </summary>
        /// <returns></returns>
        public List<CarryOutTaskView> ListToDo()
        {
            var db = GetInstance();
            var data = db.Queryable<CarryOutTaskView>().Where(r => r.Status == (int)EntityStatus.StockOutReady);
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
        /// 获取用户当前接单任务
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public List<CarryOutTaskView> FindCurrentReceive(int userId)
        {
            var db = GetInstance();
            var data = db.Queryable<CarryOutTaskView>().Where(r => r.ReceiveUserId == userId && r.Status == (int)EntityStatus.StockOutReceive);

            return data.ToList();
        }
        #endregion //Method
    }
}
