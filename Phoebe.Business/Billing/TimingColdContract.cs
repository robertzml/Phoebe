using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Business
{
    using Phoebe.Base;
    using Phoebe.Model;

    /// <summary>
    /// 计时冷藏合同
    /// </summary>
    public class TimingColdContract : IContract
    {
        #region Function
        /// <summary>
        /// 计算合同冷藏费
        /// </summary>
        /// <param name="contract">合同</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <param name="billingProcess">计费处理</param>
        /// <returns></returns>
        private decimal CalculateColdFee(Contract contract, DateTime start, DateTime end, IBillingProcess billingProcess)
        {
            decimal totalFee = 0;

            for (DateTime step = start.Date; step <= end; step = step.AddDays(1))
            {
                var storages = BusinessFactory<StoreBusiness>.Instance.GetInDay(contract.Id, step);

                foreach (var storage in storages)
                {
                    decimal totalMeter = billingProcess.GetStoreMeter(storage);
                    totalFee += billingProcess.CalculateDailyFee(totalMeter, storage.UnitPrice);
                }
            }

            return totalFee;
        }
        #endregion //Function

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
            ColdSettlement settle = new ColdSettlement();

            var contract = BusinessFactory<ContractBusiness>.Instance.FindById(contractId);

            IBillingProcess billingProcess = BillingFactory.Create((BillingType)contract.BillingType);

            settle.StartTime = start;
            settle.EndTime = end;
            settle.ContractId = contract.Id;
            settle.ContractName = contract.Name;
            settle.ColdFee = CalculateColdFee(contract, start, end, billingProcess);

            return settle;
        }

        /// <summary>
        /// 获取杂项费用
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        public MiscSettlement GetMisc(int contractId, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
