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

        #region Function

        #endregion //Function

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
        /// 根据货品获取库存
        /// </summary>
        /// <param name="cargoID">货品ID</param>
        /// <returns></returns>
        public List<Stock> GetWithCargo(string cargoID)
        {
            Guid gid;
            if (!Guid.TryParse(cargoID, out gid))
                return null;

            return this.context.Stocks.Where(r => r.CargoID == gid && r.Status == (int)EntityStatus.StoreIn).ToList();
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

            if (warehouse.IsStorage)
            {
                data = this.context.Stocks.Where(r => r.Status == (int)EntityStatus.StoreIn && r.WarehouseID == warehouseID).ToList();
            }
            else
            {
                WarehouseBusiness warehouseBusiness = new WarehouseBusiness();
                var storages = warehouseBusiness.GetStorage(warehouse);
                var sIds = storages.Select(r => r.ID);

                var d = from r in this.context.Stocks
                        where r.Status == (int)EntityStatus.StoreIn && sIds.Contains(r.WarehouseID)
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
                      
                        stock.Status = (int)EntityStatus.StoreIn;

                        this.context.Stocks.Add(stock);

                        item.StockID = stock.ID;
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
        /// <param name="details">出库详细信息</param>
        /// <returns></returns>
        public ErrorCode StockOut(StockOut data, List<StockOutDetail> details)
        {
            try
            {
                // find store first
                var stocks = this.context.Stocks.Where(r => r.CargoID == data.CargoID && r.Status == (int)EntityStatus.StoreIn);
                if (stocks.Count() == 0)
                    return ErrorCode.StockNotFound;

                // add stock out
                data.ID = Guid.NewGuid();
                data.OutTime = DateTime.Now;
                data.Status = (int)EntityStatus.StockOutReady;

                this.context.StockOuts.Add(data);

                // add stock out detail
                foreach (var item in details)
                {
                    // get store
                    var s = stocks.SingleOrDefault(r => r.WarehouseID == item.WarehouseID);
                    if (s == null)
                        return ErrorCode.StockNotFound;

                    // check stock out count
                    if (s.Count < item.Count)
                        return ErrorCode.StockOutCountOverflow;

                    item.ID = Guid.NewGuid();
                    item.StockOutID = data.ID;
                    item.StoreCount = s.Count;
                    item.CargoID = data.CargoID;
                    item.Status = (int)EntityStatus.StockOutReady;
                    item.StockID = s.ID;

                    this.context.StockOutDetails.Add(item);
                }

                this.context.SaveChanges();
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
                Guid gid;
                if (!Guid.TryParse(id, out gid))
                    return ErrorCode.ObjectNotFound;

                StockOut so = this.context.StockOuts.Find(gid);
                if (so == null)
                    return ErrorCode.ObjectNotFound;

                so.ConfirmTime = DateTime.Now;
                so.Remark = remark;
                so.Status = (int)status;

                if (status == EntityStatus.StockOut)
                {
                    //change stock out details status
                    foreach (var item in so.StockOutDetails)
                    {
                        item.Status = (int)EntityStatus.StockOut;

                        var stock = item.Stock;
                        if (stock == null)
                            return ErrorCode.StockNotFound;

                        if (stock.Count == item.Count)  // all stock out
                        {
                            item.Warehouse.Status = (int)EntityStatus.WarehouseFree;
                                                        
                            stock.Count = 0;
                            stock.OutTime = so.ConfirmTime;
                            stock.Status = (int)EntityStatus.StoreOut;
                        }
                        else
                        {
                            stock.Count -= item.Count;
                        }
                    }

                    // check cargo
                    var cargo = so.Cargo;
                    if (cargo.Stocks.Sum(r => r.Count) == 0)
                    {
                        cargo.Status = (int)EntityStatus.CargoStockOut;
                        cargo.OutTime = so.ConfirmTime;
                    }                    
                }
                else
                {
                    //change stock out details status
                    foreach (var item in so.StockOutDetails)
                    {
                        item.Status = (int)EntityStatus.StockOutCancel;
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
        /// <param name="details">移库详细信息</param>
        /// <returns></returns>
        public ErrorCode StockMove(StockMove data, List<StockMoveDetail> details)
        {
            try
            {
                // find store first
                var stocks = this.context.Stocks.Where(r => r.CargoID == data.CargoID && r.Status == (int)EntityStatus.StoreIn);
                if (stocks.Count() == 0)
                    return ErrorCode.StockNotFound;

                // add stock move
                data.ID = Guid.NewGuid();
                data.MoveTime = DateTime.Now;
                data.Status = (int)EntityStatus.StockMoveReady;

                this.context.StockMoves.Add(data);

                // add stock move details
                foreach (var item in details)
                {
                    item.ID = Guid.NewGuid();
                    item.StockMoveID = data.ID;
                    item.CargoID = data.CargoID;
                    item.Status = (int)EntityStatus.StockMoveReady;

                    var stock = stocks.FirstOrDefault(r => r.WarehouseID == item.SourceWarehouseID);
                    if (stock == null)
                        return ErrorCode.StockNotFound;

                    item.SourceStockID = stock.ID;
                    item.Count = stock.Count;

                    this.context.StockMoveDetails.Add(item);

                    // change destination warehouse status
                    var w = this.context.Warehouses.Find(item.DestinationWarehouseID);
                    w.Status = (int)EntityStatus.WarehouseReserve;
                }

                this.context.SaveChanges();
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
                Guid gid;
                if (!Guid.TryParse(id, out gid))
                    return ErrorCode.ObjectNotFound;

                StockMove sm = this.context.StockMoves.Find(gid);
                if (sm == null)
                    return ErrorCode.ObjectNotFound;

                sm.ConfirmTime = DateTime.Now;
                sm.Remark = remark;
                sm.Status = (int)status;

                if (status == EntityStatus.StockMove)
                {
                    foreach(var item in sm.StockMoveDetails)
                    {
                        item.Status = (int)EntityStatus.StockMove;

                        // change source stock
                        item.SourceStock.Count = 0;
                        item.SourceStock.OutTime = sm.ConfirmTime;
                        item.SourceStock.Status = (int)EntityStatus.StoreOut;

                        item.SourceWarehouse.Status = (int)EntityStatus.WarehouseFree;

                        // add new stock
                        Stock stock = new Stock();
                        stock.ID = Guid.NewGuid();
                        stock.WarehouseID = item.DestinationWarehouseID;
                        stock.CargoID = item.CargoID;
                        stock.Count = item.Count;
                        stock.InTime = Convert.ToDateTime(sm.ConfirmTime);
                        stock.Source = item.SourceWarehouseID;
                        stock.Status = (int)EntityStatus.StoreIn;

                        this.context.Stocks.Add(stock);

                        item.DestinationStockID = stock.ID;
                        item.DestinationWarehouse.Status = (int)EntityStatus.WarehouseOccupy;
                    }                   
                }
                else
                {
                    //change stock move details and cargo status
                    foreach (var item in sm.StockMoveDetails)
                    {
                        item.Status = (int)EntityStatus.StockMoveCancel;
                        item.DestinationWarehouse.Status = (int)EntityStatus.WarehouseFree;
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
        #endregion //Stock Move
        #endregion //Method
    }
}
