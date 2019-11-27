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
    /// 库存业务类
    /// </summary>
    public class StoreBusiness : AbstractBusiness<Store, string>, IBaseBL<Store, string>
    {
        #region Method
        /// <summary>
        /// 添加库存记录
        /// </summary>
        /// <param name="db"></param>
        /// <param name="stockIn"></param>
        /// <param name="task"></param>
        /// <returns></returns>
        public (bool success, string errorMessage, Store t) Create(SqlSugarClient db, StockIn stockIn, StockInTask task)
        {
            Store store = new Store();
            store.Id = Guid.NewGuid().ToString();
            store.CustomerId = stockIn.CustomerId;
            store.ContractId = stockIn.ContractId;            
            store.CategoryId = task.CategoryId;
            store.WarehouseId = task.WarehouseId;
            store.PositionId = task.PositionId;
            store.TrayCode = task.TrayCode;
            store.TotalCount = task.InCount;
            store.StoreCount = task.InCount;
            store.TotalWeight = task.InWeight;
            store.StoreWeight = task.InWeight;
            store.StockInTaskId = task.Id;
            store.InTime = stockIn.InTime;
            store.MoveTime = stockIn.InTime;
            store.Source = 1;
            store.Destination = 0;
            store.Status = (int)EntityStatus.StoreReady;

            var t = db.Insertable(store).ExecuteReturnEntity();
            return (true, "", t);
        }
        #endregion //Method
    }
}
