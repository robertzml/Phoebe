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
    /// 出库业务类
    /// </summary>
    public class StockOutBusiness : AbstractBusiness<StockOut, string>, IBaseBL<StockOut, string>
    {
        #region Method
        public override (bool success, string errorMessage, StockOut t) Create(StockOut entity)
        {
            var db = GetInstance();
            try
            {
                db.Ado.BeginTran();

                SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();

                entity.Id = Guid.NewGuid().ToString();
                entity.MonthTime = entity.OutTime.Year.ToString() + entity.OutTime.Month.ToString().PadLeft(2, '0');
                entity.FlowNumber = recordBusiness.GetNextSequence(db, "StockOut", entity.OutTime);
                entity.CreateTime = DateTime.Now;
                entity.Status = (int)EntityStatus.StockOutReady;

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
        /// 确认出库单
        /// </summary>
        /// <param name="id">出库单ID</param>
        /// <returns></returns>
        public (bool success, string errorMessage) Confirm(string id)
        {
            try
            {
                var db = GetInstance();

                var stockOut = db.Queryable<StockOut>().InSingle(id);
                var tasks = db.Queryable<StockOutTask>().Where(r => r.StockOutId == id).ToList();

                if (tasks.All(r => r.Status == (int)EntityStatus.StockOutFinish))
                {
                    stockOut.ConfirmTime = DateTime.Now;
                    stockOut.Status = (int)EntityStatus.StockOutFinish;

                    db.Updateable(stockOut).ExecuteCommand();
                    return (true, "");
                }
                else
                {
                    return (false, "有出库货物未完成");
                }
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
        }

        /// <summary>
        /// 删除出库单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage) Delete(string id)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                var tasks = db.Queryable<StockOutTask>().Where(r => r.StockOutId == id).ToList();
                if (tasks.Count > 0)
                {
                    return (false, "出库单含有出库任务，无法删除");
                }

                db.Deleteable<StockOut>().In(id).ExecuteCommand();

                db.Ado.CommitTran();
                return (true, "");
            }
            catch (Exception e)
            {
                db.Ado.RollbackTran();
                return (false, e.Message);
            }
        }
        #endregion //Method
    }
}