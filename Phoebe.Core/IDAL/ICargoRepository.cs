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
    /// 货品对象访问接口
    /// </summary>
    internal interface ICargoRepository : IBaseDAL<Cargo>
    {
    }
}
