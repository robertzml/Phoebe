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
    /// 入库业务类
    /// </summary>
    public class StockInService : AbstractService
    {
        #region Stock In Service
        /// <summary>
        /// 添加入库单
        /// </summary>
        /// <param name="stockIn">入库单对象</param>
        /// <returns></returns>
        public (bool success, string errorMessage, StockIn t) AddReceipt(StockIn stockIn)
        {
            var db = GetInstance();
            try
            {
                db.Ado.BeginTran();

                StockInBusiness stockInBusiness = new StockInBusiness();
                var result = stockInBusiness.Create(stockIn, db);

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
        /// 编辑入库单
        /// </summary>
        /// <param name="stockIn"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) UpdateReceipt(StockIn stockIn)
        {
            var db = GetInstance();
            try
            {
                db.Ado.BeginTran();

                StockInBusiness stockInBusiness = new StockInBusiness();
                var result = stockInBusiness.Update(stockIn, db);

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
        /// 删除入库单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) DeleteReceipt(string id)
        {
            var db = GetInstance();
            try
            {
                db.Ado.BeginTran();

                StockInTaskViewBusiness stockInTaskViewBusiness = new StockInTaskViewBusiness();

                var tasks = stockInTaskViewBusiness.FindList(id, db);
                if (tasks.Count > 0)
                {
                    return (false, "入库单含有入库任务，无法删除");
                }

                StockInBusiness stockInBusiness = new StockInBusiness();
                var result = stockInBusiness.Delete(id);

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
        /// 确认入库单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) ConfirmReceipt(string id)
        {
            var db = GetInstance();
            try
            {
                db.Ado.BeginTran();

                StockInTaskViewBusiness stockInTaskViewBusiness = new StockInTaskViewBusiness();
                var tasks = stockInTaskViewBusiness.FindList(id, db);

                if (tasks.All(r => r.Status == (int)EntityStatus.StockInFinish))
                {
                    StockInBusiness stockInBusiness = new StockInBusiness();
                    var result = stockInBusiness.Confirm(id);

                    db.Ado.CommitTran();
                    return (result.success, result.errorMessage);
                }
                else
                {
                    return (false, "有入库货物未完成");
                }
            }
            catch (Exception e)
            {
                db.Ado.RollbackTran();
                return (false, e.Message);
            }
        }

        public (bool success, string errorMessage) RevertReceipt(string id)
        {
            var db = GetInstance();
            try
            {
                db.Ado.BeginTran();

                StockInBusiness stockInBusiness = new StockInBusiness();
                var stockIn = stockInBusiness.FindById(id, db);

                if (stockIn.Status != (int)EntityStatus.StockInFinish)
                {
                    return (false, "仅已确认入库单能撤回");
                }

                StockInTaskViewBusiness stockInTaskViewBusiness = new StockInTaskViewBusiness();
                var tasks = stockInTaskViewBusiness.FindList(id, db);

                foreach (var task in tasks)
                {
                    task.Status = (int)EntityStatus.StockInReady;

                    // 撤回搬运入库任务和库存记录
                    var carryIns = db.Queryable<CarryInTask>().Where(r => r.StockInTaskId == task.Id).ToList();
                    foreach (var carryIn in carryIns)
                    {
                        var store = db.Queryable<Store>().Single(r => r.CarryInTaskId == carryIn.Id);

                        var carryOut = db.Queryable<CarryOutTask>().Count(r => r.StoreId == store.Id);
                        if (carryOut > 0)
                        {
                            return (false, "该入库单有库存记录已出库，无法撤回");
                        }

                        store.Status = (int)EntityStatus.StoreInReady;
                        db.Updateable(store).ExecuteCommand();

                        carryIn.Status = (int)EntityStatus.StockInEnter;
                        db.Updateable(carryIn).ExecuteCommand();
                    }

                    db.Updateable(task).ExecuteCommand();
                }

                // 撤回入库单
                stockIn.Status = (int)EntityStatus.StockInReady;
                db.Updateable(stockIn).ExecuteCommand();

                db.Ado.CommitTran();
                return (true, "");

            }
            catch (Exception e)
            {
                db.Ado.RollbackTran();
                return (false, e.Message);
            }
        }
        #endregion //Stock In Service

        #region Billing Service
        /// <summary>
        /// 设置入库计费
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) SetBilling(List<InBilling> data)
        {
            var db = GetInstance();
            try
            {
                db.Ado.BeginTran();

                InBillingBusiness inBillingBusiness = new InBillingBusiness();
                foreach (var item in data)
                {
                    if (item.Amount == 0)
                        continue;

                    inBillingBusiness.Save(item, db);
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
        #endregion //Billing Service

        #region Stock In Task Service
        /// <summary>
        /// 添加入库任务单
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public (bool success, string errorMessage, StockInTask t) AddTask(StockInTask task)
        {
            var db = GetInstance();
            try
            {
                db.Ado.BeginTran();

                StockInBusiness stockInBusiness = new StockInBusiness();
                var stockIn = stockInBusiness.FindById(task.StockInId);

                StockInTaskBusiness stockInTaskBusiness = new StockInTaskBusiness();
                var result = stockInTaskBusiness.Create(task, stockIn.InTime, db);

                db.Ado.CommitTran();
                return (result.success, result.errorMessage, result.t);
            }
            catch (Exception e)
            {
                db.Ado.RollbackTran();
                return (false, e.Message, null);
            }
        }
        #endregion //Stock In Task Service

        #region Carry In Service
        /// <summary>
        /// 添加搬运入库任务
        /// </summary>
        /// <param name="carryInTask"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) AddCarryIn(CarryInTask carryInTask)
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
        /// 删除搬运入库单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) DeleteCarryIn(string id)
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
        #endregion //Carry In Service
    }
}
