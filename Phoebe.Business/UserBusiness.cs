using System;
using System.Collections.Generic;
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
                return this.context.UserGroups.SingleOrDefault(r => r.ID == id);
        }
        #endregion //UserGroup Method
        #endregion //Method
    }
}
