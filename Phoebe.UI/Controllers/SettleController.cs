using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phoebe.Business;
using Phoebe.Common;
using Phoebe.Model;
using Phoebe.UI.Filters;
using Phoebe.UI.Models;
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
        /// 基本费用结算
        /// </summary>
        /// <returns></returns>
        public ActionResult Base()
        {
            CargoBusiness cargoBusiness = new CargoBusiness();
            var data = cargoBusiness.GetByBilling(EntityStatus.BillingUnsettle);

            return View(data);
        }

        /// <summary>
        /// 基本费用结算
        /// </summary>
        /// <param name="id">货品ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult BaseProcess(string id)
        {
            CargoBusiness cargoBusiness = new CargoBusiness();
            var cargo = cargoBusiness.Get(id);
            ViewBag.Cargo = cargo;

            BillingBusiness billingBusiness = new BillingBusiness();
        
            BaseSettlement data = new BaseSettlement();
            data.CargoID = cargo.ID;
            data.SumPrice = billingBusiness.GetTotalPrice(id);
            data.Discount = 100;
            data.SettleTime = DateTime.Now;
            data.TotalPrice = data.SumPrice;

            return View(data);
        }

        /// <summary>
        /// 基本费用结算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult BaseProcess(BaseSettlement model)
        {
            CargoBusiness cargoBusiness = new CargoBusiness();
            var cargo = cargoBusiness.Get(model.CargoID.ToString());
            ViewBag.Cargo = cargo;

            if (ModelState.IsValid)
            {
                var user = PageService.GetCurrentUser(User.Identity.Name);
                model.UserID = user.ID;

                ErrorCode result = this.settleBusiness.CreateBase(model);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "基本费用结算成功";
                    return RedirectToAction("Base", new { controller = "Settle" });
                }
                else
                {
                    TempData["Message"] = "基本费用结算失败";
                    ModelState.AddModelError("", "基本费用结算失败: " + result.DisplayName());
                }
            }

            return View(model);
        }

        /// <summary>
        /// 冷藏费计算
        /// </summary>
        /// <returns></returns>
        public ActionResult ColdPrice()
        {
            return View();
        }

        /// <summary>
        /// 冷藏费计算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ColdPriceProcess(ColdPrice model)
        {
            if (ModelState.IsValid)
            {
                BillingBusiness billingBusiness = new BillingBusiness();
                var total = billingBusiness.GetColdPrice(model.CargoID, model.DateFrom, model.DateTo);

                ViewBag.TotalFee = total;

                return View();
            }
            else
            {
                return View("ColdPrice", model);
            }
        }



        /// <summary>
        /// 冷藏费计算
        /// </summary>
        /// <returns></returns>
        public ActionResult ColdCost()
        {
            return View();
        }

        /// <summary>
        /// 冷藏费计算
        /// </summary>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Process(ColdCost model)
        {
            if (ModelState.IsValid)
            {
                var data = this.settleBusiness.Process(model.ContractID, model.DateFrom, model.DateTo, model.DailyFee);

                return View(data);
            }
            else
            {
                return View("ColdCost", model);
            }
        }
        #endregion //Action
    }
}