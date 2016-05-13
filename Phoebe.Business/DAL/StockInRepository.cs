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
    /// 入库Repository
    /// </summary>
    public class StockInRepository : SqlDataAccess<PhoebeContext>, IBaseDataAccess<StockIn>
    {
        #region Method
        /// <summary>
        /// 根据ID查找入库单
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public StockIn FindById(object id)
        {
            return this.context.StockIns.Find(id);
        }

        /// <summary>
        /// 查找入库单
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        public StockIn FindOne(Expression<Func<StockIn, bool>> predicate)
        {
            return this.context.StockIns.SingleOrDefault(predicate);
        }

        /// <summary>
        /// 获取所有入库单
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StockIn> FindAll()
        {
            return this.context.StockIns;
        }

        /// <summary>
        /// 按条件查询入库单
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        public IEnumerable<StockIn> Find(Expression<Func<StockIn, bool>> predicate)
        {
            return this.context.StockIns.Where(predicate);
        }


        public ErrorCode Create(StockIn entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode CreateRange(List<StockIn> entities)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Update(StockIn entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Delete(StockIn entity)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
