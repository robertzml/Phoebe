using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.BL
{
    using Phoebe.Base.Framework;
    using Phoebe.Core.View;

    /// <summary>
    /// 合同视图类
    /// </summary>
    public class ContractViewBusiness : AbstractBusiness<ContractView, int>, IBaseBL<ContractView, int>
    {
        #region Method
        /// <summary>
        /// 按客户获取
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public List<ContractView> FindByCustomer(int customerId)
        {
            var db = GetInstance();
            return db.Queryable<ContractView>().Where(r => r.CustomerId == customerId).ToList();
        }
        #endregion //Method
    }
}
