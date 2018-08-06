using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Core.BL
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Common;
    using Phoebe.Core.IDAL;
    using Phoebe.Core.DL;

    /// <summary>
    /// 用户业务类
    /// </summary>
    public class UserBusiness : AbstractBusiness<User, int>, IBaseBL<User, int>
    {
        #region Constructor
        /// <summary>
        /// 用户业务类
        /// </summary>
        public UserBusiness()
        {
            this.baseDal = RepositoryFactory<IUserRepository>.Instance;
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

            this.baseDal.Update(user);

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
        public bool Login(string username, string password)
        {
            var user = this.baseDal.FindOneByField("UserName", username);

            if (user == null)
                return false;

            if (Hasher.SHA1Encrypt(password) != user.Password)
                return false;

            if (user.Status == (int)EntityStatus.Disabled)
                return false;

            UpdateLoginTime(user, user.CurrentLoginTime, DateTime.Now);

            return true;
        }
        #endregion //Method

        #region CRUD
        /// <summary>
        /// 根据用户名获取用户
        /// </summary>
        /// <param name="username">登录名</param>
        /// <returns></returns>
        public User FindByUserName(string username)
        {
            var user = this.baseDal.FindOneByField("UserName", username);
            return user;
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <param name="isRoot">是否Root</param>
        /// <returns></returns>
        public List<User> FindAll(bool isRoot)
        {
            if (isRoot)
            {
                return this.baseDal.FindAll().ToList();
            }
            else
            {
                return this.baseDal.FindAll().Where(r => r.Id != 1).ToList();
            }
        }
        #endregion //CRUD
    }
}
