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
    using Phoebe.Core.Utility;

    /// <summary>
    /// 出库业务类
    /// </summary>
    public class StockOutBusiness : AbstractBusiness<StockOut, string>, IBaseBL<StockOut, string>
    {
        #region Method
        /// <summary>
        /// 创建出库单
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage, StockOut t) Create(StockOut entity, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();

            entity.Id = Guid.NewGuid().ToString();
            entity.MonthTime = entity.OutTime.Year.ToString() + entity.OutTime.Month.ToString().PadLeft(2, '0');
            entity.FlowNumber = recordBusiness.GetNextSequence(db, "StockOut", entity.OutTime);
            entity.CreateTime = DateTime.Now;
            entity.Status = (int)EntityStatus.StockOutReady;

            var t = db.Insertable(entity).ExecuteReturnEntity();

            return (true, "", t);
        }

        /// <summary>
        /// 编辑出库单
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage) Update(StockOut entity, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var stockOut = db.Queryable<StockOut>().InSingle(entity.Id);

            if (stockOut.OutTime != entity.OutTime)
            {
                SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();

                stockOut.OutTime = entity.OutTime;
                stockOut.MonthTime = stockOut.OutTime.Year.ToString() + stockOut.OutTime.Month.ToString().PadLeft(2, '0');
                stockOut.FlowNumber = recordBusiness.GetNextSequence(db, "StockOut", stockOut.OutTime);
            }

            stockOut.VehicleNumber = entity.VehicleNumber;
            stockOut.Remark = entity.Remark;

            db.Updateable(stockOut).ExecuteCommand();

            return (true, "");
        }

        /// <summary>
        /// 确认出库单
        /// </summary>
        /// <param name="id">出库单ID</param>
        /// <returns></returns>
        public (bool success, string errorMessage) Confirm(string id, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var stockOut = db.Queryable<StockOut>().InSingle(id);
            stockOut.ConfirmTime = DateTime.Now;
            stockOut.Status = (int)EntityStatus.StockOutFinish;

            db.Updateable(stockOut).ExecuteCommand();
            return (true, "");
        }

        /// <summary>
        /// 删除出库单
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Delete(StockOut entity, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            db.Deleteable<StockOut>().In(entity.Id).ExecuteCommand();
            return (true, "");
        }

        /// <summary>
        /// 撤回出库单
        /// </summary>
        /// <param name="stockOut"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Revert(StockOut stockOut, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            stockOut.Status = (int)EntityStatus.StockOutReady;
            db.Updateable(stockOut).UpdateColumns(r => new { r.Status }).ExecuteCommand();

            return (true, "");
        }
        #endregion //Method
    }
}