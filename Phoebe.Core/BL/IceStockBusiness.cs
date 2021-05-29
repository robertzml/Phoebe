using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.BL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.Entity;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 冰块入库业务类
    /// </summary>
    public class IceStockBusiness : AbstractBusiness<IceStock, string>, IBaseBL<IceStock, string>
    {
        #region Method
        /// <summary>
        /// 按年度搜索入库记录
        /// </summary>
        /// <param name="year">入库年份</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public List<IceStock> FindByYear(int year, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<IceStock>().Where(r => r.StockTime.Year == year);
            return data.ToList();
        }

        /// <summary>
        /// 获取整冰入库总数量
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public int GetCompleteInCount(SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<IceStock>().Where(r => r.IceType == (int)IceType.Complete && r.StockType == (int)IceStockType.CompleteIn).Sum(r => r.FlowCount);
            return data;
        }

        /// <summary>
        /// 获取整冰制冰出库总数量
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public int GetCompleteOutCount(SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<IceStock>().Where(r => r.IceType == (int)IceType.Complete && r.StockType == (int)IceStockType.CompleteOut).Sum(r => r.FlowCount);
            return data;
        }

        /// <summary>
        /// 获取碎冰入库总数量
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public int GetFragmentInCount(SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<IceStock>().Where(r => r.IceType == (int)IceType.Fragment).Sum(r => r.FlowCount);
            return data;
        }

        /// <summary>
        /// 冰块入库
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage, IceStock t) StockIn(IceStock entity, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                SequenceRecordBusiness sequenceBusiness = new SequenceRecordBusiness();
                entity.FlowNumber = sequenceBusiness.GetNextSequence(db, "IceStock", entity.StockTime);

                entity.Id = Guid.NewGuid().ToString();
                entity.CreateTime = DateTime.Now;
                entity.Status = 0;

                if (entity.IceType == (int)IceType.Complete)
                {
                    entity.StockType = (int)IceStockType.CompleteIn;
                }
                else if (entity.IceType == (int)IceType.Fragment)
                {
                    entity.StockType = (int)IceStockType.FragmentIn;
                }

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
        /// 整冰制冰出库
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage, IceStock t) StockOut(IceStock entity, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                SequenceRecordBusiness sequenceBusiness = new SequenceRecordBusiness();
                entity.FlowNumber = sequenceBusiness.GetNextSequence(db, "IceStock", entity.StockTime);

                entity.Id = Guid.NewGuid().ToString();
                entity.StockType = (int)IceStockType.CompleteOut;
                entity.CreateTime = DateTime.Now;
                entity.Status = 0;

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
        #endregion //Method
    }
}
