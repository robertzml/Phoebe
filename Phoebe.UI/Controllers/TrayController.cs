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
                ErrorCode result = this.trayBusiness.Create(model);
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
        #endregion //Action
    }
}