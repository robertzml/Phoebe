﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.BL
{
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
        public override (bool success, string errorMessage, StockOut t) Create(StockOut entity)
        {
            var db = GetInstance();
            try
            {
                db.Ado.BeginTran();

                SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();

                entity.Id = Guid.NewGuid().ToString();
                entity.MonthTime = entity.OutTime.Year.ToString() + entity.OutTime.Month.ToString().PadLeft(2, '0');
                entity.FlowNumber = recordBusiness.GetNextSequence(db, "StockOut", entity.OutTime);
                entity.CreateTime = DateTime.Now;
                entity.Status = (int)EntityStatus.StockOutReady;

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