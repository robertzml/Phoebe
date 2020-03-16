using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.BL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.Entity;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 普通库存业务类
    /// </summary>
    public class NormalStoreBusiness : AbstractBusiness<NormalStore, string>, IBaseBL<NormalStore, string>
    {
        #region Method
        /// <summary>
        /// 根据入库任务创建库存记录
        /// </summary>
        /// <param name="stockIn"></param>
        /// <param name="stockInTask"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage, NormalStore t) CreateByStockIn(StockIn stockIn, StockInTask stockInTask, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            NormalStore store = new NormalStore();
            store.Id = Guid.NewGuid().ToString();
            store.CustomerId = stockIn.CustomerId;
            store.ContractId = stockIn.ContractId;
            store.CargoId = stockInTask.CargoId;

            store.Place = stockInTask.Place;
            store.WarehouseId = stockInTask.WarehouseId;

            store.StoreCount = stockInTask.InCount;
            store.StoreWeight = stockInTask.InWeight;
            store.UnitWeight = stockInTask.UnitWeight;

            store.Batch = stockInTask.Batch;
            store.OriginPlace = stockInTask.OriginPlace;
            store.Durability = stockInTask.Durability;

            store.InTime = stockIn.InTime;
            store.StockInTaskId = stockInTask.Id;

            store.CreateTime = DateTime.Now;
            store.Remark = "";
            store.Status = (int)EntityStatus.StoreInReady;

            var t = db.Insertable(store).ExecuteReturnEntity();

            return (true, "", store);
        }

        /// <summary>
        /// 删除入库任务对应库存记录
        /// </summary>
        /// <param name="stockInTaskId">入库任务ID</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) DeleteByStockIn(string stockInTaskId, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var store = db.Queryable<NormalStore>().Single(r => r.StockInTaskId == stockInTaskId);
            if (store != null)
                db.Deleteable<NormalStore>().In(store.Id).ExecuteCommand();

            return (true, "");
        }

        /// <summary>
        /// 库存记录入库确认
        /// </summary>
        /// <param name="stockInTaskId">入库任务ID</param>
        /// <param name="db"></param>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        public (bool success, string errorMessage) FinishIn(string stockInTaskId, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var store = db.Queryable<NormalStore>().Single(r => r.StockInTaskId == stockInTaskId);
            store.Status = (int)EntityStatus.StoreIn;

            db.Updateable(store).ExecuteCommand();
            return (true, "");
        }
        #endregion //Method
    }
}
