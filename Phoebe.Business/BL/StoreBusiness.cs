using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data.Entity;

namespace Phoebe.Business
{
    using Phoebe.Base;
    using Phoebe.Model;
    using Phoebe.Business.DAL;

    /// <summary>
    /// 库存业务类
    /// </summary>
    public class StoreBusiness : BaseBusiness<Store>
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IBaseDataAccess<Store> dal;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 库存业务类
        /// </summary>
        public StoreBusiness() : base()
        {
            this.dal = RepositoryFactory<StoreRepository>.Instance;
            base.Init(this.dal);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 设置库存模型
        /// </summary>
        /// <param name="stock">库存</param>
        /// <param name="date">日期</param>
        /// <param name="count">数量</param>
        /// <param name="weight">在库重量</param>
        /// <param name="volume">在库体积</param>
        /// <param name="source">来源</param>
        /// <returns></returns>
        private Storage SetStorage(Store store, DateTime date, int count, decimal weight, decimal volume)
        {
            Storage storage = new Storage();
            storage.StorageDate = date;
            storage.StoreId = store.Id;

            storage.CustomerId = store.Cargo.Contract.CustomerId;
            storage.CustomerNumber = store.Cargo.Contract.Customer.Number;
            storage.CustomerName = store.Cargo.Contract.Customer.Name;
            storage.ContractId = store.Cargo.ContractId;
            storage.ContractName = store.Cargo.Contract.Name;

            storage.CargoId = store.CargoId;
            storage.CategoryId = store.Cargo.CategoryId;
            storage.CategoryNumber = store.Cargo.Category.Number;
            storage.CategoryName = store.Cargo.Category.Name;
            storage.Specification = store.Specification;

            storage.Count = count;
            storage.UnitWeight = store.Cargo.UnitWeight;
            storage.StoreWeight = weight;
            storage.UnitVolume = store.Cargo.UnitVolume;
            storage.StoreVolume = volume;

            storage.Number = store.WarehouseNumber;
            storage.InTime = store.InTime;
            storage.Source = (SourceType)store.Source;
            storage.UnitPrice = store.UnitPrice;
            storage.Remark = store.Remark;

            return storage;
        }

        /// <summary>
        /// 设置库存流水
        /// </summary>
        /// <param name="store">库存记录</param>
        /// <param name="stockId">操作ID</param>
        /// <param name="flowNumber">流水单号</param>
        /// <param name="storeCount">在库数量</param>
        /// <param name="flowCount">流水数量</param>
        /// <param name="flowWeight">流水重量</param>
        /// <param name="flowVolume">流水体积</param>
        /// <param name="date">流水日期</param>
        /// <param name="flowType">流水类型</param>
        /// <returns></returns>
        private StockFlow SetStockFlow(Store store, Guid stockId, string flowNumber, int storeCount, int flowCount, decimal flowWeight, decimal flowVolume, DateTime date, StockFlowType flowType)
        {
            StockFlow stockFlow = new StockFlow();
            stockFlow.StockId = stockId;
            stockFlow.FlowNumber = flowNumber;

            stockFlow.CustomerId = store.Cargo.Contract.CustomerId;
            stockFlow.CustomerNumber = store.Cargo.Contract.Customer.Number;
            stockFlow.CustomerName = store.Cargo.Contract.Customer.Name;

            stockFlow.ContractId = store.Cargo.ContractId;
            stockFlow.ContractName = store.Cargo.Contract.Name;

            stockFlow.CargoId = store.CargoId;
            stockFlow.CategoryId = store.Cargo.CategoryId;
            stockFlow.CategoryNumber = store.Cargo.Category.Number;
            stockFlow.CategoryName = store.Cargo.Category.Name;
            stockFlow.Specification = store.Specification;

            stockFlow.StoreCount = storeCount;
            stockFlow.FlowCount = flowCount;
            stockFlow.UnitWeight = store.Cargo.UnitWeight;
            stockFlow.FlowWeight = flowWeight;
            stockFlow.UnitVolume = store.Cargo.UnitVolume;
            stockFlow.FlowVolume = flowVolume;

            stockFlow.FlowDate = date;
            stockFlow.Type = flowType;
            stockFlow.UnitPrice = store.UnitPrice;

            return stockFlow;
        }

        /// <summary>
        /// 设置盘点期初数据
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="start">期初库存</param>
        /// <param name="endTime">期末时间</param>
        /// <returns></returns>
        private Inventory SetInventoryStart(List<Inventory> data, Storage start, DateTime endTime)
        {
            var inv = data.SingleOrDefault(r => r.CustomerId == start.CustomerId && r.CategoryId == start.CategoryId);

            if (inv == null)
            {
                Inventory inventory = new Inventory();
                inventory.CustomerId = start.CustomerId;
                inventory.CustomerNumber = start.CustomerNumber;
                inventory.CustomerName = start.CustomerName;
                inventory.CategoryId = start.CategoryId;
                inventory.CategoryNumber = start.CategoryNumber;
                inventory.CategoryName = start.CategoryName;
                inventory.StartTime = start.StorageDate;
                inventory.StartCount = start.Count;
                inventory.StartWeight = start.StoreWeight;
                inventory.EndTime = endTime;

                return inventory;
            }
            else
            {
                inv.StartCount += start.Count;
                inv.StartWeight += start.StoreWeight;

                return null;
            }
        }

        /// <summary>
        /// 设置盘点期末数据
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="end">期末库存</param>
        /// <param name="StartTime">期初时间</param>
        public Inventory SetInventoryEnd(List<Inventory> data, Storage end, DateTime startTime)
        {
            var inv = data.SingleOrDefault(r => r.CustomerId == end.CustomerId && r.CategoryId == end.CategoryId);

            if (inv == null)
            {
                Inventory inventory = new Inventory();
                inventory.CustomerId = end.CustomerId;
                inventory.CustomerNumber = end.CustomerNumber;
                inventory.CustomerName = end.CustomerName;
                inventory.CategoryId = end.CategoryId;
                inventory.CategoryNumber = end.CategoryNumber;
                inventory.CategoryName = end.CategoryName;
                inventory.StartTime = startTime;
                inventory.EndTime = end.StorageDate;
                inventory.EndCount = end.Count;
                inventory.EndWeight = end.StoreWeight;

                return inventory;
            }
            else
            {
                inv.EndCount += end.Count;
                inv.EndWeight += end.StoreWeight;

                return null;
            }
        }
        #endregion //Function

        #region Method
        #region Store
        /// <summary>
        /// 按条件查询库存
        /// </summary>
        /// <param name="predicates">查询条件</param>
        /// <returns></returns>
        public List<Store> GetByConditions(List<Func<Store, bool>> predicates)
        {
            IEnumerable<Store> data = this.dal.FindAll();
            foreach (var item in predicates)
            {
                data = data.Where(item);
            }

            return data.ToList();
        }

        /// <summary>
        /// 按客户获取库存记录
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <returns></returns>
        public List<Store> GetByCustomer(int customerId)
        {
            Expression<Func<Store, bool>> predicate = r => r.Cargo.Contract.CustomerId == customerId;
            var data = this.dal.Find(predicate);

            return data.ToList();
        }

        /// <summary>
        /// 按客户获取库存记录
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <param name="storeStatus">库存状态</param>
        /// <returns></returns>
        public List<Store> GetByCustomer(int customerId, EntityStatus storeStatus)
        {
            if (storeStatus != EntityStatus.StoreIn && storeStatus != EntityStatus.StoreOut && storeStatus != EntityStatus.StoreReady && storeStatus != EntityStatus.StoreMoveReady)
                return null;

            Expression<Func<Store, bool>> predicate = r => r.Status == (int)storeStatus && r.Cargo.Contract.CustomerId == customerId;
            var data = this.dal.Find(predicate);

            return data.ToList();
        }

        /// <summary>
        /// 按合同获取库存记录
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="isStoreIn">是否限定在库</param>
        /// <returns></returns>
        public List<Store> GetByContract(int contractId, bool isStoreIn)
        {
            if (isStoreIn)
            {
                Expression<Func<Store, bool>> predicate = r => r.Cargo.ContractId == contractId && r.Status == (int)EntityStatus.StoreIn;
                var data = this.dal.Find(predicate);

                return data.ToList();
            }
            else
            {
                Expression<Func<Store, bool>> predicate = r => r.Cargo.ContractId == contractId;
                var data = this.dal.Find(predicate);

                return data.ToList();
            }
        }

        /// <summary>
        /// 按货品查找库存
        /// </summary>
        /// <param name="cargoId">货品ID</param>
        /// <param name="isStoreIn">是否限定在库</param>
        /// <returns></returns>
        public List<Store> GetByCargo(Guid cargoId, bool isStoreIn)
        {
            if (isStoreIn)
            {
                var data = this.dal.Find(r => r.CargoId == cargoId && r.Status == (int)EntityStatus.StoreIn);
                return data.ToList();
            }
            else
            {
                var data = this.dal.Find(r => r.CargoId == cargoId);
                return data.ToList();
            }
        }

        /// <summary>
        /// 获取货品的在库数量
        /// </summary>
        /// <param name="cargoId">货品ID</param>
        /// <returns></returns>
        public int GetStoreCountByCargo(Guid cargoId)
        {
            var data = this.dal.Find(r => r.CargoId == cargoId && r.Status == (int)EntityStatus.StoreIn);
            return data.Sum(r => r.StoreCount);
        }
        #endregion //Store

        #region Storage
        /// <summary>
        /// 获取合同指定日库存
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public List<Storage> GetInDay(int contractId, DateTime date)
        {
            List<Storage> data = new List<Storage>();

            //find store
            var stores = this.dal.Find(r => r.Cargo.ContractId == contractId && r.MoveTime <= date && (r.OutTime == null || r.OutTime > date));
            if (stores.Count() == 0)
                return data;

            foreach (var store in stores)
            {
                // find in
                if (store.Source == (int)SourceType.StockIn) //from stock in
                {
                    var si = RepositoryFactory<StockInDetailsRepository>.Instance.FindOne(r => r.StoreId == store.Id);
                    var storage = SetStorage(store, date, si.Count, si.InWeight, si.InVolume);
                    data.Add(storage);
                }
                else //from stock move
                {
                    var sm = RepositoryFactory<StockMoveDetailsRepository>.Instance.FindOne(r => r.NewStoreId == store.Id);
                    var storage = SetStorage(store, date, sm.Count, sm.MoveWeight, sm.MoveVolume);
                    data.Add(storage);
                }

                //find stock out
                var stockOutDetails = RepositoryFactory<StockOutDetailsRepository>.Instance.Find(r => r.StoreId == store.Id && r.Status == (int)EntityStatus.StockOut && r.StockOut.OutTime <= date);
                foreach (var item in stockOutDetails)
                {
                    var s = data.SingleOrDefault(r => r.StoreId == item.StoreId);
                    if (s != null)
                    {
                        s.Count -= item.Count;
                        s.StoreWeight -= item.OutWeight;
                        s.StoreVolume -= item.OutVolume;
                    }
                }

                //find stock move out
                var smOuts = RepositoryFactory<StockMoveDetailsRepository>.Instance.Find(r => r.SourceStoreId == store.Id && r.Status == (int)EntityStatus.StockMove && r.StockMove.MoveTime <= date);
                foreach (var item in smOuts)
                {
                    var s = data.SingleOrDefault(r => r.StoreId == item.SourceStoreId);
                    if (s != null)
                    {
                        s.Count -= item.Count;
                        s.StoreWeight -= item.MoveWeight;
                        s.StoreVolume -= item.MoveVolume;
                    }
                }
            }

            return data;
        }
        #endregion //Storage

        #region Stock Flow
        /// <summary>
        /// 获取合同日流水
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="date">日期</param>
        /// <param name="includeMove">是否包含移库</param>
        /// <returns></returns>
        public List<StockFlow> GetDayFlow(int contractId, DateTime date, bool includeMove = true)
        {
            List<StockFlow> data = new List<StockFlow>();

            // find stock in
            var siDetails = RepositoryFactory<StockInDetailsRepository>.Instance.Find(r => r.StockIn.ContractId == contractId && r.StockIn.InTime == date && r.Status == (int)EntityStatus.StockIn);
            foreach (var item in siDetails)
            {
                var flow = SetStockFlow(item.Store, item.Id, item.StockIn.FlowNumber, 0, item.Count, item.InWeight, item.InVolume, item.StockIn.InTime, StockFlowType.StockIn);
                data.Add(flow);
            }

            // find stock out
            var soDetails = RepositoryFactory<StockOutDetailsRepository>.Instance.Find(r => r.StockOut.ContractId == contractId && r.StockOut.OutTime == date && r.Status == (int)EntityStatus.StockOut);
            foreach (var item in soDetails)
            {
                var flow = SetStockFlow(item.Store, item.Id, item.StockOut.FlowNumber, item.StoreCount, -item.Count, -item.OutWeight, -item.OutVolume, item.StockOut.OutTime, StockFlowType.StockOut);
                data.Add(flow);
            }

            if (includeMove)
            {
                // find stock move
                var smDetails = RepositoryFactory<StockMoveDetailsRepository>.Instance.Find(r => r.StockMove.ContractId == contractId && r.StockMove.MoveTime == date && r.Status == (int)EntityStatus.StockMove);
                foreach (var item in smDetails)
                {
                    var flow = SetStockFlow(item.SourceStore, item.Id, item.StockMove.FlowNumber, item.StoreCount, item.Count, item.MoveWeight, item.MoveVolume, item.StockMove.MoveTime, StockFlowType.StockMove);
                    data.Add(flow);
                }
            }

            return data;
        }

        /// <summary>
        /// 获取库存流水记录
        /// </summary>
        /// <param name="id">库存ID</param>
        /// <returns></returns>
        public List<StockFlow> GetStoreFlow(Guid id)
        {
            List<StockFlow> data = new List<StockFlow>();

            var store = this.dal.FindById(id);
            if (store == null)
                return null;

            // find in
            if ((SourceType)store.Source == SourceType.StockIn)
            {
                var si = RepositoryFactory<StockInDetailsRepository>.Instance.FindOne(r => r.StoreId == id && r.Status == (int)EntityStatus.StockIn);
                var flow = SetStockFlow(si.Store, si.Id, si.StockIn.FlowNumber, 0, si.Count, si.InWeight, si.InVolume, si.StockIn.InTime, StockFlowType.StockIn);
                data.Add(flow);
            }
            else
            {
                var smi = RepositoryFactory<StockMoveDetailsRepository>.Instance.FindOne(r => r.NewStoreId == id && r.Status == (int)EntityStatus.StockMove);
                var flow = SetStockFlow(smi.NewStore, smi.Id, smi.StockMove.FlowNumber, 0, smi.Count, smi.MoveWeight, smi.MoveVolume, smi.StockMove.MoveTime, StockFlowType.StockMoveIn);
                data.Add(flow);
            }

            // find out
            var so = RepositoryFactory<StockOutDetailsRepository>.Instance.Find(r => r.StoreId == id && r.Status == (int)EntityStatus.StockOut);
            foreach (var item in so)
            {
                var flow = SetStockFlow(item.Store, item.Id, item.StockOut.FlowNumber, item.StoreCount, -item.Count, -item.OutWeight, -item.OutVolume, item.StockOut.OutTime, StockFlowType.StockOut);
                data.Add(flow);
            }
            var smo = RepositoryFactory<StockMoveDetailsRepository>.Instance.Find(r => r.SourceStoreId == id && r.Status == (int)EntityStatus.StockMove);
            foreach (var item in smo)
            {
                var flow = SetStockFlow(item.SourceStore, item.Id, item.StockMove.FlowNumber, item.StoreCount, -item.Count, -item.MoveWeight, -item.MoveVolume, item.StockMove.MoveTime, StockFlowType.StockMoveOut);
                data.Add(flow);
            }

            return data;
        }

        /// <summary>
        /// 获取客户流水记录
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <returns></returns>
        public List<StockFlow> GetCustomerFlow(int customerId, bool includeMove)
        {
            List<StockFlow> data = new List<StockFlow>();

            // find stock in
            var siDetails = RepositoryFactory<StockInDetailsRepository>.Instance.Find(r => r.StockIn.Contract.CustomerId == customerId && r.Status == (int)EntityStatus.StockIn);
            foreach (var item in siDetails)
            {
                var flow = SetStockFlow(item.Store, item.Id, item.StockIn.FlowNumber, 0, item.Count, item.InWeight, item.InVolume, item.StockIn.InTime, StockFlowType.StockIn);
                data.Add(flow);
            }

            // find stock out
            var soDetails = RepositoryFactory<StockOutDetailsRepository>.Instance.Find(r => r.StockOut.Contract.CustomerId == customerId && r.Status == (int)EntityStatus.StockOut);
            foreach (var item in soDetails)
            {
                var flow = SetStockFlow(item.Store, item.Id, item.StockOut.FlowNumber, item.StoreCount, -item.Count, -item.OutWeight, -item.OutVolume, item.StockOut.OutTime, StockFlowType.StockOut);
                data.Add(flow);
            }

            if (includeMove)
            {
                // find stock move
                var smDetails = RepositoryFactory<StockMoveDetailsRepository>.Instance.Find(r => r.StockMove.Contract.CustomerId == customerId && r.Status == (int)EntityStatus.StockMove);
                foreach (var item in smDetails)
                {
                    var flow = SetStockFlow(item.SourceStore, item.Id, item.StockMove.FlowNumber, item.StoreCount, item.Count, item.MoveWeight, item.MoveVolume, item.StockMove.MoveTime, StockFlowType.StockMove);
                    data.Add(flow);
                }
            }

            return data;
        }

        /// <summary>
        /// 修正库存流水
        /// </summary>
        /// <param name="id">库存ID</param>
        /// <returns></returns>
        /// <remarks>
        /// 修正出库时间，对应出库记录的在库数量，移库记录的在库数量
        /// </remarks>
        public ErrorCode FixStore(Guid id)
        {
            try
            {
                var store = this.dal.FindById(id);

                if (store == null)
                    return ErrorCode.ObjectNotFound;
                if (store.Status == (int)EntityStatus.StoreReady || store.Status == (int)EntityStatus.StoreMoveReady)
                    return ErrorCode.Error;

                var flows = GetStoreFlow(id).OrderBy(r => r.FlowDate);

                TransactionRepository trans = new TransactionRepository();
                var result = trans.StoreFixTrans(store, flows);

                return result;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }

        /// <summary>
        /// 获取入库记录
        /// </summary>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <param name="customerId">客户ID</param>
        /// <returns></returns>
        public List<StockFlow> GetFlowIn(DateTime start, DateTime end, int customerId)
        {
            List<StockFlow> data = new List<StockFlow>();
            if (customerId == 0)
            {
                // find stock in
                var siDetails = RepositoryFactory<StockInDetailsRepository>.Instance.Find(r => r.StockIn.InTime >= start && r.StockIn.InTime <= end && r.Status == (int)EntityStatus.StockIn);
                foreach (var item in siDetails)
                {
                    var flow = SetStockFlow(item.Store, item.Id, item.StockIn.FlowNumber, 0, item.Count, item.InWeight, item.InVolume, item.StockIn.InTime, StockFlowType.StockIn);
                    data.Add(flow);
                }
            }
            else
            {
                // find stock in
                var siDetails = RepositoryFactory<StockInDetailsRepository>.Instance.Find(r => r.StockIn.Contract.CustomerId == customerId && r.StockIn.InTime >= start && r.StockIn.InTime <= end && r.Status == (int)EntityStatus.StockIn);
                foreach (var item in siDetails)
                {
                    var flow = SetStockFlow(item.Store, item.Id, item.StockIn.FlowNumber, 0, item.Count, item.InWeight, item.InVolume, item.StockIn.InTime, StockFlowType.StockIn);
                    data.Add(flow);
                }
            }

            return data;
        }

        /// <summary>
        /// 获取出库记录
        /// </summary>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <param name="customerId">客户ID</param>
        /// <returns></returns>
        public List<StockFlow> GetFlowOut(DateTime start, DateTime end, int customerId)
        {
            List<StockFlow> data = new List<StockFlow>();
            if (customerId == 0)
            {
                // find stock out
                var soDetails = RepositoryFactory<StockOutDetailsRepository>.Instance.Find(r => r.StockOut.OutTime >= start && r.StockOut.OutTime <= end && r.Status == (int)EntityStatus.StockOut);
                foreach (var item in soDetails)
                {
                    var flow = SetStockFlow(item.Store, item.Id, item.StockOut.FlowNumber, item.StoreCount, item.Count, item.OutWeight, item.OutVolume, item.StockOut.OutTime, StockFlowType.StockOut);
                    data.Add(flow);
                }
            }
            else
            {
                // find stock out
                var soDetails = RepositoryFactory<StockOutDetailsRepository>.Instance.Find(r => r.StockOut.Contract.CustomerId == customerId && r.StockOut.OutTime >= start && r.StockOut.OutTime <= end && r.Status == (int)EntityStatus.StockOut);
                foreach (var item in soDetails)
                {
                    var flow = SetStockFlow(item.Store, item.Id, item.StockOut.FlowNumber, item.StoreCount, item.Count, item.OutWeight, item.OutVolume, item.StockOut.OutTime, StockFlowType.StockOut);
                    data.Add(flow);
                }
            }

            return data;
        }
        #endregion //Stock Flow

        #region Inventory
        /// <summary>
        /// 获取库存盘点
        /// </summary>
        /// <param name="startTime">开始日期</param>
        /// <param name="endTime">结束日期</param>
        /// <param name="customerId">客户ID</param>
        /// <returns></returns>
        public List<Inventory> GetInventory(DateTime startTime, DateTime endTime, int customerId)
        {
            List<Inventory> data = new List<Inventory>();

            var customer = BusinessFactory<CustomerBusiness>.Instance.FindById(customerId);
            var contracts = BusinessFactory<ContractBusiness>.Instance.GetByCustomer(customerId);

            foreach (var contract in contracts)
            {
                var startStorages = GetInDay(contract.Id, startTime);
                var endStorages = GetInDay(contract.Id, endTime);

                foreach (var storage in startStorages)
                {
                    var inv = SetInventoryStart(data, storage, endTime);
                    if (inv != null)
                    {
                        data.Add(inv);
                    }
                }

                foreach (var storage in endStorages)
                {
                    var inv = SetInventoryEnd(data, storage, startTime);
                    if (inv != null)
                    {
                        data.Add(inv);
                    }
                }
            }

            return data;
        }
        #endregion //Inventory
        #endregion //Method
    }
}
