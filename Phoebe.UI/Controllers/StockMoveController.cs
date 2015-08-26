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
    /// 移库控制器
    /// </summary>
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

        #region Action
        /// <summary>
        /// 货品移库
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 货品移库
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(StockMove model)
        {
            if (ModelState.IsValid)
            {
                var user = PageService.GetCurrentUser(User.Identity.Name);
                model.UserID = user.ID;

                ErrorCode result = this.storeBusiness.StockMove(model);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "货品移库成功";
                    return RedirectToAction("Audit", new { controller = "StockMove" });
                }
                else
                {
                    TempData["Message"] = "货品移库失败";
                    ModelState.AddModelError("", "货品移库失败: " + result.DisplayName());
                }
            }

            return View(model);
        }

        /// <summary>
        /// 移库审核
        /// </summary>
        /// <returns></returns>
        public ActionResult Audit()
        {
            var data = this.storeBusiness.GetStockMoveByStatus(EntityStatus.StockMoveReady);
            return View(data);
        }
        #endregion //Action
    }
}