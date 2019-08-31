using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.BL
{
    using Phoebe.Base.Framework;
    using Phoebe.Core.Entity;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 仓位业务类
    /// </summary>
    public class PositionBusiness : AbstractBusiness<Position, int>, IBaseBL<Position, int>
    {
        #region Method
        /// <summary>
        /// 按货架查找仓位
        /// </summary>
        /// <param name="shelfId">货架ID</param>
        /// <returns></returns>
        public List<Position> FindByShelf(int shelfId)
        {
            var db = GetInstance();
            return db.Queryable<Position>().Where(r => r.ShelfId == shelfId).ToList();
        }

        /// <summary>
        /// 批量生成仓位
        /// </summary>
        /// <param name="shelfId">货架ID</param>
        /// <returns></returns>
        public (bool success, string errorMessage) Generate(int shelfId)
        {
            try
            {
                var db = GetInstance();

                var shelf = db.Queryable<Shelf>().InSingle(shelfId);
                if (shelf == null)
                    return (false, "未找到仓位");

                if (shelf.Type != (int)ShelfType.Position)
                {
                    return (false, "非仓位货架");
                }

                var warehouse = db.Queryable<Warehouse>().InSingle(shelf.WarehouseId);

                for (int row = 1; row <= shelf.Row; row++)
                {
                    for (int layer = 1; layer <= shelf.Layer; layer++)
                    {
                        for (int depth = 1; depth <= shelf.Depth; depth++)
                        {
                            var position = new Position();
                            position.WarehouseId = shelf.WarehouseId;
                            position.ShelfId = shelf.Id;
                            position.Row = row;
                            position.Layer = layer;
                            position.Depth = depth;

                            if (shelf.Entrance == 1)
                            {
                                position.Number = string.Format("{0}-{1}{2}-{3:D2}-{4}-{5:D2}",
                                    warehouse.Number, shelf.Number, shelf.EntranceNumber, row, layer, depth);
                                position.ViceNumber = "";
                            }
                            else if (shelf.Entrance == 2)
                            {
                                string[] en = shelf.EntranceNumber.Split('-');
                                position.Number = string.Format("{0}-{1}{2}-{3:D2}-{4}-{5:D2}",
                                    warehouse.Number, shelf.Number, en[0], row, layer, depth);

                                position.ViceNumber = string.Format("{0}-{1}{2}-{3:D2}-{4}-{5:D2}",
                                    warehouse.Number, shelf.Number, en[1], row, layer, shelf.Depth - depth + 1);
                            }

                            position.IsEmpty = true;
                            position.Remark = "";
                            position.Status = 0;

                            db.Insertable(position).ExecuteCommand();
                        }
                    }
                }

                return (true, "");
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
        }
        #endregion //Method
    }
}
