using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
