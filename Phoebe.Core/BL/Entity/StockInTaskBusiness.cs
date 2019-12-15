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
        /// 入库完成
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="cargoId"></param>
        /// <param name="userId"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Finish(string taskId, string cargoId, int userId, string remark)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                //var task = db.Queryable<StockInTask>().Single(r => r.Id == taskId);

                //if (task.Status != (int)EntityStatus.StockInEnter)
                //{
                //    return (false, "该任务无法完成");
                //}

                //// update task
                //task.FinishTime = DateTime.Now;
                //task.Status = (int)EntityStatus.StockInFinish;
                //db.Updateable(task).ExecuteCommand();

                //// update store status
                //var store = db.Queryable<Store>().Single(r => r.Id == task.StoreId);
                //store.CargoId = cargoId;
                //store.Remark = remark;
                //store.Status = (int)EntityStatus.StoreIn;
                //db.Updateable(store).ExecuteCommand();

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
