﻿using System;
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
            store.Status = (int)EntityStatus.StoreInReady;

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
            store.Status = (int)EntityStatus.StoreInReady;

            var t = db.Insertable(store).ExecuteReturnEntity();

            return (true, "", t);
        }

        /// <summary>
        /// 库存记录入库确认
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
        public (bool success, string errorMessage) FinishIn(string id, string trayCode, int storeCount, decimal storeWeight, string remark, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var store = db.Queryable<Store>().Single(r => r.Id == id);
            store.TrayCode = trayCode;

            store.StoreCount = storeCount;
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
        /// 修改库存状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) UpdateStatus(string id, EntityStatus status, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var store = db.Queryable<Store>().InSingle(id);
            store.Status = (int)status;

            db.Updateable(store).UpdateColumns(r => new { r.Status }).ExecuteCommand();
            return (true, "");
        }
        #endregion //Method
    }
}
