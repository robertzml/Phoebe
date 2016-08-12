using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Business
{
    using Phoebe.Base;
    using Phoebe.Model;

    /// <summary>
    /// 非计时冷藏合同
    /// </summary>
    public class UntimingColdContract : IContract
    {
        #region Function
        /// <summary>
        /// 获取合同日冷藏费记录
        /// </summary>
        /// <param name="contract">合同对象</param>
        /// <param name="date">日期</param>
        /// <param name="billingProcess">计费处理</param>
        /// <returns></returns>
        private List<DailyColdRecord> GetDailyColdRecord(Contract contract, DateTime date, IBillingProcess billingProcess)
        {
            List<DailyColdRecord> records = new List<DailyColdRecord>();

            var flows = BusinessFactory<StoreBusiness>.Instance.GetDayFlow(contract.Id, date, false);
            var storages = BusinessFactory<StoreBusiness>.Instance.GetInDay(contract.Id, date);

            foreach (var flow in flows)
            {
                DailyColdRecord frecord = new DailyColdRecord();
                frecord.RecordDate = date;
                frecord.CategoryNumber = flow.CategoryNumber;
                frecord.CategoryName = flow.CategoryName;
                frecord.Count = flow.FlowCount;

                frecord.UnitMeter = billingProcess.GetUnitMeter(flow);
                frecord.FlowMeter = billingProcess.GetFlowMeter(flow);
                frecord.FlowType = flow.Type;

                if (flow.Type == StockFlowType.StockIn)
                {
                    frecord.DailyFee = billingProcess.CalculateDailyFee(frecord.FlowMeter, flow.UnitPrice);
                }
                records.Add(frecord);
            }

            DailyColdRecord record;
            if (flows.Count != 0)
                record = records.Last();
            else
            {
                record = new DailyColdRecord();
                record.RecordDate = date;
                record.FlowType = StockFlowType.None;
            }

            foreach (var storage in storages)
            {
                decimal totalMeter = billingProcess.GetStoreMeter(storage);

                record.TotalMeter += totalMeter;
            }

            if (flows.Count == 0)
                records.Add(record);

            return records;
        }

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
                var flows = BusinessFactory<StoreBusiness>.Instance.GetDayFlow(contract.Id, step, false).Where(r => r.Type == StockFlowType.StockIn);

                foreach (var flow in flows)
                {
                    decimal flowMeter = billingProcess.GetFlowMeter(flow);
                    totalFee += billingProcess.CalculateDailyFee(flowMeter, flow.UnitPrice);
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

        public MiscSettlement GetMisc(int contractId, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
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
            List<DailyColdRecord> records = new List<DailyColdRecord>();
            var contract = BusinessFactory<ContractBusiness>.Instance.FindById(contractId);
            if (contract == null)
                return records;

            IBillingProcess billingProcess = BillingFactory.Create((BillingType)contract.BillingType);

            decimal totalFee = 0;
            for (DateTime step = start.Date; step <= end; step = step.AddDays(1))
            {
                var record = GetDailyColdRecord(contract, step, billingProcess);

                var last = record.Last();
                totalFee += record.Sum(r => r.DailyFee);
                last.TotalFee = totalFee;

                records.AddRange(record);
            }

            return records;
        }
        #endregion //Method
    }
}
