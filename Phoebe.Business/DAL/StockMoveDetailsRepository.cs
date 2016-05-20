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
    /// 移库记录Repository
    /// </summary>
    public class StockMoveDetailsRepository : SqlDataAccess<PhoebeContext>, IBaseDataAccess<StockMoveDetail>
    {
        #region Method
        /// <summary>
        /// 根据ID查找
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public StockMoveDetail FindById(object id)
        {
            return this.context.StockMoveDetails.Find(id);
        }

        /// <summary>
        /// 查找记录
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        public StockMoveDetail FindOne(Expression<Func<StockMoveDetail, bool>> predicate)
        {
            return this.context.StockMoveDetails.SingleOrDefault(predicate);
        }


        public IEnumerable<StockMoveDetail> FindAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 查找记录
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        public IEnumerable<StockMoveDetail> Find(Expression<Func<StockMoveDetail, bool>> predicate)
        {
            return this.context.StockMoveDetails.Where(predicate);
        }


        public ErrorCode Create(StockMoveDetail entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode CreateRange(List<StockMoveDetail> entities)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Update(StockMoveDetail entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Delete(StockMoveDetail entity)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
