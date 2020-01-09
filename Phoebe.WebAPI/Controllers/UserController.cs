using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Phoebe.WebAPI.Controllers
{
    using Phoebe.Core.BL;
    using Phoebe.Core.Entity;
    using Phoebe.WebAPI.Model;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Action
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ResponseData> Login(string userName, string password)
        {
            var userBusiness = new UserBusiness();
            var result = userBusiness.Login(userName, password);
                       
            ResponseData data = new ResponseData
            {
                Status = result.success ? 0 : 1,
                ErrorMessage = result.errorMessage               
            };

            if (result.success)
            {
                var user = userBusiness.FindByUserName(userName);
                user.Password = "";
                data.Entity = user;
            }
            else
            {
                data.Entity = null;
            }

            return data;
        }

        /// <summary>
        /// 启用禁用用户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="enable"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ResponseData> Enable(int id, bool enable)
        {
            var userBusiness = new UserBusiness();
            if (enable)
            {
                userBusiness.Enable(id);
            }
            else
            {
                userBusiness.Disable(id);
            }

            ResponseData data = new ResponseData
            {
                Status = 0,
                ErrorMessage = "",
                Entity = null
            };
            return data;
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public ActionResult<List<User>> List()
        {
            var userBusiness = new UserBusiness();
            var data= userBusiness.FindAll();
            data.ForEach(r => r.Password = "");
            return data;
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public ActionResult<User> Get(string userName)
        {
            var userBusiness = new UserBusiness();
            return userBusiness.FindByUserName(userName);
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult<User> GetById(int id)
        {
            var userBusiness = new UserBusiness();
            return userBusiness.FindById(id);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Create(User user)
        {
            var userBusiness = new UserBusiness();

            var task = Task.Run(() =>
            {
                var result = userBusiness.Create(user);

                ResponseData data = new ResponseData
                {
                    Status = result.success ? 0 : 1,
                    ErrorMessage = result.errorMessage
                };

                return data;
            });

            return await task;
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Update(User user)
        {
            var userBusiness = new UserBusiness();

            var task = Task.Run(() =>
            {
                var result = userBusiness.Update(user);

                ResponseData data = new ResponseData
                {
                    Status = result.success ? 0 : 1,
                    ErrorMessage = result.errorMessage
                };

                return data;
            });

            return await task;
        }
        #endregion //Action
    }
}