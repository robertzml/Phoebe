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
        public Billing FindById(object id)
        {
            throw new NotImplementedException();
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

        public Billing FindOne(Expression<Func<Billing, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
