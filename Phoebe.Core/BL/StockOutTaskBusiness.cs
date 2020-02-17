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
    using Phoebe.Core.DL;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 出库任务业务类
    /// </summary>
    public class StockOutTaskBusiness : AbstractBusiness<StockOutTask, string>, IBaseBL<StockOutTask, string>
    {
        #region Method
        public override (bool success, string errorMessage, StockOutTask t) Create(StockOutTask entity, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                var stockOut = db.Queryable<StockOut>().InSingle(entity.StockOutId);

                StoreViewBusiness svBusiness = new StoreViewBusiness();
                var stores = svBusiness.FindByCargo(stockOut.ContractId, entity.CargoId, true, db);

                entity.Id = Guid.NewGuid().ToString();
                entity.StoreCount = stores.Sum(r => r.StoreCount);
                entity.StoreWeight = stores.Sum(r => r.StoreWeight);

                if (entity.OutCount > entity.StoreCount)
                    return (false, "出库数量大于在库数量", null);
                if (entity.OutWeight > entity.StoreWeight)
                    return (false, "出库重量大于在库重量", null);

                SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();
                entity.TaskCode = recordBusiness.GetNextSequence(db, "StockOutTask", stockOut.OutTime);

                entity.CreateTime = DateTime.Now;
                entity.Status = (int)EntityStatus.StockOutReady;

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
        /// 确认出库任务
        /// </summary>
        /// <param name="stockOutTaskId"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Confirm(string stockOutTaskId)
        {
            try
            {
                var db = GetInstance();

                var task = db.Queryable<StockOutTask>().InSingle(stockOutTaskId);

                var carryIn = db.Queryable<CarryInTask>().Where(r => r.StockOutTaskId == stockOutTaskId).ToList();
                if (carryIn.Any(r => r.Status != (int)EntityStatus.StockInFinish))
                {
                    return (false, "有搬运入库任务未完成");
                }

                var carryOut = db.Queryable<CarryOutTask>().Where(r => r.StockOutTaskId == stockOutTaskId).ToList();
                if (carryOut.All(r => r.Status == (int)EntityStatus.StockOutFinish))
                {
                    task.OutCount = carryOut.Sum(r => r.MoveCount);
                    task.OutWeight = carryOut.Sum(r => r.MoveWeight);

                    task.FinishTime = DateTime.Now;
                    task.Status = (int)EntityStatus.StockOutFinish;

                    db.Updateable(task).ExecuteCommand();

                    return (true, "");
                }
                else
                {
                    return (false, "有搬运出库任务未完成");
                }
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
        }

        /// <summary>
        /// 删除出库任务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage) Delete(string id, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

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

                db.Deleteable<StockOutTask>().In(id).ExecuteCommand();

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
