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
            var data = cargoBusiness.Get(id);
            if (data == null)
                return HttpNotFound();

            ViewBag.Cargo = data;
            return View();
        }
        #endregion //Action
    }
}