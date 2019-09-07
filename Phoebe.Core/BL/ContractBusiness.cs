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
        /// 按客户获取
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public List<Contract> FindByCustomer(int customerId)
        {
            var db = GetInstance();
            return db.Queryable<Contract>().Where(r => r.CustomerId == customerId).ToList();
        }

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
                var number = sequenceBusiness.GetNextSequence(db, "Contract", entity.SignDate);
                if (!string.IsNullOrEmpty(number))
                    entity.Number = number;

                var count = db.Queryable<Contract>().Count(r => r.Number == entity.Number);
                if (count > 0)
                {
                    return (false, "编码重复", null);
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
        /// 编辑合同
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage) Update(Contract entity)
        {
            var db = GetInstance();
            var count = db.Queryable<Contract>().Count(r => r.Id != entity.Id && r.Number == entity.Number);
            if (count > 0)
            {
                return (false, "编码重复");
            }

            return base.Update(entity);
        }
        #endregion //Method
    }
}
