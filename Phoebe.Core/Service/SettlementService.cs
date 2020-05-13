using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.Service
{
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.Billing;
    using Phoebe.Core.BL;
    using Phoebe.Core.DL;
    using Phoebe.Core.Entity;
    using Phoebe.Core.View;
    using Phoebe.Core.Model;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 结算服务类
    /// </summary>
    public class SettlementService : AbstractService
    {
        #region Method
        /// <summary>
        /// 获取客户一段时间内入库费用
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <param name="startTime">开始日期</param>
        /// <param name="endTime">结束日期</param>
        /// <returns></returns>
        public List<InBillingView> GetPeriodInBilling(int customerId, DateTime startTime, DateTime endTime)
        {
            try
            {
                var db = GetInstance();

                ContractViewBusiness contractViewBusiness = new ContractViewBusiness();
                var contracts = contractViewBusiness.Query(r => r.CustomerId == customerId, db);

                List<InBillingView> data = new List<InBillingView>();

                InBillingViewBusiness inBillingViewBusiness = new InBillingViewBusiness();
                foreach (var contract in contracts)
                {
                    var billings = inBillingViewBusiness.FindPeriod(contract.Id, startTime, endTime);
                    data.AddRange(billings);
                }

                return data;
            }
            catch (Exception e)
            {               
                return null;
            }
        }

        /// <summary>
        /// 获取客户一段时间内出库费用
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <param name="startTime">开始日期</param>
        /// <param name="endTime">结束日期</param>
        /// <returns></returns>
        public List<OutBillingView> GetPeriodOutBilling(int customerId, DateTime startTime, DateTime endTime)
        {
            try
            {
                var db = GetInstance();

                ContractViewBusiness contractViewBusiness = new ContractViewBusiness();
                var contracts = contractViewBusiness.Query(r => r.CustomerId == customerId, db);

                List<OutBillingView> data = new List<OutBillingView>();

                OutBillingViewBusiness outBillingViewBusiness = new OutBillingViewBusiness();
                foreach (var contract in contracts)
                {
                    var billings = outBillingViewBusiness.FindPeriod(contract.Id, startTime, endTime);
                    data.AddRange(billings);
                }

                return data;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion //Method
    }
}
 