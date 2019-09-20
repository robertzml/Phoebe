using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.BL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.View;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 库存视图业务类
    /// </summary>
    public class StoreViewBusiness : AbstractBusiness<StoreView, string>, IBaseBL<StoreView, string>
    {
        #region Method
        /// <summary>
        /// 查找在库库存
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>
        public StoreView FindStoreIn(int positionId)
        {
            var db = GetInstance();
            var data = db.Queryable<StoreView>().Single(r => r.PositionId == positionId && r.Status == (int)EntityStatus.StoreIn);
            return data;
        }
        #endregion //Method
    }
}
