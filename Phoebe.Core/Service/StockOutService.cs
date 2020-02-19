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
        #endregion //Stock Out Task Service
    }
}
