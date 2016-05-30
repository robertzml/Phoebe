using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Phoebe.Business
{
    using Phoebe.Base;
    using Phoebe.Model;
    using Phoebe.Business.DAL;

    /// <summary>
    /// 缴费业务类
    /// </summary>
    public class PaymentBusiness : BaseBusiness<Payment>
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IBaseDataAccess<Payment> dal;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 缴费业务类
        /// </summary>
        public PaymentBusiness() : base()
        {
            this.dal = RepositoryFactory<PaymentRepository>.Instance;
            base.Init(this.dal);
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取客户缴费记录
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <returns></returns>
        public List<Payment> GetByCustomer(int customerId)
        {
            var payments = this.dal.Find(r => r.CustomerId == customerId);
            return payments.ToList();
        }
        #endregion //Method
    }
}
