using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        #endregion //Field

        #region Constructor
        public UserBusiness()
        {
            this.context = new PhoebeContext();
        }
        #endregion //Constructor

        #region Method
        #region User Method

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
