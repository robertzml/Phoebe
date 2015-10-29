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
    [EnhancedAuthorize]
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
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 合同冷藏费表单
        /// </summary>
        /// <returns></returns>
        public ActionResult ContractCold()
        {
            return View();
        }

        /// <summary>
        /// 合同冷藏费表单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ContractColdResult(ContractColdInput model)
        {
            if (ModelState.IsValid)
            {
                var records = this.settleBusiness.ProcessDailyCold(model.ContractID, model.DateFrom, model.DateTo);
                return View(records);
            }
            else
            {
                return View("ContractCold", model);
            }
        }

        /// <summary>
        /// 货品冷藏费表单
        /// </summary>
        /// <returns></returns>
        public ActionResult CargoCold()
        {
            return View();
        }

        /// <summary>
        /// 货品冷藏费表单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CargoColdResult(CargoColdInput model)
        {
            if (ModelState.IsValid)
            {
                var records = this.settleBusiness.ProcessDailyCold(model.CargoID, model.DateFrom, model.DateTo);
                return View(records);
            }
            else
            {
                return View("ColdPrice", model);
            }
        }
        #endregion //Action
    }
}