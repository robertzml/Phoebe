using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Business
{
    using Phoebe.Base;
    using Phoebe.Model;

    /// <summary>
    /// 速冻合同
    /// </summary>
    public class FreezeContract : IContract
    {
        #region Method
        /// <summary>
        /// 获取基本费用
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        public List<BaseSettlement> GetBaseFee(int contractId, DateTime start, DateTime end)
        {
            var billings = BusinessFactory<BillingBusiness>.Instance.GetByContract(contractId, start, end);

            List<BaseSettlement> data = new List<BaseSettlement>();
            foreach (var item in billings)
            {
                BaseSettlement bs = new BaseSettlement();
                bs.ContractId = contractId;
                bs.ContractName = item.Contract.Name;
                bs.StockInId = item.StockInId;
                bs.TakeTime = item.StockIn.InTime;
                bs.HandlingUnitPrice = item.HandlingUnitPrice;
                bs.HandlingPrice = item.HandlingPrice;
                bs.FreezeUnitPrice = item.FreezeUnitPrice;
                bs.FreezePrice = item.FreezePrice;
                bs.DisposePrice = item.DisposePrice;
                bs.PackingPrice = item.PackingPrice;
                bs.RentPrice = item.RentPrice;
                bs.OtherPrice = item.OtherPrice;
                bs.TotalPrice = item.TotalPrice;
                bs.Remark = item.Remark;

                data.Add(bs);
            }

            return data;
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
        /// 获取杂项费用
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        public MiscSettlement GetMisc(int contractId, DateTime start, DateTime end)
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
        #endregion //Method
    }
}
