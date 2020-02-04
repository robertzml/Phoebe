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
        public (bool success, string errorMessage) Create(Store store, SqlSugarClient db = null)
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
        #endregion //Method
    }
}
