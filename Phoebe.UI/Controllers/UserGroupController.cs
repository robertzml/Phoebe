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
    /// 用户组控制器
    /// </summary>
    public class UserGroupController : Controller
    {
        #region Field
        /// <summary>
        /// 用户业务
        /// </summary>
        private UserBusiness userBusiness;
        #endregion //Field

        #region Constructor
        public UserGroupController()
        {
            this.userBusiness = new UserBusiness();
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 用户组主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var data = this.userBusiness.GetUserGroup(true);
            return View(data);
        }
        #endregion //Action
    }
}