using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Core.BL
{
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.Entity;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 入库业务类
    /// </summary>
    public class StockInBusiness : AbstractBusiness<StockIn, string>, IBaseBL<StockIn, string>
    {
        #region Method
        public override (bool success, string errorMessage, StockIn t) Create(StockIn entity)
        {
            var db = GetInstance();
            try
            {
                db.Ado.BeginTran();

                SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();

                entity.Id = Guid.NewGuid().ToString();
                entity.MonthTime = entity.InTime.Year.ToString() + entity.InTime.Month.ToString().PadLeft(2, '0');
                entity.FlowNumber = recordBusiness.GetNextSequence(db, "StockIn", entity.InTime);
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

        /// <summary>
        /// 确认入库单
        /// </summary>
        /// <param name="id">入库单ID</param>
        /// <returns></returns>
        public (bool success, string errorMessage) Confirm(string id)
        {
            try
            {
                var db = GetInstance();

                var stockIn = db.Queryable<StockIn>().InSingle(id);
                var tasks = db.Queryable<StockInTask>().Where(r => r.StockInId == id).ToList();

                if (tasks.All(r => r.Status == (int)EntityStatus.StockInFinish))
                {
                    stockIn.ConfirmTime = DateTime.Now;
                    stockIn.Status = (int)EntityStatus.StockInFinish;

                    db.Updateable(stockIn).ExecuteCommand();
                    return (true, "");
                }
                else
                {
                    return (false, "有入库货物未完成");
                }
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
        }
        #endregion //Method
    }
}
