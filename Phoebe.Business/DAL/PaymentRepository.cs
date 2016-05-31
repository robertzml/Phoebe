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
    /// 缴费Repository
    /// </summary>
    public class PaymentRepository : SqlDataAccess<PhoebeContext>, IBaseDataAccess<Payment>
    {
        #region Method
        /// <summary>
        /// 根据ID查找
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public Payment FindById(object id)
        {
            return this.context.Payments.Find(id);
        }

        public Payment FindOne(Expression<Func<Payment, bool>> predicate)
        {
            throw new NotImplementedException();
        }       

        /// <summary>
        /// 获取所有缴费
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Payment> FindAll()
        {
            return this.context.Payments;
        }

        /// <summary>
        /// 查找缴费
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        public IEnumerable<Payment> Find(Expression<Func<Payment, bool>> predicate)
        {
            return this.context.Payments.Where(predicate);
        }

        /// <summary>
        /// 添加缴费
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ErrorCode Create(Payment entity)
        {
            try
            {
                this.context.Payments.Add(entity);
                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch(Exception)
            {
                return ErrorCode.Exception;
            }
        }

        public ErrorCode CreateRange(List<Payment> entities)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Update(Payment entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除缴费
        /// </summary>
        /// <param name="entity">缴费对象</param>
        /// <returns></returns>
        public ErrorCode Delete(Payment entity)
        {
            try
            {
                this.context.Payments.Remove(entity);

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
