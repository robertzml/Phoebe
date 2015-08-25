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
    [EnhancedAuthorize]
    public class StockMoveController : Controller
    {
        #region Field
        /// <summary>
        /// 仓储业务
        /// </summary>
        private StoreBusiness storeBusiness;
        #endregion //Field

        #region Constructor
        public StockMoveController()
        {
            this.storeBusiness = new StoreBusiness();
        }
        #endregion //Constructor

        // GET: StockMove
        public ActionResult Index()
        {
            return View();
        }
    }
}