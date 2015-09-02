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
            var data = this.cargoBusiness.Get(EntityStatus.CargoStockIn);
            return View(data);
        }

        /// <summary>
        /// 未入库货品
        /// </summary>
        /// <returns></returns>
        public ActionResult ListByNotIn()
        {
            var data1 = this.cargoBusiness.Get(EntityStatus.CargoNotIn);
            var data2 = this.cargoBusiness.Get(EntityStatus.CargoStockInReady);
            var data = data1.Union(data2);
          
            return View(data);
        }

        /// <summary>
        /// 已出库货品
        /// </summary>
        /// <returns></returns>
        public ActionResult ListByOut()
        {
            var data = this.cargoBusiness.Get(EntityStatus.CargoStockOut);
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
        /// 货品信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public ActionResult DetailsModal(string id)
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

        #region JSON
        /// <summary>
        /// 获取二级分类
        /// </summary>
        /// <param name="firstId">一级分类ID</param>
        /// <returns></returns>
        public JsonResult GetSecondCategory(int firstId)
        {
            CategoryBusiness categoryBusiness = new CategoryBusiness();
            var category = categoryBusiness.GetSecondCategoryByFirst(firstId);

            var data = from r in category
                       select new { r.ID, r.Name };

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 获取货品
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="contractID">所属合同</param>
        /// <returns></returns>
        public JsonResult GetCargos(int type, int contractID)
        {
            if (type == 1)  // not stock in
            {
                var cargos = this.cargoBusiness.Get(EntityStatus.CargoNotIn).Where(r => r.ContractID == contractID);

                var data = from r in cargos
                           select new { r.ID, r.Name, FirstCategoryName = r.FirstCategory.Name };

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取当前托盘货品
        /// </summary>
        /// <param name="trayID">托盘ID</param>
        /// <returns></returns>
        /// <remarks>
        /// 调用：
        /// /StoreOut/Create
        /// </remarks>
        public JsonResult GetCargoInTray(int trayID)
        {
            var cargos = this.cargoBusiness.GetInTray(trayID);
            var data = from r in cargos
                       select new { r.ID, r.Name, FirstCategoryName = r.FirstCategory.Name };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion //JSON
    }
}