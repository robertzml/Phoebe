using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phoebe.Business;
using Phoebe.Common;
using Phoebe.Model;

namespace Phoebe.UI.Controllers
{
    /// <summary>
    /// 团体客户控制器
    /// </summary>
    public class GroupCustomerController : Controller
    {
        #region Field
        /// <summary>
        /// 客户业务
        /// </summary>
        private CustomerBusiness customerBusiness;
        #endregion //Field

        #region Constructor
        public GroupCustomerController()
        {
            this.customerBusiness = new CustomerBusiness();
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 团体客户主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var data = this.customerBusiness.GetGroupCustomer();
            return View(data);
        }
        #endregion //Action
    }
}