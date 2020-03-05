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
    /// 库存视图业务类
    /// </summary>
    public class StoreViewBusiness : AbstractBusiness<StoreView, string>, IBaseBL<StoreView, string>
    {
        #region Query
        /// <summary>
        /// 按合同获取库存记录
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <returns></returns>
        public List<StoreView> FindByContract(int contractId)
        {
            var db = GetInstance();
            var data = db.Queryable<StoreView>().Where(r => r.ContractId == contractId).ToList();
            return data;
        }

        /// <summary>
        /// 按货品查找库存
        /// </summary>
        /// <param name="cargoId">货品ID</param>
        /// <param name="isStoreIn">是否限定在库</param>
        /// <returns></returns>
        public List<StoreView> FindByCargo(string cargoId, bool isStoreIn)
        {
            var db = GetInstance();
            if (isStoreIn)
            {
                var data = db.Queryable<StoreView>().Where(r => r.CargoId == cargoId && r.Status == (int)EntityStatus.StoreIn).ToList();
                return data;
            }
            else
            {
                var data = db.Queryable<StoreView>().Where(r => r.CargoId == cargoId).ToList();
                return data;
            }
        }

        /// <summary>
        /// 按货品查找库存
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="cargoId">货品ID</param>
        /// <param name="isStoreIn">是否限定在库</param>
        /// <param name="db">数据库连接</param>
        /// <returns></returns>
        public List<StoreView> FindByCargo(int contractId, string cargoId, bool isStoreIn, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();
            if (isStoreIn)
            {
                var data = db.Queryable<StoreView>().Where(r => r.ContractId == contractId && r.CargoId == cargoId && r.Status == (int)EntityStatus.StoreIn).ToList();
                return data;
            }
            else
            {
                var data = db.Queryable<StoreView>().Where(r => r.ContractId == contractId && r.CargoId == cargoId).ToList();
                return data;
            }
        }

        /// <summary>
        /// 按仓位查找库存
        /// </summary>
        /// <param name="positionId">仓位ID</param>
        /// <param name="db"></param>
        /// <returns></returns>
        /// <remarks>
        /// 库存状态为：在库，准备移入
        /// </remarks>
        public List<StoreView> FindByPosition(int positionId, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<StoreView>().Where(r => r.PositionId == positionId && (r.Status == (int)EntityStatus.StoreIn || r.Status == (int)EntityStatus.StoreInReady));
            return data.ToList();
        }

        /// <summary>
        /// 按托盘码查找库存
        /// </summary>
        /// <param name="trayCode">托盘码</param>
        /// <param name="db"></param>
        /// <returns></returns>
        /// <remarks>
        /// 库存状态限定为在库，准备入库，准备出库
        /// </remarks>
        public List<StoreView> FindByTray(string trayCode, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<StoreView>().Where(r => r.TrayCode == trayCode && r.Status != (int)EntityStatus.StoreOut);
            return data.ToList();
        }

        /// <summary>
        /// 通过货架码获取最外侧库存
        /// </summary>
        /// <param name="shelfCode"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        /// <remarks>
        /// 虚拟货架不返回库存记录
        /// </remarks>
        public List<StoreView> FindOutside(string shelfCode, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            List<StoreView> data = new List<StoreView>();

            // 找出最外侧占用的仓位
            PositionBusiness positionBusiness = new PositionBusiness();
            var position = positionBusiness.FindOutside(shelfCode, db);
            if (position == null)
            {
                return data;
            }

            var shelf = db.Queryable<Shelf>().InSingle(position.ShelfId);
            if (shelf.Type == (int)ShelfType.Virtual)
                return data;

            data = db.Queryable<StoreView>().Where(r => r.PositionId == position.Id
                && (r.Status == (int)EntityStatus.StoreIn || r.Status == (int)EntityStatus.StoreInReady)).ToList();
            return data;
        }

        /// <summary>
        /// 按出库单查找库存
        /// 出库单规定了出库类型：普通库或者仓位库
        /// </summary>
        /// <param name="stockOutId">出库单ID</param>
        /// <param name="cargoId">货品ID</param>
        /// <returns></returns>
        public List<StoreView> FindByStockOut(string stockOutId, string cargoId)
        {
            StockOutViewBusiness stockOutViewBusiness = new StockOutViewBusiness();
            var stockOut = stockOutViewBusiness.FindById(stockOutId);

            var db = GetInstance();

            if (stockOut.Type == (int)StockOutType.Normal)
            {
                var data = db.Queryable<StoreView>().Where(r => r.WarehouseType == (int)WarehouseType.Normal
                    && r.ContractId == stockOut.ContractId && r.CargoId == cargoId
                    && r.Status == (int)EntityStatus.StoreIn).ToList();

                return data;
            }
            else if (stockOut.Type == (int)StockOutType.Position)
            {
                var data = db.Queryable<StoreView>().Where(r => r.WarehouseType == (int)WarehouseType.Position
                   && r.ContractId == stockOut.ContractId && r.CargoId == cargoId
                   && r.Status == (int)EntityStatus.StoreIn).ToList();

                return data;
            }
            else
                return new List<StoreView>();
        }
        #endregion //Query

        #region Storage
        /// <summary>
        /// 获取库存记录链表
        /// </summary>
        /// <param name="id">库存ID</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public List<StoreView> GetInOrder(string id, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            List<StoreView> data = new List<StoreView>();

            // 获取当前库存记录
            var store = db.Queryable<StoreView>().InSingle(id);
            data.Add(store);

            // 查找前序记录
            string prev = store.PrevStoreId;
            while (!string.IsNullOrEmpty(prev))
            {
                var find = db.Queryable<StoreView>().InSingle(prev);
                prev = find.PrevStoreId;

                data.Insert(0, find);
            }

            string next = store.Id;
            while (!string.IsNullOrEmpty(next))
            {
                var find = db.Queryable<StoreView>().Single(r => r.PrevStoreId == next);
                if (find != null)
                {
                    next = find.Id;
                    data.Add(find);
                }
                else
                    next = "";
            }

            return data;
        }

        /// <summary>
        /// 获取合同指定日库存
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public List<StoreView> GetInDay(int contractId, DateTime date, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            date = date.Date;

            var stores = db.Queryable<StoreView>()
                .Where(r => r.ContractId == contractId && r.InTime <= date && (r.OutTime == null || r.OutTime > date))
                .ToList();

            return stores;
        }
        #endregion //Storage
    }
}
