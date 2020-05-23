using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.BL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Core.Entity;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 结算业务类
    /// </summary>
    public class SettlementBusiness : AbstractBusiness<Settlement, string>, IBaseBL<Settlement, string>
    {
        #region Override
        /// <summary>
        /// 添加结算
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage, Settlement t) Create(Settlement entity, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var count = db.Queryable<Settlement>()
                .Count(r => r.CustomerId == entity.CustomerId && r.SettleTime >= entity.StartTime && r.SettleTime <= entity.EndTime);

            if (count > 0)
                return (false, "该时段已结算", null);

            SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();

            entity.Id = Guid.NewGuid().ToString();
            entity.Number = recordBusiness.GetNextSequence(db, "Settlement", entity.SettleTime);
            entity.DueFee = Math.Round(entity.SumFee * entity.Discount / 100 - entity.Remission, 3);

            return base.Create(entity, db);
        }
        #endregion //Override
    }
}
