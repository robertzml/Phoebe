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
    using Phoebe.Core.View;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 搬运出库任务业务类
    /// </summary>
    public class CarryOutTaskBusiness : AbstractBusiness<CarryOutTask, string>, IBaseBL<CarryOutTask, string>
    {
        #region Function
        /// <summary>
        /// 生成临时搬运出库任务
        /// </summary>
        /// <param name="outTask"></param>
        /// <param name="position"></param>
        /// <param name="viceShelf"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        private CarryOutTask GenerateTempOutTask(StockOutTaskView outTask, PositionView position, bool viceShelf, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            CarryOutTask task = new CarryOutTask();
            task.Id = Guid.NewGuid().ToString();
            task.Type = (int)CarryOutTaskType.Temp;
            task.StockOutTaskId = outTask.Id;

            // find store
            var store = db.Queryable<StoreView>().Single(r => r.PositionId == position.Id && r.Status == (int)EntityStatus.StoreIn);
            if (store != null)
            {
                task.StoreId = store.Id;
                task.StoreCount = store.StoreCount;
                task.MoveCount = store.StoreCount;
                task.StoreWeight = store.StoreWeight;
                task.MoveWeight = store.StoreWeight;
                task.Place = store.Place;
            }

            if (viceShelf)
                task.ShelfCode = position.ViceShelfCode;
            else
                task.ShelfCode = position.ShelfCode;
            task.PositionId = position.Id;

            task.CreateTime = DateTime.Now;
            task.Status = (int)EntityStatus.StockOutReady;

            return task;
        }

        private CarryInTask GenerateTempInTask(CarryOutTask outTask, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            CarryInTask task = new CarryInTask();
            task.Id = Guid.NewGuid().ToString();
            task.CreateTime = DateTime.Now;
            task.CheckTime = DateTime.Now;
            //task.TaskCode = recordBusiness.GetNextSequence(db, "CarryInTask", entity.CreateTime);
            task.Status = (int)EntityStatus.StockInCheck;

            return null;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 批量添加搬运出库任务
        /// 指同一出库任务下的搬运任务，并且生成相关临时搬运出库任务
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Create(List<CarryOutTask> data)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();
                var now = DateTime.Now;

                var stockOutTask = db.Queryable<StockOutTaskView>().InSingle(data.First().StockOutTaskId);

                // 设置出库的搬运任务信息
                foreach (var item in data)
                {
                    item.Id = Guid.NewGuid().ToString();
                    item.Type = (int)CarryOutTaskType.Out;
                    item.CreateTime = now;
                    item.TaskCode = recordBusiness.GetNextSequence(db, "CarryOutTask", item.CreateTime);

                    var store = db.Queryable<StoreView>().InSingle(item.StoreId);
                    item.PositionId = store.PositionId;
                    item.Place = store.Place;
                    item.Status = (int)EntityStatus.StockOutReady;

                    db.Insertable(item).ExecuteReturnEntity();
                }

                List<CarryOutTask> tempOutTasks = new List<CarryOutTask>();
                foreach (var carryOuTask in data)
                {
                    // 搬运出库任务的仓位
                    var currentPos = db.Queryable<PositionView>().InSingle(carryOuTask.PositionId);

                    // 找到该货物同一排的所有仓位
                    var positions = db.Queryable<PositionView>()
                        .Where(r => r.ShelfId == currentPos.ShelfId && r.Row == currentPos.Row && r.Layer == currentPos.Layer).ToList();

                    if (currentPos.ShelfCode == carryOuTask.ShelfCode)
                    {
                        var outPos = positions.Where(r => r.Depth < currentPos.Depth).ToList();
                        foreach (var pos in outPos)
                        {
                            if (tempOutTasks.Any(r => r.PositionId == pos.Id))
                                continue;

                            var tempTask = GenerateTempOutTask(stockOutTask, pos, false, db);
                            tempOutTasks.Add(tempTask);
                        }
                    }
                    else if (currentPos.ViceShelfCode == carryOuTask.ShelfCode)
                    {
                        var outPos = positions.Where(r => r.Depth > currentPos.Depth).ToList();
                        foreach (var pos in outPos)
                        {
                            if (tempOutTasks.Any(r => r.PositionId == pos.Id))
                                continue;

                            var tempTask = GenerateTempOutTask(stockOutTask, pos, false, db);
                            tempOutTasks.Add(tempTask);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }

                foreach (var item in tempOutTasks)
                {
                    item.TaskCode = recordBusiness.GetNextSequence(db, "CarryOutTask", item.CreateTime);
                    db.Insertable(item).ExecuteReturnEntity();
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
        #endregion //Method
    }
}
