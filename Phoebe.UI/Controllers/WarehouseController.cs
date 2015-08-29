using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phoebe.Business;
using Phoebe.Common;
using Phoebe.Model;
using Phoebe.UI.Filters;

namespace Phoebe.UI.Controllers
{
    /// <summary>
    /// 仓库控制器
    /// </summary>    
    [EnhancedAuthorize]
    public class WarehouseController : Controller
    {
        #region Field
        /// <summary>
        /// 仓库业务
        /// </summary>
        private WarehouseBusiness warehouseBusiness;
        #endregion //Field

        #region Constructor
        public WarehouseController()
        {
            this.warehouseBusiness = new WarehouseBusiness();
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 仓库主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var data = this.warehouseBusiness.Get();
            return View(data);
        }

        /// <summary>
        /// 仓库信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public ActionResult Info(int id)
        {
            var data = this.warehouseBusiness.Get(id);
            return View(data);
        }

        /// <summary>
        /// 仓库库存
        /// </summary>
        /// <returns></returns>
        public ActionResult Store()
        {
            var data = this.warehouseBusiness.GetTop();
            return View(data);
        }

        /// <summary>
        /// 仓库库存
        /// </summary>
        /// <param name="warehouseID">仓库ID</param>
        /// <returns></returns>
        public ActionResult StoreInWarehouse(int warehouseID)
        {
            StoreBusiness storeBusiness = new StoreBusiness();
            var data = storeBusiness.GetInWarehouse(warehouseID);
            return View(data);
        }

        /// <summary>
        /// 添加仓库
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 添加仓库
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Warehouse model)
        {
            if (ModelState.IsValid)
            {
                if (model.ParentId == 0)
                    model.Hierarchy = 1;
                else
                {
                    var parent = this.warehouseBusiness.Get((int)model.ParentId);
                    model.Hierarchy = parent.Hierarchy + 1;
                }

                ErrorCode result = this.warehouseBusiness.Create(model);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "添加仓库成功";
                    return RedirectToAction("Index", "Warehouse");
                }
                else
                {
                    TempData["Message"] = "添加仓库失败";
                    ModelState.AddModelError("", "添加仓库失败: " + result.DisplayName());
                }
            }

            return View(model);
        }

        /// <summary>
        /// 编辑仓库
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = this.warehouseBusiness.Get(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 编辑仓库
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(Warehouse model)
        {
            if (ModelState.IsValid)
            {
                var data = this.warehouseBusiness.Get(model.ID);

                if (model.ParentId == 0)
                    data.Hierarchy = 1;
                else
                {
                    var parent = this.warehouseBusiness.Get((int)model.ParentId);
                    data.Hierarchy = parent.Hierarchy + 1;
                }

                data.Remark = model.Remark;
                ErrorCode result = this.warehouseBusiness.Save();

                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "编辑仓库成功";
                    return RedirectToAction("Index", "Warehouse");
                }
                else
                {
                    TempData["Message"] = "编辑仓库失败";
                    ModelState.AddModelError("", "编辑仓库失败: " + result.DisplayName());
                }
            }

            return View(model);
        }
        #endregion //Action

        #region Json
        /// <summary>
        /// 获取仓库列表
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 调用:
        /// 
        /// </remarks>
        public JsonResult GetWarehouseList()
        {
            var warehouses = this.warehouseBusiness.Get();
            var data = from r in warehouses
                       select new { r.ID, r.Name, r.Hierarchy, r.ParentId };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion //Json
    }
}