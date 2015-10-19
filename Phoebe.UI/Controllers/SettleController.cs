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
                IBillingProcess billingProcess = new BillingUnitWeight();
                var total = billingProcess.CalculateColdPrice(model.CargoID, model.DateFrom, model.DateTo);

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