using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Core.BL
{
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
        public override (bool success, string errorMessage, StockIn t) Create(StockIn entity)
        {
            var db = GetInstance();
            try
            {
                db.Ado.BeginTran();

                SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();

                entity.Id = Guid.NewGuid().ToString();
                entity.MonthTime = entity.InTime.Year.ToString() + entity.InTime.Month.ToString().PadLeft(2, '0');
                entity.FlowNumber = recordBusiness.GetNextSequence(db, "StockIn", entity.InTime);
                entity.CreateTime = DateTime.Now;
                entity.Status = (int)EntityStatus.StockInReady;

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
        /// 编辑入库单
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage) Update(StockIn entity)
        {
            var db = GetInstance();
            try
            {
                db.Ado.BeginTran();

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

                var t = db.Updateable(stockIn).ExecuteCommand();

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
        /// 确认入库单
        /// </summary>
        /// <param name="id">入库单ID</param>
        /// <returns></returns>
        public (bool success, string errorMessage) Confirm(string id)
        {
            try
            {
                var db = GetInstance();

                var stockIn = db.Queryable<StockIn>().InSingle(id);
                var tasks = db.Queryable<StockInTask>().Where(r => r.StockInId == id).ToList();

                if (tasks.All(r => r.Status == (int)EntityStatus.StockInFinish))
                {
                    stockIn.ConfirmTime = DateTime.Now;
                    stockIn.Status = (int)EntityStatus.StockInFinish;

                    db.Updateable(stockIn).ExecuteCommand();
                    return (true, "");
                }
                else
                {
                    return (false, "有入库货物未完成");
                }
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
        }

        /// <summary>
        /// 撤回入库单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Recall(string id)
        {
            return (false, "");
        }

        /// <summary>
        /// 删除入库单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage) Delete(string id)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                var tasks = db.Queryable<StockInTask>().Where(r => r.StockInId == id).ToList();
                if (tasks.Count > 0)
                {
                    return (false, "入库单含有入库任务，无法删除");
                }

                db.Deleteable<StockIn>().In(id).ExecuteCommand();

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
