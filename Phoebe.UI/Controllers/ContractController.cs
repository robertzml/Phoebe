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
    /// 合同控制器
    /// </summary>
    public class ContractController : Controller
    {
        #region Field
        /// <summary>
        /// 合同业务
        /// </summary>
        private ContractBusiness contractBusiness;
        #endregion //Field

        #region Constructor
        public ContractController()
        {
            this.contractBusiness = new ContractBusiness();
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 合同主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var data = this.contractBusiness.Get();
            return View(data);
        }

        /// <summary>
        /// 合同信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var data = this.contractBusiness.Get(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 添加合同
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 添加合同
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Contract model)
        {
            if (ModelState.IsValid)
            {
                model.Status = 0;

                CustomerBusiness customerBusiness = new CustomerBusiness();
                if (model.CustomerType == 1)
                {
                    var cus = customerBusiness.GetGroupCustomer(model.CustomerID);
                    if (cus == null)
                    {
                        TempData["Message"] = "签订合同失败";
                        ModelState.AddModelError("", "签订合同失败: 客户不存在");
                        return View(model);
                    }
                }
                else
                {
                    var cus = customerBusiness.GetScatterCustomer(model.CustomerID);
                    if (cus == null)
                    {
                        TempData["Message"] = "签订合同失败";
                        ModelState.AddModelError("", "签订合同失败: 客户不存在");
                        return View(model);
                    }
                }

                ErrorCode result = this.contractBusiness.Create(model);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "签订合同成功";
                    return RedirectToAction("Details", new { controller = "Contract", id = model.ID });
                }
                else
                {
                    TempData["Message"] = "签订合同失败";
                    ModelState.AddModelError("", "签订合同失败: " + result.DisplayName());
                }
            }

            return View(model);
        }
        #endregion //Action
    }
}