using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Business
{
    using Phoebe.Base;
    using Phoebe.Model;

    /// <summary>
    /// 冰块合同
    /// </summary>
    public class IceContract : IContract
    {
        #region Field
        /// <summary>
        /// 费用名称
        /// </summary>
        private string feeName = "冰块费用";
        #endregion //Field

        #region Method
        /// <summary>
        /// 获取基本费用
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        public List<BaseSettlement> GetBaseFee(int contractId, DateTime start, DateTime end)
        {
            return null;
        }

        /// <summary>
        /// 获取冷藏费用
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public ColdSettlement GetColdFee(int contractId, DateTime start, DateTime end)
        {
            return null;
        }

        /// <summary>
        /// 获取合同日冷藏费记录 
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public List<DailyColdRecord> GetColdRecord(int contractId, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取杂项费用
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        public MiscSettlement GetMiscFee(int contractId, DateTime start, DateTime end)
        {
            MiscSettlement settle = new MiscSettlement();

            var contract = BusinessFactory<ContractBusiness>.Instance.FindById(contractId);
            var sales = BusinessFactory<IceSaleBusiness>.Instance.GetByContract(contractId, start, end);

            settle.ContractId = contractId;
            settle.ContractName = contract.Name;
            settle.StartTime = start;
            settle.EndTime = end;
            settle.FeeName = this.feeName;
            settle.TotalFee = sales.Sum(r => r.SaleFee);

            return settle;
        }
        #endregion //Method
    }
}
