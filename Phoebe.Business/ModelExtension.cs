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
        #region User
        /// <summary>
        /// 判断用户是否Root
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns></returns>
        public static bool IsRoot(this User user)
        {
            return user.ID == 1;
        }
        #endregion //User

        #region Contract
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
        #endregion //Contract

        #region Cargo
        /// <summary>
        /// 货品相关合同名称
        /// </summary>
        /// <param name="cargo">货品对象</param>
        /// <returns></returns>
        public static string ContractName(this Cargo cargo)
        {
            ContractBusiness contractBusiness = new ContractBusiness();
            var data = contractBusiness.Get(cargo.ContractID);

            if (data == null)
                return "";
            else
                return data.Number + " - " + data.Name;
        }
        #endregion //Cargo

        #region Settlement
        /// <summary>
        /// 结算相关客户名称
        /// </summary>
        /// <param name="settlement">结算对象</param>
        /// <returns></returns>
        public static string CustomerName(this Settlement settlement)
        {
            CustomerBusiness customerBusiness = new CustomerBusiness();

            if (settlement.CustomerType == (int)CustomerType.Group)
            {
                var data = customerBusiness.GetGroupCustomer(settlement.CustomerID);
                if (data == null)
                    return "";
                else
                    return data.Name;
            }
            else if (settlement.CustomerType == (int)CustomerType.Scatter)
            {
                var data = customerBusiness.GetScatterCustomer(settlement.CustomerID);
                if (data == null)
                    return "";
                else
                    return data.Name;
            }
            else
                return "";
        }
        #endregion //Settlement
    }
}
