using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Business
{
    using Phoebe.Base;
    using Phoebe.Common;
    using Phoebe.Model;
    using Phoebe.Business.DAL;

    /// <summary>
    /// 用户组业务类
    /// </summary>
    public class UserGroupBusiness : BaseBusiness<UserGroup>
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IBaseDataAccess<UserGroup> dal;

        /// <summary>
        /// Root用户组ID
        /// </summary>
        private static int rootGroupId = 1;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 用户业务类
        /// </summary>
        public UserGroupBusiness() : base()
        {
            this.dal = RepositoryFactory<UserGroupRepository>.Instance;
            base.Init(this.dal);
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取用户组
        /// </summary>
        /// <param name="isRoot">是否Root</param>
        /// <returns></returns>
        public List<UserGroup> Get(bool isRoot)
        {
            if (isRoot)
            {
                return this.dal.FindAll().ToList();
            }
            else
            {
                return this.dal.Find(r => r.Id != rootGroupId).ToList();
            }
        }
        #endregion //Method
    }
}
