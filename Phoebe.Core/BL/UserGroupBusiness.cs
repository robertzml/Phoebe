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
        #region Constructor
        /// <summary>
        /// 用户组业务类
        /// </summary>
        public UserGroupBusiness()
        {
            this.baseDal = RepositoryFactory<IUserGroupRepository>.Instance;
        }
        #endregion //Constructor
    }
}
