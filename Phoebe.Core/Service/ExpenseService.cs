using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.Service
{
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.Billing;
    using Phoebe.Core.DL;
    using Phoebe.Core.Model;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 计费服务类
    /// </summary>
    public class ExpenseService : AbstractService
    {
        #region Method
        /// <summary>
        /// 获取合同日冷藏费记录
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <param name="contractId">合同ID</param>
        /// <param name="startTime">开始日期</param>
        /// <param name="endTime">结束日期</param>
        /// <returns></returns>
        public (bool success, string errorMessage, List<DailyColdRecord> data) GetDailyColdFee(int customerId, int contractId, DateTime startTime, DateTime endTime)
        {
            try
            {
                var db = GetInstance();

                var contractViewBusiness = new ContractViewBusiness();
                var contract = contractViewBusiness.FindById(contractId, db);

                if (contract.CustomerId != customerId)
                {
                    return (false, "合同不属于该客户", null);
                }

                var contractBill = ContractFactory.Create((ContractType)contract.Type);

                var data = contractBill.GetColdRecord(contractId, startTime, endTime, db);

                return (true, "", data);
            }
            catch (Exception e)
            {
                return (false, e.Message, null);
            }
        }
        #endregion //Method
    }
}
