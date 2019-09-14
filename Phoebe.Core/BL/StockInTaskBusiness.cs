﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.BL
{
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
        public override (bool success, string errorMessage, StockInTask t) Create(StockInTask entity)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                var stockIn = db.Queryable<StockIn>().Single(r => r.Id == entity.StockInId);

                SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();
                entity.TaskCode = recordBusiness.GetNextSequence(db, "StockInTask", stockIn.InTime);

                entity.Id = Guid.NewGuid().ToString();
                entity.CreateTIme = DateTime.Now;
                entity.Status = (int)EntityStatus.StockInCheck;

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
        /// 接单
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Receive(StockInTask entity)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                var task = db.Queryable<StockInTask>().Single(r => r.Id == entity.Id);
                if (task.Status != (int)EntityStatus.StockInCheck)
                    return (false, "无法接单");

                task.ReceiveUserId = entity.ReceiveUserId;
                task.ReceiveUserName = entity.ReceiveUserName;
                task.ReceiveTime = DateTime.Now;
                task.Status = (int)EntityStatus.StockInReceive;

                db.Updateable(task).ExecuteCommand();

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
        /// 上架
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Enter(StockInTask entity)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                var task = db.Queryable<StockInTask>().Single(r => r.Id == entity.Id);

                if (task.Status != (int)EntityStatus.StockInReceive)
                {
                    return (false, "该任务无法上架");
                }

                task.ShelfCode = entity.ShelfCode;

                // find position
                PositionBusiness positionBusiness = new PositionBusiness();
                var position = positionBusiness.FindEmpty(db, task.ShelfCode);
                if (position == null)
                {
                    return (false, "无空仓位");
                }

                // update position
                position.IsEmpty = false;
                db.Updateable(position).ExecuteCommand();

                task.PositionId = position.Id;
                task.EnterTime = DateTime.Now;
                task.Status = (int)EntityStatus.StockInEnter;

                db.Updateable(task).ExecuteCommand();

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
        /// 完成
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Finish(StockInTask entity)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                var task = db.Queryable<StockInTask>().Single(r => r.Id == entity.Id);

                if (task.Status != (int)EntityStatus.StockInEnter)
                {
                    return (false, "该任务无法完成");
                }

                task.FinishTime = DateTime.Now;
                task.Status = (int)EntityStatus.StockInFinish;

                db.Updateable(task).ExecuteCommand();

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
