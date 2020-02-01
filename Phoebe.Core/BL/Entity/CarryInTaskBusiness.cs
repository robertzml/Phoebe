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
        /// <summary>
        /// 由入库创建搬运入库任务
        /// </summary>
        /// <param name="stockInTaskId"></param>
        /// <param name="trayCode"></param>
        /// <param name="moveCount"></param>
        /// <param name="moveWeight"></param>
        /// <param name="checkUserId"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public (bool success, string errorMessage, CarryInTask t) Create(string stockInTaskId, string trayCode,
            int moveCount, decimal moveWeight, int checkUserId, string remark)
        {
            var db = GetInstance();
            try
            {
                db.Ado.BeginTran();

                var trayUse = db.Queryable<StoreView>().Where(r => r.TrayCode == trayCode && (r.Status == (int)EntityStatus.StoreIn || r.Status == (int)EntityStatus.StoreInReady));
                if (trayUse.Count() > 0)
                {
                    return (false, "托盘已使用", null);
                }

                SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();

                var stockInTask = db.Queryable<StockInTaskView>().InSingle(stockInTaskId);
                var checkUser = db.Queryable<User>().InSingle(checkUserId);

                CarryInTask entity = new CarryInTask();
                entity.Id = Guid.NewGuid().ToString();
                entity.Type = (int)CarryInTaskType.In;
                entity.CustomerId = stockInTask.CustomerId;
                entity.ContractId = stockInTask.ContractId;
                entity.CargoId = stockInTask.CargoId;
                entity.StockInTaskId = stockInTaskId;

                entity.MoveCount = moveCount;
                entity.MoveWeight = moveWeight;

                entity.CreateTime = DateTime.Now;

                entity.TaskCode = recordBusiness.GetNextSequence(db, "CarryInTask", entity.CreateTime);
                entity.TrayCode = trayCode;

                entity.CheckTime = DateTime.Now;
                entity.CheckUserName = checkUser.Name;

                entity.Status = (int)EntityStatus.StockInCheck;
                entity.Remark = remark;

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

                    if (!string.IsNullOrEmpty(carryTask.StockInTaskId))
                    {
                        // 由入库任务生成的搬运任务
                        var stockInTask = db.Queryable<StockInTaskView>().InSingle(carryTask.StockInTaskId);

                        // add store
                        StoreBusiness storeBusiness = new StoreBusiness();
                        var store = storeBusiness.Create(db, stockInTask, carryTask);
                        carryTask.StoreId = store.t.Id;
                    }
                    else
                    {
                        // 由出库任务生成的搬运任务
                        var stockOutTask = db.Queryable<StockOutTaskView>().InSingle(carryTask.StockOutTaskId);

                        // add store
                        StoreBusiness storeBusiness = new StoreBusiness();
                        var store = storeBusiness.Create(db, stockOutTask, carryTask);
                        carryTask.StoreId = store.t.Id;
                    }

                    // update task
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

        /// <summary>
        /// 取消接单
        /// </summary>
        /// <param name="trayCode"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) UnReceive(string trayCode, int userId)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                var tasks = db.Queryable<CarryInTask>().Where(r => r.TrayCode == trayCode && r.Status == (int)EntityStatus.StockInReceive).ToList();
                if (tasks.Count == 0)
                    return (false, "该托盘无已接单搬运入库任务");

                // 检查用户情况
                if (tasks.Any(r => r.ReceiveUserId != userId))
                {
                    return (false, "非本人任务，无法取消接单");
                }

                // 更新任务状态
                var now = DateTime.Now;
                foreach (var task in tasks)
                {
                    task.ReceiveUserId = 0;
                    task.ReceiveUserName = "";
                    task.ReceiveTime = null;
                    task.Status = (int)EntityStatus.StockInCheck;

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
        /// 删除搬运入库
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage) Delete(string id)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                var carryIn = db.Queryable<CarryInTask>().InSingle(id);
                if (carryIn.Status != (int)EntityStatus.StockInCheck)
                {
                    return (false, "仅能删除已清点状态的搬运入库任务");
                }

                db.Deleteable<CarryInTask>().In(id).ExecuteCommand();

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
        /// 生成临时搬运入库任务
        /// 由搬运出库任务生成
        /// </summary>
        /// <param name="carryOutTask">搬运出库任务</param>
        /// <returns></returns>
        public static CarryInTask SetTempInTask(CarryOutTask carryOutTask)
        {
            CarryInTask task = new CarryInTask();
            task.Id = Guid.NewGuid().ToString();
            task.Type = (int)CarryInTaskType.Temp;
            task.CustomerId = carryOutTask.CustomerId;
            task.ContractId = carryOutTask.ContractId;
            task.CargoId = carryOutTask.CargoId;

            task.StoreId = carryOutTask.StoreId; // 暂时保存原库存ID

            task.StockOutTaskId = carryOutTask.StockOutTaskId;
            task.MoveCount = carryOutTask.StoreCount - carryOutTask.MoveCount;
            task.MoveWeight = carryOutTask.StoreWeight - carryOutTask.MoveWeight;

            task.TrayCode = carryOutTask.TrayCode;

            task.CheckUserId = carryOutTask.ReceiveUserId;
            task.CheckUserName = carryOutTask.ReceiveUserName;
            task.CreateTime = DateTime.Now;
            task.CheckTime = DateTime.Now;
            task.Status = (int)EntityStatus.StockInCheck;

            return task;
        }
        #endregion //Method
    }
}
