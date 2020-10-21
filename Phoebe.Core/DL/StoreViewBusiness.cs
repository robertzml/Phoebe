using System;
using System.Collections.Generic;
using System.Linq;
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
    using System.Linq.Expressions;

    /// <summary>
    /// 库存视图业务类
    /// </summary>
    public class StoreViewBusiness : AbstractBusiness<StoreView, string>, IBaseBL<StoreView, string>
    {
        #region Query
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
        /// 获取出库任务对应的库存记录
        /// </summary>
        /// <param name="stockOutTaskId">出库任务ID</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public List<StoreView> FindByStockOutTask(string stockOutTaskId, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            List<StoreView> data = new List<StoreView>();
            var carryOuts = db.Queryable<CarryOutTask>().Where(r => r.StockOutTaskId == stockOutTaskId).ToList();

            foreach (var carryOut in carryOuts)
            {
                var store = db.Queryable<StoreView>().Single(r => r.CarryOutTaskId == carryOut.Id);
                if (store != null)
                    data.Add(store);
            }

            return data;
        }

        /// <summary>
        /// 出库时查找库存记录
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="cargoId">货品ID</param>
        /// <returns></returns>
        /// <remarks>
        /// 去除已经添加的待出库库存记录
        /// </remarks>
        public List<StoreView> FindForStockOut(int contractId, string cargoId, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<StoreView>()
                .Where(r => r.ContractId == contractId && r.CargoId == cargoId && r.Status == (int)EntityStatus.StoreIn)
                .ToList();

            // 已经添加出库的托盘不能继续添加
            var carryOuts = db.Queryable<CarryOutTask>()
                .Where(r => r.ContractId == contractId && r.CargoId == cargoId &&
                    (r.Status == (int)EntityStatus.StockOutReady || r.Status == (int)EntityStatus.StockOutLeave ||
                    r.Status == (int)EntityStatus.StockOutCheck))
                .ToList();

            var trayCodes = carryOuts.Select(r => r.TrayCode);

            data = data.Where(r => !trayCodes.Contains(r.TrayCode)).ToList();

            return data;
        }

        /// <summary>
        /// 出库时查找库存记录
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <returns></returns>
        /// <remarks>
        /// 去除已经添加的待出库库存记录
        /// </remarks>
        public List<StoreView> FindForStockOut(int contractId, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<StoreView>()
                .Where(r => r.ContractId == contractId && r.Status == (int)EntityStatus.StoreIn)
                .ToList();

            // 已经添加出库的托盘不能继续添加
            var carryOuts = db.Queryable<CarryOutTask>()
                .Where(r => r.ContractId == contractId &&
                    (r.Status == (int)EntityStatus.StockOutReady || r.Status == (int)EntityStatus.StockOutLeave ||
                    r.Status == (int)EntityStatus.StockOutCheck))
                .ToList();

            var trayCodes = carryOuts.Select(r => r.TrayCode);

            data = data.Where(r => !trayCodes.Contains(r.TrayCode)).ToList();

            return data;
        }

        /// <summary>
        /// 找放回的库存记录
        /// </summary>
        /// <param name="prevStoreId">前序库存ID</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public StoreView FindNext(string prevStoreId, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<StoreView>().Single(r => r.PrevStoreId == prevStoreId);

            return data;
        }

        /// <summary>
        /// 获取指定仓位托盘码
        /// </summary>
        /// <param name="positionId">仓位ID</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public string GetPositionTray(int positionId, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<StoreView>().Single(r => r.PositionId == positionId && r.Status == (int)EntityStatus.StoreIn);
            if (data == null)
                return "";
            else
                return data.TrayCode;
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

        /// <summary>
        /// 获取客户指定日库存
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <param name="date">日期</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public List<StoreView> GetInDayByCustomer(int customerId, DateTime date, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            date = date.Date;

            var stores = db.Queryable<StoreView>()
                .Where(r => r.CustomerId == customerId && r.InTime <= date && (r.OutTime == null || r.OutTime > date))
                .ToList();

            return stores;
        }
        #endregion //Storage
    }
}
