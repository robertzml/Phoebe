using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phoebe.Business;
using Phoebe.Common;
using Phoebe.Model;
using Phoebe.UI.Filters;

namespace Phoebe.UI.Controllers
{
    /// <summary>
    /// 用户组控制器
    /// </summary>
    public class UserGroupController : Controller
    {
        #region Field
        /// <summary>
        /// 用户业务
        /// </summary>
        private UserBusiness userBusiness;
        #endregion //Field

        #region Constructor
        public UserGroupController()
        {
            this.userBusiness = new UserBusiness();
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 用户组主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var data = this.userBusiness.GetUserGroup(true);
            return View(data);
        }

        /// <summary>
        /// 用户组信息
        /// </summary>
        /// <param name="id">用户组ID</param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var data = this.userBusiness.GetUserGroup(id, true);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 添加用户组
        /// </summary>
        /// <returns></returns>
        [EnhancedAuthorize(Roles = "Root")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 添加用户组
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [EnhancedAuthorize(Roles = "Root")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(UserGroup model)
        {
            if (ModelState.IsValid)
            {
                ErrorCode result = this.userBusiness.CreateUserGroup(model);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "添加用户组成功";
                    return RedirectToAction("Index", new { controller = "UserGroup" });
                }
                else
                {
                    TempData["Message"] = "添加用户组失败";
                    ModelState.AddModelError("", "添加用户组失败: " + result.DisplayName());
                }
            }

            return View(model);
        }

        /// <summary>
        /// 编辑用户组
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = this.userBusiness.GetUserGroup(id, false);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 编辑用户组
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(UserGroup model)
        {
            if (ModelState.IsValid)
            {
                ErrorCode result = this.userBusiness.EditUserGroup(model);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "编辑用户组成功";
                    return RedirectToAction("Details", new { controller = "UserGroup", id = model.ID });
                }
                else
                {
                    TempData["Message"] = "编辑用户组失败";
                    ModelState.AddModelError("", "编辑用户组失败: " + result.DisplayName());
                }
            }

            return View(model);
        }
        #endregion //Action
    }
}