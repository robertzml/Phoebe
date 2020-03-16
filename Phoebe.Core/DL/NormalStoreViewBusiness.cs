using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.DL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.BL;
    using Phoebe.Core.Entity;
    using Phoebe.Core.View;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 普通库存视图类
    /// </summary>
    public class NormalStoreViewBusiness : AbstractBusiness<NormalStoreView, string>, IBaseBL<NormalStoreView, string>
    {
        #region Query
        /// <summary>
        /// 按合同获取库存记录
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <returns></returns>
        public List<NormalStoreView> FindByContract(int contractId)
        {
            var db = GetInstance();
            var data = db.Queryable<NormalStoreView>().Where(r => r.ContractId == contractId).ToList();
            return data;
        }
        #endregion //Query
    }
}
