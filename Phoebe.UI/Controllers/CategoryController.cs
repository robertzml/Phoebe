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
    /// 类别控制器
    /// </summary>
    public class CategoryController : Controller
    {
        #region Field
        /// <summary>
        /// 类别业务
        /// </summary>
        private CategoryBusiness categoryBusiness;
        #endregion //Field

        #region Constructor
        public CategoryController()
        {
            this.categoryBusiness = new CategoryBusiness();
        }
        #endregion ///Constructor

        #region Action
        /// <summary>
        /// 类别主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var data = this.categoryBusiness.GetFirstCategory();
            return View(data);
        }
        #endregion //Action
    }
}