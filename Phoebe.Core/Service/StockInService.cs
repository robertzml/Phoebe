﻿using System;
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

                // 删除入库费用
                InBillingBusiness inBillingBusiness = new InBillingBusiness();
                var billings = db.Queryable<InBilling>().Where(r => r.StockInId == id).ToList();
                foreach (var item in billings)
                {
                    inBillingBusiness.Delete(item.Id, db);
                }

                StockInBusiness stockInBusiness = new StockInBusiness();
                var result = stockInBusiness.Delete(id, db);

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

                if (tasks.Any(r => r.Status != (int)EntityStatus.StockInFinish))
                {
                    return (false, "有入库货物未完成");
                }

                StockInBusiness stockInBusiness = new StockInBusiness();
                var result = stockInBusiness.Confirm(id, db);

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
        /// 撤回入库单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

                StoreBusiness storeBusiness = new StoreBusiness();
                CarryInTaskBusiness carryInTaskBusiness = new CarryInTaskBusiness();
                StockInTaskBusiness stockInTaskBusiness = new StockInTaskBusiness();
                var tasks = db.Queryable<StockInTask>().Where(r => r.StockInId == stockIn.Id).ToList();
                foreach (var task in tasks)
                {
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

                        // 撤回库存记录
                        storeBusiness.Revert(store, db);

                        // 撤回搬运入库任务
                        carryInTaskBusiness.Revert(carryIn, db);
                    }

                    // 撤回入库任务
                    stockInTaskBusiness.Revert(task, db);
                }

                // 撤回入库单
                stockInBusiness.Revert(stockIn, db);

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
                var stockIn = stockInBusiness.FindById(task.StockInId, db);

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

        /// <summary>
        /// 确认入库任务
        /// </summary>
        /// <param name="stockInTaskId"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) FinishTask(string stockInTaskId)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                var task = db.Queryable<StockInTaskView>().InSingle(stockInTaskId);
                int inCount = task.InCount;
                decimal inWeight = task.InWeight;

                if (task.StockInType == (int)StockInType.Position)   // 仓位库入库检查搬运任务
                {
                    var carryIn = db.Queryable<CarryInTask>().Where(r => r.StockInTaskId == stockInTaskId).ToList();
                    if (carryIn.Count == 0)
                    {
                        return (false, "缺少搬运入库任务");
                    }

                    if (carryIn.Any(r => r.Status != (int)EntityStatus.StockInFinish))
                    {
                        return (false, "有搬运入库任务未完成");
                    }

                    inCount = carryIn.Sum(r => r.MoveCount);
                    inWeight = carryIn.Sum(r => r.MoveWeight);
                }

                StockInTaskBusiness stockInTaskBusiness = new StockInTaskBusiness();
                stockInTaskBusiness.Finish(stockInTaskId, inCount, inWeight, db);

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
        /// 更新入库任务
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) UpdateTask(StockInTask inTask)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                var entity = db.Queryable<StockInTask>().InSingle(inTask.Id);

                if (entity.Status == (int)EntityStatus.StockInFinish)
                {
                    return (false, "无法编辑已确认入库任务单");
                }

                if (entity.CargoId != inTask.CargoId)
                {
                    entity.CargoId = inTask.CargoId;
                    entity.UnitWeight = inTask.UnitWeight;

                    // 修改搬运入库任务对应信息
                    var carryIns = db.Queryable<CarryInTask>().Where(r => r.StockInTaskId == inTask.Id && r.Type == (int)CarryInTaskType.In).ToList();

                    foreach (var carryIn in carryIns)
                    {
                        carryIn.MoveWeight = inTask.UnitWeight * carryIn.MoveCount / 1000;
                        db.Updateable(carryIn).ExecuteCommand();

                        var store = db.Queryable<Store>().Single(r => r.CarryInTaskId == carryIn.Id);
                        if (store != null)
                        {
                            store.StoreWeight = carryIn.MoveWeight;
                            store.TotalWeight = carryIn.MoveWeight;
                            db.Updateable(store).ExecuteCommand();
                        }
                    }
                }

                entity.Batch = inTask.Batch;
                entity.OriginPlace = inTask.OriginPlace;
                entity.Durability = inTask.Durability;
                entity.Remark = inTask.Remark;

                db.Updateable(entity).ExecuteCommand();

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
        /// 删除入库任务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) DeleteTask(string id)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                var carryIn = db.Queryable<CarryInTask>().Where(r => r.StockInTaskId == id).ToList();
                if (carryIn.Count > 0)
                {
                    return (false, "入库任务含有搬运入库，无法删除");
                }

                var carryOut = db.Queryable<CarryOutTask>().Where(r => r.StockInTaskId == id).ToList();
                if (carryOut.Count > 0)
                {
                    return (false, "入库任务含有搬运出库，无法删除");
                }

                StockInTaskBusiness stockInTaskBusiness = new StockInTaskBusiness();
                var result = stockInTaskBusiness.Delete(id, db);

                db.Ado.CommitTran();
                return (result.success, result.errorMessage);
            }
            catch (Exception e)
            {
                db.Ado.RollbackTran();
                return (false, e.Message);
            }
        }
        #endregion //Stock In Task Service
    }
}
