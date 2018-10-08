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
    /// 客户业务类
    /// </summary>
    public class CustomerBusiness : AbstractBusiness<Customer, int>, IBaseBL<Customer, int>
    {
        #region Constructor
        /// <summary>
        /// 客户业务类
        /// </summary>
        public CustomerBusiness()
        {
            this.baseDal = RepositoryFactory<ICustomerRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 根据编码获取客户
        /// </summary>
        /// <param name="number">客户编码</param>
        /// <returns></returns>
        public Customer FindByNumber(string number)
        {
            var data = this.baseDal.FindOneByField("Number", number);
            return data;
        }
        #endregion //Method

        #region CRUD
        /// <summary>
        /// 添加客户
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public override Customer Create(Customer entity)
        {
            var count = this.baseDal.Count("Number", entity.Number);
            if (count != 0)
                throw new PoseidonException(ErrorCode.DuplicateNumber);

            entity.Status = 0;

            return base.Create(entity);
        }

        /// <summary>
        /// 编辑客户
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public override (bool success, string errorMessage) Update(Customer entity)
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
