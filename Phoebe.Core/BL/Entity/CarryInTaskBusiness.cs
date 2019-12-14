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
    /// 搬运入库任务业务类
    /// </summary>
    public class CarryInTaskBusiness : AbstractBusiness<CarryInTask, string>, IBaseBL<CarryInTask, string>
    {
        #region Method

        public override (bool success, string errorMessage, CarryInTask t) Create(CarryInTask entity)
        {
            var db = GetInstance();
            try
            {
                db.Ado.BeginTran();

                SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();

                entity.Id = Guid.NewGuid().ToString();
                entity.CreateTime = DateTime.Now;
                entity.CheckTime = DateTime.Now;
                entity.TaskCode = recordBusiness.GetNextSequence(db, "CarryInTask", entity.CreateTime);
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
        #endregion //Method
    }
}
