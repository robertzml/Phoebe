﻿using System;
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
    using Phoebe.Core.View;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 出库任务业务类
    /// </summary>
    public class StockOutTaskBusiness : AbstractBusiness<StockOutTask, string>, IBaseBL<StockOutTask, string>
    {
        #region Method
        /// <summary>
        /// 添加出库任务
        /// </summary>
        /// <param name="entity">出库任务</param>
        /// <param name="storeCount">在库数量</param>
        /// <param name="storeWeight">在库重量</param>
        /// <param name="outTime">出库时间</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage, StockOutTask t) Create(StockOutTask entity, int storeCount, decimal storeWeight, DateTime outTime, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            entity.Id = Guid.NewGuid().ToString();
            entity.StoreCount = storeCount;
            entity.StoreWeight = storeWeight;

            SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();
            entity.TaskCode = recordBusiness.GetNextSequence(db, "StockOutTask", outTime);

            entity.CreateTime = DateTime.Now;
            entity.Status = (int)EntityStatus.StockOutReady;

            var t = db.Insertable(entity).ExecuteReturnEntity();

            return (true, "", t);
        }

        /// <summary>
        /// 由搬运出库任务添加出库任务
        /// </summary>
        /// <param name="stockOutId">出库单ID</param>
        /// <param name="carryOutTask">搬运出库任务</param>
        /// <param name="user">清点人</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage, StockOutTask t) Create(string stockOutId, CarryOutTask carryOutTask, User user, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var task = db.Queryable<StockOutTask>().Single(r => r.StockOutId == stockOutId && r.CargoId == carryOutTask.CargoId);
            if (task == null)
            {
                SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();

                // 计算在库数量用
                var stores = db.Queryable<Store>()
                  .Where(r => r.CargoId == carryOutTask.CargoId && (r.Status == (int)EntityStatus.StoreIn || r.Status == (int)EntityStatus.StoreOutReady));

                var now = DateTime.Now;

                task = new StockOutTask();
                task.Id = Guid.NewGuid().ToString();
                task.StockOutId = stockOutId;
                task.TaskCode = recordBusiness.GetNextSequence(db, "StockOutTask", now);
                task.CargoId = carryOutTask.CargoId;
                task.StoreCount = stores.Sum(r => r.StoreCount);
                task.StoreWeight = stores.Sum(r => r.StoreWeight);
                task.OutCount = carryOutTask.MoveCount;
                task.OutWeight = carryOutTask.MoveWeight;

                task.CreateTime = now;
                task.UserId = user.Id;
                task.UserName = user.Name;

                task.Remark = "";
                task.Status = (int)EntityStatus.StockOutReady;

                db.Insertable(task).ExecuteCommand();
            }
            else
            {
                task.OutCount += carryOutTask.MoveCount;
                task.OutWeight += carryOutTask.MoveWeight;

                db.Updateable(task).ExecuteCommand();
            }

            return (true, "", task);
        }

        /// <summary>
        /// 确认出库任务
        /// </summary>
        /// <param name="id"></param>
        /// <param name="outCount"></param>
        /// <param name="outWeight"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Finish(string id, int outCount, decimal outWeight, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var task = db.Queryable<StockOutTask>().InSingle(id);

            task.OutCount = outCount;
            task.OutWeight = outWeight;

            task.FinishTime = DateTime.Now;
            task.Status = (int)EntityStatus.StockOutFinish;

            db.Updateable(task).ExecuteCommand();

            return (true, "");
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

            var stockOutTask = db.Queryable<StockOutTask>().InSingle(id);
            if (stockOutTask.Status != (int)EntityStatus.StockOutReady)
            {
                return (false, "仅能删除待出库状态的出库任务单");
            }

            db.Deleteable<StockOutTask>().In(id).ExecuteCommand();

            db.Ado.CommitTran();
            return (true, "");
        }
        #endregion //Method
    }
}