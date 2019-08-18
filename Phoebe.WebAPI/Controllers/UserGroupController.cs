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

    /// <summary>
    /// 用户组控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserGroupController : ControllerBase
    {
        #region Action
        /// <summary>
        /// 获取所有用户组
        /// </summary>
        /// <returns></returns>
        public ActionResult<List<UserGroup>> List()
        {
            UserGroupBusiness userGroupBusiness = new UserGroupBusiness();
            return userGroupBusiness.FindAll();
        }
        #endregion //Action
    }
}