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
        /// <summary>
        /// 设置库存模型
        /// </summary>
        /// <param name="cargo">货品</param>
        /// <param name="stock">库存</param>
        /// <param name="date">日期</param>
        /// <param name="count">数量</param>
        /// <param name="weight">总重量</param>
        /// <param name="source">来源</param>
        /// <returns></returns>
        private Storage SetStorage(Cargo cargo, Stock stock, DateTime date, int count, double weight, SourceType source)
        {
            Storage storage = new Storage();
            storage.StorageDate = date;
            storage.WarehouseID = stock.WarehouseID;
            storage.Number = stock.Warehouse.Number;
            storage.StockID = stock.ID;
            storage.CargoID = cargo.ID;
            storage.CargoName = cargo.Name;
            storage.ContractID = cargo.ContractID;
            storage.ContractName = cargo.Contract.Name;

            storage.FirstCategoryID = cargo.FirstCategoryID;
            storage.FirstCategoryName = cargo.FirstCategory.Name;
            storage.SecondCategoryID = cargo.SecondCategoryID;
            storage.SecondCategoryName = cargo.SecondCategory.Name;
            if (cargo.ThirdCategoryID != null)
            {
                storage.ThirdCategoryID = cargo.ThirdCategoryID.Value;
                storage.ThirdCategoryName = cargo.ThirdCategory.Name;
            }
            else
            {
                storage.ThirdCategoryID = 0;
                storage.ThirdCategoryName = "";
            }
            storage.Count = count;
            storage.Weight = weight;
            storage.InTime = cargo.InTime.Value;
            storage.Source = (int)source;

            return storage;
        }

        /// <summary>
        /// 设置流水模型
        /// </summary>
        /// <param name="cargo">货品</param>
        /// <param name="count">流水数量</param>
        /// <param name="weight">流水重量</param>
        /// <param name="date">流水日期</param>
        /// <param name="type">流水类型</param>
        /// <returns></returns>
        private StockFlow SetStockFlow(Cargo cargo, int count, double weight, DateTime date, StockFlowType type)
        {
            StockFlow stockFlow = new StockFlow();
            stockFlow.CargoID = cargo.ID;
            stockFlow.CargoName = cargo.Name;
            stockFlow.ContractID = cargo.ContractID;
            stockFlow.ContractName = cargo.Contract.Name;
            stockFlow.CustomerID = cargo.Contract.CustomerID;
            stockFlow.CustomerName = cargo.Contract.Customer.Name;

            stockFlow.FirstCategoryID = cargo.FirstCategoryID;
            stockFlow.FirstCategoryName = cargo.FirstCategory.Name;
            stockFlow.SecondCategoryID = cargo.SecondCategoryID;
            stockFlow.SecondCategoryName = cargo.SecondCategory.Name;
            if (cargo.ThirdCategoryID == null)
            {
                stockFlow.ThirdCategoryID = 0;
                stockFlow.ThirdCategoryName = "";
            }
            else
            {
                stockFlow.ThirdCategoryID = cargo.ThirdCategoryID.Value;
                stockFlow.ThirdCategoryName = cargo.ThirdCategory.Name;
            }

            stockFlow.Count = count;
            stockFlow.UnitWeight = cargo.UnitWeight;
            stockFlow.Weight = weight;
            stockFlow.FlowDate = date;
            stockFlow.Type = type;
            stockFlow.CountChange = true;

            return stockFlow;
        }
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
        /// 根据客户获取库存
        /// </summary>
        /// <param name="customerID">客户ID</param>
        /// <returns></returns>
        public List<Stock> GetByCustomer(int customerID)
        {
            var cargos = from r in this.context.Cargoes
                         where (from s in this.context.Contracts
                                where s.CustomerID == customerID
                                select s.ID).Contains(r.ContractID)
                         select r;

            var stocks = from r in this.context.Stocks
                         where cargos.Select(s => s.ID).Contains(r.CargoID)
                         orderby r.Warehouse.Number
                         select r;

            return stocks.ToList();
        }

        /// <summary>
        /// 根据合同获取库存
        /// </summary>
        /// <param name="contractID">合同ID</param>
        /// <returns></returns>
        public List<Stock> GetByContract(int contractID)
        {
            var data = from r in this.context.Stocks
                       where (from s in this.context.Cargoes
                              where s.ContractID == contractID
                              select s.ID).Contains(r.CargoID)
                       select r;

            return data.ToList();
        }

        /// <summary>
        /// 获取货品指定日库存
        /// </summary>
        /// <param name="cargoID">货品ID</param>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public List<Storage> GetInDay(Guid cargoID, DateTime date)
        {
            List<Storage> data = new List<Storage>();

            var cargo = this.context.Cargoes.Find(cargoID);
            if (cargo.InTime > date || cargo.OutTime < date)
                return data;

            //find stock
            var stocks = this.context.Stocks.Where(r => r.CargoID == cargoID);

            if (stocks.Count() == 0)
                return data;

            foreach (var stock in stocks)
            {
                if (stock.InTime > date || stock.OutTime < date)
                    continue;

                if (stock.Source == (int)SourceType.StockIn)
                {
                    var si = this.context.StockInDetails.Single(r => r.StockID == stock.ID);
                    var storage = SetStorage(cargo, stock, date, si.Count, si.InWeight, SourceType.StockIn);
                    data.Add(storage);
                }
                else //source stock move
                {
                    var sm = this.context.StockMoveDetails.Single(r => r.NewStockID == stock.ID);
                    var storage = SetStorage(cargo, stock, date, sm.Count, sm.MoveWeight, SourceType.StockMove);
                    data.Add(storage);
                }

                //find stock out
                var stockOutDetails = this.context.StockOutDetails.Where(r => r.StockID == stock.ID && r.Status == (int)EntityStatus.StockOut && r.StockOut.OutTime <= date);
                foreach (var item in stockOutDetails)
                {
                    var s = data.SingleOrDefault(r => r.StockID == item.StockID);
                    if (s != null)
                    {
                        s.Count -= item.Count;
                        s.Weight -= item.OutWeight;
                    }
                }

                //find stock move out
                var smOuts = this.context.StockMoveDetails.Where(r => r.SourceStockID == stock.ID && r.Status == (int)EntityStatus.StockMove && r.StockMove.MoveTime <= date);
                foreach (var item in smOuts)
                {
                    var s = data.SingleOrDefault(r => r.StockID == item.SourceStockID);
                    if (s != null)
                    {
                        s.Count -= item.Count;
                        s.Weight -= item.MoveWeight;
                    }
                }
            }

            return data;
        }

        /// <summary>
        /// 获取合同指定日库存
        /// </summary>
        /// <param name="contractID">合同ID</param>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public List<Storage> GetInDay(int contractID, DateTime date)
        {
            List<Storage> data = new List<Storage>();

            var cargos = this.context.Cargoes.Where(r => r.ContractID == contractID && r.InTime <= date && (r.OutTime == null || r.OutTime > date));

            foreach (var cargo in cargos)
            {
                var s = GetInDay(cargo.ID, date);
                data.AddRange(s);
            }

            return data;
        }

        /// <summary>
        /// 获取货品日流水
        /// </summary>
        /// <param name="cargoID">货品ID</param>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public List<StockFlow> GetDaysFlow(Guid cargoID, DateTime date)
        {
            List<StockFlow> data = new List<StockFlow>();

            var cargo = this.context.Cargoes.Find(cargoID);
            if (cargo.InTime > date || cargo.OutTime < date)
                return data;

            //find stock in
            var siDetail = this.context.StockInDetails.SingleOrDefault(r => r.CargoID == cargoID && r.Status == (int)EntityStatus.StockIn && r.StockIn.InTime == date);
            if (siDetail != null)
            {
                var flow = SetStockFlow(cargo, siDetail.Count, siDetail.InWeight, date, StockFlowType.StockIn);
                data.Add(flow);
            }

            //find stock out
            var soDetails = this.context.StockOutDetails.Where(r => r.CargoID == cargoID && r.Status == (int)EntityStatus.StockOut && r.StockOut.OutTime == date);
            foreach (var item in soDetails)
            {
                var flow = SetStockFlow(cargo, -item.Count, item.OutWeight, date, StockFlowType.StockOut);
                data.Add(flow);
            }

            //find stock move in
            var smInDetail = this.context.StockMoveDetails.SingleOrDefault(r => r.NewCargoID == cargoID && r.Status == (int)EntityStatus.StockMove && r.StockMove.MoveTime == date);
            if (smInDetail != null)
            {
                var flow = SetStockFlow(cargo, smInDetail.Count, smInDetail.MoveWeight, date, StockFlowType.StockMoveIn);
                data.Add(flow);
            }

            //find stock move out
            var smOutDetails = this.context.StockMoveDetails.Where(r => r.SourceCargoID == cargoID && r.Status == (int)EntityStatus.StockMove && r.StockMove.MoveTime == date);
            foreach (var item in smOutDetails)
            {
                var flow = SetStockFlow(cargo, -item.Count, item.MoveWeight, date, StockFlowType.StockMoveOut);
                if (item.IsAllMove)
                    flow.CountChange = false;
                data.Add(flow);
            }

            return data;
        }

        /// <summary>
        /// 获取合同日流水
        /// </summary>
        /// <param name="contractID">合同ID</param>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public List<StockFlow> GetDaysFlow(int contractID, DateTime date)
        {
            List<StockFlow> data = new List<StockFlow>();

            var cargos = this.context.Cargoes.Where(r => r.ContractID == contractID && r.InTime <= date && (r.OutTime == null || r.OutTime >= date));
            foreach (var cargo in cargos)
            {
                var s = GetDaysFlow(cargo.ID, date);
                data.AddRange(s);
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
            var data = this.context.StockIns.OrderByDescending(r => r.InTime).ToList();
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
        /// 获取入库月份分组
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 用于树形导航分组
        /// </remarks>
        public string[] GetStockInMonthGroup()
        {
            var m = this.context.StockIns.GroupBy(r => r.MonthTime).Select(g => g.Key).OrderByDescending(s => s);
            return m.ToArray();
        }

        /// <summary>
        /// 按月度获取入库记录
        /// </summary>
        /// <param name="monthTime">月份</param>
        /// <returns></returns>
        public List<StockIn> GetStockInByMonth(string monthTime)
        {
            var data = this.context.StockIns.Where(r => r.MonthTime == monthTime)
                .OrderByDescending(r => r.FlowNumber);
            return data.ToList();
        }

        /// <summary>
        /// 获取最新流水单号
        /// </summary>
        /// <param name="inTime">入库时间</param>
        /// <returns></returns>
        public string GetLastStockInFlowNumber(DateTime inTime)
        {
            var data = this.context.StockIns.Where(r => r.InTime == inTime).OrderByDescending(r => r.FlowNumber);
            if (data.Count() == 0)
                return string.Format("{0}{1}{2}0001",
                    inTime.Year, inTime.Month.ToString().PadLeft(2, '0'), inTime.Day.ToString().PadLeft(2, '0'));
            else
            {
                int newNumber = Convert.ToInt32(data.First().FlowNumber.Substring(8)) + 1;
                return string.Format("{0}{1}{2}{3}", inTime.Year, inTime.Month.ToString().PadLeft(2, '0'),
                    inTime.Day.ToString().PadLeft(2, '0'), newNumber.ToString().PadLeft(4, '0'));
            }
        }

        /// <summary>
        /// 货品入库
        /// </summary>
        /// <param name="data">入库信息</param>
        /// <param name="details">入库详细</param>
        /// <param name="billing">计费信息</param>
        /// <param name="cargos">货品信息</param>
        /// <returns></returns>
        public ErrorCode StockIn(StockIn data, List<StockInDetail> details, Billing billing, List<Cargo> cargos)
        {
            try
            {
                // add stock in
                data.FlowNumber = GetLastStockInFlowNumber(data.InTime);
                this.context.StockIns.Add(data);

                // add cargos
                this.context.Cargoes.AddRange(cargos);

                // add billing
                this.context.Billings.Add(billing);

                // add stock in details
                this.context.StockInDetails.AddRange(details);

                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }

        /// <summary>
        /// 入库确认
        /// </summary>
        /// <param name="id">入库ID</param>
        /// <returns></returns>
        public ErrorCode StockInConfirm(Guid id)
        {
            try
            {
                StockIn si = this.context.StockIns.Find(id);
                if (si == null)
                    return ErrorCode.ObjectNotFound;

                si.Status = (int)EntityStatus.StockIn;
                si.Billing.Status = (int)EntityStatus.Normal;

                // add stock information
                foreach (var item in si.StockInDetails)
                {
                    // change stock in details and cargo status
                    item.Status = (int)EntityStatus.StockIn;
                    item.Cargo.InTime = si.InTime;
                    item.Cargo.Status = (int)EntityStatus.CargoStockIn;

                    Stock stock = new Stock();
                    stock.ID = Guid.NewGuid();
                    stock.WarehouseID = item.WarehouseID;
                    stock.Count = item.Count;
                    stock.CargoID = item.CargoID;
                    stock.InTime = si.InTime;
                    stock.Source = (int)SourceType.StockIn;
                    stock.Status = (int)EntityStatus.StoreIn;

                    this.context.Stocks.Add(stock);

                    item.StockID = stock.ID;

                    this.context.SaveChanges();
                }

                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }
        #endregion //Stock In

        #region Stock Out
        /// <summary>
        /// 获取出库记录
        /// </summary>
        /// <returns></returns>
        public List<StockOut> GetStockOut()
        {
            return this.context.StockOuts.OrderByDescending(r => r.OutTime).ToList();
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
        /// 按月度获取出库记录
        /// </summary>
        /// <param name="monthTime">月份</param>
        /// <returns></returns>
        public List<StockOut> GetStockOutByMonth(string monthTime)
        {
            var data = this.context.StockOuts.Where(r => r.MonthTime == monthTime).OrderByDescending(r => r.FlowNumber);
            return data.ToList();
        }

        /// <summary>
        /// 获取出库月份分组
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 用于树形导航分组
        /// </remarks>
        public string[] GetStockOutMonthGroup()
        {
            var m = this.context.StockOuts.GroupBy(r => r.MonthTime).Select(g => g.Key).OrderByDescending(s => s);
            return m.ToArray();
        }

        /// <summary>
        /// 获取最新出库流水单号
        /// </summary>
        /// <param name="outTime">出库时间</param>
        /// <returns></returns>
        public string GetLastStockOutFlowNumber(DateTime outTime)
        {
            var data = this.context.StockOuts.Where(r => r.OutTime == outTime).OrderByDescending(r => r.FlowNumber);
            if (data.Count() == 0)
                return string.Format("{0}{1}{2}0001",
                    outTime.Year, outTime.Month.ToString().PadLeft(2, '0'), outTime.Day.ToString().PadLeft(2, '0'));
            else
            {
                int newNumber = Convert.ToInt32(data.First().FlowNumber.Substring(8)) + 1;
                return string.Format("{0}{1}{2}{3}", outTime.Year, outTime.Month.ToString().PadLeft(2, '0'),
                    outTime.Day.ToString().PadLeft(2, '0'), newNumber.ToString().PadLeft(4, '0'));
            }
        }

        /// <summary>
        /// 货品出库
        /// </summary>
        /// <param name="data"></param>
        /// <param name="details"></param>
        /// <returns></returns>
        public ErrorCode StockOut(StockOut data, List<StockOutDetail> details)
        {
            try
            {
                // add stock out
                data.FlowNumber = GetLastStockOutFlowNumber(data.OutTime);
                this.context.StockOuts.Add(data);

                // add stock out details
                foreach (var item in details)
                {
                    var stock = this.context.Stocks.Single(r => r.CargoID == item.CargoID && r.Status == (int)EntityStatus.StoreIn);
                    item.StockID = stock.ID;
                }
                this.context.StockOutDetails.AddRange(details);

                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }

        /// <summary>
        /// 出库确认
        /// </summary>
        /// <param name="id">出库ID</param>
        /// <returns></returns>
        public ErrorCode StockOutConfirm(Guid id)
        {
            try
            {
                StockOut so = this.context.StockOuts.Find(id);
                if (so == null)
                    return ErrorCode.ObjectNotFound;

                so.Status = (int)EntityStatus.StockOut;

                foreach (var item in so.StockOutDetails)
                {
                    //check cargo count
                    var cargo = item.Cargo;
                    if (cargo.StoreCount < item.Count)
                        return ErrorCode.StockOutCountOverflow;

                    var stock = item.Stock;
                    if (cargo.StoreCount == item.Count) // all stock out
                    {
                        cargo.StoreCount = 0;
                        cargo.OutTime = so.OutTime;
                        cargo.Status = (int)EntityStatus.CargoStockOut;

                        stock.Count = 0;
                        stock.OutTime = so.OutTime;
                        stock.Destination = (int)DestinationType.StockOut;
                        stock.Status = (int)EntityStatus.StoreOut;
                    }
                    else
                    {
                        cargo.StoreCount -= item.Count;
                        stock.Count -= item.Count;
                    }

                    //change stockout details status
                    item.Status = (int)EntityStatus.StockOut;
                }

                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }

        /// <summary>
        /// 锁定出库
        /// </summary>
        /// <param name="id">出库ID</param>
        /// <param name="isLock">是否锁定</param>
        /// <returns></returns>
        public ErrorCode StockOutLock(Guid id, bool isLock)
        {
            try
            {
                StockOut so = this.context.StockOuts.Find(id);
                if (so == null)
                    return ErrorCode.ObjectNotFound;

                so.IsLock = isLock;

                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }
        #endregion //Stock Out

        #region Stock Move
        /// <summary>
        /// 获取移库记录
        /// </summary>
        /// <returns></returns>
        public List<StockMove> GetStockMove()
        {
            return this.context.StockMoves.OrderByDescending(r => r.MoveTime).ToList();
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
        /// 按月度获取移库记录
        /// </summary>
        /// <param name="monthTime">月份</param>
        /// <returns></returns>
        public List<StockMove> GetStockMoveByMonth(string monthTime)
        {
            var data = this.context.StockMoves.Where(r => r.MonthTime == monthTime).OrderByDescending(r => r.FlowNumber);
            return data.ToList();
        }

        /// <summary>
        /// 获取移库月份分组
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 用于树形导航分组
        /// </remarks>
        public string[] GetStockMoveMonthGroup()
        {
            var m = this.context.StockMoves.GroupBy(r => r.MonthTime).Select(g => g.Key).OrderByDescending(s => s);
            return m.ToArray();
        }

        /// <summary>
        /// 获取最新移库流水单号
        /// </summary>
        /// <param name="moveTime">移库时间</param>
        /// <returns></returns>
        public string GetLastStockMoveFlowNumber(DateTime moveTime)
        {
            var data = this.context.StockMoves.Where(r => r.MoveTime == moveTime).OrderByDescending(r => r.FlowNumber);
            if (data.Count() == 0)
                return string.Format("{0}{1}{2}0001",
                    moveTime.Year, moveTime.Month.ToString().PadLeft(2, '0'), moveTime.Day.ToString().PadLeft(2, '0'));
            else
            {
                int newNumber = Convert.ToInt32(data.First().FlowNumber.Substring(8)) + 1;
                return string.Format("{0}{1}{2}{3}", moveTime.Year, moveTime.Month.ToString().PadLeft(2, '0'),
                    moveTime.Day.ToString().PadLeft(2, '0'), newNumber.ToString().PadLeft(4, '0'));
            }
        }

        /// <summary>
        /// 货品移库
        /// </summary>
        /// <param name="data">移库数据</param>
        /// <param name="details">详细信息</param>
        /// <returns></returns>
        public ErrorCode StockMove(StockMove data, List<StockMoveDetail> details)
        {
            try
            {
                // add stock move
                data.FlowNumber = GetLastStockMoveFlowNumber(data.MoveTime);
                this.context.StockMoves.Add(data);

                // add stock move details
                foreach (var item in details)
                {
                    var stock = this.context.Stocks.Single(r => r.CargoID == item.SourceCargoID && r.Status == (int)EntityStatus.StoreIn);
                    item.SourceStockID = stock.ID;
                }
                this.context.StockMoveDetails.AddRange(details);

                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }

        /// <summary>
        /// 移库确认
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ErrorCode StockMoveConfirm(Guid id)
        {
            try
            {
                StockMove sm = this.context.StockMoves.Find(id);
                if (sm == null)
                    return ErrorCode.ObjectNotFound;

                sm.Status = (int)EntityStatus.StockMove;

                foreach (var item in sm.StockMoveDetails)
                {
                    //check cargo count
                    var cargo = item.SourceCargo;
                    if (cargo.StoreCount < item.Count)
                        return ErrorCode.StockMoveCountOverflow;

                    var stock = item.SourceStock;
                    if (cargo.StoreCount == item.Count) // all move
                    {
                        cargo.WarehouseID = item.WarehouseID;

                        stock.Count = 0;
                        stock.OutTime = sm.MoveTime;
                        stock.Destination = (int)DestinationType.StockMove;
                        stock.Status = (int)EntityStatus.StoreOut;

                        Stock newStock = new Stock();
                        newStock.ID = Guid.NewGuid();
                        newStock.WarehouseID = item.WarehouseID;
                        newStock.CargoID = cargo.ID;
                        newStock.Count = item.Count;
                        newStock.InTime = sm.MoveTime;
                        newStock.Source = (int)SourceType.StockMove;
                        newStock.Remark = stock.Remark;
                        newStock.Status = (int)EntityStatus.StoreIn;

                        this.context.Stocks.Add(newStock);

                        item.IsAllMove = true;
                        item.NewStockID = newStock.ID;
                    }
                    else
                    {
                        cargo.StoreCount -= item.Count;
                        stock.Count -= item.Count;

                        // add new cargo
                        Cargo newCargo = new Cargo
                        {
                            ID = Guid.NewGuid(),
                            Name = cargo.Name,
                            FirstCategoryID = cargo.FirstCategoryID,
                            SecondCategoryID = cargo.SecondCategoryID,
                            ThirdCategoryID = cargo.ThirdCategoryID,
                            Count = item.Count,
                            EqualWeight = cargo.EqualWeight,
                            UnitWeight = cargo.UnitWeight,
                            TotalWeight = item.MoveWeight,
                            UnitVolume = cargo.UnitVolume,
                            TotalVolume = Math.Round(Convert.ToDouble(item.Count * cargo.UnitVolume), 3),
                            StoreCount = item.Count,
                            WarehouseID = item.WarehouseID,
                            UnitPrice = cargo.UnitPrice,
                            OriginPlace = cargo.OriginPlace,
                            Specification = cargo.Specification,
                            ShelfLife = cargo.ShelfLife,
                            ContractID = cargo.ContractID,
                            RegisterTime = cargo.RegisterTime,
                            UserID = cargo.UserID,
                            InTime = sm.MoveTime,
                            Remark = cargo.Remark,
                            Status = (int)EntityStatus.CargoStockIn
                        };

                        this.context.Cargoes.Add(newCargo);

                        // add new stock
                        Stock newStock = new Stock();
                        newStock.ID = Guid.NewGuid();
                        newStock.WarehouseID = item.WarehouseID;
                        newStock.CargoID = newCargo.ID;
                        newStock.Count = item.Count;
                        newStock.InTime = sm.MoveTime;
                        newStock.Source = 1;
                        newStock.Remark = stock.Remark;
                        newStock.Status = (int)EntityStatus.StoreIn;

                        this.context.Stocks.Add(newStock);

                        item.IsAllMove = false;
                        item.NewCargoID = newCargo.ID;
                        item.NewStockID = newStock.ID;
                    }

                    //change stockmove details status
                    item.Status = (int)EntityStatus.StockMove;
                }

                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }
        #endregion //Stock Move
        #endregion //Method
    }
}
