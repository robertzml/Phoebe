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
        public ActionResult<ResponseData> Login(string userName, string password)
        {
            var userBusiness = new UserBusiness();
            var result = userBusiness.Login(userName, password);

            ResponseData data = new ResponseData();
            data.Status = result.success ? 0 : 1;
            data.ErrorMessage = result.errorMessage;
            data.Entity = null;

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
        #endregion //Action
    }
}