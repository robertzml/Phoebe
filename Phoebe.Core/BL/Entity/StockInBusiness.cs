using System;
using System.Collections.Generic;
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
        #endregion //Method
    }
}
