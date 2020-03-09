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
    /// 普通库存业务类
    /// </summary>
    public class NormalStoreBusiness : AbstractBusiness<NormalStore, string>, IBaseBL<NormalStore, string>
    {
    }
}
