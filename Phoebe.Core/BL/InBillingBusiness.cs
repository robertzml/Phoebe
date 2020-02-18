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
    /// 入库计费业务类
    /// </summary>
    public class InBillingBusiness : AbstractBusiness<InBilling, string>, IBaseBL<InBilling, string>
    {
        #region Method
        /// <summary>
        /// 保存入库计费
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Save(InBilling entity, SqlSugarClient db = null)
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

        /// <summary>
        /// 删除入库费用
        /// </summary>
        /// <param name="id"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage) Delete(string id, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            db.Deleteable<InBilling>().In(id).ExecuteCommand();
            return (true, "");
        }
        #endregion //Method
    }
}
