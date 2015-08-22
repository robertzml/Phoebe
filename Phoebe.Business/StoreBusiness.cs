using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 仓储业务类
    /// </summary>
    public class StoreBusiness
    {
        #region Field
        private PhoebeContext context;
        #endregion //Field

        #region Constructor
        public StoreBusiness()
        {
            this.context = new PhoebeContext();
        }
        #endregion //Constructor

        #region Method
        #region Stock
        /// <summary>
        /// 获取所有库存记录
        /// </summary>
        /// <returns></returns>
        public List<Stock> GetStock()
        {
            return this.context.Stocks.ToList();
        }

        /// <summary>
        /// 获取当前库存
        /// </summary>
        /// <param name="trayID">托盘ID</param>
        /// <returns></returns>
        public List<Stock> GetInTray(int trayID)
        {
            return this.context.Stocks.Where(r => r.Status == (int)EntityStatus.StoreIn && r.TrayID == trayID).ToList();
        }
        #endregion //Stock

        #region Stock In
        /// <summary>
        /// 获取所有入库记录
        /// </summary>
        /// <returns></returns>
        public List<StockIn> GetStockIn()
        {
            var data = this.context.StockIns.ToList();
            return data;
        }

        /// <summary>
        /// 获取入库记录
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public StockIn GetStockIn(string id)
        {
            Guid gid;
            if (!Guid.TryParse(id, out gid))
                return null;

            return this.context.StockIns.Find(gid);
        }

        /// <summary>
        /// 获取入库记录
        /// </summary>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public List<StockIn> GetStockInByStatus(EntityStatus status)
        {
            return this.context.StockIns.Where(r => r.Status == (int)status).ToList();
        }

        /// <summary>
        /// 货品入库
        /// </summary>
        /// <param name="data">入库数据</param>
        /// <param name="cargos">货品数据</param>
        /// <returns></returns>
        public ErrorCode StockIn(StockIn data, string[] cargos)
        {
            try
            {
                data.ID = Guid.NewGuid();
                data.InTime = DateTime.Now;
                data.Status = (int)EntityStatus.StockInReady;

                this.context.StockIns.Add(data);

                // add stock in detail
                for (int i = 0; i < cargos.Length; i++)
                {
                    StockInDetail detail = new StockInDetail
                    {
                        StockInID = data.ID,
                        CargoID = new Guid(cargos[i]),
                        Status = (int)EntityStatus.StockInReady
                    };
                    this.context.StockInDetails.Add(detail);

                    // change cargo status
                    Guid gid = new Guid(cargos[i]);
                    Cargo cargo = this.context.Cargoes.Find(gid);
                    cargo.Status = (int)EntityStatus.CargoStockInReady;
                }

                // change tray status
                Tray tray = this.context.Trays.Find(data.TrayID);
                tray.Status = (int)EntityStatus.TrayInuse;

                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 入库审核
        /// </summary>
        /// <param name="id">入库ID</param>
        /// <param name="remark">备注</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public ErrorCode StockInAudit(string id, string remark, EntityStatus status)
        {
            try
            {
                Guid gid;
                if (!Guid.TryParse(id, out gid))
                    return ErrorCode.ObjectNotFound;

                StockIn si = this.context.StockIns.Find(gid);
                if (si == null)
                    return ErrorCode.ObjectNotFound;

                si.ConfirmTime = DateTime.Now;
                si.Remark = remark;
                si.Status = (int)status;

                // change tray position
                if (status == EntityStatus.StockIn)
                {
                    si.Tray.WarehouseID = si.WarehouseID;

                    // add stock information
                    foreach (var item in si.StockInDetails)
                    {
                        // change stock in details and cargo status
                        item.Status = (int)EntityStatus.StockIn;
                        item.Cargo.Status = (int)EntityStatus.CargoStockIn;

                        Stock stock = new Stock();
                        stock.ID = Guid.NewGuid();
                        stock.WarehouseID = si.WarehouseID;
                        stock.TrayID = si.TrayID;
                        stock.CargoID = item.CargoID;
                        stock.InTime = Convert.ToDateTime(si.ConfirmTime);
                        stock.Source = 0;
                        stock.StockInID = si.ID;
                        stock.Status = (int)EntityStatus.StoreIn;

                        this.context.Stocks.Add(stock);
                    }
                }
                else
                {
                    // change tray status
                    si.Tray.Status = (int)EntityStatus.TrayUnused;

                    // change stock in details and cargo status
                    foreach (var item in si.StockInDetails)
                    {
                        item.Status = (int)EntityStatus.StockInCancel;
                        item.Cargo.Status = (int)EntityStatus.CargoNotIn;
                    }
                }

                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }
        #endregion //Stock In

        #region Stock Out
        /// <summary>
        /// 获取出库记录
        /// </summary>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public List<StockOut> GetStockOutByStatus(EntityStatus status)
        {
            return this.context.StockOuts.Where(r => r.Status == (int)status).ToList();
        }

        /// <summary>
        /// 货品出库
        /// </summary>
        /// <param name="data">出库数据</param>
        /// <returns></returns>
        public ErrorCode StockOut(StockOut data)
        {
            try
            {
                // find store first
                var stocks = this.context.Stocks.Where(r => r.Status == (int)EntityStatus.StoreIn && r.TrayID == data.TrayID);
                if (stocks.Count() == 0)
                    return ErrorCode.StockNotFound;

                // add stock out
                data.ID = Guid.NewGuid();
                data.WarehouseID = stocks.First().WarehouseID;
                data.OutTime = DateTime.Now;
                data.Status = (int)EntityStatus.StockOutReady;

                this.context.StockOuts.Add(data);

                // add stock out detail
                foreach (var item in stocks)
                {
                    StockOutDetail detail = new StockOutDetail
                    {
                        StockOutID = data.ID,
                        CargoID = item.CargoID,
                        Status = (int)EntityStatus.StockOutReady
                    };
                    this.context.StockOutDetails.Add(detail);

                    // change cargos status
                    item.Cargo.Status = (int)EntityStatus.CargoStockOutReady;
                }

                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }
        #endregion //Stock Out
        #endregion //Method
    }
}
