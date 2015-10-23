﻿using System;
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
    /// 库存控制器
    /// </summary>
    public class StockController : Controller
    {
        #region Field
        /// <summary>
        /// 仓储业务
        /// </summary>
        private StoreBusiness storeBusiness;
        #endregion //Field

        #region Constructor
        public StockController()
        {
            this.storeBusiness = new StoreBusiness();
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 库存历史
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var data = this.storeBusiness.GetStock();
            return View(data);
        }

        /// <summary>
        /// 库存信息
        /// </summary>
        /// <param name="id">库存ID</param>
        /// <returns></returns>
        public ActionResult Details(string id)
        {
            var data = this.storeBusiness.GetStock(id);
            if (data == null)
                return HttpNotFound();

            TransferBusiness transferBusiness = new TransferBusiness();

            ViewBag.StockIn = this.storeBusiness.GetStockInByStore(id);
            ViewBag.StockOut = this.storeBusiness.GetStockOutByStore(id);
            ViewBag.StockMove = this.storeBusiness.GetStockMoveByStore(id);
            ViewBag.Transfer = transferBusiness.GetByStore(id);

            return View(data);
        }

        /// <summary>
        /// 库存信息
        /// </summary>
        /// <param name="id">库存ID</param>
        /// <returns></returns>
        public ActionResult DetailsModal(string id)
        {
            var data = this.storeBusiness.GetStock(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 库位存储列表
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            var data = this.storeBusiness.GetStorage();
            return View(data);
        }

        /// <summary>
        /// 库存快照
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Snapshoot()
        {
            return View();
        }

        /// <summary>
        /// 库存快照
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult SnapshootProcess(StoreSnapshootInput model)
        {
            if (ModelState.IsValid)
            {
                var data = this.storeBusiness.GetInDay(model.ContractID, model.Date);
                return View(data);
            }
            else
            {
                return View("Snapshoot", model);
            }
        }
        #endregion //Action

        #region Json
        /// <summary>
        /// 根据货品获取库存
        /// </summary>
        /// <param name="cargoID">货品ID</param>
        /// <remarks>
        /// 调用：
        /// /StockOut/Create
        /// /Transfer/Create
        /// </remarks>
        /// <returns></returns>
        public JsonResult GetWithCargo(string cargoID)
        {
            var stock = this.storeBusiness.GetWithCargo(cargoID);
            var data = from r in stock
                       orderby r.Warehouse.Number
                       select new { r.WarehouseID, r.Warehouse.Number, r.Count };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion //Json
    }
}