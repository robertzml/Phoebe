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
        /// 基本费用结算记录
        /// </summary>
        /// <returns></returns>
        public ActionResult BaseList()
        {
            var data = this.settleBusiness.GetBase();
            return View(data);
        }

        /// <summary>
        /// 基本费用结算信息
        /// </summary>
        /// <param name="id">结算ID</param>
        /// <returns></returns>
        public ActionResult BaseDetails(string id)
        {
            var data = this.settleBusiness.GetBase(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 基本费用结算
        /// </summary>
        /// <returns></returns>
        public ActionResult Base()
        {
            CargoBusiness cargoBusiness = new CargoBusiness();
            var data = cargoBusiness.GetByBilling(EntityStatus.BillingUnsettle);

            return View(data);
        }

        /// <summary>
        /// 基本费用结算
        /// </summary>
        /// <param name="id">货品ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult BaseProcess(string id)
        {
            CargoBusiness cargoBusiness = new CargoBusiness();
            var cargo = cargoBusiness.Get(id);
            ViewBag.Cargo = cargo;

            BillingBusiness billingBusiness = new BillingBusiness();

            BaseSettlement data = new BaseSettlement();
            data.CargoID = cargo.ID;
            data.SumPrice = billingBusiness.GetTotalPrice(id);
            data.Discount = 100;
            data.SettleTime = DateTime.Now;
            data.TotalPrice = data.SumPrice;

            return View(data);
        }

        /// <summary>
        /// 基本费用结算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult BaseProcess(BaseSettlement model)
        {
            CargoBusiness cargoBusiness = new CargoBusiness();
            var cargo = cargoBusiness.Get(model.CargoID.ToString());
            ViewBag.Cargo = cargo;

            if (ModelState.IsValid)
            {
                var user = PageService.GetCurrentUser(User.Identity.Name);
                model.UserID = user.ID;

                ErrorCode result = this.settleBusiness.BaseCreate(model);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "基本费用结算成功";
                    return RedirectToAction("Base", new { controller = "Settle" });
                }
                else
                {
                    TempData["Message"] = "基本费用结算失败";
                    ModelState.AddModelError("", "基本费用结算失败: " + result.DisplayName());
                }
            }

            return View(model);
        }

        /// <summary>
        /// 基本费用审核
        /// </summary>
        /// <returns></returns>
        public ActionResult BaseAudit()
        {
            var data = this.settleBusiness.GetBase(EntityStatus.SettleUnpaid);
            return View(data);
        }

        /// <summary>
        /// 基本费用审核
        /// </summary>
        /// <param name="id">结算单ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult BaseConfirm(string id)
        {
            var data = this.settleBusiness.GetBase(id);

            if (data == null || data.Status != (int)EntityStatus.SettleUnpaid)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 基本费用审核
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult BaseConfirm(BaseSettlement model)
        {
            if (ModelState.IsValid)
            {
                if (model.ConfirmTime == null)
                {
                    TempData["Message"] = "审核失败，请选择确认时间";
                    return RedirectToAction("BaseConfirm", new { controller = "Settle", id = model.ID.ToString() });
                }

                if (model.PaidPrice == null)
                {
                    TempData["Message"] = "审核失败，请输入付款金额";
                    return RedirectToAction("BaseConfirm", new { controller = "Settle", id = model.ID.ToString() });
                }

                string id = Request.Form["ID"];
                string remark = Request.Form["Remark"];
                EntityStatus status = Request.Form["auditResult"] == "1" ? EntityStatus.SettlePaid : EntityStatus.SettleCancel;

                ErrorCode result = this.settleBusiness.BaseAudit(id, model.PaidPrice.Value, model.ConfirmTime.Value, remark, status);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "基本费用审核完毕";
                    return RedirectToAction("BaseAudit", "Settle");
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
        /// 冷藏费用结算记录
        /// </summary>
        /// <returns></returns>
        public ActionResult ColdList()
        {
            var data = this.settleBusiness.GetCold();
            return View(data);
        }

        /// <summary>
        /// 冷藏费结算
        /// </summary>
        /// <returns></returns>
        public ActionResult Cold()
        {
            return View();
        }

        /// <summary>
        /// 冷藏费结算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ColdProcess(ColdInput model)
        {
            if (ModelState.IsValid)
            {
                var records = this.settleBusiness.ProcessDailyCold(model.ContractID, model.DateFrom, model.DateTo);

                ViewBag.ContractID = model.ContractID;
                ViewBag.StartTime = model.DateFrom;
                ViewBag.EndTime = model.DateTo;
                if (records.Count != 0)
                    ViewBag.SumPrice = records.Last().TotalFee;

                return View(records);
            }
            else
            {
                return View("Cold", model);
            }
        }

        /// <summary>
        /// 冷藏费结算
        /// </summary>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ColdStart()
        {
            ColdSettlement data = new ColdSettlement();
            data.ContractID = Convert.ToInt32(Request.Form["ContractID"]);
            data.StartTime = Convert.ToDateTime(Request.Form["StartTime"]);
            data.EndTime = Convert.ToDateTime(Request.Form["EndTime"]);
            data.SumPrice = Convert.ToDecimal(Request.Form["SumPrice"]);

            data.Discount = 100;
            data.TotalPrice = data.SumPrice;
            data.SettleTime = DateTime.Now.Date;
            return View(data);
        }

        /// <summary>
        /// 冷藏费结算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ColdCreate(ColdSettlement model)
        {
            if (ModelState.IsValid)
            {
                var user = PageService.GetCurrentUser(User.Identity.Name);
                model.UserID = user.ID;

                ErrorCode result = this.settleBusiness.ColdCreate(model);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "冷藏费用结算成功";
                    return RedirectToAction("Cold", new { controller = "Settle" });
                }
                else
                {
                    TempData["Message"] = "冷藏费用结算失败";
                    ModelState.AddModelError("", "冷藏费用结算失败: " + result.DisplayName());
                }
            }

            return RedirectToAction("Cold", new { controller = "Settle" });
        }

        /// <summary>
        /// 冷藏费计算
        /// </summary>
        /// <returns></returns>
        public ActionResult ColdPrice()
        {
            return View();
        }

        /// <summary>
        /// 冷藏费计算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ColdPriceProcess(ColdPrice model)
        {
            if (ModelState.IsValid)
            {
                BillingBusiness billingBusiness = new BillingBusiness();
                var total = billingBusiness.CalculateColdPrice(model.CargoID, model.DateFrom, model.DateTo);

                ViewBag.TotalFee = total;

                return View();
            }
            else
            {
                return View("ColdPrice", model);
            }
        }
        #endregion //Action
    }
}