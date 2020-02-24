using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Core.BL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
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
        public List<Position> FindByShelf(int shelfId, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            return db.Queryable<Position>().Where(r => r.ShelfId == shelfId).ToList();
        }

        /// <summary>
        /// 按货架和排查找仓位
        /// </summary>
        /// <param name="shelfId">货架ID</param>
        /// <param name="row">排数</param>
        /// <returns></returns>
        public List<Position> FindList(int shelfId, int row, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            return db.Queryable<Position>().Where(r => r.ShelfId == shelfId && r.Row == row).OrderBy(r => r.Number).ToList();
        }

        /// <summary>
        /// 根据货架码查找空仓位
        /// </summary>
        /// <param name="shelfCode">货架码</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public Position FindAvailable(string shelfCode, SqlSugarClient db)
        {
            bool vice = false; //是否副货架码
            var data = db.Queryable<Position>().Where(r => r.ShelfCode == shelfCode).OrderBy(r => r.Depth).ToList();
            if (data.Count == 0)
            {
                vice = true;
                data = db.Queryable<Position>().Where(r => r.ViceShelfCode == shelfCode).OrderBy(r => r.Depth).ToList();
            }

            if (data.Count == 0)
                return null;

            var shelf = db.Queryable<Shelf>().Single(r => r.Id == data[0].ShelfId);
            if (shelf.Type == (int)ShelfType.Virtual) //判断是否虚拟货架
                return data[0];

            if (vice)
            {
                var find = data.FindLastIndex(r => r.Status != (int)EntityStatus.Available);
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
                // 找出第一个不可用的仓位
                var find = data.FindIndex(r => r.Status != (int)EntityStatus.Available);
                if (find == -1) //仓位全部可用
                {
                    return data.Last();
                }
                else
                {
                    if (find > 0)
                        return data[find - 1]; //返回不可用前一个仓位
                    else
                        return null; //不可用仓位为第一个，则该列放满
                }
            }
        }

        /// <summary>
        /// 根据货架码获取最外侧占用的仓位
        /// </summary>
        /// <param name="shelfCode">货架码</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public Position FindOutside(string shelfCode, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            bool vice = false; //是否副货架码
            var data = db.Queryable<Position>().Where(r => r.ShelfCode == shelfCode).OrderBy(r => r.Depth).ToList();
            if (data.Count == 0)
            {
                vice = true;
                data = db.Queryable<Position>().Where(r => r.ViceShelfCode == shelfCode).OrderBy(r => r.Depth).ToList();
            }

            if (data.Count == 0)
                return null;

            var shelf = db.Queryable<Shelf>().Single(r => r.Id == data[0].ShelfId);
            if (shelf.Type == (int)ShelfType.Virtual) //虚拟货架返回第一个仓位
                return data[0];

            if (vice)
            {                
                var pos = data.FindLast(r => r.Status == (int)EntityStatus.Occupy); //找出第一个占用的仓位
                if (pos == null)
                    return null;

                var disCount = data.Count(r => r.Depth > pos.Depth && r.Status == (int)EntityStatus.Disabled);
                if (disCount > 0) //前方存在禁用仓位
                    return null;

                return pos;
            }
            else
            {
                var pos = data.Find(r => r.Status == (int)EntityStatus.Occupy);
                if (pos == null)
                    return null;

                var disCount = data.Count(r => r.Depth < pos.Depth && r.Status == (int)EntityStatus.Disabled);
                if (disCount > 0)
                    return null;

                return pos;
            }
        }

        /// <summary>
        /// 仓位数量
        /// </summary>
        /// <param name="shelfId"></param>
        /// <returns></returns>
        public int Count(int shelfId, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            return db.Queryable<Position>().Count(r => r.ShelfId == shelfId);
        }

        /// <summary>
        /// 批量生成仓位
        /// </summary>
        /// <param name="shelfId">货架ID</param>
        /// <returns></returns>
        public (bool success, string errorMessage) Generate(int shelfId, SqlSugarClient db = null)
        {
            try
            {
                if (db == null)
                    db = GetInstance();

                var shelf = db.Queryable<Shelf>().InSingle(shelfId);
                if (shelf == null)
                    return (false, "未找到仓位");

                if (shelf.Type != (int)ShelfType.Position && shelf.Type != (int)ShelfType.Virtual)
                {
                    return (false, "非仓位或虚拟货架");
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

                            position.Remark = "";
                            position.Status = (int)EntityStatus.Available;

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

        /// <summary>
        /// 修改仓位状态
        /// </summary>
        /// <param name="position">仓位</param>
        /// <param name="status">状态</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) UpdateStatus(Position position, EntityStatus status, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            position.Status = (int)status;
            db.Updateable(position).ExecuteCommand();

            return (true, "");
        }
        #endregion //Method
    }
}
