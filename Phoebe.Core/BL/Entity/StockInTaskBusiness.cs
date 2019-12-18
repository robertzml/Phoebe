using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Core.BL
{
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.Entity;

    /// <summary>
    /// 入库任务业务类
    /// </summary>
    public class StockInTaskBusiness : AbstractBusiness<StockInTask, string>, IBaseBL<StockInTask, string>
    {
        #region Method
        /// <summary>
        /// 添加入库任务
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage, StockInTask t) Create(StockInTask entity)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                var stockIn = db.Queryable<StockIn>().Single(r => r.Id == entity.StockInId);

                SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();
                entity.TaskCode = recordBusiness.GetNextSequence(db, "StockInTask", stockIn.InTime);

                entity.Id = Guid.NewGuid().ToString();
                //entity.InWeight = entity.InCount * entity.UnitWeight;
                entity.CreateTime = DateTime.Now;
                entity.Status = (int)EntityStatus.StockInReady;

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
