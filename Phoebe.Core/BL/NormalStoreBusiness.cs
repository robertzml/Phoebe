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
        #endregion //Method
    }
}
