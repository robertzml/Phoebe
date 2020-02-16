using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Core.Service
{
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.Entity;
    using Phoebe.Core.BL;
    using Phoebe.Core.DL;
    using Phoebe.Core.View;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 搬运入库业务类
    /// </summary>
    public class CarryInService : AbstractService
    {
        #region Carry In Service
        /// <summary>
        /// 添加搬运入库任务
        /// </summary>
        /// <param name="carryInTask"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) AddTask(CarryInTask carryInTask)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                // 检查托盘是否在架上
                var trayUse = db.Queryable<StoreView>().Where(r => r.TrayCode == carryInTask.TrayCode
                    && (r.Status == (int)EntityStatus.StoreIn || r.Status == (int)EntityStatus.StoreInReady));
                if (trayUse.Count() > 0)
                {
                    return (false, "托盘已使用");
                }

                CarryInTaskBusiness carryInTaskBusiness = new CarryInTaskBusiness();
                carryInTask.Type = (int)CarryInTaskType.In;

                var result = carryInTaskBusiness.CreateByStockIn(carryInTask, db);

                db.Ado.CommitTran();
                return (result.success, result.errorMessage);
            }
            catch (Exception e)
            {
                db.Ado.RollbackTran();
                return (false, e.Message);
            }
        }

        /// <summary>
        /// 搬运入库任务接单
        /// </summary>
        /// <param name="trayCode"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) ReceiveTask(string trayCode, int userId)
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

                // 更新任务状态到接单
                CarryInTaskBusiness carryInTaskBusiness = new CarryInTaskBusiness();
                foreach (var task in tasks)
                {
                    carryInTaskBusiness.Receive(task, user, db);
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

                // 获取托盘上所有任务
                CarryInTaskBusiness carryInTaskBusiness = new CarryInTaskBusiness();
                var tasks = db.Queryable<CarryInTask>().Where(r => r.TrayCode == trayCode && r.Status == (int)EntityStatus.StockInReceive).ToList();
                if (tasks.Count == 0)
                    return (false, "该托盘无入库任务");

                var user = db.Queryable<User>().InSingle(userId);
                if (tasks.All(r => r.ReceiveUserId != user.Id))
                    return (false, "非本用户任务");

                // 找出空仓位
                PositionBusiness positionBusiness = new PositionBusiness();
                var position = positionBusiness.FindAvailable(shelfCode, db);
                if (position == null)
                {
                    return (false, "无空仓位");
                }

                // 更新仓位状态
                position.Status = (int)EntityStatus.Occupy;
                db.Updateable(position).ExecuteCommand();

                foreach (var carryTask in tasks)
                {
                    if (string.IsNullOrEmpty(carryTask.StockInTaskId))
                    {
                        // 由出库任务生成的搬运任务
                        var stockOutTask = db.Queryable<StockOutTaskView>().InSingle(carryTask.StockOutTaskId);

                        // 添加库存记录
                        StoreBusiness storeBusiness = new StoreBusiness();
                        var store = storeBusiness.CreateByStockOut(stockOutTask, carryTask, db);

                        // 更新搬运入库任务
                        carryInTaskBusiness.Enter(carryTask, shelfCode, position.Id, store.t.Id, db);
                    }
                    else
                    {
                        // 由入库任务生成的搬运任务
                        var stockInTask = db.Queryable<StockInTaskView>().InSingle(carryTask.StockInTaskId);

                        // 添加库存记录
                        StoreBusiness storeBusiness = new StoreBusiness();
                        var store = storeBusiness.CreateByStockIn(stockInTask, carryTask, position.Id, db);

                        // 添加冷藏费记录
                        ColdFeeBusiness coldFeeBusiness = new ColdFeeBusiness();
                        coldFeeBusiness.Start(store.t, db);

                        // 更新搬运入库任务
                        carryInTaskBusiness.Enter(carryTask, shelfCode, position.Id, store.t.Id, db);
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
        /// 完成搬运入库任务
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="userId"></param>
        /// <param name="trayCode"></param>
        /// <param name="moveCount"></param>
        /// <param name="moveWeight"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Finish(string taskId, int userId, string trayCode, int moveCount, decimal moveWeight, string remark)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                // 检查搬运入库任务
                CarryInTaskBusiness carryInTaskBusiness = new CarryInTaskBusiness();
                var task = carryInTaskBusiness.FindById(taskId);

                if (task.Status != (int)EntityStatus.StockInEnter)
                {
                    return (false, "该任务无法完成");
                }

                if (trayCode != task.TrayCode)
                {
                    var exist = db.Queryable<Store>().Where(r => r.TrayCode == trayCode &&
                        (r.Status == (int)EntityStatus.StoreIn || r.Status == (int)EntityStatus.StoreInReady));
                    if (exist.Count() > 0)
                    {
                        return (false, "托盘已在库中");
                    }
                }

                // 确认搬运入库任务
                carryInTaskBusiness.Finish(task, trayCode, moveCount, moveCount, db);

                // 确认库存记录
                StoreBusiness storeBusiness = new StoreBusiness();
                storeBusiness.Finish(task.StoreId, trayCode, moveCount, moveWeight, remark, db);

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
        /// 删除搬运入库单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) DeleteTask(string id)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                CarryInTaskBusiness taskBusiness = new CarryInTaskBusiness();

                var result = taskBusiness.Delete(id, db);

                db.Ado.CommitTran();
                return (result.success, result.errorMessage);
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

                CarryInTaskBusiness carryInTaskBusiness = new CarryInTaskBusiness();
                var tasks = db.Queryable<CarryInTask>().Where(r => r.TrayCode == trayCode && r.Status == (int)EntityStatus.StockInReceive).ToList();
                if (tasks.Count == 0)
                    return (false, "该托盘无已接单搬运入库任务");

                // 检查用户情况
                if (tasks.Any(r => r.ReceiveUserId != userId))
                {
                    return (false, "非本人任务，无法取消接单");
                }

                // 更新任务状态
                foreach (var task in tasks)
                {
                    carryInTaskBusiness.UnReceive(task, db);
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
        #endregion //Carry In Service
    }
}
