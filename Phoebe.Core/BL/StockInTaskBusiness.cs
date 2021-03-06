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
            entity.CreateTime = DateTime.Now;
            entity.Status = (int)EntityStatus.StockInReady;

            var t = db.Insertable(entity).ExecuteReturnEntity();

            return (true, "", t);
        }

        /// <summary>
        /// 确认入库任务
        /// </summary>
        /// <param name="id">入库任务</param>
        /// <param name="inCount"></param>
        /// <param name="inWeight"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Finish(string id, int inCount, decimal inWeight, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var task = db.Queryable<StockInTask>().InSingle(id);

            task.InCount = inCount;
            task.InWeight = inWeight;

            task.FinishTime = DateTime.Now;
            task.Status = (int)EntityStatus.StockInFinish;

            db.Updateable(task).ExecuteCommand();

            return (true, "");
        }

        /// <summary>
        /// 删除入库任务
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Delete(StockInTask task, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            db.Deleteable<StockInTask>().In(task.Id).ExecuteCommand();

            return (true, "");
        }

        /// <summary>
        /// 撤回入库任务
        /// </summary>
        /// <param name="task"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Revert(StockInTask task, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            task.Status = (int)EntityStatus.StockInReady;
            db.Updateable(task).UpdateColumns(r => new { r.Status }).ExecuteCommand();

            return (true, "");
        }
        #endregion //Method
    }
}