using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    public static class ModelExtension
    {
        /// <summary>
        /// 合同相关客户名称
        /// </summary>
        /// <param name="contract">合同对象</param>
        /// <returns></returns>
        public static string CustomerName(this Contract contract)
        {
            CustomerBusiness customerBusiness = new CustomerBusiness();

            if (contract.CustomerType == (int)CustomerType.Group)
            {
                var data = customerBusiness.GetGroupCustomer(contract.CustomerID);
                if (data == null)
                    return "";
                else
                    return data.Name;
            }
            else if (contract.CustomerType == (int)CustomerType.Scatter)
            {
                var data = customerBusiness.GetScatterCustomer(contract.CustomerID);
                if (data == null)
                    return "";
                else
                    return data.Name;
            }
            else
                return "";
        }
    }
}
