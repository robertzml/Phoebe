using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Phoebe.Business.DAL
{
    using Phoebe.Base;
    using Phoebe.Model;

    /// <summary>
    /// 计费Repository
    /// </summary>
    public class BillingRepository : SqlDataAccess<PhoebeContext>, IBaseDataAccess<Billing>
    {
        #region Method
        /// <summary>
        /// 根据ID查找
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public Billing FindById(object id)
        {
            return this.context.Billings.Find(id);
        }

        /// <summary>
        /// 根据条件查找
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        public Billing FindOne(Expression<Func<Billing, bool>> predicate)
        {
            return this.context.Billings.SingleOrDefault(predicate);
        }

        public IEnumerable<Billing> FindAll()
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Billing> Find(Expression<Func<Billing, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Create(Billing entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode CreateRange(List<Billing> entities)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Update(Billing entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Delete(Billing entity)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
