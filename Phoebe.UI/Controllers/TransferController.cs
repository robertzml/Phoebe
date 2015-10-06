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
    /// 转户控制器
    /// </summary>
    [EnhancedAuthorize]
    public class TransferController : Controller
    {
        #region Field
        /// <summary>
        /// 转户业务
        /// </summary>
        private TransferBusiness transferBusiness;
        #endregion //Field

        #region Constructor
        public TransferController()
        {
            this.transferBusiness = new TransferBusiness();
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 货品转户
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }
        #endregion //Action
    }
}