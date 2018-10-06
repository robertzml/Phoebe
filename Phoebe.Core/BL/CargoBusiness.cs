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
    /// 货品业务类
    /// </summary>
    public class CargoBusiness : AbstractBusiness<Cargo>, IBaseBL<Cargo>
    {
        #region Constructor
        /// <summary>
        /// 货品业务类
        /// </summary>
        public CargoBusiness()
        {
            this.baseDal = RepositoryFactory<ICargoRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 按客户查找货品
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <returns></returns>
        public IEnumerable<Cargo> GetByCustomer(int customerId)
        {
            return this.baseDal.FindListByField("CustomerId", customerId);
        }
        #endregion //Method
    }
}
