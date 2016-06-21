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

        /// <summary>
        /// 查找单条记录
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        public IceStore FindOne(Expression<Func<IceStore, bool>> predicate)
        {
            return this.context.IceStores.SingleOrDefault(predicate);
        }

        public IEnumerable<IceStore> Find(Expression<Func<IceStore, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 查找所有记录
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IceStore> FindAll()
        {
            return this.context.IceStores;
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
