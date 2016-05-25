using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Phoebe.Business
{
    using Phoebe.Base;
    using Phoebe.Common;
    using Phoebe.Model;
    using Phoebe.Business.DAL;

    /// <summary>
    /// 用户业务类
    /// </summary>
    public class UserBusiness : BaseBusiness<User>
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IBaseDataAccess<User> dal;

        /// <summary>
        /// 用户注册初始化时间
        /// </summary>
        private DateTime initialTime = new DateTime(2015, 1, 1);

        /// <summary>
        /// Root用户组ID
        /// </summary>
        private static int rootGroupId = 1;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 用户业务类
        /// </summary>
        public UserBusiness() : base()
        {
            this.dal = new UserRepository();
            base.Init(this.dal);
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

            this.dal.Update(user);

            return;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <param name="isRoot">是否Root</param>
        /// <returns></returns>
        public List<User> Get(bool isRoot)
        {
            if (isRoot)
            {
                return this.dal.FindAll().ToList();
            }
            else
            {
                return this.dal.FindAll().Where(r => r.Id != 1).ToList();
            }
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="isRoot">是否Root</param>
        /// <returns></returns>
        public User Get(int id, bool isRoot)
        {
            if (id == 1 && !isRoot)
                return null;
            else
                return this.dal.FindById(id);
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="username">登录名</param>
        /// <returns></returns>
        public User Get(string username)
        {
            var data = this.dal.FindOne(r => r.UserName == username);
            return data;
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override ErrorCode Create(User entity)
        {
            if (entity.UserGroupId == rootGroupId)
                return ErrorCode.UserCannotCreate;

            if (this.dal.Find(r => r.UserName == entity.UserName).Count() > 0)
                return ErrorCode.DuplicateName;

            entity.LastLoginTime = initialTime;
            entity.CurrentLoginTime = initialTime;
            entity.Status = 0;

            var result = this.dal.Create(entity);
            return result;
        }

        /// <summary>
        /// 启用用户
        /// </summary>
        /// <param name="id">用户ID</param>
        public void Enable(int id)
        {
            var user = this.dal.FindById(id);
            if (user == null || id == 1)
                return;

            user.Status = (int)EntityStatus.Normal;
            this.dal.Update(user);
        }

        /// <summary>
        /// 禁用用户
        /// </summary>
        /// <param name="id">用户ID</param>
        public void Disable(int id)
        {
            var user = this.dal.FindById(id);
            if (user == null || id == 1)
                return;

            user.Status = (int)EntityStatus.UserDisable;
            this.dal.Update(user);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public ErrorCode Login(string username, string password)
        {
            var user = this.dal.FindOne(r => r.UserName == username);

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
        /// 修改密码
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="oldPassword">原密码</param>
        /// <param name="newPassword">新密码</param>
        /// <returns></returns>
        public ErrorCode ChangePassword(string username, string oldPassword, string newPassword)
        {
            var user = this.dal.FindOne(r => r.UserName == username);
            if (user == null)
                return ErrorCode.UserNotExist;

            if (user.Password != Hasher.SHA1Encrypt(oldPassword))
                return ErrorCode.WrongPassword;

            user.Password = Hasher.SHA1Encrypt(newPassword);

            var result = this.dal.Update(user);
            return result;
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// Root用户组ID
        /// </summary>
        public static int RootGroupID
        {
            get
            {
                return rootGroupId;
            }
        }
        #endregion //Property
    }
}
