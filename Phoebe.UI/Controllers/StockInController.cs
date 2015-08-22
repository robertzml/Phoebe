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
        /// <summary>
        /// 入库记录
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var data = this.storeBusiness.GetStockIn();
            return View(data);
        }

        /// <summary>
        /// 入库信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public ActionResult Details(string id)
        {
            var data = this.storeBusiness.GetStockIn(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
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

        /// <summary>
        /// 入库审核
        /// </summary>
        /// <returns></returns>
        public ActionResult Audit()
        {
            var data = this.storeBusiness.GetStockInByStatus(EntityStatus.StockInReady);
            return View(data);
        }

        /// <summary>
        /// 入库确认
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Confirm(string id)
        {
            var data = this.storeBusiness.GetStockIn(id);

            if (data == null || data.Status != (int)EntityStatus.StockInReady)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 入库确认
        /// </summary>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Confirm()
        {
            string id = Request.Form["ID"];
            string remark = Request.Form["Remark"];
            EntityStatus status = Request.Form["auditResult"] == "1" ? EntityStatus.StockIn : EntityStatus.StockInCancel;

            this.storeBusiness.StockInAudit(id, remark, status);

            TempData["Message"] = "入库审核完毕";
            return RedirectToAction("Audit", "StockIn");
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