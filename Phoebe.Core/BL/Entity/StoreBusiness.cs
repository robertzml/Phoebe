using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.BL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.Entity;
    using Phoebe.Core.View;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 库存业务类
    /// </summary>
    public class StoreBusiness : AbstractBusiness<Store, string>, IBaseBL<Store, string>
    {
        #region Method
        /// <summary>
        /// 由入库任务生成库存记录
        /// </summary>
        /// <param name="db"></param>
        /// <param name="stockInTask"></param>
        /// <param name="task"></param>
        /// <returns></returns>
        public (bool success, string errorMessage, Store t) Create(SqlSugarClient db, StockInTaskView stockInTask, CarryInTask task)
        {
            Store store = new Store();
            store.Id = Guid.NewGuid().ToString();
            store.CustomerId = stockInTask.CustomerId;
            store.ContractId = stockInTask.ContractId;
            store.CargoId = stockInTask.CargoId;

            store.PositionId = task.PositionId;
            store.TrayCode = task.TrayCode;

            store.TotalCount = task.MoveCount;
            store.StoreCount = task.MoveCount;
            store.TotalWeight = task.MoveWeight;
            store.StoreWeight = task.MoveWeight;
          
            store.InTime = stockInTask.InTime;
            store.CarryInTaskId = task.Id;

            store.CreateTime = DateTime.Now;
            store.Status = (int)EntityStatus.StoreInReady;

            var t = db.Insertable(store).ExecuteReturnEntity();
            return (true, "", t);
        }

        /// <summary>
        /// 由出库任务生成库存记录
        /// </summary>
        /// <param name="db"></param>
        /// <param name="stockOutTask"></param>
        /// <param name="task"></param>
        /// <returns></returns>
        public (bool success, string errorMessage, Store t) Create(SqlSugarClient db, StockOutTaskView stockOutTask, CarryInTask task)
        {
            Store store = new Store();
            store.Id = Guid.NewGuid().ToString();
            store.CustomerId = stockOutTask.CustomerId;
            store.ContractId = stockOutTask.ContractId;
            store.CargoId = stockOutTask.CargoId;

            store.PositionId = task.PositionId;
            store.TrayCode = task.TrayCode;

            store.TotalCount = task.MoveCount;
            store.StoreCount = task.MoveCount;
            store.TotalWeight = task.MoveWeight;
            store.StoreWeight = task.MoveWeight;
           
            store.InTime = stockOutTask.OutTime;            
            store.CarryInTaskId = task.Id;

            store.CreateTime = DateTime.Now;
            store.Status = (int)EntityStatus.StoreInReady;

            var t = db.Insertable(store).ExecuteReturnEntity();
            return (true, "", t);
        }
        #endregion //Method
    }
}
