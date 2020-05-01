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
    /// 缴费业务类
    /// </summary>
    public class PaymentBusiness : AbstractBusiness<Payment, string>, IBaseBL<Payment, string>
    {
    }
}
