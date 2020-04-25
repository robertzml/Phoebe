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
        /// <param name="stockInTask">入库任务</param>
        /// <param name="task">搬运入库任务</param>
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

            store.StoreCount = task.MoveCount;
            store.StoreWeight = task.MoveWeight;
            store.UnitWeight = task.UnitWeight;

            store.Batch = stockInTask.Batch;
            store.OriginPlace = stockInTask.OriginPlace;
            store.Durability = stockInTask.Durability;

            store.InitialTime = stockInTask.InTime;
            store.InTime = stockInTask.InTime;
            store.StockInId = stockInTask.StockInId;
            store.CarryInTaskId = task.Id;

            store.CreateTime = DateTime.Now;
            store.Status = (int)EntityStatus.StoreIn;
            store.Remark = stockInTask.Remark;

            var t = db.Insertable(store).ExecuteReturnEntity();
            return (true, "", t);
        }

        /// <summary>
        /// 由出库任务生成库存记录
        /// </summary>
        /// <param name="stockOutTask">出库任务</param>
        /// <param name="task">搬运入库任务</param>
        /// <param name="positionId"></param>
        /// <param name="db"></param>
        /// <remarks>
        /// 临时搬运入库生成的库存记录，即出库后重新上架
        /// 旧库存记录保存在CarryInTask 的库存ID中，生成新库存记录后更新
        /// </remarks>
        /// <returns></returns>
        public (bool success, string errorMessage, Store t) CreateByBack(CarryInTask task, int positionId, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            Store store = new Store();
            store.Id = Guid.NewGuid().ToString();
            store.CustomerId = task.CustomerId;
            store.ContractId = task.ContractId;
            store.CargoId = task.CargoId;

            store.PositionId = positionId;
            store.TrayCode = task.TrayCode;

            store.StoreCount = task.MoveCount;
            store.StoreWeight = task.MoveWeight;
            store.UnitWeight = task.UnitWeight;

            Store oldStore = db.Queryable<Store>().InSingle(task.StoreId);

            store.Batch = oldStore.Batch;
            store.OriginPlace = oldStore.OriginPlace;
            store.Durability = oldStore.Durability;
            store.StockInId = oldStore.StockInId;
            store.PrevStoreId = oldStore.Id;

            store.InitialTime = oldStore.InitialTime;
            store.InTime = oldStore.OutTime.Value; //库存入库时间为旧库存出库时间
            store.CarryInTaskId = task.Id;

            store.CreateTime = DateTime.Now;
            store.Status = (int)EntityStatus.StoreIn;
            store.Remark = oldStore.Remark;

            var t = db.Insertable(store).ExecuteReturnEntity();

            return (true, "", t);
        }

        /// <summary>
        /// 系统搬运创建的新库存记录
        /// </summary>
        /// <param name="oldStore">原库存记录</param>
        /// <param name="carryInTask">搬运入库任务</param>
        /// <param name="positionId">新仓位ID</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage, Store t) CreateByMove(Store oldStore, CarryInTask carryInTask, int positionId, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            Store store = new Store();
            store.Id = Guid.NewGuid().ToString();
            store.CustomerId = oldStore.CustomerId;
            store.ContractId = oldStore.ContractId;
            store.CargoId = oldStore.CargoId;

            store.PositionId = positionId;
            store.TrayCode = oldStore.TrayCode;

            store.StoreCount = oldStore.StoreCount;
            store.StoreWeight = oldStore.StoreWeight;
            store.UnitWeight = oldStore.UnitWeight;

            store.Batch = oldStore.Batch;
            store.OriginPlace = oldStore.OriginPlace;
            store.Durability = oldStore.Durability;

            store.InitialTime = oldStore.InitialTime;
            store.InTime = oldStore.OutTime.Value;
            store.StockInId = oldStore.StockInId;
            store.PrevStoreId = oldStore.Id;
            store.CarryInTaskId = carryInTask.Id;

            store.CreateTime = DateTime.Now;
            store.Status = (int)EntityStatus.StoreIn;
            store.Remark = oldStore.Remark;

            var t = db.Insertable(store).ExecuteReturnEntity();
            return (true, "", t);
        }

        /// <summary>
        /// 根据搬运入库任务修改库存记录
        /// </summary>
        /// <param name="id">库存ID</param>
        /// <param name="trayCode"></param>
        /// <param name="storeCount"></param>
        /// <param name="storeWeight"></param>
        /// <param name="db"></param>
        /// <remarks>
        /// 可更新托盘码、库存数量、库存重量
        /// </remarks>
        /// <returns></returns>
        public (bool success, string errorMessage) UpdateIn(string id, string trayCode, int storeCount, decimal storeWeight, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var store = db.Queryable<Store>().Single(r => r.Id == id);

            store.TrayCode = trayCode;
            store.StoreCount = storeCount;
            store.StoreWeight = storeWeight;

            db.Updateable(store).UpdateColumns(r => new { r.TrayCode, r.StoreCount, r.StoreWeight }).ExecuteCommand();
            return (true, "");
        }

        /// <summary>
        /// 库存记录下架
        /// </summary>
        /// <param name="id"></param>
        /// <param name="carryOutTaskId"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        /// <remarks>
        /// 库存状态为准备移出
        /// </remarks>
        public (bool success, string errorMessage) Leave(string id, string carryOutTaskId, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var store = db.Queryable<Store>().InSingle(id);
            store.CarryOutTaskId = carryOutTaskId;
            store.OutTime = DateTime.Now.Date; //库存出库时间为当前时间，若重新入库，新库存入库时间等于前一出库时间
            store.Status = (int)EntityStatus.StoreOutReady;

            db.Updateable(store).ExecuteCommand();
            return (true, "");
        }

        /// <summary>
        /// 确认库存出库
        /// </summary>
        /// <param name="id">库存ID</param>
        /// <param name="db"></param>
        /// <returns></returns>
        /// <remarks>
        /// 出库搬运修改出库时间为出库单时间，临时搬运不修改等入库后修改
        /// </remarks>
        public (bool success, string errorMessage) FinishOut(string id, DateTime? outTime, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var store = db.Queryable<Store>().InSingle(id);
            if (outTime.HasValue)
                store.OutTime = outTime.Value;
            store.Status = (int)EntityStatus.StoreOut;

            db.Updateable(store).ExecuteCommand();
            return (true, "");
        }

        /// <summary>
        /// 确认库存出库
        /// </summary>
        /// <param name="store">库存记录</param>
        /// <param name="carryOutTask">搬运出库任务</param>
        /// <param name="db"></param>
        /// <returns></returns>
        /// <remarks>
        /// 确认库存出库，直接结束
        /// </remarks>
        public (bool success, string errorMessage) FinishOut(Store store, CarryOutTask carryOutTask, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            store.CarryOutTaskId = carryOutTask.Id;
            store.OutTime = carryOutTask.MoveTime.Value.Date;
            store.Status = (int)EntityStatus.StoreOut;

            db.Updateable(store).ExecuteCommand();
            return (true, "");
        }
        #endregion //Method
    }
}
