using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.BL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.Entity;

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
            entity.Status = (int)EntityStatus.FeeStart;

            var contract = db.Queryable<Contract>().InSingle(entity.ContractId);
            entity.UnitPrice = contract.UnitPrice;

            db.Insertable(entity).ExecuteCommand();
            return (true, "");
        }

        /// <summary>
        /// 结束计费
        /// </summary>
        /// <param name="id"></param>
        /// <param name="store"></param>
        /// <param name="endDate"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) End(string id, Store store, DateTime endDate, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var entity = db.Queryable<ColdFee>().InSingle(id);

            entity.EndDate = endDate;
            entity.Days = endDate.Subtract(entity.StartDate).Days;
            entity.Amount =  entity.Days * entity.UnitPrice * store.StoreWeight;
            entity.Status = (int)EntityStatus.FeeEnd;

            db.Updateable(entity).ExecuteCommand();

            return (true, "");
        }
        #endregion //Method
    }
}
