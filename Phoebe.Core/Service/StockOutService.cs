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
                var result = stockOutBusiness.Delete(id);

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

                // 获取出库单
                StockOutTaskBusiness stockOutTaskBusiness = new StockOutTaskBusiness();
                CarryOutTaskBusiness carryOutTaskBusiness = new CarryOutTaskBusiness();
                CarryInTaskBusiness carryInTaskBusiness = new CarryInTaskBusiness();
                StockOutBusiness stockOutBusiness = new StockOutBusiness();
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
                        carryOutTask.StockOutTaskId = result.t.Id;

                        // 更新搬运出库任务
                        carryOutTaskBusiness.Check(carryOutTask.Id, result.t.Id, carryOutTask.MoveCount, carryOutTask.MoveWeight, carryOutTask.Remark, user, db);

                        if (carryOutTask.MoveCount < carryOutTask.StoreCount)
                        {
                            // 创建放回任务
                            carryInTaskBusiness.CreateBack(carryOutTask, user, db);
                        }
                    }
                    else //无需出库的货物放回
                    {
                        // 更新搬运出库任务
                        carryOutTaskBusiness.CheckUnmove(carryOutTask.Id, user, db);

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
        #endregion //Stock Out Task Service
    }
}
