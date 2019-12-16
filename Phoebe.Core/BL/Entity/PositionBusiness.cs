using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Core.BL
{
    using SqlSugar;
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
        /// 查找仓位
        /// </summary>
        /// <param name="shelfId"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public List<Position> FindList(int shelfId, int row)
        {
            var db = GetInstance();
            return db.Queryable<Position>().Where(r => r.ShelfId == shelfId && r.Row == row).OrderBy(r => r.Number).ToList();
        }

        /// <summary>
        /// 查找仓位
        /// </summary>
        /// <param name="shelfId"></param>
        /// <param name="row"></param>
        /// <param name="layer"></param>
        /// <param name="depth"></param>
        /// <returns></returns>
        public Position Find(int shelfId, int row, int layer, int depth)
        {
            var db = GetInstance();
            return db.Queryable<Position>().Single(r => r.ShelfId == shelfId && r.Row == row && r.Layer == layer && r.Depth == depth);
        }

        /// <summary>
        /// 根据货架码查找空仓位
        /// </summary>
        /// <param name="db"></param>
        /// <param name="shelfCode">货架码</param>
        /// <returns></returns>
        public Position FindEmpty(SqlSugarClient db, string shelfCode)
        {
            bool vice = false; //是否副货架码
            var data = db.Queryable<Position>().Where(r => r.ShelfCode == shelfCode).OrderBy(r => r.Depth).ToList();
            if (data.Count == 0)
            {
                data = db.Queryable<Position>().Where(r => r.ViceShelfCode == shelfCode).OrderBy(r => r.Depth).ToList();
                vice = true;
            }

            if (data.Count == 0)
                return null;

            if (vice)
            {
                var shelf = db.Queryable<Shelf>().Single(r => r.Id == data[0].ShelfId);

                var find = data.FindLastIndex(r => r.IsEmpty == false);
                if (find == -1)
                {
                    return data.First();
                }
                else
                {
                    if (find == shelf.Depth - 1)
                    {
                        return null;
                    }
                    else
                    {
                        return data[find + 1];
                    }
                }
            }
            else
            {
                var find = data.FindIndex(r => r.IsEmpty == false);
                if (find == -1)
                {
                    return data.Last();
                }
                else
                {
                    if (find > 0)
                        return data[find - 1];
                    else
                        return null;
                }
            }
        }

        /// <summary>
        /// 仓位数量
        /// </summary>
        /// <param name="shelfId"></param>
        /// <returns></returns>
        public int Count(int shelfId)
        {
            var db = GetInstance();
            return db.Queryable<Position>().Count(r => r.ShelfId == shelfId);
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

                                position.ShelfCode = position.Number.Substring(0, 12);
                            }
                            else if (shelf.Entrance == 2)
                            {
                                string[] en = shelf.EntranceNumber.Split('-');
                                position.Number = string.Format("{0}-{1}{2}-{3:D2}-{4}-{5:D2}",
                                    warehouse.Number, shelf.Number, en[0], row, layer, depth);

                                position.ViceNumber = string.Format("{0}-{1}{2}-{3:D2}-{4}-{5:D2}",
                                    warehouse.Number, shelf.Number, en[1], row, layer, shelf.Depth - depth + 1);

                                position.ShelfCode = position.Number.Substring(0, 12);
                                position.ViceShelfCode = position.ViceNumber.Substring(0, 12);
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
