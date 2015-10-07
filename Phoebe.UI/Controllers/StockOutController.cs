using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
    /// 货品出库控制器
    /// </summary>
    [EnhancedAuthorize]
    public class StockOutController : Controller
    {
        #region Field
        /// <summary>
        /// 仓储业务
        /// </summary>
        private StoreBusiness storeBusiness;
        #endregion //Field

        #region Constructor
        public StockOutController()
        {
            this.storeBusiness = new StoreBusiness();
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 出库记录
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var data = this.storeBusiness.GetStockOut();
            return View(data);
        }

        /// <summary>
        /// 出库信息
        /// </summary>
        /// <param name="id">出库ID</param>
        /// <returns></returns>
        public ActionResult Details(string id)
        {
            var data = this.storeBusiness.GetStockOut(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 货品出库
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 货品出库
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(StockOut model)
        {
            if (ModelState.IsValid)
            {
                var user = PageService.GetCurrentUser(User.Identity.Name);
                model.UserID = user.ID;

                string[] warehouses = Regex.Split(Request.Form["warehouseID[]"], ",");
                string[] counts = Regex.Split(Request.Form["count[]"], ",");

                List<StockOutDetail> details = new List<StockOutDetail>();
                for (int i = 0; i < warehouses.Length; i++)
                {
                    bool flag = true;
                    int warehouseId = Convert.ToInt32(warehouses[i]);

                    int count;
                    if (!Int32.TryParse(counts[i], out count))
                    {
                        flag = false;
                    }
                    else
                    {
                        if (count < 0)
                            flag = false;
                        else if (count == 0)
                            continue;
                    }

                    if (!flag)
                    {
                        TempData["Message"] = "货品出库失败";
                        ModelState.AddModelError("", "货品出库失败: 输入数据格式有误。");

                        return View(model);
                    }

                    StockOutDetail detail = new StockOutDetail();
                    detail.WarehouseID = warehouseId;
                    detail.Count = count;

                    details.Add(detail);
                }

                ErrorCode result = this.storeBusiness.StockOut(model, details);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "货品出库成功";
                    return RedirectToAction("Audit", new { controller = "StockOut" });
                }
                else
                {
                    TempData["Message"] = "货品出库失败";
                    ModelState.AddModelError("", "货品出库失败: " + result.DisplayName());
                }
            }

            return View(model);
        }

        /// <summary>
        /// 出库审核
        /// </summary>
        /// <returns></returns>
        public ActionResult Audit()
        {
            var data = this.storeBusiness.GetStockOutByStatus(EntityStatus.StockOutReady);
            return View(data);
        }

        /// <summary>
        /// 出库确认
        /// </summary>
        /// <param name="id">出库ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Confirm(string id)
        {
            var data = this.storeBusiness.GetStockOut(id);
            if (data == null || data.Status != (int)EntityStatus.StockOutReady)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 出库确认
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Confirm(StockOut model)
        {
            if (ModelState.IsValid)
            {
                if (model.ConfirmTime == null)
                {
                    TempData["Message"] = "出库审核失败，请输入选择确认时间";
                    return RedirectToAction("Confirm", new { controller = "StockOut", id = model.ID.ToString() });
                }

                string id = Request.Form["ID"];
                string remark = Request.Form["Remark"];
                EntityStatus status = Request.Form["auditResult"] == "1" ? EntityStatus.StockOut : EntityStatus.StockOutCancel;

                ErrorCode result = this.storeBusiness.StockOutAudit(id, model.ConfirmTime.Value, remark, status);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "出库审核完毕";
                    return RedirectToAction("Audit", "StockOut");
                }
                else
                {
                    TempData["Message"] = "出库审核失败";
                    ModelState.AddModelError("", "出库审核失败: " + result.DisplayName());
                }
            }

            return View(model);
        }
        #endregion //Action
    }
}