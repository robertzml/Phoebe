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
    /// 入库控制器
    /// </summary>
    [EnhancedAuthorize]
    public class StockInController : Controller
    {
        #region Field
        /// <summary>
        /// 仓储业务
        /// </summary>
        private StoreBusiness storeBusiness;
        #endregion //Field

        #region Constructor
        public StockInController()
        {
            this.storeBusiness = new StoreBusiness();
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 入库记录
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var data = this.storeBusiness.GetStockIn();
            return View(data);
        }

        /// <summary>
        /// 入库信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public ActionResult Details(string id)
        {
            var data = this.storeBusiness.GetStockIn(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 货品入库
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 货品入库
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(StockIn model)
        {
            if (ModelState.IsValid)
            {
                var user = PageService.GetCurrentUser(User.Identity.Name);
                model.UserID = user.ID;

                string[] warehouses = Regex.Split(Request.Form["warehouse[]"], ",");
                string[] counts = Regex.Split(Request.Form["count[]"], ",");

                List<StockInDetail> details = new List<StockInDetail>();
                for (int i = 0; i < warehouses.Length; i++)
                {
                    bool flag = true;
                    int warehouseId, count;
                    if (!Int32.TryParse(warehouses[i], out warehouseId))
                        flag = false;

                    if (!Int32.TryParse(counts[i], out count))
                    {
                        flag = false;
                    }
                    else
                    {
                        if (count <= 0)
                            flag = false;
                    }

                    if (!flag)
                    {
                        TempData["Message"] = "货品入库失败";
                        ModelState.AddModelError("", "货品入库失败: 输入数据格式有误。");

                        return View(model);
                    }

                    StockInDetail detail = new StockInDetail();
                    detail.WarehouseID = warehouseId;
                    detail.Count = count;

                    if (details.Any(r => r.WarehouseID == warehouseId))
                    {
                        TempData["Message"] = "货品入库失败";
                        ModelState.AddModelError("", "货品入库失败: 仓库选择重复。");
                        return View(model);
                    }

                    details.Add(detail);
                }

                CargoBusiness cargoBusiness = new CargoBusiness();
                var cargo = cargoBusiness.Get(model.CargoID.ToString());
                if (details.Sum(r => r.Count) != cargo.Count)
                {
                    TempData["Message"] = "货品入库失败";
                    ModelState.AddModelError("", "货品入库失败: 入库数量与总数不等。");
                    return View(model);
                }

                ErrorCode result = this.storeBusiness.StockIn(model, details);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "货品入库成功";
                    return RedirectToAction("Audit", new { controller = "StockIn" });
                }
                else
                {
                    TempData["Message"] = "货品入库失败";
                    ModelState.AddModelError("", "货品入库失败: " + result.DisplayName());
                }

            }

            return View(model);
        }

        /// <summary>
        /// 入库审核
        /// </summary>
        /// <returns></returns>
        public ActionResult Audit()
        {
            var data = this.storeBusiness.GetStockInByStatus(EntityStatus.StockInReady);
            return View(data);
        }

        /// <summary>
        /// 入库确认
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Confirm(string id)
        {
            var data = this.storeBusiness.GetStockIn(id);

            if (data == null || data.Status != (int)EntityStatus.StockInReady)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 入库确认
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Confirm(StockIn model)
        {
            if (ModelState.IsValid)
            {
                if (model.ConfirmTime == null)
                {
                    TempData["Message"] = "入库审核失败，请输入选择确认时间";
                    return RedirectToAction("Confirm", new { controller = "StockIn", id = model.ID.ToString() });
                }

                string id = Request.Form["ID"];
                string remark = Request.Form["Remark"];
                EntityStatus status = Request.Form["auditResult"] == "1" ? EntityStatus.StockIn : EntityStatus.StockInCancel;

                ErrorCode result = this.storeBusiness.StockInAudit(id, model.ConfirmTime.Value, remark, status);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "入库审核完毕";
                    return RedirectToAction("Audit", "StockIn");
                }
                else
                {
                    TempData["Message"] = "入库审核失败";
                    ModelState.AddModelError("", "入库审核失败: " + result.DisplayName());
                }
            }

            return View(model);
        }
        #endregion //Action

        #region Json

        #endregion //Json
    }
}