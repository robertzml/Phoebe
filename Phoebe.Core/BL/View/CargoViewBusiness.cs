using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.BL
{
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.View;

    public class CargoViewBusiness : AbstractBusiness<CargoView, string>, IBaseBL<CargoView, string>
    {
        #region Method
        /// <summary>
        /// 按客户获取货物
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="contractId"></param>
        /// <returns></returns>
        public List<CargoView> FindByCustomer(int customerId, int contractId = 0)
        {
            var db = GetInstance();

            if (contractId == 0)
                return db.Queryable<CargoView>().Where(r => r.CustomerId == customerId).ToList();
            else
                return db.Queryable<CargoView>().Where(r => r.CustomerId == customerId && r.ContractId == contractId).ToList();
        }
        #endregion //Method
    }
}
