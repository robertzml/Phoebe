using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.BL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.Entity;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 冰块入库业务类
    /// </summary>
    public class IceStockBusiness : AbstractBusiness<IceStock, string>, IBaseBL<IceStock, string>
    {
    }
}
