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

    /// <summary>
    /// 冷藏费业务类
    /// </summary>
    public class ColdFeeBusiness : AbstractBusiness<ColdFee, string>, IBaseBL<ColdFee, string>
    {
        #region Method
        /// <summary>
        /// 创建冷藏费记录
        /// </summary>
        /// <param name="store">库存记录</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Start(Store store, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            ColdFee entity = new ColdFee();
            entity.Id = Guid.NewGuid().ToString();
            entity.StoreId = store.Id;
            entity.CustomerId = store.CustomerId;
            entity.ContractId = store.ContractId;
            entity.StartDate = store.InTime;
            entity.Days = 1;
            entity.Count = store.StoreWeight;
            entity.Status = (int)EntityStatus.FeeStart;

            var contract = db.Queryable<Contract>().InSingle(entity.ContractId);
            entity.UnitPrice = contract.UnitPrice;

            db.Insertable(entity).ExecuteCommand();
            return (true, "");
        }

        /// <summary>
        /// 结束计费
        /// </summary>
        /// <param name="store">库存记录</param>
        /// <param name="endDate">日期</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) End(StoreView store, DateTime endDate, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var entity = db.Queryable<ColdFee>().Single(r => r.StoreId == store.Id);
            if (entity == null)
                return (true, "无冷藏费");

            entity.EndDate = endDate;
            entity.Days = endDate.Subtract(entity.StartDate).Days;          

            entity.Amount = entity.Days * entity.UnitPrice * store.StoreWeight;
            entity.Status = (int)EntityStatus.FeeEnd;

            db.Updateable(entity).ExecuteCommand();

            return (true, "");
        }

        /// <summary>
        /// 更新冷藏费记录
        /// </summary>
        /// <param name="storeId">库存ID</param>
        /// <param name="count">数量</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Update(string storeId, decimal count, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<ColdFee>().Single(r => r.StoreId == storeId);
            if (data == null)
                return (false, "库存未找到冷藏费记录");

            data.Count = count;

            db.Updateable(data).ExecuteCommand();
            return (true, "");
        }

        /// <summary>
        /// 获取库存冷藏费
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public ColdFee FindByStore(string storeId, DateTime current, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<ColdFee>().Single(r => r.StoreId == storeId);
            if (current > data.EndDate)
            {
                return data;
            }
            else
            {
                data.Days = current.Subtract(data.StartDate).Days;
                data.Amount = data.UnitPrice * data.Count * data.Days;

                return data;
            }
        }
        #endregion //Method
    }
}
