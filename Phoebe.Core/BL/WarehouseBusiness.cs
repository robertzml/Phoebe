using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.BL
{
    using Phoebe.Base.Framework;
    using Phoebe.Core.Entity;

    /// <summary>
    /// 仓库业务表
    /// </summary>
    public class WarehouseBusiness : AbstractBusiness<Warehouse, int>, IBaseBL<Warehouse, int>
    {
        #region Method
        /// <summary>
        /// 创建仓库
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage, Warehouse t) Create(Warehouse entity)
        {
            var db = GetInstance();
            var count = db.Queryable<Warehouse>().Count(r => r.Number == entity.Number);
            if (count > 0)
            {
                return (false, "编号重复", null);
            }

            return base.Create(entity);
        }
        #endregion //Business
    }
}
