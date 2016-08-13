using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Phoebe.Business
{
    using Phoebe.Base;
    using Phoebe.Model;
    using Phoebe.Business.DAL;

    /// <summary>
    /// 计费业务类
    /// </summary>
    public class BillingBusiness : BaseBusiness<Billing>
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IBaseDataAccess<Billing> dal;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 计费业务类
        /// </summary>
        public BillingBusiness() : base()
        {
            this.dal = RepositoryFactory<BillingRepository>.Instance;
            base.Init(this.dal);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 获取库存对应计费信息
        /// </summary>
        /// <param name="storage">库存对象</param>
        /// <returns></returns>
        private Billing GetByStorage(Storage storage)
        {
            var store = BusinessFactory<StoreBusiness>.Instance.FindById(storage.StoreId);

            // find the origin store
            while ((SourceType)store.Source != SourceType.StockIn)
            {
                var smd = RepositoryFactory<StockMoveDetailsRepository>.Instance.FindOne(r => r.NewStoreId == store.Id);
                store = smd.SourceStore;
            }

            var sid = RepositoryFactory<StockInDetailsRepository>.Instance.FindOne(r => r.StoreId == store.Id);
            var billing = this.dal.FindById(sid.StockInId);
            return billing;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 获取库存的计费信息
        /// </summary>
        /// <param name="store">库存对象</param>
        /// <returns></returns>
        public Billing GetByStore(Store store)
        {
            // find the origin store
            while ((SourceType)store.Source != SourceType.StockIn)
            {
                var smd = RepositoryFactory<StockMoveDetailsRepository>.Instance.FindOne(r => r.NewStoreId == store.Id);
                store = smd.SourceStore;
            }

            var sid = RepositoryFactory<StockInDetailsRepository>.Instance.FindOne(r => r.StoreId == store.Id);
            var billing = this.dal.FindById(sid.StockInId);
            return billing;
        }

        /// <summary>
        /// 获取客户时间段内的计费信息
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public List<Billing> GetByCustomer(int customerId, DateTime start, DateTime end)
        {
            var data = this.dal.Find(r => r.StockIn.InTime >= start && r.StockIn.InTime <= end && r.Status == (int)EntityStatus.Normal && r.Contract.CustomerId == customerId);
            return data.ToList();
        }

        /// <summary>
        /// 获取合同的计费信息
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <returns></returns>
        public List<Billing> GetByContract(int contractId)
        {
            return this.dal.Find(r => r.ContractId == contractId).ToList();
        }

        /// <summary>
        /// 获取合同的计费信息
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public List<Billing> GetByContract(int contractId, DateTime start, DateTime end)
        {
            var data = this.dal.Find(r => r.StockIn.InTime >= start && r.StockIn.InTime <= end && r.Status == (int)EntityStatus.Normal && r.ContractId == contractId);
            return data.ToList();
        }
        #endregion //Method
    }
}
