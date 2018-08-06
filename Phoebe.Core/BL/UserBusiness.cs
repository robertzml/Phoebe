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
    }
}
