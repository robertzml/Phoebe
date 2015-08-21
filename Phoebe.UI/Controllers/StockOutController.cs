using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phoebe.Business;
using Phoebe.Common;
using Phoebe.Model;
using Phoebe.UI.Filters;
using Phoebe.UI.Services;

namespace Phoebe.UI.Controllers
{
    /// <summary>
    /// 货品出库控制器
    /// </summary>
    [EnhancedAuthorize]
    public class StockOutController : Controller
    {
        #region Field
        /// <summary>
        /// 仓储业务
        /// </summary>
        private StoreBusiness storeBusiness;
        #endregion //Field

        #region Constructor
        public StockOutController()
        {
            this.storeBusiness = new StoreBusiness();
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 货品出库
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        #endregion //Action
    }
}