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
                entity.InWeight = entity.InCount * entity.UnitWeight;
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
        /// 接单
        /// </summary>
        /// <param name="trayCode">托盘码</param>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public (bool success, string errorMessage) Receive(string trayCode, int userId)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                //var tasks = db.Queryable<StockInTask>().Where(r => r.TrayCode == trayCode && r.Status == (int)EntityStatus.StockInCheck).ToList();
                //if (tasks.Count == 0)
                //    return (false, "该托盘无入库任务");

                //var user = db.Queryable<User>().InSingle(userId);

                ////检查用户情况
                //var exists = db.Queryable<StockInTask>().Count(r => r.ReceiveUserId == user.Id && r.Status == (int)EntityStatus.StockInReceive);
                //if (exists != 0)
                //    return (false, "用户还有入库任务未完成");

                //// 更新任务状态
                //var now = DateTime.Now;
                //foreach (var task in tasks)
                //{
                //    task.ReceiveUserId = user.Id;
                //    task.ReceiveUserName = user.Name;
                //    task.ReceiveTime = now;
                //    task.Status = (int)EntityStatus.StockInReceive;

                //    db.Updateable(task).ExecuteCommand();
                //}

                db.Ado.CommitTran();
                return (true, "");
            }
            catch (Exception e)
            {
                db.Ado.RollbackTran();
                return (false, e.Message);
            }
        }

        /// <summary>
        /// 上架
        /// </summary>
        /// <param name="trayCode">托盘码</param>
        /// <param name="shelfCode">货架码</param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Enter(string trayCode, string shelfCode, int userId)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                //var tasks = db.Queryable<StockInTask>().Where(r => r.TrayCode == trayCode && r.Status == (int)EntityStatus.StockInReceive).ToList();
                //if (tasks.Count == 0)
                //    return (false, "该托盘无入库任务");

                //var user = db.Queryable<User>().InSingle(userId);
                //if (tasks.All(r => r.ReceiveUserId != user.Id))
                //    return (false, "非本用户任务");

                //// find position
                //PositionBusiness positionBusiness = new PositionBusiness();
                //var position = positionBusiness.FindEmpty(db, shelfCode);
                //if (position == null)
                //{
                //    return (false, "无空仓位");
                //}

                //// update position
                //position.IsEmpty = false;
                //db.Updateable(position).ExecuteCommand();

                //foreach (var task in tasks)
                //{
                //    // set task info
                //    task.ShelfCode = shelfCode;
                //    task.PositionId = position.Id;
                //    task.EnterTime = DateTime.Now;
                //    task.Status = (int)EntityStatus.StockInEnter;

                //    // find stock in
                //    var stockIn = db.Queryable<StockIn>().InSingle(task.StockInId);

                //    // add store
                //    StoreBusiness storeBusiness = new StoreBusiness();
                //    var store = storeBusiness.Create(db, stockIn, task);

                //    // update task
                //    task.StoreId = store.t.Id;
                //    db.Updateable(task).ExecuteCommand();
                //}

                db.Ado.CommitTran();
                return (true, "");
            }
            catch (Exception e)
            {
                db.Ado.RollbackTran();
                return (false, e.Message);
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
