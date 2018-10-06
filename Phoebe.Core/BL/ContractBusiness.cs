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
    /// 合同业务类
    /// </summary>
    public class ContractBusiness : AbstractBusiness<Contract, int>, IBaseBL<Contract, int>
    {
        #region Constructor
        /// <summary>
        /// 合同业务类
        /// </summary>
        public ContractBusiness()
        {
            this.baseDal = RepositoryFactory<IContractRepository>.Instance;
        }
        #endregion //Constructor
    }
}
