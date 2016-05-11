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
    /// 客户业务类
    /// </summary>
    public class CustomerBusiness : BaseBusiness<Customer>
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IBaseDataAccess<Customer> dal;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 客户业务类
        /// </summary>
        public CustomerBusiness() : base()
        {
            this.dal = new CustomerRepository();
            base.Init(this.dal);
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 根据编码获取客户
        /// </summary>
        /// <param name="number">客户编码</param>
        /// <returns></returns>
        public Customer GetByNumber(string number)
        {
            Expression<Func<Customer, bool>> predicate = r => r.Number == number;
            var data = this.dal.Find(predicate);
            if (data.Count() == 0)
                return null;
            else
                return data.First();
        }
        #endregion //Method
    }
}
