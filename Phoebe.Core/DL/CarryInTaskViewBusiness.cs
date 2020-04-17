using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.DL
{
    using SqlSugar;
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
        public List<CarryInTaskView> FindByTray(string trayCode, EntityStatus status, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<CarryInTaskView>().Where(r => r.TrayCode == trayCode && r.Status == (int)status);
            return data.ToList();
        }

        /// <summary>
        /// 根据入库任务查找
        /// </summary>
        /// <param name="stockInTaskId"></param>
        /// <returns></returns>
        public List<CarryInTaskView> FindByStockInTask(string stockInTaskId, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<CarryInTaskView>().Where(r => r.StockInTaskId == stockInTaskId);
            return data.ToList();
        }

        /// <summary>
        /// 根据出库任务查找
        /// </summary>
        /// <param name="stockOutTaskId"></param>
        /// <returns></returns>
        public List<CarryInTaskView> FindByStockOutTask(string stockOutTaskId, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<CarryInTaskView>().Where(r => r.StockOutTaskId == stockOutTaskId);
            return data.ToList();
        }

        /// <summary>
        /// 根据库存入库时间查找
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="inTime">库存入库时间</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public List<CarryInTaskView> FindByInTime(int contractId, DateTime inTime, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<CarryInTaskView>().Where(r => r.ContractId == contractId && r.InTime == inTime);
            return data.ToList();
        }

        /// <summary>
        /// 根据库存出库时间查找
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="outTime">库存出库时间</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public List<CarryInTaskView> FindByOutTime(int contractId, DateTime outTime, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<CarryInTaskView>().Where(r => r.ContractId == contractId && r.OutTime == outTime);
            return data.ToList();
        }
        #endregion //Method
    }
}
