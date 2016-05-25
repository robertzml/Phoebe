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
    /// 结算Repository
    /// </summary>
    public class SettlementRepository : SqlDataAccess<PhoebeContext>, IBaseDataAccess<Settlement>
    {
        #region Method
        public Settlement FindById(object id)
        {
            throw new NotImplementedException();
        }

        public Settlement FindOne(Expression<Func<Settlement, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Settlement> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Settlement> Find(Expression<Func<Settlement, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Create(Settlement entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode CreateRange(List<Settlement> entities)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Update(Settlement entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Delete(Settlement entity)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
