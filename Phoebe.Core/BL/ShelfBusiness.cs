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

        /// <summary>
        /// 创建货架
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage, Shelf t) Create(Shelf entity)
        {
            var db = GetInstance();
            var count = db.Queryable<Shelf>().Count(r => r.Number == entity.Number);
            if (count > 0)
            {
                return (false, "编号重复", null);
            }

            return base.Create(entity);
        }

        /// <summary>
        /// 编辑货架
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage) Update(Shelf entity)
        {
            var db = GetInstance();
            var count = db.Queryable<Shelf>().Count(r => r.Id != entity.Id && r.Number == entity.Number);
            if (count > 0)
            {
                return (false, "编号重复");
            }

            return base.Update(entity);
        }
        #endregion //Method
    }
}
