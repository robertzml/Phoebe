using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Core.BL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.Entity;
    using Phoebe.Core.View;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 搬运出库任务业务类
    /// </summary>
    public class CarryOutTaskBusiness : AbstractBusiness<CarryOutTask, string>, IBaseBL<CarryOutTask, string>
    {
        #region Function
        /// <summary>
        /// 生成临时搬运出库任务
        /// </summary>
        /// <param name="outTask"></param>
        /// <param name="position"></param>
        /// <param name="viceShelf"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        private CarryOutTask GenerateTempOutTask(StockOutTaskView outTask, PositionView position, bool viceShelf, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            CarryOutTask task = new CarryOutTask();
            task.Id = Guid.NewGuid().ToString();
            task.Type = (int)CarryOutTaskType.Temp;
            task.StockOutTaskId = outTask.Id;

            // find store
            var store = db.Queryable<StoreView>().Single(r => r.PositionId == position.Id && r.Status == (int)EntityStatus.StoreIn);
            if (store != null)
            {
                task.StoreId = store.Id;
                task.StoreCount = store.StoreCount;
                task.MoveCount = store.StoreCount;
                task.StoreWeight = store.StoreWeight;
                task.MoveWeight = store.StoreWeight;
                task.Place = store.Place;
            }
            else
            {
                return null;
            }

            if (viceShelf)
                task.ShelfCode = position.ViceShelfCode;
            else
                task.ShelfCode = position.ShelfCode;
            task.PositionId = position.Id;

            task.CreateTime = DateTime.Now;
            task.Status = (int)EntityStatus.StockOutReady;

            return task;
        }

        private CarryInTask GenerateTempInTask(CarryOutTask outTask, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            CarryInTask task = new CarryInTask();
            task.Id = Guid.NewGuid().ToString();
            task.CreateTime = DateTime.Now;
            task.CheckTime = DateTime.Now;
            //task.TaskCode = recordBusiness.GetNextSequence(db, "CarryInTask", entity.CreateTime);
            task.Status = (int)EntityStatus.StockInCheck;

            return null;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 批量添加搬运出库任务
        /// 指同一出库任务下的搬运任务，并且生成相关临时搬运出库任务
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Create(List<CarryOutTask> data)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();
                var now = DateTime.Now;

                var stockOutTask = db.Queryable<StockOutTaskView>().InSingle(data.First().StockOutTaskId);

                // 设置出库的搬运任务信息
                foreach (var item in data)
                {
                    item.Id = Guid.NewGuid().ToString();
                    item.Type = (int)CarryOutTaskType.Out;
                    item.CreateTime = now;
                    item.TaskCode = recordBusiness.GetNextSequence(db, "CarryOutTask", item.CreateTime);

                    var store = db.Queryable<StoreView>().InSingle(item.StoreId);
                    item.PositionId = store.PositionId;
                    item.Place = store.Place;
                    item.Status = (int)EntityStatus.StockOutReady;

                    db.Insertable(item).ExecuteReturnEntity();
                }

                List<CarryOutTask> tempOutTasks = new List<CarryOutTask>();
                foreach (var carryOuTask in data)
                {
                    // 搬运出库任务的仓位
                    var currentPos = db.Queryable<PositionView>().InSingle(carryOuTask.PositionId);

                    // 找到该货物同一排的所有仓位
                    var positions = db.Queryable<PositionView>()
                        .Where(r => r.ShelfId == currentPos.ShelfId && r.Row == currentPos.Row && r.Layer == currentPos.Layer).ToList();

                    if (currentPos.ShelfCode == carryOuTask.ShelfCode)
                    {
                        var outPos = positions.Where(r => r.Depth < currentPos.Depth).ToList();
                        foreach (var pos in outPos)
                        {
                            if (tempOutTasks.Any(r => r.PositionId == pos.Id))
                                continue;

                            var tempTask = GenerateTempOutTask(stockOutTask, pos, false, db);
                            if (tempTask != null)
                                tempOutTasks.Add(tempTask);
                        }
                    }
                    else if (currentPos.ViceShelfCode == carryOuTask.ShelfCode)
                    {
                        var outPos = positions.Where(r => r.Depth > currentPos.Depth).ToList();
                        foreach (var pos in outPos)
                        {
                            if (tempOutTasks.Any(r => r.PositionId == pos.Id))
                                continue;

                            var tempTask = GenerateTempOutTask(stockOutTask, pos, false, db);
                            if (tempTask != null)
                                tempOutTasks.Add(tempTask);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }

                foreach (var item in tempOutTasks)
                {
                    item.TaskCode = recordBusiness.GetNextSequence(db, "CarryOutTask", item.CreateTime);
                    db.Insertable(item).ExecuteReturnEntity();
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
        /// 出库接单
        /// </summary>
        /// <param name="taskCode">任务码</param>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public (bool success, string errorMessage) Receive(string taskCode, int userId)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                var task = db.Queryable<CarryOutTask>().Single(r => r.TaskCode == taskCode && r.Status == (int)EntityStatus.StockOutReady);
                if (task == null)
                    return (false, "未找到搬运出库任务");

                var user = db.Queryable<User>().InSingle(userId);

                // 检查用户情况
                var exists = db.Queryable<CarryOutTask>().Count(r => r.ReceiveUserId == user.Id && r.Status == (int)EntityStatus.StockOutReceive);
                if (exists != 0)
                    return (false, "用户还有出库任务未完成");

                // 更新任务状态
                task.ReceiveUserId = user.Id;
                task.ReceiveUserName = user.Name;
                task.ReceiveTime = DateTime.Now;
                task.Status = (int)EntityStatus.StockOutReceive;

                db.Updateable(task).ExecuteCommand();


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
        /// 下架
        /// </summary>
        /// <param name="taskCode">任务码</param>
        /// <param name="trayCode">托盘码</param>
        /// <param name="shelfCode">货架码</param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Leave(string taskCode, string trayCode, string shelfCode, int userId)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                var task = db.Queryable<CarryOutTask>().Single(r => r.TaskCode == taskCode && r.Status == (int)EntityStatus.StockOutReceive);
                if (task == null)
                    return (false, "该任务不存在");

                if (task.TrayCode != trayCode || task.ShelfCode != shelfCode)
                    return (false, "托盘或货架不一致");

                var user = db.Queryable<User>().InSingle(userId);
                if (task.ReceiveUserId != user.Id)
                    return (false, "非本用户任务");

                // find position
                var position = db.Queryable<Position>().InSingle(task.PositionId);

                // update position
                position.Status = (int)EntityStatus.Available;
                db.Updateable(position).ExecuteCommand();

                // set task info                   
                task.MoveTime = DateTime.Now;
                task.Status = (int)EntityStatus.StockOutLeave;
                db.Updateable(task).ExecuteCommand();

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
        /// 出库完成
        /// 清点和完成一起
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

                var task = db.Queryable<CarryOutTask>().Single(r => r.Id == taskId);

                if (task.Status != (int)EntityStatus.StockOutLeave)
                {
                    return (false, "该任务无法完成");
                }

                var user = db.Queryable<User>().InSingle(userId);

                // update task
                var now = DateTime.Now;
                task.CheckTime = now;
                task.CheckUserId = userId;
                task.CheckUserName = user.Name;
                task.FinishTime = now;                
                task.Status = (int)EntityStatus.StockOutFinish;
                db.Updateable(task).ExecuteCommand();

                // update store status
                var store = db.Queryable<Store>().Single(r => r.Id == task.StoreId);                
                store.Status = (int)EntityStatus.StoreOut;
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
