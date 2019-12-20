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

        /// <summary>
        /// 确认入库任务
        /// </summary>
        /// <param name="stockInTaskId"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Confirm(string stockInTaskId)
        {
            var db = GetInstance();

            var task = db.Queryable<StockInTask>().InSingle(stockInTaskId);
            var carryIn = db.Queryable<CarryInTask>().Where(r => r.StockInTaskId == stockInTaskId).ToList();
            if (carryIn.All(r => r.Status == (int)EntityStatus.StockInFinish))
            {
                task.InCount = carryIn.Sum(r => r.MoveCount);
                task.InWeight = carryIn.Sum(r => r.MoveWeight);

                task.FinishTime = DateTime.Now;
                task.Status = (int)EntityStatus.StockInFinish;

                db.Updateable(task).ExecuteCommand();

                return (true, "");
            }
            else
            {
                return (false, "有搬运入库任务未完成");
            }
        }
        #endregion //Method
    }
}