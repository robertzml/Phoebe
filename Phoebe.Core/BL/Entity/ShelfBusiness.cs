using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.BL
{
    using Phoebe.Base.Framework;
    using Phoebe.Core.Entity;

    /// <summary>
    /// 货架业务类
    /// </summary>
    public class ShelfBusiness : AbstractBusiness<Shelf, int>, IBaseBL<Shelf, int>
    {
        #region Method
        /// <summary>
        /// 按仓库查找
        /// </summary>
        /// <param name="warehouseId">仓库ID</param>
        /// <returns></returns>
        public List<Shelf> FindByWarehouse(int warehouseId)
        {
            var db = GetInstance();
            return db.Queryable<Shelf>().Where(r => r.WarehouseId == warehouseId).ToList();
        }
        #endregion //Method
    }
}
