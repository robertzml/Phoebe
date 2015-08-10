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
    public class ScatterCustomerController : Controller
    {
        #region Field
        /// <summary>
        /// 客户业务
        /// </summary>
        private CustomerBusiness customerBusiness;
        #endregion //Field

        #region Constructor
        public ScatterCustomerController()
        {
            this.customerBusiness = new CustomerBusiness();
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 零散客户主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var data = this.customerBusiness.GetScatterCustomer();
            return View(data);
        }

        /// <summary>
        /// 添加零散客户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 添加零散客户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(ScatterCustomer model)
        {
            if (ModelState.IsValid)
            {
                model.Status = 0;
                ErrorCode result = this.customerBusiness.CreateScatterCustomer(model);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "添加零散客户成功";
                    return RedirectToAction("Index", "ScatterCustomer");
                }
                else
                {
                    TempData["Message"] = "添加零散客户失败";
                    ModelState.AddModelError("", "添加零散客户失败: " + result.DisplayName());
                }
            }

            return View(model);
        }
        #endregion //Action
    }
}