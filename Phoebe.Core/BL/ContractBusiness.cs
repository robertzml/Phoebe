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
        #endregion //CRUD
    }
}
