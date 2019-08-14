﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.BL
{
    using Phoebe.Base.Framework;
    using Phoebe.Core.Entity;
    using Phoebe.Common;
    using SqlSugar;

    /// <summary>
    /// 用户业务类
    /// </summary>
    public class UserBusiness : AbstractBusiness<User, int>, IBaseBL<User, int>
    {
        #region Function
        /// <summary>
        /// 更新登录时间
        /// </summary>
        /// <param name="_id">用户系统ID</param>
        /// <param name="last">上次登录时间</param>
        /// <param name="current">本次登录时间</param>
        private void UpdateLoginTime(User user, DateTime last, DateTime current)
        {
            user.LastLoginTime = last;
            user.CurrentLoginTime = current;

            this.Update(user);

            return;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 检查用户是否Root
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns></returns>
        public bool IsRoot(User user)
        {
            return user.UserGroupId == 1;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public (bool success, string errorMessage) Login(string username, string password)
        {
            var db = GetInstance();
            var user = db.Queryable<User>().Single(r => r.UserName == username);

            if (user == null)
                return (false, "用户不存在");

            if (Hasher.SHA1Encrypt(password) != user.Password)
                return (false, "密码错误");

            if (user.Status != (int)Phoebe.Base.System.EntityStatus.Normal)
                return (false, "用户未启用");

            UpdateLoginTime(user, user.CurrentLoginTime, DateTime.Now);

            return (true, "");
        }

        /// <summary>
        /// 根据用户名获取用户
        /// </summary>
        /// <param name="username">登录名</param>
        /// <returns></returns>
        public User FindByUserName(string username)
        {
            var db = GetInstance();
            return db.Queryable<User>().Single(r => r.UserName == username);
        }
        #endregion //Method
    }
}
