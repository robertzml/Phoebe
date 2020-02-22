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
    using Phoebe.Core.Utility;

    /// <summary>
    /// 入库业务类
    /// </summary>
    public class StockInBusiness : AbstractBusiness<StockIn, string>, IBaseBL<StockIn, string>
    {
        #region Method
        /// <summary>
        /// 添加入库单
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage, StockIn t) Create(StockIn entity, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();

            entity.Id = Guid.NewGuid().ToString();
            entity.MonthTime = entity.InTime.Year.ToString() + entity.InTime.Month.ToString().PadLeft(2, '0');
            entity.FlowNumber = recordBusiness.GetNextSequence(db, "StockIn", entity.InTime);
            entity.CreateTime = DateTime.Now;
            entity.Status = (int)EntityStatus.StockInReady;

            var t = db.Insertable(entity).ExecuteReturnEntity();

            return (true, "", t);
        }

        /// <summary>
        /// 编辑入库单
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage) Update(StockIn entity, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var stockIn = db.Queryable<StockIn>().InSingle(entity.Id);

            if (stockIn.InTime != entity.InTime)
            {
                SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();

                stockIn.InTime = entity.InTime;
                stockIn.MonthTime = stockIn.InTime.Year.ToString() + stockIn.InTime.Month.ToString().PadLeft(2, '0');
                stockIn.FlowNumber = recordBusiness.GetNextSequence(db, "StockIn", stockIn.InTime);
            }

            stockIn.Type = entity.Type;
            stockIn.ContractId = entity.ContractId;
            stockIn.VehicleNumber = entity.VehicleNumber;
            stockIn.Remark = entity.Remark;

            db.Updateable(stockIn).ExecuteCommand();

            return (true, "");
        }

        /// <summary>
        /// 确认入库单
        /// </summary>
        /// <param name="id">入库单ID</param>
        /// <returns></returns>
        public (bool success, string errorMessage) Confirm(string id, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var stockIn = db.Queryable<StockIn>().InSingle(id);
            stockIn.ConfirmTime = DateTime.Now;
            stockIn.Status = (int)EntityStatus.StockInFinish;

            db.Updateable(stockIn).ExecuteCommand();
            return (true, "");
        }

        /// <summary>
        /// 撤回入库单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Revert(StockIn stockIn, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            // 撤回入库单
            stockIn.Status = (int)EntityStatus.StockInReady;
            db.Updateable(stockIn).ExecuteCommand();

            return (true, "");
        }

        /// <summary>
        /// 删除入库单
        /// </summary>
        /// <param name="id"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage) Delete(string id, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var stockIn = db.Queryable<StockIn>().InSingle(id);
            if (stockIn.Status != (int)EntityStatus.StockInReady)
            {
                return (false, "仅能删除待入库状态的入库单");
            }

            db.Deleteable<StockIn>().In(id).ExecuteCommand();

            return (true, "");
        }
        #endregion //Method
    }
}