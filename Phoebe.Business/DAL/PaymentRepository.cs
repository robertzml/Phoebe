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
        public Payment FindById(object id)
        {
            throw new NotImplementedException();
        }

        public Payment FindOne(Expression<Func<Payment, bool>> predicate)
        {
            throw new NotImplementedException();
        }       

        public IEnumerable<Payment> FindAll()
        {
            throw new NotImplementedException();
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

        public ErrorCode Create(Payment entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode CreateRange(List<Payment> entities)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Update(Payment entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Delete(Payment entity)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
