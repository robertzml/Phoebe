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
        /// 获取库存记录
        /// </summary>
        /// <param name="id">库存ID</param>
        /// <returns></returns>
        public Stock GetStock(string id)
        {
            Guid gid;
            if (!Guid.TryParse(id, out gid))
                return null;

            return this.context.Stocks.Find(gid);
        }

        /// <summary>
        /// 获取库存记录
        /// </summary>
        /// <param name="warehouseID">仓库ID</param>
        /// <returns></returns>
        public List<Stock> GetInWarehouse(int warehouseID)
        {
            List<Stock> data = new List<Stock>();

            Warehouse warehouse = this.context.Warehouses.Find(warehouseID);
            if (warehouse == null)
                return data;

            if (warehouse.Hierarchy == 1)
                return data;

            if (warehouse.ChildrenWarehouse.Count() == 0)
            {
                data = this.context.Stocks.Where(r => r.Status == (int)EntityStatus.StoreIn && r.WarehouseID == warehouseID).ToList();
            }
            else
            {
                var d = from r in this.context.Stocks
                        where r.Status == (int)EntityStatus.StoreIn && (r.WarehouseID == warehouseID ||
                         (from s in this.context.Warehouses
                          where s.ParentId == warehouseID
                          select s.ID).Contains(r.WarehouseID))
                        select r;
                data = d.ToList();
            }
            return data;
        }
        #endregion //Stock

        #region Stock In
        /// <summary>
        /// 获取所有入库记录
        /// </summary>
        /// <returns></returns>
        public List<StockIn> GetStockIn()
        {
            var data = this.context.StockIns.OrderByDescending(r => r.ConfirmTime).ToList();
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
        /// <param name="details">入库详细信息</param>
        /// <returns></returns>
        public ErrorCode StockIn(StockIn data, List<StockInDetail> details)
        {
            try
            {
                data.ID = Guid.NewGuid();
                data.InTime = DateTime.Now;
                data.Status = (int)EntityStatus.StockInReady;

                this.context.StockIns.Add(data);

                // add stock in detail
                foreach (var item in details)
                {
                    item.ID = Guid.NewGuid();
                    item.StockInID = data.ID;
                    item.CargoID = data.CargoID;
                    item.Status = (int)EntityStatus.StockInReady;

                    this.context.StockInDetails.Add(item);

                    // edit warehouse status
                    Warehouse warehosue = this.context.Warehouses.Find(item.WarehouseID);
                    warehosue.Status = (int)EntityStatus.WarehouseReserve;
                }

                // change cargo status
                var cargo = this.context.Cargoes.Find(data.CargoID);
                cargo.Status = (int)EntityStatus.CargoStockInReady;
               
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

                if (status == EntityStatus.StockIn)
                {
                    // add stock information
                    foreach (var item in si.StockInDetails)
                    {
                        // change stock in details, cargo and warehouse status
                        item.Status = (int)EntityStatus.StockIn;
                        item.Cargo.InTime = si.ConfirmTime;
                        item.Cargo.Status = (int)EntityStatus.CargoStockIn;
                        item.Warehouse.Status = (int)EntityStatus.WarehouseOccupy;

                        Stock stock = new Stock();
                        stock.ID = Guid.NewGuid();
                        stock.WarehouseID = item.WarehouseID;
                        stock.Count = item.Count;
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
                    // change stock in details, cargo and warehouse status
                    foreach (var item in si.StockInDetails)
                    {
                        item.Status = (int)EntityStatus.StockInCancel;
                        item.Cargo.Status = (int)EntityStatus.CargoNotIn;
                        item.Warehouse.Status = (int)EntityStatus.WarehouseFree;
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
        /// <returns></returns>
        public List<StockOut> GetStockOut()
        {
            return this.context.StockOuts.OrderByDescending(r => r.ConfirmTime).ToList();
        }

        /// <summary>
        /// 获取出库记录
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public StockOut GetStockOut(string id)
        {
            Guid gid;
            if (!Guid.TryParse(id, out gid))
                return null;

            return this.context.StockOuts.Find(gid);
        }

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
                //// find store first
                //var stocks = this.context.Stocks.Where(r => r.Status == (int)EntityStatus.StoreIn && r.TrayID == data.TrayID);
                //if (stocks.Count() == 0)
                //    return ErrorCode.StockNotFound;

                //// add stock out
                //data.ID = Guid.NewGuid();
                //data.WarehouseID = stocks.First().WarehouseID;
                //data.OutTime = DateTime.Now;
                //data.Status = (int)EntityStatus.StockOutReady;

                //this.context.StockOuts.Add(data);

                //// add stock out detail
                //foreach (var item in stocks)
                //{
                //    StockOutDetail detail = new StockOutDetail
                //    {
                //        StockOutID = data.ID,
                //        CargoID = item.CargoID,
                //        Status = (int)EntityStatus.StockOutReady
                //    };
                //    this.context.StockOutDetails.Add(detail);

                //    // change cargos status
                //    item.Cargo.Status = (int)EntityStatus.CargoStockOutReady;
                //}

                //this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 出库审核
        /// </summary>
        /// <param name="id">出库ID</param>
        /// <param name="remark">备注</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public ErrorCode StockOutAudit(string id, string remark, EntityStatus status)
        {
            try
            {
                //Guid gid;
                //if (!Guid.TryParse(id, out gid))
                //    return ErrorCode.ObjectNotFound;

                //StockOut so = this.context.StockOuts.Find(gid);
                //if (so == null)
                //    return ErrorCode.ObjectNotFound;

                //so.ConfirmTime = DateTime.Now;
                //so.Remark = remark;
                //so.Status = (int)status;

                //if (status == EntityStatus.StockOut)
                //{
                //    // find store
                //    var stocks = this.context.Stocks.Where(r => r.Status == (int)EntityStatus.StoreIn && r.TrayID == so.TrayID);
                //    if (stocks.Count() == 0)
                //        return ErrorCode.StockNotFound;

                //    //edit stock information
                //    foreach (var item in stocks)
                //    {
                //        item.OutTime = so.ConfirmTime;
                //        item.Destination = 0;
                //        item.StockOutID = so.ID;
                //        item.Status = (int)EntityStatus.StoreOut;
                //    }

                //    //change stock out details and cargo status
                //    foreach (var item in so.StockOutDetails)
                //    {
                //        item.Status = (int)EntityStatus.StockOut;
                //        item.Cargo.OutTime = so.ConfirmTime;
                //        item.Cargo.Status = (int)EntityStatus.CargoStockOut;
                //    }

                //    //change tray status and position
                //    so.Tray.WarehouseID = null;
                //    so.Tray.Status = (int)EntityStatus.TrayUnused;
                //}
                //else
                //{
                //    //change stock out details and cargo status
                //    foreach (var item in so.StockOutDetails)
                //    {
                //        item.Status = (int)EntityStatus.StockOutCancel;
                //        item.Cargo.Status = (int)EntityStatus.CargoStockIn;
                //    }
                //}

                //this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }
        #endregion //Stock Out

        #region Stock Move
        /// <summary>
        /// 获取移库记录
        /// </summary>
        /// <returns></returns>
        public List<StockMove> GetStockMove()
        {
            return this.context.StockMoves.OrderByDescending(r => r.ConfirmTime).ToList();
        }

        /// <summary>
        /// 获取移库记录
        /// </summary>
        /// <param name="id">移库ID</param>
        /// <returns></returns>
        public StockMove GetStockMove(string id)
        {
            Guid gid;
            if (!Guid.TryParse(id, out gid))
                return null;

            return this.context.StockMoves.Find(gid);
        }

        /// <summary>
        /// 获取移库记录
        /// </summary>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public List<StockMove> GetStockMoveByStatus(EntityStatus status)
        {
            return this.context.StockMoves.Where(r => r.Status == (int)status).ToList();
        }

        /// <summary>
        /// 货品移库
        /// </summary>
        /// <param name="data">移库数据</param>
        /// <returns></returns>
        public ErrorCode StockMove(StockMove data)
        {
            try
            {
                //// find store first
                //var stocks = this.context.Stocks.Where(r => r.Status == (int)EntityStatus.StoreIn && r.TrayID == data.TrayID);
                //if (stocks.Count() == 0)
                //    return ErrorCode.StockNotFound;

                //// add stock move
                //data.ID = Guid.NewGuid();
                //data.SourceWarehouseID = stocks.First().WarehouseID;
                //data.MoveTime = DateTime.Now;
                //data.Status = (int)EntityStatus.StockMoveReady;

                //this.context.StockMoves.Add(data);

                //// add stock move details
                //foreach (var item in stocks)
                //{
                //    StockMoveDetail detail = new StockMoveDetail
                //    {
                //        StockMoveID = data.ID,
                //        CargoID = item.CargoID,
                //        Status = (int)EntityStatus.StockMoveReady
                //    };
                //    this.context.StockMoveDetails.Add(detail);

                //    // change cargos status
                //    item.Cargo.Status = (int)EntityStatus.CargoStockMoveReady;
                //}

                //this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 移库审核
        /// </summary>
        /// <param name="id">移库ID</param>
        /// <param name="remark">备注</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public ErrorCode StockMoveAudit(string id, string remark, EntityStatus status)
        {
            try
            {
                //Guid gid;
                //if (!Guid.TryParse(id, out gid))
                //    return ErrorCode.ObjectNotFound;

                //StockMove sm = this.context.StockMoves.Find(gid);
                //if (sm == null)
                //    return ErrorCode.ObjectNotFound;

                //sm.ConfirmTime = DateTime.Now;
                //sm.Remark = remark;
                //sm.Status = (int)status;

                //if (status == EntityStatus.StockMove)
                //{
                //    // find store
                //    var stocks = this.context.Stocks.Where(r => r.Status == (int)EntityStatus.StoreIn && r.TrayID == sm.TrayID);
                //    if (stocks.Count() == 0)
                //        return ErrorCode.StockNotFound;

                //    //edit stock information
                //    foreach (var item in stocks)
                //    {
                //        item.OutTime = sm.ConfirmTime;
                //        item.Destination = sm.DestinationWarehouseID;
                //        item.StockMoveID = sm.ID;
                //        item.Status = (int)EntityStatus.StoreOut;
                //    }

                //    // add another stock information
                //    foreach (var item in sm.StockMoveDetails)
                //    {
                //        Stock stock = new Stock();
                //        stock.ID = Guid.NewGuid();
                //        stock.WarehouseID = sm.DestinationWarehouseID;
                //        stock.TrayID = sm.TrayID;
                //        stock.CargoID = item.CargoID;
                //        stock.InTime = Convert.ToDateTime(sm.ConfirmTime);
                //        stock.Source = sm.SourceWarehouseID;
                //        stock.Status = (int)EntityStatus.StoreIn;

                //        this.context.Stocks.Add(stock);

                //        //change stock move details and cargo status
                //        item.Status = (int)EntityStatus.StockMove;
                //        item.Cargo.Status = (int)EntityStatus.CargoStockIn;
                //    }

                //    //change tray status and position
                //    sm.Tray.WarehouseID = sm.DestinationWarehouseID;
                //}
                //else
                //{
                //    //change stock move details and cargo status
                //    foreach (var item in sm.StockMoveDetails)
                //    {
                //        item.Status = (int)EntityStatus.StockMoveCancel;
                //        item.Cargo.Status = (int)EntityStatus.CargoStockIn;
                //    }
                //}

                //this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }
        #endregion //Stock Move
        #endregion //Method
    }
}
