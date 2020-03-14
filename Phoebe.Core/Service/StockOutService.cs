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
    /// 出库服务类
    /// </summary>
    public class StockOutService : AbstractService
    {
        #region Stock Out Service
        /// <summary>
        /// 添加出库单
        /// </summary>
        /// <param name="stockOut">出库单对象</param>
        /// <returns></returns>
        public (bool success, string errorMessage, StockOut t) AddReceipt(StockOut stockOut)
        {
            var db = GetInstance();
            try
            {
                db.Ado.BeginTran();

                StockOutBusiness stockOutBusiness = new StockOutBusiness();
                var result = stockOutBusiness.Create(stockOut, db);

                db.Ado.CommitTran();
                return (result.success, result.errorMessage, result.t);
            }
            catch (Exception e)
            {
                db.Ado.RollbackTran();
                return (false, e.Message, null);
            }
        }

        /// <summary>
        /// 编辑出库单
        /// </summary>
        /// <param name="stockOut"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) UpdateReceipt(StockOut stockOut)
        {
            var db = GetInstance();
            try
            {
                db.Ado.BeginTran();

                StockOutBusiness stockOutBusiness = new StockOutBusiness();
                var result = stockOutBusiness.Update(stockOut, db);

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
        /// 删除出库单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) DeleteReceipt(string id)
        {
            var db = GetInstance();
            try
            {
                db.Ado.BeginTran();

                StockOutTaskViewBusiness stockOutTaskViewBusiness = new StockOutTaskViewBusiness();

                var tasks = stockOutTaskViewBusiness.FindList(id, db);
                if (tasks.Count > 0)
                {
                    return (false, "出库单含有出库任务，无法删除");
                }

                // 删除出库费用

                // 删除出库单
                StockOutBusiness stockOutBusiness = new StockOutBusiness();

                var stockOut = stockOutBusiness.FindById(id, db);
                if (stockOut.Status != (int)EntityStatus.StockOutReady)
                {
                    return (false, "仅能删除待出库状态的出库单");
                }

                var result = stockOutBusiness.Delete(stockOut, db);

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
        /// 确认出库单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) FinishReceipt(string id)
        {
            var db = GetInstance();
            try
            {
                db.Ado.BeginTran();

                StockOutTaskViewBusiness stockOutTaskViewBusiness = new StockOutTaskViewBusiness();
                var tasks = stockOutTaskViewBusiness.FindList(id, db);

                if (tasks.Any(r => r.Status != (int)EntityStatus.StockOutFinish))
                {
                    return (false, "有出库货物未完成");
                }

                StockOutBusiness stockOutBusiness = new StockOutBusiness();
                var result = stockOutBusiness.Confirm(id, db);

                // 重新核对冷藏费结束时间

                db.Ado.CommitTran();
                return (result.success, result.errorMessage);
            }
            catch (Exception e)
            {
                db.Ado.RollbackTran();
                return (false, e.Message);
            }
        }
        #endregion //Stock Out Service

        #region Stock Out Task Service
        /// <summary>
        /// 添加出库任务单
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public (bool success, string errorMessage, StockOutTask t) AddTask(StockOutTask task)
        {
            var db = GetInstance();
            try
            {
                db.Ado.BeginTran();

                StockOutBusiness stockOutBusiness = new StockOutBusiness();
                var stockOut = stockOutBusiness.FindById(task.StockOutId, db);

                StoreViewBusiness svBusiness = new StoreViewBusiness();
                var stores = svBusiness.FindByCargo(stockOut.ContractId, task.CargoId, true, db);

                var storeCount = stores.Sum(r => r.StoreCount);
                var storeWeight = stores.Sum(r => r.StoreWeight);

                if (task.OutCount > storeCount)
                    return (false, "出库数量大于在库数量", null);
                if (task.OutWeight > storeWeight)
                    return (false, "出库重量大于在库重量", null);

                StockOutTaskBusiness stockOutTaskBusiness = new StockOutTaskBusiness();
                var result = stockOutTaskBusiness.Create(task, storeCount, storeWeight, stockOut.OutTime, db);

                db.Ado.CommitTran();
                return (result.success, result.errorMessage, result.t);
            }
            catch (Exception e)
            {
                db.Ado.RollbackTran();
                return (false, e.Message, null);
            }
        }

        /// <summary>
        /// 添加出库货物
        /// </summary>
        /// <param name="stockOutId">出库单ID</param>
        /// <param name="tasks">搬运出库任务</param>
        /// <param name="userId">创建人</param>
        /// <returns></returns>
        /// <remarks>
        /// 管理员搜索库存记录，提交需出库的货物
        /// </remarks>
        public (bool success, string errorMessage) AddOutStore(string stockOutId, List<CarryOutTask> tasks, int userId)
        {
            var db = GetInstance();
            try
            {
                db.Ado.BeginTran();

                StockOutBusiness stockOutBusiness = new StockOutBusiness();
                StockOutTaskBusiness stockOutTaskBusiness = new StockOutTaskBusiness();
                CarryOutTaskBusiness carryOutTaskBusiness = new CarryOutTaskBusiness();
                StoreViewBusiness storeViewBusiness = new StoreViewBusiness();

                // 获取创建人
                UserBusiness userBusiness = new UserBusiness();
                var user = userBusiness.FindById(userId);

                // 获取出库单
                var stockOut = stockOutBusiness.FindById(stockOutId);                      
               
                foreach (var carryOutTask in tasks)
                {
                    // 查找是否已有出库任务单
                    var stockOutTasks = db.Queryable<StockOutTask>().Where(r => r.StockOutId == stockOut.Id).ToList();

                    var find = stockOutTasks.Find(r => r.CargoId == carryOutTask.CargoId && r.UnitWeight == carryOutTask.UnitWeight);
                    if (find == null)
                    {
                        // 创建出库任务
                        var result = stockOutTaskBusiness.Create(stockOutId, carryOutTask, user, db);
                        carryOutTask.StockOutTaskId = result.t.Id;
                    }
                    else
                    {
                        carryOutTask.StockOutTaskId = find.Id;
                    }

                    // 找出对应库存
                    var store = storeViewBusiness.FindById(carryOutTask.StoreId);

                    // 设置搬运出库任务信息
                    carryOutTaskBusiness.CreateByStockOut(carryOutTask, store, db);
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
        /// 扫托盘码出库
        /// </summary>
        /// <param name="stockOutId">出库单ID</param>
        /// <param name="trayCode">托盘码</param>
        /// <param name="tasks">托盘码对应的出库任务</param>
        /// <returns></returns>
        /// <remarks>
        /// 叉车工先下架，仓管再扫码选择出库数量
        /// 通过搬运出库任务创建出库任务
        /// </remarks>
        public (bool success, string errorMessage) AddCarryOut(string stockOutId, string trayCode, int userId, List<CarryOutTask> tasks)
        {
            var db = GetInstance();
            try
            {
                db.Ado.BeginTran();

                // 获取清点人
                UserBusiness userBusiness = new UserBusiness();
                var user = userBusiness.FindById(userId);

                StockOutTaskBusiness stockOutTaskBusiness = new StockOutTaskBusiness();
                CarryOutTaskBusiness carryOutTaskBusiness = new CarryOutTaskBusiness();
                CarryInTaskBusiness carryInTaskBusiness = new CarryInTaskBusiness();
                StockOutBusiness stockOutBusiness = new StockOutBusiness();

                // 获取出库单
                var stockOut = stockOutBusiness.FindById(stockOutId);

                foreach (var carryOutTask in tasks)
                {
                    if (carryOutTask.TrayCode != trayCode)
                        return (false, "托盘码与货物不一致");

                    if (carryOutTask.MoveCount > 0)
                    {
                        if (carryOutTask.ContractId != stockOut.ContractId)
                            return (false, "出库货物非当前合同所有");

                        // 创建出库任务
                        var result = stockOutTaskBusiness.Create(stockOutId, carryOutTask, user, db);

                        // 更新搬运出库任务
                        carryOutTaskBusiness.Check(carryOutTask.Id, result.t.Id, carryOutTask.MoveCount, carryOutTask.MoveWeight, carryOutTask.Remark, user, db);

                        if (carryOutTask.MoveCount < carryOutTask.StoreCount)
                        {
                            if (string.IsNullOrEmpty(carryOutTask.StockOutTaskId))
                                carryOutTask.StockOutTaskId = result.t.Id;

                            // 创建放回任务
                            carryInTaskBusiness.CreateBack(carryOutTask, user, db);
                        }
                    }
                    else //无需出库的货物放回
                    {
                        // 更新搬运出库任务
                        carryOutTaskBusiness.CheckUnmove(carryOutTask, user, db);

                        // 创建放回任务
                        carryInTaskBusiness.CreateBack(carryOutTask, user, db);
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
        /// 确认出库任务
        /// </summary>
        /// <param name="stockOutTaskId"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) FinishTask(string stockOutTaskId)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                var task = db.Queryable<StockOutTask>().InSingle(stockOutTaskId);

                var carryIn = db.Queryable<CarryInTask>().Where(r => r.StockOutTaskId == stockOutTaskId).ToList();
                if (carryIn.Any(r => r.Status != (int)EntityStatus.StockInFinish))
                {
                    return (false, "有搬运入库任务未完成");
                }

                var carryOut = db.Queryable<CarryOutTask>().Where(r => r.StockOutTaskId == stockOutTaskId).ToList();
                if (carryOut.Any(r => r.Status != (int)EntityStatus.StockOutFinish))
                {
                    return (false, "有搬运出库任务未完成");
                }

                int outCount = carryOut.Sum(r => r.MoveCount);
                decimal outWeight = carryOut.Sum(r => r.MoveWeight);

                StockOutTaskBusiness stockOutTaskBusiness = new StockOutTaskBusiness();
                stockOutTaskBusiness.Finish(stockOutTaskId, outCount, outWeight, db);

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
        /// 删除出库任务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) DeleteTask(string id)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                var carryIn = db.Queryable<CarryInTask>().Where(r => r.StockOutTaskId == id).ToList();
                if (carryIn.Count > 0)
                {
                    return (false, "出库任务含有搬运入库，无法删除");
                }

                var carryOut = db.Queryable<CarryOutTask>().Where(r => r.StockOutTaskId == id).ToList();
                if (carryOut.Count > 0)
                {
                    return (false, "出库任务含有搬运出库，无法删除");
                }

                StockOutTaskBusiness stockOutTaskBusiness = new StockOutTaskBusiness();
                var stockOutTask = stockOutTaskBusiness.FindById(id, db);

                if (stockOutTask.Status != (int)EntityStatus.StockOutReady)
                {
                    return (false, "仅能删除待出库状态的出库任务单");
                }

                // 删除出库任务
                var result = stockOutTaskBusiness.Delete(stockOutTask, db);

                db.Ado.CommitTran();
                return (result.success, result.errorMessage);
            }
            catch (Exception e)
            {
                db.Ado.RollbackTran();
                return (false, e.Message);
            }
        }
        #endregion //Stock Out Task Service
    }
}
