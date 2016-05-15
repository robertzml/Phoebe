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
        #endregion //Method
    }
}
