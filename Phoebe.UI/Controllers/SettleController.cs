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
    /// 结算控制器
    /// </summary>
    public class SettleController : Controller
    {
        #region Field
        /// <summary>
        /// 结算业务
        /// </summary>
        private SettleBusiness settleBusiness;
        #endregion //Field

        #region Constructor
        public SettleController()
        {
            this.settleBusiness = new SettleBusiness();
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 待结算货品列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            CargoBusiness cargoBusiness = new CargoBusiness();
            var data = cargoBusiness.Get(EntityStatus.CargoStockOut);
            return View(data);
        }

        /// <summary>
        /// 货品结算
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string id)
        {
            CargoBusiness cargoBusiness = new CargoBusiness();
            var cargo = cargoBusiness.Get(id);
            if (cargo == null)
                return HttpNotFound();

            ViewBag.Cargo = cargo;

            Settlement data = new Settlement();
            data.CargoID = cargo.ID;
            data.Discount = 100;

            return View(data);
        }

        /// <summary>
        /// 货品结算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Settlement model)
        {
            CargoBusiness cargoBusiness = new CargoBusiness();
            var cargo = cargoBusiness.Get(model.CargoID.ToString());
            ViewBag.Cargo = cargo;

            if (ModelState.IsValid)
            {
                var user = PageService.GetCurrentUser(User.Identity.Name);
                model.UserID = user.ID;

                ErrorCode result = this.settleBusiness.Create(model);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "货品结算成功";
                    return RedirectToAction("Audit", new { controller = "Settle" });
                }
                else
                {
                    TempData["Message"] = "货品结算失败";
                    ModelState.AddModelError("", "货品结算失败: " + result.DisplayName());
                }
            }

            return View(model);
        }

        /// <summary>
        /// 付款审核
        /// </summary>
        /// <returns></returns>
        public ActionResult Audit()
        {
            var data = this.settleBusiness.Get(EntityStatus.SettleUnpaid);
            return View(data);
        }

        /// <summary>
        /// 付款确认
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Confirm(string id)
        {
            var data = this.settleBusiness.Get(id);

            if (data == null || data.Status != (int)EntityStatus.SettleUnpaid)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 付款确认
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Confirm(Settlement model)
        {
            if (ModelState.IsValid)
            {
                string id = Request.Form["ID"];
                string remark = Request.Form["Remark"];
                decimal paid = Convert.ToDecimal(Request.Form["PaidPrice"]);

                ErrorCode result = this.settleBusiness.Audit(id, paid, remark);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "付款审核完毕";
                    return RedirectToAction("Audit", "Settle");
                }
                else
                {
                    TempData["Message"] = "付款审核失败";
                    ModelState.AddModelError("", "付款审核失败: " + result.DisplayName());
                }
            }

            return View(model);
        }
        #endregion //Action
    }
}