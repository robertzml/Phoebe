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
    /// 团体客户控制器
    /// </summary>
    public class GroupCustomerController : Controller
    {
        #region Field
        /// <summary>
        /// 客户业务
        /// </summary>
        private CustomerBusiness customerBusiness;
        #endregion //Field

        #region Constructor
        public GroupCustomerController()
        {
            this.customerBusiness = new CustomerBusiness();
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 团体客户主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var data = this.customerBusiness.GetGroupCustomer();
            return View(data);
        }

        /// <summary>
        /// 团体客户信息
        /// </summary>
        /// <param name="id">客户ID</param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var data = this.customerBusiness.GetGroupCustomer(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 添加团体客户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 添加团体客户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(GroupCustomer model)
        {
            if (ModelState.IsValid)
            {
                model.Status = 0;
                ErrorCode result = this.customerBusiness.CreateGroupCustomer(model);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "添加团体客户成功";
                    return RedirectToAction("Index", "GroupCustomer");
                }
                else
                {
                    TempData["Message"] = "添加团体客户失败";
                    ModelState.AddModelError("", "添加团体客户失败: " + result.DisplayName());
                }
            }

            return View(model);
        }

        /// <summary>
        /// 编辑团体客户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = this.customerBusiness.GetGroupCustomer(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 编辑团体客户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(GroupCustomer model)
        {
            if (ModelState.IsValid)
            {
                ErrorCode result = this.customerBusiness.EditGroupCustomer(model);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "编辑团体客户成功";
                    return RedirectToAction("Details", new { controller = "GroupCustomer", id = model.ID });
                }
                else
                {
                    TempData["Message"] = "编辑团体客户失败";
                    ModelState.AddModelError("", "编辑团体客户失败: " + result.DisplayName());
                }
            }

            return View(model);
        }
        #endregion //Action
    }
}