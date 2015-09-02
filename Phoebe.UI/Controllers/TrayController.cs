using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phoebe.Business;
using Phoebe.Common;
using Phoebe.Model;

namespace Phoebe.UI.Controllers
{
    /// <summary>
    /// 托盘控制器
    /// </summary>
    public class TrayController : Controller
    {
        #region Field
        /// <summary>
        /// 货品业务
        /// </summary>
        private TrayBusiness trayBusiness;
        #endregion //Field

        #region Constructor
        public TrayController()
        {
            this.trayBusiness = new TrayBusiness();
        }
        #endregion ///Constructor

        #region Action
        /// <summary>
        /// 托盘主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var data = this.trayBusiness.Get();
            return View(data);
        }

        /// <summary>
        /// 托盘信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var data = this.trayBusiness.Get(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 废弃托盘列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ListByAbandon()
        {
            var data = this.trayBusiness.Get(EntityStatus.TrayAbandon);
            return View(data);
        }

        /// <summary>
        /// 添加托盘
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 添加托盘
        /// </summary>
        /// <param name="model">托盘对象</param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Tray model)
        {
            if (ModelState.IsValid)
            {
                int count = 1;
                if (string.IsNullOrEmpty(Request.Form["count"]))
                    count = 1;
                else
                    count = Convert.ToInt32(Request.Form["count"]);

                ErrorCode result = this.trayBusiness.Create(model, count);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "添加托盘成功";
                    return RedirectToAction("Index", new { controller = "Tray" });
                }
                else
                {
                    TempData["Message"] = "添加托盘失败";
                    ModelState.AddModelError("", "添加托盘失败: " + result.DisplayName());
                }
            }

            return View(model);
        }

        /// <summary>
        /// 废弃托盘
        /// </summary>
        /// <param name="id">托盘ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Abandon(int id)
        {
            var data = this.trayBusiness.Get(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 废弃托盘
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Abandon(Tray model)
        {
            ErrorCode result = this.trayBusiness.Abandon(model.ID);
            if (result == ErrorCode.Success)
            {
                TempData["Message"] = "废弃托盘成功";
                return RedirectToAction("Details", new { controller = "Tray", id = model.ID });
            }
            else
            {
                TempData["Message"] = "废弃托盘失败" + result.DisplayName();
                return RedirectToAction("Abandon", model.ID);
            }
        }
        #endregion //Action

        #region Json
        /// <summary>
        /// 获取仓库内托盘
        /// </summary>
        /// <param name="warehouseID">仓库ID</param>
        /// <returns></returns>
        /// <remarks>
        /// 调用：
        /// /StockOut/Create
        /// /StockMove/Create
        /// </remarks>
        public JsonResult GetInWarehouse(int warehouseID)
        {
            var trays = this.trayBusiness.GetInWarehouse(warehouseID);
            var data = from r in trays
                       select new { r.ID, Name = r.ID.ToString().PadLeft(6, '0'), r.Status };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion //Json
    }
}