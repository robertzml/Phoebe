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
    /// 结算Repository
    /// </summary>
    public class SettlementRepository : SqlDataAccess<PhoebeContext>, IBaseDataAccess<Settlement>
    {
        #region Method
        /// <summary>
        /// 查找结算
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public Settlement FindById(object id)
        {
            return this.context.Settlements.Find(id);
        }

        public Settlement FindOne(Expression<Func<Settlement, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取所有结算
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Settlement> FindAll()
        {
            return this.context.Settlements;
        }

        /// <summary>
        /// 根据条件查找
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        public IEnumerable<Settlement> Find(Expression<Func<Settlement, bool>> predicate)
        {
            return this.context.Settlements.Where(predicate);
        }

        public ErrorCode Create(Settlement entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode CreateRange(List<Settlement> entities)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Update(Settlement entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除结算
        /// </summary>
        /// <param name="entity">结算对象</param>
        /// <returns></returns>
        public ErrorCode Delete(Settlement entity)
        {
            try
            {
                this.context.Settlements.Remove(entity);

                this.context.SaveChanges();
                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }
        #endregion //Method
    }
}
