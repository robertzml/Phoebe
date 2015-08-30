using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phoebe.Business;
using Phoebe.Common;
using Phoebe.Model;
using Phoebe.UI.Models;
using Phoebe.UI.Filters;
using Phoebe.UI.Services;

namespace Phoebe.UI.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    [EnhancedAuthorize(Roles = "Root,Administrator")]
    public class UserController : Controller
    {
        #region Field
        /// <summary>
        /// 用户业务
        /// </summary>
        private UserBusiness userBusiness;
        #endregion //Field

        #region Constructor
        public UserController()
        {
            this.userBusiness = new UserBusiness();
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 用户主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var user = PageService.GetCurrentUser(User.Identity.Name);

            var data = this.userBusiness.GetUser(user.IsRoot());
            return View(data);
        }

        /// <summary>
        /// 用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var user = PageService.GetCurrentUser(User.Identity.Name);

            var data = this.userBusiness.GetUser(id, user.IsRoot());
            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(CreateUserModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new Model.User();
                user.Username = model.Username;
                user.Password = model.Password;
                user.UserGroupID = model.UserGroupID;
                user.Name = model.Name;
                user.Remark = model.Remark;

                ErrorCode result = this.userBusiness.CreateUser(user);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "添加用户成功";
                    return RedirectToAction("Index", new { controller = "User" });
                }
                else
                {
                    TempData["Message"] = "添加用户失败";
                    ModelState.AddModelError("", "添加用户失败: " + result.DisplayName());
                }
            }

            return View(model);
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = this.userBusiness.GetUser(id, false);
            if (data == null || id == 1)
                return HttpNotFound();

            EditUserModel model = new EditUserModel
            {
                ID = data.ID,
                Username = data.Username,
                UserGroupID = data.UserGroupID,
                Name = data.Name,
                Remark = data.Remark
            };

            return View(model);
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="model">用户模型</param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(EditUserModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new Model.User
                {
                    ID = model.ID,
                    UserGroupID = model.UserGroupID,
                    Password = model.Password,
                    Name = model.Name,
                    Remark = model.Remark
                };

                ErrorCode result = this.userBusiness.EditUser(user);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "编辑用户成功";
                    return RedirectToAction("Details", new { controller = "User", id = model.ID });
                }
                else
                {
                    TempData["Message"] = "编辑用户失败";
                    ModelState.AddModelError("", "编辑用户失败: " + result.DisplayName());
                }
            }

            return View(model);
        }

        /// <summary>
        /// 启用用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        public ActionResult Enable(int id)
        {
            this.userBusiness.Enable(id);
            TempData["Message"] = "用户已启用";
            return RedirectToAction("Details", "User", new { id = id });
        }

        /// <summary>
        /// 禁用用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        public ActionResult Disable(int id)
        {
            this.userBusiness.Disable(id);
            TempData["Message"] = "用户已禁用";
            return RedirectToAction("Details", "User", new { id = id });
        }
        #endregion //Action
    }
}