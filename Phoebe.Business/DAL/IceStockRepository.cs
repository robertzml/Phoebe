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
    /// 冰块出入库Repository
    /// </summary>
    public class IceStockRepository : SqlDataAccess<PhoebeContext>, IBaseDataAccess<IceStock>
    {
        #region Method
        public IceStock FindById(object id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 查找单条记录
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <returns></returns>
        public IceStock FindOne(Expression<Func<IceStock, bool>> predicate)
        {
            return this.context.IceStocks.SingleOrDefault(predicate);
        }

        public IEnumerable<IceStock> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IceStock> Find(Expression<Func<IceStock, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Create(IceStock entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode CreateRange(List<IceStock> entities)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Update(IceStock entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Delete(IceStock entity)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
