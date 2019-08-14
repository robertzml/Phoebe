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