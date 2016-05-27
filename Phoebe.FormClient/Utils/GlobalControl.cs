using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Base;
using Phoebe.Model;

namespace Phoebe.FormClient
{
    /// <summary>
    /// 系统全局操作
    /// </summary>
    public class GlobalControl
    {
        #region Field
        /// <summary>
        /// 当前用户
        /// </summary>
        public LoginUser CurrentUser = null;
        #endregion //Field

        #region Method
        /// <summary>
        /// 设置登录用户
        /// </summary>
        /// <param name="user">用户信息</param>
        public LoginUser ConvertToLoginUser(User user)
        {
            LoginUser lu = new LoginUser
            {
                Id = user.Id,
                UserName = user.UserName,
                UserGroupId = user.UserGroupId,
                UserGroupName = user.UserGroup.Name,
                UserGroupTitle = user.UserGroup.Title,
                Rank = user.UserGroup.Rank,
                IsRoot = user.UserGroupId == Phoebe.Business.UserBusiness.RootGroupID,
                Name = user.Name,
                LastLoginTime = user.LastLoginTime,
                CurrentLoginTime = user.CurrentLoginTime,
                Remark = user.Remark,
                Status = user.Status
            };

            return lu;
        }
        #endregion //Method
    }
}
