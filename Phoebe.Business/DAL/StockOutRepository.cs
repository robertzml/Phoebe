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
    /// 出库Repository
    /// </summary>
    public class StockOutRepository : SqlDataAccess<PhoebeContext>, IBaseDataAccess<StockOut>
    {
        #region Method
        /// <summary>
        /// 查找出库单
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public StockOut FindById(object id)
        {
            return this.context.StockOuts.Find(id);
        }

        public StockOut FindOne(Expression<Func<StockOut, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 查找所有出库单
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StockOut> FindAll()
        {
            return this.context.StockOuts;
        }

        /// <summary>
        /// 按条件查询出库
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        public IEnumerable<StockOut> Find(Expression<Func<StockOut, bool>> predicate)
        {
            return this.context.StockOuts.Where(predicate);
        }

        public ErrorCode Create(StockOut entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode CreateRange(List<StockOut> entities)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Update(StockOut entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除出库
        /// </summary>
        /// <param name="entity">出库对象</param>
        /// <returns></returns>
        public ErrorCode Delete(StockOut entity)
        {
            try
            {
                this.context.StockOuts.Remove(entity);
                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch(Exception)
            {
                return ErrorCode.Exception;
            }
        }
        #endregion //Method
    }
}
