using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
        /// 客户业务类
        /// </summary>
        public ContractBusiness() : base()
        {
            this.dal = new ContractRepository();
            base.Init(this.dal);
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取客户相关合同
        /// </summary>
        /// <param name="customerId">客户Id</param>
        /// <returns></returns>
        public List<Contract> GetByCustomer(int customerId)
        {
            Expression<Func<Contract, bool>> predicate = r => r.CustomerId == customerId;
            return this.dal.Find(predicate).ToList();
        }
        #endregion //Method
    }
}
