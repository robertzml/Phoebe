using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.BL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Core.Entity;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 结算业务类
    /// </summary>
    public class SettlementBusiness : AbstractBusiness<Settlement, string>, IBaseBL<Settlement, string>
    {
    }
}
