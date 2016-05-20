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
    /// 入库记录Repository
    /// </summary>
    public class StockInDetailsRepository : SqlDataAccess<PhoebeContext>, IBaseDataAccess<StockInDetail>
    {
        #region Method
        public StockInDetail FindById(object id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 查找入库记录
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        public StockInDetail FindOne(Expression<Func<StockInDetail, bool>> predicate)
        {
            return this.context.StockInDetails.SingleOrDefault(predicate);
        }

        public IEnumerable<StockInDetail> FindAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 按条件查询
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        public IEnumerable<StockInDetail> Find(Expression<Func<StockInDetail, bool>> predicate)
        {
            return this.context.StockInDetails.Where(predicate);
        }

        /// <summary>
        /// 添加入库记录
        /// </summary>
        /// <param name="entity">入库记录</param>
        /// <returns></returns>
        public ErrorCode Create(StockInDetail entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 添加多个入库详细记录
        /// </summary>
        /// <param name="entities">入库记录列表</param>
        /// <returns></returns>
        public ErrorCode CreateRange(List<StockInDetail> entities)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Update(StockInDetail entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Delete(StockInDetail entity)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
