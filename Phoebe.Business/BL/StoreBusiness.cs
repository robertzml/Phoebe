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
            this.dal = new StoreRepository();
            base.Init(this.dal);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 设置流水模型
        /// </summary>
        /// <param name="cargo">货品</param>
        /// <param name="count">流水数量</param>
        /// <param name="weight">流水重量</param>
        /// <param name="date">流水日期</param>
        /// <param name="type">流水类型</param>
        /// <returns></returns>
        private StockFlow SetStockFlow(Store store, int count, double weight, DateTime date, StockFlowType type)
        {
            StockFlow stockFlow = new StockFlow();
            stockFlow.CustomerId = store.Cargo.Contract.CustomerId;
            stockFlow.CustomerNumber = store.Cargo.Contract.Customer.Number;
            stockFlow.CustomerName = store.Cargo.Contract.Customer.Name;

            stockFlow.ContractId = store.Cargo.ContractId;
            stockFlow.ContractName = store.Cargo.Contract.Name;

            stockFlow.CategoryId = store.Cargo.CategoryId;
            stockFlow.CategoryNumber = store.Cargo.Category.Number;
            stockFlow.CategoryName = store.Cargo.Category.Name;

            stockFlow.Count = count;
            stockFlow.UnitWeight = store.Cargo.UnitWeight;
            stockFlow.Weight = weight;
            stockFlow.FlowDate = date;
            stockFlow.Type = type;
            stockFlow.CountChange = true;

            return stockFlow;
        }
        #endregion //Function

        #region Method
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

        public List<StockFlow> GetDayFlow(int contractId, DateTime date)
        {
            List<StockFlow> data = new List<StockFlow>();

            //find stock in
            var siDetails = RepositoryFactory<StockInDetailsRepository>.Instance.Find(r => r.StockIn.ContractId == contractId && r.StockIn.InTime == date && r.Status == (int)EntityStatus.StockIn);
            foreach (var item in siDetails)
            {
                var flow = SetStockFlow(item.Store, item.Count, item.InWeight, date, StockFlowType.StockIn);
                data.Add(flow);
            }

            return data;
        }
        #endregion //Method
    }
}
