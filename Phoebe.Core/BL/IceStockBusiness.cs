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
    /// 冰块入库业务类
    /// </summary>
    public class IceStockBusiness : AbstractBusiness<IceStock, string>, IBaseBL<IceStock, string>
    {
        #region Method
        /// <summary>
        /// 按年度搜索入库记录
        /// </summary>
        /// <param name="year">入库年份</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public List<IceStock> FindByYear(int year, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<IceStock>().Where(r => r.StockTime.Year == year);
            return data.ToList();
        }

        /// <summary>
        /// 冰块入库
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage, IceStock t) Create(IceStock entity, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                SequenceRecordBusiness sequenceBusiness = new SequenceRecordBusiness();
                entity.FlowNumber = sequenceBusiness.GetNextSequence(db, "IceStock", entity.StockTime);

                entity.Id = Guid.NewGuid().ToString();
                entity.CreateTime = DateTime.Now;
                entity.Status = 0;

                var t = db.Insertable(entity).ExecuteReturnEntity();

                db.Ado.CommitTran();
                return (true, "", t);
            }
            catch (Exception e)
            {
                db.Ado.RollbackTran();
                return (false, e.Message, null);
            }
        }
        #endregion //Method
    }
}
