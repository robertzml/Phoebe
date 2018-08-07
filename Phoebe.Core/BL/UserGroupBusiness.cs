using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Core.BL
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Phoebe.Core.IDAL;
    using Phoebe.Core.DL;

    /// <summary>
    /// 用户组业务类
    /// </summary>
    public class UserGroupBusiness : AbstractBusiness<UserGroup, int>, IBaseBL<UserGroup, int>
    {
        #region Field
        /// <summary>
        /// Root用户组ID
        /// </summary>
        private static int rootGroupId = 1;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 用户组业务类
        /// </summary>
        public UserGroupBusiness()
        {
            this.baseDal = RepositoryFactory<IUserGroupRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取用户组
        /// </summary>
        /// <param name="isRoot">是否Root</param>
        /// <returns></returns>
        public List<UserGroup> GetAll(bool isRoot)
        {
            if (isRoot)
            {
                return this.baseDal.FindAll().ToList();
            }
            else
            {
                return this.baseDal.FindAll().Where(r => r.Id != rootGroupId).ToList();
            }
        }
        #endregion //Method
    }
}
