using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Phoebe.Business;
using Phoebe.Model;

namespace Phoebe.UI.Services
{
    /// <summary>
    /// 页面服务
    /// </summary>
    public class PageService
    {
        #region Method
        /// <summary>
        /// 获取当前用户
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public static User GetCurrentUser(string username)
        {
            UserBusiness userBusiness = new UserBusiness();
            var user = userBusiness.GetUser(username);
            return user;
        }
        #endregion //Method
    }
}