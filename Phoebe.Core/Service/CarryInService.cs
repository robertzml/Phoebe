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

                // 操作用户
                var user = db.Queryable<User>().InSingle(carryInTask.CheckUserId);

                StockInTaskViewBusiness stockInTaskViewBusiness = new StockInTaskViewBusiness();
                var stockInTask = db.Queryable<StockInTaskView>().InSingle(carryInTask.StockInTaskId);

                CarryInTaskBusiness carryInTaskBusiness = new CarryInTaskBusiness();

                var result = carryInTaskBusiness.CreateByStockIn(carryInTask, stockInTask, user, db);

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

                // 操作用户
                var user = db.Queryable<User>().InSingle(userId);

                // 找出空仓位
                PositionBusiness positionBusiness = new PositionBusiness();
                var position = positionBusiness.FindAvailable(shelfCode, db);
                if (position == null)
                {
                    return (false, "无空仓位");
                }

                // 检查上架任务来源
                CarryInTaskBusiness carryInTaskBusiness = new CarryInTaskBusiness();

                // 先找托盘上的搬运入库任务
                var carryInTasks = db.Queryable<CarryInTask>().Where(r => r.TrayCode == trayCode && r.Status == (int)EntityStatus.StockInCheck).ToList();

                // 再找托盘上的搬运出库任务
                CarryOutTaskBusiness carryOutTaskBusiness = new CarryOutTaskBusiness();
                var carryOutTasks = db.Queryable<CarryOutTask>().Where(r => r.TrayCode == trayCode && r.Status == (int)EntityStatus.StockOutLeave).ToList();

                foreach (var carryOutTask in carryOutTasks)
                {
                    // 先创建放回搬运任务
                    var result = carryInTaskBusiness.CreateBack(carryOutTask, user, db);
                    carryInTasks.Add(result.t);

                    // 清点搬运出库
                    carryOutTaskBusiness.CheckUnmove(carryOutTask, user, db);
                }

                if (carryInTasks.Count == 0)
                    return (false, "该托盘无入库任务");

                // 更新仓位状态
                var shelf = db.Queryable<Shelf>().Single(r => r.Id == position.ShelfId);
                if (shelf.Type == (int)ShelfType.Position)
                    positionBusiness.UpdateStatus(position, EntityStatus.Occupy, db);

                StoreBusiness storeBusiness = new StoreBusiness();
                ColdFeeBusiness coldFeeBusiness = new ColdFeeBusiness();

                foreach (var carryTask in carryInTasks)
                {
                    Store store = null;
                    if (!string.IsNullOrEmpty(carryTask.StockInTaskId))
                    {
                        // 由入库任务生成的搬运任务
                        var stockInTask = db.Queryable<StockInTaskView>().InSingle(carryTask.StockInTaskId);

                        // 添加库存记录
                        var result = storeBusiness.CreateByStockIn(stockInTask, carryTask, position.Id, db);
                        store = result.t;
                    }
                    else
                    {
                        // 放回任务生成的搬运任务
                        // 添加库存记录
                        var result = storeBusiness.CreateByBack(carryTask, position.Id, db);
                        store = result.t;
                    }

                    // 更新搬运入库任务
                    carryInTaskBusiness.Enter(carryTask, shelfCode, position.Id, store.Id, user, db);
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

                if (task.Type == (int)CarryInTaskType.Temp) // 临时搬运入库任务需先确认对应搬运出库任务
                {
                    var count = db.Queryable<CarryOutTask>().Count(r => r.TrayCode == trayCode && r.Status != (int)EntityStatus.StockOutFinish);
                    if (count > 0)
                        return (false, "临时搬运入库任务需先确认对应搬运出库任务");
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
                carryInTaskBusiness.Finish(task, trayCode, moveCount, moveWeight, db);

                // 确认库存记录
                StoreBusiness storeBusiness = new StoreBusiness();
                storeBusiness.FinishIn(task.StoreId, trayCode, moveCount, moveWeight, remark, db);              

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
                var carryIn = taskBusiness.FindById(id, db);
                if (carryIn.Status != (int)EntityStatus.StockInCheck)
                {
                    return (false, "仅能删除已清点状态的搬运入库任务");
                }

                // 删除搬运入库               
                taskBusiness.Delete(carryIn, db);

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
