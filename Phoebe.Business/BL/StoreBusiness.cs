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
        #endregion //Function

        #region Method
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
        #endregion //Method
    }
}
