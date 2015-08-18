using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phoebe.Business;
using Phoebe.Common;
using Phoebe.Model;
using Phoebe.UI.Models;

namespace Phoebe.UI.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
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
            var data = this.userBusiness.GetUser(true);
            return View(data);
        }

        /// <summary>
        /// 用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var data = this.userBusiness.GetUser(id, true);
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
        #endregion //Action
    }
}