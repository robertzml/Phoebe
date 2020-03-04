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

                var data = contractBill.GetDailyColdRecord(contractId, startTime, endTime, db);                               

                return (true, "", data);
            }
            catch(Exception e)
            {
                return (false, e.Message, null);
            }
        }
        #endregion //Method
    }
}
