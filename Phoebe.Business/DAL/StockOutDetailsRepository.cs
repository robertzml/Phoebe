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
    /// 出库记录Repository
    /// </summary>
    public class StockOutDetailsRepository : SqlDataAccess<PhoebeContext>, IBaseDataAccess<StockOutDetail>
    {
        #region Method
        public StockOutDetail FindById(object id)
        {
            throw new NotImplementedException();
        }

        public StockOutDetail FindOne(Expression<Func<StockOutDetail, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StockOutDetail> FindAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 按条件查询
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        public IEnumerable<StockOutDetail> Find(Expression<Func<StockOutDetail, bool>> predicate)
        {
            return this.context.StockOutDetails.Where(predicate);
        }

        public ErrorCode Create(StockOutDetail entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode CreateRange(List<StockOutDetail> entities)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Update(StockOutDetail entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Delete(StockOutDetail entity)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
