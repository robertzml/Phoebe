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
    /// 出库业务类
    /// </summary>
    public class OutBillingBusiness : AbstractBusiness<OutBilling, string>, IBaseBL<OutBilling, string>
    {
        #region Method
        /// <summary>
        /// 保存出库计费
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Save(OutBilling entity, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            if (string.IsNullOrEmpty(entity.Id))
            {
                entity.Id = Guid.NewGuid().ToString();
                db.Insertable(entity).ExecuteCommand();
            }
            else
            {
                db.Updateable(entity).ExecuteCommand();
            }

            return (true, "");
        }
        #endregion //Method
    }
}
