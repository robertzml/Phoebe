using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Core.BL
{
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.Entity;
    using Phoebe.Core.View;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 搬运入库任务业务类
    /// </summary>
    public class CarryInTaskBusiness : AbstractBusiness<CarryInTask, string>, IBaseBL<CarryInTask, string>
    {
        #region Method
        public override (bool success, string errorMessage, CarryInTask t) Create(CarryInTask entity)
        {
            var db = GetInstance();
            try
            {
                db.Ado.BeginTran();

                SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();

                entity.Id = Guid.NewGuid().ToString();
                entity.CreateTime = DateTime.Now;
                entity.CheckTime = DateTime.Now;
                entity.TaskCode = recordBusiness.GetNextSequence(db, "CarryInTask", entity.CreateTime);
                entity.Status = (int)EntityStatus.StockInCheck;

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

                var tasks = db.Queryable<CarryInTask>().Where(r => r.TrayCode == trayCode && r.Status == (int)EntityStatus.StockInCheck).ToList();
                if (tasks.Count == 0)
                    return (false, "该托盘无入库任务");

                var user = db.Queryable<User>().InSingle(userId);

                // 检查用户情况
                var exists = db.Queryable<CarryInTask>().Count(r => r.ReceiveUserId == user.Id && r.Status == (int)EntityStatus.StockInReceive);
                if (exists != 0)
                    return (false, "用户还有入库任务未完成");

                // 更新任务状态
                var now = DateTime.Now;
                foreach (var task in tasks)
                {
                    task.ReceiveUserId = user.Id;
                    task.ReceiveUserName = user.Name;
                    task.ReceiveTime = now;
                    task.Status = (int)EntityStatus.StockInReceive;

                    db.Updateable(task).ExecuteCommand();
                }

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

                var tasks = db.Queryable<CarryInTask>().Where(r => r.TrayCode == trayCode && r.Status == (int)EntityStatus.StockInReceive).ToList();
                if (tasks.Count == 0)
                    return (false, "该托盘无入库任务");

                var user = db.Queryable<User>().InSingle(userId);
                if (tasks.All(r => r.ReceiveUserId != user.Id))
                    return (false, "非本用户任务");

                // find position
                PositionBusiness positionBusiness = new PositionBusiness();
                var position = positionBusiness.FindAvailable(db, shelfCode);
                if (position == null)
                {
                    return (false, "无空仓位");
                }

                // update position
                position.Status = (int)EntityStatus.Occupy;
                db.Updateable(position).ExecuteCommand();

                foreach (var carryTask in tasks)
                {
                    // set task info
                    carryTask.ShelfCode = shelfCode;
                    carryTask.PositionId = position.Id;
                    carryTask.MoveTime = DateTime.Now;
                    carryTask.Status = (int)EntityStatus.StockInEnter;

                    // find stock in task
                    var stockInTask = db.Queryable<StockInTaskView>().InSingle(carryTask.StockInTaskId);

                    // add store
                    StoreBusiness storeBusiness = new StoreBusiness();
                    var store = storeBusiness.Create(db, stockInTask, carryTask);

                    // update task
                    carryTask.StoreId = store.t.Id;
                    db.Updateable(carryTask).ExecuteCommand();
                }

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
        /// <param name="userId"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Finish(string taskId, int userId, string remark)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                var task = db.Queryable<CarryInTask>().Single(r => r.Id == taskId);

                if (task.Status != (int)EntityStatus.StockInEnter)
                {
                    return (false, "该任务无法完成");
                }

                // update task
                task.FinishTime = DateTime.Now;
                task.Status = (int)EntityStatus.StockInFinish;
                db.Updateable(task).ExecuteCommand();

                // update store status
                var store = db.Queryable<Store>().Single(r => r.Id == task.StoreId);
                store.Remark = remark;
                store.Status = (int)EntityStatus.StoreIn;
                db.Updateable(store).ExecuteCommand();

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
