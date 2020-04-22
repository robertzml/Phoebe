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
        public (bool success, string errorMessage, Position position) Enter(string trayCode, string shelfCode, int userId)
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
                    return (false, "无空仓位", null);
                }

                StoreBusiness storeBusiness = new StoreBusiness();

                // 检查上架任务来源
                CarryInTaskBusiness carryInTaskBusiness = new CarryInTaskBusiness();

                // 先找托盘上的搬运入库任务
                var carryInTasks = db.Queryable<CarryInTask>().Where(r => r.TrayCode == trayCode && r.Status == (int)EntityStatus.StockInCheck).ToList();

                // 再找托盘上的搬运出库任务
                CarryOutTaskBusiness carryOutTaskBusiness = new CarryOutTaskBusiness();
                var carryOutTasks = db.Queryable<CarryOutTask>().Where(r => r.TrayCode == trayCode && r.Status == (int)EntityStatus.StockOutLeave).ToList();

                foreach (var carryOutTask in carryOutTasks)
                {
                    if (carryOutTask.Type == (int)CarryOutTaskType.Out && carryOutTask.Status != (int)EntityStatus.StockOutCheck)
                    {
                        db.Ado.RollbackTran();
                        return (false, "托盘还未扫码出库", null);
                    }

                    // 先创建放回搬运任务
                    var (success, errorMessage, t) = carryInTaskBusiness.CreateBack(carryOutTask, user, db);
                    carryInTasks.Add(t);

                    // 清点搬运出库
                    carryOutTaskBusiness.CheckUnmove(carryOutTask.Id, user, db);

                    // 库存记录出库
                    storeBusiness.FinishOut(carryOutTask.StoreId, null, db);
                }

                if (carryInTasks.Count == 0)
                {
                    db.Ado.RollbackTran();
                    return (false, "该托盘无入库任务", null);
                }

                // 更新仓位状态
                var shelf = db.Queryable<Shelf>().Single(r => r.Id == position.ShelfId);
                if (shelf.Type == (int)ShelfType.Position)
                    positionBusiness.UpdateStatus(position, EntityStatus.Occupy, db);

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
                return (true, "", position);
            }
            catch (Exception e)
            {
                db.Ado.RollbackTran();
                return (false, e.Message, null);
            }
        }

        /// <summary>
        /// 编辑搬运入库任务
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) EditTask(CarryInTask task)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                // 编辑搬运入库任务
                CarryInTaskBusiness carryInTaskBusiness = new CarryInTaskBusiness();
                carryInTaskBusiness.Edit(task, db);

                // 编辑库存记录
                if (!string.IsNullOrEmpty(task.StoreId))
                {
                    StoreBusiness storeBusiness = new StoreBusiness();
                    storeBusiness.UpdateIn(task.StoreId, task.TrayCode, task.MoveCount, task.MoveWeight, db);
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
