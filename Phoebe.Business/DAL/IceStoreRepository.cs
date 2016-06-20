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
    /// 冰块库存Repository
    /// </summary>
    public class IceStoreRepository : SqlDataAccess<PhoebeContext>, IBaseDataAccess<IceStore>
    {
        #region Method
        public IceStore FindById(object id)
        {
            throw new NotImplementedException();
        }

        public IceStore FindOne(Expression<Func<IceStore, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IceStore> Find(Expression<Func<IceStore, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IceStore> FindAll()
        {
            throw new NotImplementedException();
        }

        public ErrorCode Create(IceStore entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode CreateRange(List<IceStore> entities)
        {
            throw new NotImplementedException();
        }        

        public ErrorCode Update(IceStore entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Delete(IceStore entity)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
