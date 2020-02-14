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

    /// <summary>
    /// 入库任务业务类
    /// </summary>
    public class StockInTaskBusiness : AbstractBusiness<StockInTask, string>, IBaseBL<StockInTask, string>
    {
        #region Method
        /// <summary>
        /// 添加入库任务
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public (bool success, string errorMessage, StockInTask t) Create(StockInTask entity, DateTime inTime, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();         

            SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();
            entity.TaskCode = recordBusiness.GetNextSequence(db, "StockInTask", inTime);

            entity.Id = Guid.NewGuid().ToString();
            //entity.InWeight = entity.InCount * entity.UnitWeight;
            entity.CreateTime = DateTime.Now;
            entity.Status = (int)EntityStatus.StockInReady;

            var t = db.Insertable(entity).ExecuteReturnEntity();

            return (true, "", t);
        }

        /// <summary>
        /// 确认入库任务
        /// </summary>
        /// <param name="stockInTaskId"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Confirm(string stockInTaskId)
        {
            try
            {
                var db = GetInstance();

                var task = db.Queryable<StockInTask>().InSingle(stockInTaskId);
                var carryIn = db.Queryable<CarryInTask>().Where(r => r.StockInTaskId == stockInTaskId).ToList();
                if (carryIn.Count == 0)
                {
                    return (false, "缺少搬运入库任务");
                }

                if (carryIn.All(r => r.Status == (int)EntityStatus.StockInFinish))
                {
                    task.InCount = carryIn.Sum(r => r.MoveCount);
                    task.InWeight = carryIn.Sum(r => r.MoveWeight);

                    task.FinishTime = DateTime.Now;
                    task.Status = (int)EntityStatus.StockInFinish;

                    db.Updateable(task).ExecuteCommand();

                    return (true, "");
                }
                else
                {
                    return (false, "有搬运入库任务未完成");
                }
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
        }

        /// <summary>
        /// 更新入库任务
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage) Update(StockInTask inTask, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

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

                    var carryIns = db.Queryable<CarryInTask>().Where(r => r.StockInTaskId == inTask.Id).ToList();

                    foreach (var carryIn in carryIns)
                    {
                        carryIn.MoveWeight = inTask.UnitWeight * carryIn.MoveCount / 1000;
                        db.Updateable(carryIn).ExecuteCommand();

                        var store = db.Queryable<Store>().Single(r => r.CarryInTaskId == carryIn.Id);
                        store.StoreWeight = carryIn.MoveWeight;
                        store.TotalWeight = carryIn.MoveWeight;
                        db.Updateable(store).ExecuteCommand();
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
        public override (bool success, string errorMessage) Delete(string id, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

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

                db.Deleteable<StockInTask>().In(id).ExecuteCommand();

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