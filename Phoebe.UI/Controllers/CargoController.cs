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
    /// 货品控制器
    /// </summary>
    [EnhancedAuthorize]
    public class CargoController : Controller
    {
        #region Field
        /// <summary>
        /// 货品业务
        /// </summary>
        private CargoBusiness cargoBusiness;
        #endregion //Field

        #region Constructor
        public CargoController()
        {
            this.cargoBusiness = new CargoBusiness();
        }
        #endregion ///Constructor

        #region Action
        /// <summary>
        /// 货品主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 未入库货品
        /// </summary>
        /// <returns></returns>
        public ActionResult ListByNotIn()
        {
            var data = this.cargoBusiness.Get(EntityStatus.CargoNotIn);
            return View(data);
        }

        /// <summary>
        /// 货品信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public ActionResult Details(string id)
        {
            var data = this.cargoBusiness.Get(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 货品登记
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 货品登记
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Cargo model)
        {
            if (ModelState.IsValid)
            {
                var user = PageService.GetCurrentUser(User.Identity.Name);

                model.UserID = user.ID;

                ErrorCode result = this.cargoBusiness.Create(model);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "货品登记成功";
                    return RedirectToAction("Details", new { controller = "Cargo", id = model.ID });
                }
                else
                {
                    TempData["Message"] = "货品登记失败";
                    ModelState.AddModelError("", "货品登记失败: " + result.DisplayName());
                }

            }

            return View(model);
        }
        #endregion //Action
    }
}