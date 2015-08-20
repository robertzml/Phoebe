using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
    /// 入库控制器
    /// </summary>
    [EnhancedAuthorize]
    public class StockInController : Controller
    {
        #region Field
        /// <summary>
        /// 仓储业务
        /// </summary>
        private StoreBusiness storeBusiness;
        #endregion //Field

        #region Constructor
        public StockInController()
        {
            this.storeBusiness = new StoreBusiness();
        }
        #endregion //Constructor

        #region Action
        // GET: StockIn
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 货品入库
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 货品入库
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(StockIn model)
        {
            if (ModelState.IsValid)
            {
                var user = PageService.GetCurrentUser(User.Identity.Name);
                model.UserID = user.ID;

                string[] cargos = Regex.Split(Request.Form["CargoList[]"], ",");
                if (cargos.Length == 0)
                {
                    TempData["Message"] = "货品入库失败";
                    ModelState.AddModelError("", "货品入库失败: 未选择货品");
                    return View(model);
                }

                ErrorCode result = this.storeBusiness.StockIn(model, cargos);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "货品入库成功";
                    return RedirectToAction("Index", new { controller = "Cargo" });
                }
                else
                {
                    TempData["Message"] = "货品入库失败";
                    ModelState.AddModelError("", "货品入库失败: " + result.DisplayName());
                }

            }

            return View(model);
        }
        #endregion //Action

        #region Json
        /// <summary>
        /// 获取相关合同
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public JsonResult GetContracts(int type)
        {
            CargoBusiness cargoBusiness = new CargoBusiness();

            if (type == 0)
            {
                var contracts = cargoBusiness.GetWithUnStockIn();
                var data = from r in contracts
                           select new { r.ID, r.Name, r.Number };

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }
        #endregion //Json
    }
}