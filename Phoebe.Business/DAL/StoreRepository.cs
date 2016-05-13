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
    /// 库存Repository
    /// </summary>
    public class StoreRepository : SqlDataAccess<PhoebeContext>, IBaseDataAccess<Store>
    {
        #region Method
        public Store FindById(object id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取所有库存
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Store> FindAll()
        {
            return this.context.Stores;
        }

        /// <summary>
        /// 按条件查找库存
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        public IEnumerable<Store> Find(Expression<Func<Store, bool>> predicate)
        {
            return this.context.Stores.Where(predicate);
        }

        public ErrorCode Create(Store entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode CreateRange(List<Store> entities)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Update(Store entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Delete(Store entity)
        {
            throw new NotImplementedException();
        }

        public Store FindOne(Expression<Func<Store, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
