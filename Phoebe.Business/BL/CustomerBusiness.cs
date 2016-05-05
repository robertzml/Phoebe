using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Base;
using Phoebe.Model;
using Phoebe.Business.DAL;

namespace Phoebe.Business
{
    /// <summary>
    /// 客户业务类
    /// </summary>
    public class CustomerBusiness : BaseBusiness<Customer>
    {
        #region Constructor
        /// <summary>
        /// 客户业务类
        /// </summary>
        public CustomerBusiness() : base()
        {
            base.Init(new CustomerRepository());
        }
        #endregion //Constructor
    }
}
