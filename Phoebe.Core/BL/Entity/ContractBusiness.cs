using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.BL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Core.Entity;

    /// <summary>
    /// 合同业务类
    /// </summary>
    public class ContractBusiness : AbstractBusiness<Contract, int>, IBaseBL<Contract, int>
    {
        #region Method
        /// <summary>
        /// 创建合同
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage, Contract t) Create(Contract entity)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                SequenceRecordBusiness sequenceBusiness = new SequenceRecordBusiness();
                entity.Number = sequenceBusiness.GetNextSequence(db, "Contract", entity.SignDate);
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

        /// <summary>
        /// 编辑合同
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage) Update(Contract entity)
        {
            return base.Update(entity);
        }
        #endregion //Method
    }
}
