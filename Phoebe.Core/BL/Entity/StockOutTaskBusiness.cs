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
    /// 出库任务业务类
    /// </summary>
    public class StockOutTaskBusiness : AbstractBusiness<StockOutTask, string>, IBaseBL<StockOutTask, string>
    {
        #region Method
        public override (bool success, string errorMessage, StockOutTask t) Create(StockOutTask entity)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                var stockOut = db.Queryable<StockOut>().InSingle(entity.StockOutId);
                    
                StoreViewBusiness svBusiness = new StoreViewBusiness();
                var stores = svBusiness.FindByCargo(stockOut.ContractId, entity.CargoId, true, db);
                
                entity.StoreCount = stores.Sum(r => r.StoreCount);
                entity.StoreWeight = stores.Sum(r => r.StoreWeight);

                SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();
                entity.TaskCode = recordBusiness.GetNextSequence(db, "StockOutTask", stockOut.OutTime);

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
