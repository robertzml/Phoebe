using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Core.BL
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Common;
    using Phoebe.Core.IDAL;
    using Phoebe.Core.DL;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 合同业务类
    /// </summary>
    public class ContractBusiness : AbstractBusiness<Contract, int>, IBaseBL<Contract, int>
    {
        #region Constructor
        /// <summary>
        /// 合同业务类
        /// </summary>
        public ContractBusiness()
        {
            this.baseDal = RepositoryFactory<IContractRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取客户所有合同
        /// </summary>
        /// <param name="customerId">客户Id</param>
        /// <returns></returns>
        public IEnumerable<Contract> GetByCustomer(int customerId)
        {
            return this.baseDal.FindListByField("CustomerId", customerId);
        }

        /// <summary>
        /// 获取客户冷库合同
        /// </summary>
        /// <param name="customerId">客户Id</param>
        /// <returns></returns>
        /// <remarks>
        /// 指冷库租赁相关合同
        /// </remarks>
        public IEnumerable<Contract> GetColdByCustomer(int customerId)
        {
            var data = this.baseDal.FindListByField("CustomerId", customerId);
            var filter = data.Where(r =>
                r.Type == (int)ContractType.TimingCold || r.Type == (int)ContractType.UntimingCold ||
                r.Type == (int)ContractType.Freeze || r.Type == (int)ContractType.MinDuration);

            return filter;
        }
        #endregion //Method

        #region CRUD
        /// <summary>
        /// 添加合同
        /// </summary>
        /// <param name="entity">合同对象</param>
        /// <returns></returns>
        public override Contract Create(Contract entity)
        {
            if (this.baseDal.Count("Number", entity.Number) > 0)
                throw new PoseidonException(ErrorCode.DuplicateNumber);

            entity.Status = 0;

            return base.Create(entity);
        }

        /// <summary>
        /// 编辑合同
        /// </summary>
        /// <param name="entity">合同实体</param>
        /// <returns></returns>
        public override bool Update(Contract entity)
        {
            var data = this.baseDal.FindOneByField("Number", entity.Number);
            if (data.Id != entity.Id)
            {
                throw new PoseidonException(ErrorCode.DuplicateNumber);
            }

            return base.Update(entity);
        }

        /// <summary>
        /// 删除合同
        /// </summary>
        /// <param name="entity">合同对象</param>
        /// <returns></returns>
        public override bool Delete(Contract entity)
        {
            //if (BusinessFactory<BillingBusiness>.Instance.GetByContract(entity.Id).Count > 0)
            //    return ErrorCode.ContractHasStore;

            //if (BusinessFactory<CargoBusiness>.Instance.GetByContract(entity.Id).Count > 0)
            //    return ErrorCode.ContractHasCargo;

            var result = this.baseDal.Delete(entity);
            return result;
        }
        #endregion //CRUD
    }
}
