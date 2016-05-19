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
    /// 移库Repository
    /// </summary>
    public class StockMoveRepository : SqlDataAccess<PhoebeContext>, IBaseDataAccess<StockMove>
    {
        #region Method
        /// <summary>
        /// 查找移库
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public StockMove FindById(object id)
        {
            return this.context.StockMoves.Find(id);
        }

        public StockMove FindOne(Expression<Func<StockMove, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StockMove> FindAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 按条件查询
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        public IEnumerable<StockMove> Find(Expression<Func<StockMove, bool>> predicate)
        {
            return this.context.StockMoves.Where(predicate);
        }

        public ErrorCode Create(StockMove entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode CreateRange(List<StockMove> entities)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Update(StockMove entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Delete(StockMove entity)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
