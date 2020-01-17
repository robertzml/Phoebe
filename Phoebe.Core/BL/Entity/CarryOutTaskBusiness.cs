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
        /// 设置临时搬运出库任务
        /// </summary>
        /// <remarks>
        /// 根据库存记录生成，一条库存记录对应一条搬运任务。
        /// 一个仓位上可能有多条库存记录
        /// </remarks>
        /// <param name="store">库存记录</param>
        /// <returns></returns>
        private CarryOutTask SetTempOutTaskInfo(StoreView store)
        {
            CarryOutTask task = new CarryOutTask();
            task.Id = Guid.NewGuid().ToString();
            task.Type = (int)CarryOutTaskType.Temp;

            task.CustomerId = store.CustomerId;
            task.ContractId = store.ContractId;
            task.CargoId = store.CargoId;

            task.StoreId = store.Id;
            task.StoreCount = store.StoreCount;
            task.MoveCount = 0;
            task.StoreWeight = store.StoreWeight;
            task.MoveWeight = 0;
            task.TrayCode = store.TrayCode;
            task.PositionId = store.PositionId;
            task.Place = store.Place;

            task.CreateTime = DateTime.Now;
            task.Status = (int)EntityStatus.StockOutReady;
            task.Remark = "";

            return task;
        }

        /// <summary>
        /// 生成临时搬运出库任务
        /// </summary>
        /// <param name="outTask">出库任务</param>
        /// <param name="position">仓位</param>
        /// <param name="viceShelf">取货货架口</param>
        /// <param name="db"></param>
        /// <returns></returns>
        private List<CarryOutTask> GenerateTempOutTask(StockOutTaskView outTask, PositionView position, bool viceShelf, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            List<CarryOutTask> data = new List<CarryOutTask>();

            // 查找仓位上库存记录
            var stores = db.Queryable<StoreView>().Where(r => r.PositionId == position.Id && r.Status == (int)EntityStatus.StoreIn).ToList();
            foreach (var store in stores)
            {
                CarryOutTask task = SetTempOutTaskInfo(store);
                task.StockOutTaskId = outTask.Id;

                if (viceShelf)
                {
                    task.ShelfCode = position.ViceShelfCode;
                    task.PositionNumber = position.ViceNumber;
                }
                else
                {
                    task.ShelfCode = position.ShelfCode;
                    task.PositionNumber = position.Number;
                }

                data.Add(task);
            }

            return data;
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
                List<CarryOutTask> tempOutTasks = new List<CarryOutTask>();

                // 设置出库的搬运任务信息
                foreach (var item in data)
                {
                    item.Id = Guid.NewGuid().ToString();
                    item.Type = (int)CarryOutTaskType.Out;
                    item.CustomerId = stockOutTask.CustomerId;
                    item.ContractId = stockOutTask.ContractId;
                    item.CargoId = stockOutTask.CargoId;
                    item.CreateTime = now;
                    item.TaskCode = recordBusiness.GetNextSequence(db, "CarryOutTask", item.CreateTime);

                    // 检查出库搬运任务托盘上是否有其它货物
                    var stores = db.Queryable<StoreView>().Where(r => r.PositionId == item.PositionId && r.Status == (int)EntityStatus.StoreIn).ToList();
                    foreach (var store in stores)
                    {
                        if (store.Id == item.StoreId)
                        {
                            if (store.ShelfCode == item.ShelfCode)
                            {
                                item.PositionNumber = store.PositionNumber;
                            }
                            else
                            {
                                item.PositionNumber = store.VicePositionNumber;
                            }

                            item.Place = store.Place;
                            item.Status = (int)EntityStatus.StockOutReady;

                            db.Insertable(item).ExecuteReturnEntity();
                        }
                        else
                        {
                            var temp = SetTempOutTaskInfo(store);
                            temp.StockOutTaskId = stockOutTask.Id;
                            temp.ShelfCode = item.ShelfCode;

                            if (store.ShelfCode == temp.ShelfCode)
                            {
                                temp.PositionNumber = store.PositionNumber;
                            }
                            else
                            {
                                temp.PositionNumber = store.VicePositionNumber;
                            }

                            tempOutTasks.Add(temp);
                        }
                    }
                }

                // 检查是否有需要临时搬运的任务
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
                                tempOutTasks.AddRange(tempTask);
                        }
                    }
                    else if (currentPos.ViceShelfCode == carryOuTask.ShelfCode)
                    {
                        var outPos = positions.Where(r => r.Depth > currentPos.Depth).ToList();
                        foreach (var pos in outPos)
                        {
                            if (tempOutTasks.Any(r => r.PositionId == pos.Id))
                                continue;

                            var tempTask = GenerateTempOutTask(stockOutTask, pos, true, db);
                            if (tempTask != null)
                                tempOutTasks.AddRange(tempTask);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }

                // 添加临时搬运出库任务
                foreach (var item in tempOutTasks)
                {
                    item.TaskCode = recordBusiness.GetNextSequence(db, "CarryOutTask", item.CreateTime);
                    db.Insertable(item).ExecuteCommand();
                }

                // 设置库存状态
                foreach (var item in data)
                {
                    var store = db.Queryable<Store>().Single(r => r.Id == item.StoreId);
                    store.Status = (int)EntityStatus.StoreOutReady;
                    db.Updateable(store).ExecuteCommand();
                }
                foreach (var item in tempOutTasks)
                {
                    var store = db.Queryable<Store>().Single(r => r.Id == item.StoreId);
                    store.Status = (int)EntityStatus.StoreOutReady;
                    db.Updateable(store).ExecuteCommand();
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
        /// <param name="trayCode">托盘码</param>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public (bool success, string errorMessage) Receive(string trayCode, int userId)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                var tasks = db.Queryable<CarryOutTask>().Where(r => r.TrayCode == trayCode && r.Status == (int)EntityStatus.StockOutReady).ToList();
                if (tasks.Count == 0)
                    return (false, "该托盘无出库任务");

                var user = db.Queryable<User>().InSingle(userId);

                // 检查用户情况
                var exists = db.Queryable<CarryOutTask>().Count(r => r.ReceiveUserId == user.Id && r.Status == (int)EntityStatus.StockOutReceive);
                if (exists != 0)
                    return (false, "用户还有出库任务未完成");

                // 更新任务状态
                var now = DateTime.Now;
                foreach (var task in tasks)
                {
                    task.ReceiveUserId = user.Id;
                    task.ReceiveUserName = user.Name;
                    task.ReceiveTime = DateTime.Now;
                    task.Status = (int)EntityStatus.StockOutReceive;

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
        /// 下架
        /// </summary>
        /// <param name="trayCode">托盘码</param>
        /// <param name="shelfCode">货架码</param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Leave(string trayCode, string shelfCode, int userId)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                var tasks = db.Queryable<CarryOutTask>().Where(r => r.TrayCode == trayCode && r.Status == (int)EntityStatus.StockOutReceive).ToList();
                if (tasks.Count == 0)
                    return (false, "该托盘无出库任务");

                var user = db.Queryable<User>().InSingle(userId);

                // 检查状态
                foreach (var task in tasks)
                {
                    if (task.ReceiveUserId != user.Id)
                        return (false, "非本用户任务");

                    if (task.TrayCode != trayCode || task.ShelfCode != shelfCode)
                        return (false, "托盘或货架不一致");
                }

                // find position
                var position = db.Queryable<Position>().InSingle(tasks[0].PositionId);

                // update position
                position.Status = (int)EntityStatus.Available;
                db.Updateable(position).ExecuteCommand();

                // 更新搬运出库任务状态
                foreach (var task in tasks)
                {
                    task.MoveTime = DateTime.Now;
                    task.Status = (int)EntityStatus.StockOutLeave;
                    db.Updateable(task).ExecuteCommand();

                    // 生成临时出库任务对应临时入库任务
                    if (task.Type == (int)CarryOutTaskType.Temp)
                    {
                        SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();
                        var inTask = CarryInTaskBusiness.SetTempInTask(task);
                        inTask.TaskCode = recordBusiness.GetNextSequence(db, "CarryInTask", inTask.CreateTime);

                        db.Insertable(inTask).ExecuteCommand();
                    }
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
        /// 出库完成
        /// 清点和完成一起
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="userId"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Finish(string taskId, int userId, int moveCount, decimal moveWeight, string remark)
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
                task.MoveCount = moveCount;
                task.MoveWeight = moveWeight;
                task.CheckTime = now;
                task.CheckUserId = userId;
                task.CheckUserName = user.Name;
                task.FinishTime = now;
                if (task.Remark == null)
                    task.Remark = remark;
                else
                    task.Remark += remark;

                task.Status = (int)EntityStatus.StockOutFinish;
                db.Updateable(task).ExecuteCommand();

                // 非全出则创建搬回的入库任务
                if (task.Type == (int)CarryOutTaskType.Out && task.StoreCount > task.MoveCount)
                {
                    SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();
                    var inTask = CarryInTaskBusiness.SetTempInTask(task);
                    inTask.TaskCode = recordBusiness.GetNextSequence(db, "CarryInTask", inTask.CreateTime);

                    db.Insertable(inTask).ExecuteCommand();
                }

                var stockOutTask = db.Queryable<StockOutTaskView>().InSingle(task.StockOutTaskId);

                // 更新库存状态
                var store = db.Queryable<Store>().Single(r => r.Id == task.StoreId);
                store.CarryOutTaskId = task.Id;
                store.OutTime = stockOutTask.OutTime;
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
