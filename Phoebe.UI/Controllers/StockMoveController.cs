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
    /// 移库控制器
    /// </summary>
    [EnhancedAuthorize]
    public class StockMoveController : Controller
    {
        #region Field
        /// <summary>
        /// 仓储业务
        /// </summary>
        private StoreBusiness storeBusiness;
        #endregion //Field

        #region Constructor
        public StockMoveController()
        {
            this.storeBusiness = new StoreBusiness();
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 移库记录
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var data = this.storeBusiness.GetStockMove();
            return View(data);
        }

        /// <summary>
        /// 移库信息
        /// </summary>
        /// <param name="id">移库ID</param>
        /// <returns></returns>
        public ActionResult Details(string id)
        {
            var data = this.storeBusiness.GetStockMove(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 货品移库
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 货品移库
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(StockMove model)
        {
            if (ModelState.IsValid)
            {
                var user = PageService.GetCurrentUser(User.Identity.Name);
                model.UserID = user.ID;

                string swId = Request.Form["SourceWarehouseID"];
                string dwId = Request.Form["DestinationWarehouseID"];
                if (string.IsNullOrEmpty(swId) || string.IsNullOrEmpty(dwId))
                {
                    TempData["Message"] = "货品移库失败";
                    ModelState.AddModelError("", "货品移库失败: 请选择库位。");

                    return View(model);
                }

                // ready to add multiple stock moves
                List<StockMoveDetail> details = new List<StockMoveDetail>();
                                
                StockMoveDetail detail = new StockMoveDetail();
                detail.SourceWarehouseID = Convert.ToInt32(swId);
                detail.DestinationWarehouseID = Convert.ToInt32(dwId);

                details.Add(detail);

                ErrorCode result = this.storeBusiness.StockMove(model, details);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "货品移库成功";
                    return RedirectToAction("Audit", new { controller = "StockMove" });
                }
                else
                {
                    TempData["Message"] = "货品移库失败";
                    ModelState.AddModelError("", "货品移库失败: " + result.DisplayName());
                }
            }

            return View(model);
        }

        /// <summary>
        /// 移库审核
        /// </summary>
        /// <returns></returns>
        public ActionResult Audit()
        {
            var data = this.storeBusiness.GetStockMoveByStatus(EntityStatus.StockMoveReady);
            return View(data);
        }

        /// <summary>
        /// 移库确认
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Confirm(string id)
        {
            var data = this.storeBusiness.GetStockMove(id);

            if (data == null || data.Status != (int)EntityStatus.StockMoveReady)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 移库确认
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Confirm(StockMove model)
        {
            if (ModelState.IsValid)
            {
                if (model.ConfirmTime == null)
                {
                    TempData["Message"] = "移库审核失败，请选择确认时间";
                    return RedirectToAction("Confirm", new { controller = "StockMove", id = model.ID.ToString() });
                }


                string id = Request.Form["ID"];
                string remark = Request.Form["Remark"];
                EntityStatus status = Request.Form["auditResult"] == "1" ? EntityStatus.StockMove : EntityStatus.StockMoveCancel;

                ErrorCode result = this.storeBusiness.StockMoveAudit(id, model.ConfirmTime.Value, remark, status);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "移库审核完毕";
                    return RedirectToAction("Audit", "StockMove");
                }
                else
                {
                    TempData["Message"] = "移库审核失败";
                    ModelState.AddModelError("", "移库审核失败: " + result.DisplayName());
                }
            }

            return View(model);
        }
        #endregion //Action
    }
}