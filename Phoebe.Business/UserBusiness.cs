using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Common;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 用户业务类
    /// </summary>
    public class UserBusiness
    {
        #region Field
        private PhoebeContext context;

        /// <summary>
        /// 用户注册初始化时间
        /// </summary>
        private DateTime initialTime = new DateTime(2015, 1, 1);
        #endregion //Field

        #region Constructor
        public UserBusiness()
        {
            this.context = new PhoebeContext();
        }
        #endregion //Constructor

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

            this.context.SaveChanges();

            return;
        }
        #endregion //Function

        #region Method
        #region User Method
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <param name="isRoot">是否Root</param>
        /// <returns></returns>
        public List<User> GetUser(bool isRoot)
        {
            if (isRoot)
            {
                return this.context.Users.ToList();
            }
            else
            {
                return this.context.Users.Where(r => r.ID != 1).ToList();
            }
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="isRoot">是否Root</param>
        /// <returns></returns>
        public User GetUser(int id, bool isRoot)
        {
            if (id == 1 && !isRoot)
                return null;
            else
                return this.context.Users.Find(id);
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="username">登录名</param>
        /// <returns></returns>
        public User GetUser(string username)
        {
            var data = this.context.Users.SingleOrDefault(r => r.Username == username);
            return data;
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="data">用户数据</param>
        /// <returns></returns>
        public ErrorCode CreateUser(User data)
        {
            try
            {
                data.Password = Hasher.SHA1Encrypt(data.Password);
                data.LastLoginTime = initialTime;
                data.CurrentLoginTime = initialTime;
                data.Status = 0;

                if (data.UserGroupID == 1)
                    return ErrorCode.NoPrivilege;

                int count = this.context.Users.Count(r => r.Username == data.Username);
                if (count > 0)
                    return ErrorCode.DuplicateUserName;

                this.context.Users.Add(data);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }
        #endregion //User Method


        #region UserGroup Method
        /// <summary>
        /// 获取所有用户组
        /// </summary>
        /// <param name="isRoot">是否Root</param>
        /// <returns></returns>
        public List<UserGroup> GetUserGroup(bool isRoot)
        {
            if (isRoot)
            {
                return this.context.UserGroups.ToList();
            }
            else
            {
                return this.context.UserGroups.Where(r => r.ID != 1).ToList();
            }
        }

        /// <summary>
        /// 获取用户组
        /// </summary>
        /// <param name="id">用户组ID</param>
        /// <param name="isRoot">是否Root</param>
        /// <returns></returns>
        public UserGroup GetUserGroup(int id, bool isRoot)
        {
            if (id == 1 && !isRoot)
                return null;
            else
                return this.context.UserGroups.Find(id);
        }

        /// <summary>
        /// 添加用户组
        /// </summary>
        /// <param name="data">用户组数据</param>
        /// <returns></returns>
        public ErrorCode CreateUserGroup(UserGroup data)
        {
            try
            {
                data.Status = 0;

                this.context.UserGroups.Add(data);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 编辑用户组
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ErrorCode EditUserGroup(UserGroup data)
        {
            try
            {
                this.context.Entry(data).State = EntityState.Modified;
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }
        #endregion //UserGroup Method

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public ErrorCode Login(string username, string password)
        {
            User user = this.context.Users.SingleOrDefault(r => r.Username == username);
            if (user == null)
                return ErrorCode.UserNotExist;

            if (Hasher.SHA1Encrypt(password) != user.Password)           
                return ErrorCode.WrongPassword;

            if (user.Status == (int)EntityStatus.UserDisable)
                return ErrorCode.UserDisabled;

            UpdateLoginTime(user, user.CurrentLoginTime, DateTime.Now);

            return ErrorCode.Success;
        }

        /// <summary>
        /// 保存更新
        /// </summary>
        /// <returns></returns>
        public ErrorCode Save()
        {
            try
            {
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }
        #endregion //Method
    }
}
