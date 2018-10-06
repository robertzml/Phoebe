using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Core.IDAL
{
    using Poseidon.Base.Framework;
    using Phoebe.Core.DL;

    /// <summary>
    /// 合同对象访问接口
    /// </summary>
    internal interface IContractRepository : IBaseDAL<Contract, int>
    {
    }
}
