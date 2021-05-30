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
    /// 冰块销售业务类
    /// </summary>
    public class IceSaleBusiness : AbstractBusiness<IceSale, string>, IBaseBL<IceSale, string>
    {
        #region Method
        /// <summary>
        /// 添加冰块销售
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage, IceSale t) Create(IceSale entity, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                SequenceRecordBusiness sequenceBusiness = new SequenceRecordBusiness();
                entity.FlowNumber = sequenceBusiness.GetNextSequence(db, "IceSale", entity.SaleTime);

                entity.Id = Guid.NewGuid().ToString();
                entity.SaleFee = Math.Round(entity.SaleCount * entity.SaleUnitPrice, 2);
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
