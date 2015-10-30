using System;
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
    /// 结算控制器
    /// </summary>
    [EnhancedAuthorize]
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
        /// 费用结算
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 结算记录
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            var data = this.settleBusiness.Get();
            return View(data);
        }

        /// <summary>
        /// 结算信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public ActionResult Details(string id)
        {
            var data = this.settleBusiness.Get(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 处理结算信息
        /// </summary>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ProcessInfo(SettleInput model)
        {
            if (ModelState.IsValid)
            {
                SettleProcess process = new SettleProcess();
                process.Billings = this.settleBusiness.BaseProcess(model.CustomerType, model.CustomerID, model.DateFrom, model.DateTo);
                process.ColdSettles = this.settleBusiness.ColdProcess(model.CustomerType, model.CustomerID, model.DateFrom, model.DateTo);

                ViewBag.SettleProcess = process;
                TempData["SettleProcess"] = process;

                Settlement data = new Settlement();
                data.CustomerType = model.CustomerType;
                data.CustomerID = model.CustomerID;
                data.StartTime = model.DateFrom.Date;
                data.EndTime = model.DateTo.Date;
                data.Discount = 100;
                data.SumPrice = process.Billings.Sum(r => r.TotalPrice) + process.ColdSettles.Sum(r => r.ColdPrice);
                data.TotalPrice = data.SumPrice;
                data.SettleTime = DateTime.Now.Date;

                return View(data);
            }
            else
            {
                return View("Index", model);
            }
        }

        /// <summary>
        /// 添加结算
        /// </summary>
        /// <param name="model">结算模型</param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Settlement model)
        {
            if (ModelState.IsValid)
            {
                SettleProcess process = TempData["SettleProcess"] as SettleProcess;
                if (process == null)
                {
                    TempData["Message"] = "数据过期";
                    return RedirectToAction("Index");
                }

                var user = PageService.GetCurrentUser(User.Identity.Name);
                model.UserID = user.ID;

                List<SettlementDetail> details = new List<SettlementDetail>();

                foreach (var item in process.Billings)
                {
                    SettlementDetail detail = new SettlementDetail();
                    detail.ID = Guid.NewGuid();
                    detail.CargoID = item.CargoID;
                    detail.ExpenseType = (int)ExpenseType.Base;
                    detail.SumPrice = item.TotalPrice;

                    details.Add(detail);
                }

                foreach (var item in process.ColdSettles)
                {
                    SettlementDetail detail = new SettlementDetail();
                    detail.ID = Guid.NewGuid();
                    detail.ContractID = item.ContractID;
                    detail.ExpenseType = (int)ExpenseType.Cold;
                    detail.SumPrice = item.ColdPrice;

                    details.Add(detail);
                }

                ErrorCode result = this.settleBusiness.Create(model, details);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "结算成功";
                    return RedirectToAction("List");
                }
                else
                {
                    TempData["Message"] = "结算失败";
                    ModelState.AddModelError("", "结算失败: " + result.DisplayName());
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        /// <summary>
        /// 结算审核
        /// </summary>
        /// <returns></returns>
        public ActionResult Audit()
        {
            var data = this.settleBusiness.GetByStatus(EntityStatus.SettleUnpaid);
            return View(data);
        }

        /// <summary>
        /// 结算确认
        /// </summary>
        /// <param name="id">结算ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Confirm(string id)
        {
            var data = this.settleBusiness.Get(id);

            if (data == null || data.Status != (int)EntityStatus.SettleUnpaid)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 结算确认
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Confirm(Settlement model)
        {
            if (ModelState.IsValid)
            {
                if (model.ConfirmTime == null)
                {
                    TempData["Message"] = "审核失败，请选择确认时间";
                    return RedirectToAction("Confirm", new { controller = "Settle", id = model.ID.ToString() });
                }

                if (model.PaidPrice == null)
                {
                    TempData["Message"] = "审核失败，请输入付款金额";
                    return RedirectToAction("Confirm", new { controller = "Settle", id = model.ID.ToString() });
                }

                string id = Request.Form["ID"];
                string remark = Request.Form["Remark"];
                EntityStatus status = Request.Form["auditResult"] == "1" ? EntityStatus.SettlePaid : EntityStatus.SettleCancel;

                ErrorCode result = this.settleBusiness.Audit(id, model.PaidPrice.Value, model.ConfirmTime.Value, remark, status);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "基本费用审核完毕";
                    return RedirectToAction("Audit", "Settle");
                }
                else
                {
                    TempData["Message"] = "基本费用审核失败";
                    ModelState.AddModelError("", "基本费用审核失败: " + result.DisplayName());
                }
            }

            return View(model);
        }

        /// <summary>
        /// 合同冷藏费表单
        /// </summary>
        /// <returns></returns>
        public ActionResult ContractCold()
        {
            return View();
        }

        /// <summary>
        /// 合同冷藏费表单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ContractColdResult(ContractColdInput model)
        {
            if (ModelState.IsValid)
            {
                var records = this.settleBusiness.ProcessDailyCold(model.ContractID, model.DateFrom, model.DateTo);
                return View(records);
            }
            else
            {
                return View("ContractCold", model);
            }
        }

        /// <summary>
        /// 货品冷藏费表单
        /// </summary>
        /// <returns></returns>
        public ActionResult CargoCold()
        {
            return View();
        }

        /// <summary>
        /// 货品冷藏费表单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CargoColdResult(CargoColdInput model)
        {
            if (ModelState.IsValid)
            {
                var records = this.settleBusiness.ProcessDailyCold(model.CargoID, model.DateFrom, model.DateTo);
                return View(records);
            }
            else
            {
                return View("ColdPrice", model);
            }
        }
        #endregion //Action
    }
}