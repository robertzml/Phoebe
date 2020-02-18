using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.Service
{
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.Entity;
    using Phoebe.Core.BL;
    using Phoebe.Core.DL;
    using Phoebe.Core.View;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 冷藏费业务类
    /// </summary>
    public class ColdFeeService : AbstractService
    {
        #region Query
        public ColdFee FindByStore(string storeId, DateTime current)
        {
            var db = GetInstance();

            ColdFeeBusiness coldFeeBusiness = new ColdFeeBusiness();
            return coldFeeBusiness.FindByStore(storeId, current, db);
        }
        #endregion //Query
    }
}
