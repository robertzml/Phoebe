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
        /// <param name="stockInTask"></param>
        /// <param name="task"></param>
        /// <param name="positionId"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage, Store t) CreateByStockIn(StockInTaskView stockInTask, CarryInTask task, int positionId, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            Store store = new Store();
            store.Id = Guid.NewGuid().ToString();
            store.CustomerId = stockInTask.CustomerId;
            store.ContractId = stockInTask.ContractId;
            store.CargoId = stockInTask.CargoId;

            store.PositionId = positionId;
            store.TrayCode = task.TrayCode;

            store.TotalCount = task.MoveCount;
            store.StoreCount = task.MoveCount;
            store.TotalWeight = task.MoveWeight;
            store.StoreWeight = task.MoveWeight;

            store.Batch = stockInTask.Batch;
            store.OriginPlace = stockInTask.OriginPlace;
            store.Durability = stockInTask.Durability;

            store.InTime = stockInTask.InTime;
            store.StockInId = stockInTask.StockInId;
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
        /// <remarks>
        /// 临时搬运入库生成的库存记录，即出库后重新上架
        /// 旧库存记录保存在CarryInTask 的库存ID中，生成新库存记录后更新
        /// </remarks>
        /// <returns></returns>
        public (bool success, string errorMessage, Store t) CreateByStockOut(StockOutTaskView stockOutTask, CarryInTask task, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            Store store = new Store();
            store.Id = Guid.NewGuid().ToString();
            store.CustomerId = task.CustomerId;
            store.ContractId = task.ContractId;
            store.CargoId = task.CargoId;

            store.PositionId = task.PositionId;
            store.TrayCode = task.TrayCode;

            store.TotalCount = task.MoveCount;
            store.StoreCount = task.MoveCount;
            store.TotalWeight = task.MoveWeight;
            store.StoreWeight = task.MoveWeight;

            Store oldStore = db.Queryable<Store>().InSingle(task.StoreId);

            store.Batch = oldStore.Batch;
            store.OriginPlace = oldStore.OriginPlace;
            store.Durability = oldStore.Durability;
            store.StockInId = oldStore.StockInId;
            store.PrevStoreId = oldStore.Id;

            store.InTime = stockOutTask.OutTime;
            store.CarryInTaskId = task.Id;

            store.CreateTime = DateTime.Now;
            store.Status = (int)EntityStatus.StoreInReady;

            var t = db.Insertable(store).ExecuteReturnEntity();
            return (true, "", t);
        }

        /// <summary>
        /// 库存记录确认
        /// </summary>
        /// <param name="id"></param>
        /// <param name="trayCode"></param>
        /// <param name="storeCount"></param>
        /// <param name="storeWeight"></param>
        /// <param name="remark"></param>
        /// <param name="db"></param>
        /// <remarks>
        /// 可更新托盘码、库存数量、库存重量
        /// </remarks>
        /// <returns></returns>
        public (bool success, string errorMessage) Finish(string id, string trayCode, int storeCount, decimal storeWeight, string remark, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var store = db.Queryable<Store>().Single(r => r.Id == id);
            store.TrayCode = trayCode;

            store.TotalCount = storeCount;
            store.StoreCount = storeCount;
            store.TotalWeight = storeWeight;
            store.StoreWeight = storeWeight;

            store.Remark = remark;
            store.Status = (int)EntityStatus.StoreIn;

            db.Updateable(store).ExecuteCommand();
            return (true, "");
        }

        /// <summary>
        /// 撤回库存记录
        /// </summary>
        /// <param name="store"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Revert(Store store, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            store.Status = (int)EntityStatus.StoreInReady;
            db.Updateable(store).ExecuteCommand();

            return (true, "");
        }

        /// <summary>
        /// 删除搬运入库对应库存记录
        /// </summary>
        /// <param name="carryInId"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) DeleteByCarryIn(string carryInId, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var store = db.Queryable<Store>().Single(r => r.CarryInTaskId == carryInId);
            if (store != null)
                db.Deleteable<Store>().In(store.Id).ExecuteCommand();

            return (true, "");
        }
        #endregion //Method
    }
}
