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
    /// 合同业务类
    /// </summary>
    public class ContractBusiness : BaseBusiness<Contract>
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IBaseDataAccess<Contract> dal;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 合同业务类
        /// </summary>
        public ContractBusiness() : base()
        {
            this.dal = RepositoryFactory<ContractRepository>.Instance;
            base.Init(this.dal);
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取客户所有合同
        /// </summary>
        /// <param name="customerId">客户Id</param>
        /// <returns></returns>
        public List<Contract> GetByCustomer(int customerId)
        {
            Expression<Func<Contract, bool>> predicate = r => r.CustomerId == customerId;
            return this.dal.Find(predicate).ToList();
        }

        /// <summary>
        /// 获取客户冷库合同
        /// </summary>
        /// <param name="customerId">客户Id</param>
        /// <returns></returns>
        /// <remarks>
        /// 指冷库租赁相关合同
        /// </remarks>
        public List<Contract> GetByCustomer2(int customerId)
        {
            Expression<Func<Contract, bool>> predicate = r => r.CustomerId == customerId &&
                (r.Type == (int)ContractType.TimingCold || r.Type == (int)ContractType.UntimingCold || r.Type == (int)ContractType.Freeze);
            return this.dal.Find(predicate).ToList();
        }

        /// <summary>
        /// 获取客户相关合同
        /// </summary>
        /// <param name="customerId">客户Id</param>
        /// <param name="type">合同类型</param>
        /// <returns></returns>
        public List<Contract> GetByCustomer(int customerId, ContractType type)
        {
            Expression<Func<Contract, bool>> predicate = r => r.CustomerId == customerId && r.Type == (int)type;
            return this.dal.Find(predicate).ToList();
        }

        /// <summary>
        /// 添加合同
        /// </summary>
        /// <param name="entity">合同对象</param>
        /// <returns></returns>
        public override ErrorCode Create(Contract entity)
        {
            if (this.dal.Find(r => r.Number == entity.Number).Count() > 0)
                return ErrorCode.DuplicateNumber;

            entity.Status = 0;

            var result = this.dal.Create(entity);
            return result;
        }

        /// <summary>
        /// 编辑合同
        /// </summary>
        /// <param name="entity">合同实体</param>
        /// <returns></returns>
        public override ErrorCode Update(Contract entity)
        {
            if (this.dal.Find(r => r.Id != entity.Id && r.Number == entity.Number).Count() > 0)
                return ErrorCode.DuplicateNumber;

            var result = this.dal.Update(entity);
            return result;
        }

        /// <summary>
        /// 删除合同
        /// </summary>
        /// <param name="entity">合同对象</param>
        /// <returns></returns>
        public override ErrorCode Delete(Contract entity)
        {
            if (BusinessFactory<BillingBusiness>.Instance.GetByContract(entity.Id).Count > 0)
                return ErrorCode.ContractHasStore;

            if (BusinessFactory<CargoBusiness>.Instance.GetByContract(entity.Id).Count > 0)
                return ErrorCode.ContractHasCargo;

            var result = this.dal.Delete(entity);
            return result;
        }

        /// <summary>
        /// 强制删除合同
        /// </summary>
        /// <param name="entity">合同对象</param>
        /// <returns></returns>
        public ErrorCode ForceDelete(Contract entity)
        {
            var trans = new TransactionRepository();
            var result = trans.ContractForceDeleteTrans(entity);

            return result;
        }
        #endregion //Method
    }
}
