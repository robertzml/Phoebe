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
    /// 转户控制器
    /// </summary>
    [EnhancedAuthorize]
    public class TransferController : Controller
    {
        #region Field
        /// <summary>
        /// 转户业务
        /// </summary>
        private TransferBusiness transferBusiness;
        #endregion //Field

        #region Constructor
        public TransferController()
        {
            this.transferBusiness = new TransferBusiness();
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 转户记录
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var data = this.transferBusiness.Get();
            return View(data);
        }

        /// <summary>
        /// 转户信息
        /// </summary>
        /// <param name="id">转户ID</param>
        /// <returns></returns>
        public ActionResult Details(string id)
        {
            var data = this.transferBusiness.Get(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 货品转户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 货品转户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Transfer model)
        {
            if (ModelState.IsValid)
            {
                var user = PageService.GetCurrentUser(User.Identity.Name);
                model.UserID = user.ID;

                string oldContractID = Request.Form["OldContractID"];
                string newContractID = Request.Form["NewContractID"];

                if (string.IsNullOrEmpty(newContractID))
                {
                    TempData["Message"] = "货品转户失败";
                    ModelState.AddModelError("", "货品转户失败: 请选择新合同。");

                    return View(model);
                }

                if (oldContractID == newContractID)
                {
                    TempData["Message"] = "货品转户失败";
                    ModelState.AddModelError("", "货品转户失败: 两次合同不能相同。");

                    return View(model);
                }

                string[] isTrans = Regex.Split(Request.Form["isTrans"], ",");
                List<TransferDetail> details = new List<TransferDetail>();
                for (int i = 0; i < isTrans.Length; i++)
                {
                    int warehouseId = Convert.ToInt32(isTrans[i]);

                    TransferDetail detail = new TransferDetail();
                    detail.WarehouseID = warehouseId;

                    details.Add(detail);
                }

                ErrorCode result = this.transferBusiness.Transfer(model, details, Convert.ToInt32(newContractID));
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "货品转户成功";
                    return RedirectToAction("Audit", new { controller = "Transfer" });
                }
                else
                {
                    TempData["Message"] = "货品转户失败";
                    ModelState.AddModelError("", "货品转户失败: " + result.DisplayName());
                }
            }

            return View(model);
        }

        /// <summary>
        /// 转户审核
        /// </summary>
        /// <returns></returns>
        public ActionResult Audit()
        {
            var data = this.transferBusiness.Get(EntityStatus.TransferReady);
            return View(data);
        }

        /// <summary>
        /// 转户确认
        /// </summary>
        /// <param name="id">转户ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Confirm(string id)
        {
            var data = this.transferBusiness.Get(id);
            if (data == null || data.Status != (int)EntityStatus.TransferReady)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 转户确认
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Confirm(Transfer model)
        {
            if (ModelState.IsValid)
            {
                if (model.ConfirmTime == null)
                {
                    TempData["Message"] = "转户审核失败，请选择确认时间";
                    return RedirectToAction("Confirm", new { controller = "Transfer", id = model.ID.ToString() });
                }

                string id = Request.Form["ID"];
                string remark = Request.Form["Remark"];
                EntityStatus status = Request.Form["auditResult"] == "1" ? EntityStatus.Transfer : EntityStatus.TransferCancel;

                ErrorCode result = this.transferBusiness.Audit(id, model.ConfirmTime.Value, remark, status);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "转户审核完毕";
                    return RedirectToAction("Audit", "Transfer");
                }
                else
                {
                    TempData["Message"] = "转户审核失败";
                    ModelState.AddModelError("", "转户审核失败: " + result.DisplayName());
                }
            }

            return View(model);
        }
        #endregion //Action
    }
}