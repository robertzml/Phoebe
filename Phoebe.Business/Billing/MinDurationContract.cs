using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Business
{
    using Phoebe.Base;
    using Phoebe.Business.DAL;
    using Phoebe.Model;

    /// <summary>
    /// 最短时间合同
    /// </summary>
    public class MinDurationContract : IContract
    {
        #region Field
        private string feeName = "最短时间费用";
        #endregion //Field

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

            string existFlowNumber = "";
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
                    if (flow.FlowNumber != existFlowNumber)
                    {
                        var stockIn = BusinessFactory<StockInBusiness>.Instance.GetByFlowNumber(flow.FlowNumber);
                        frecord.HandlingFee = stockIn.Billing.HandlingPrice;
                        existFlowNumber = flow.FlowNumber;
                    }
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
                record.DailyFee += billingProcess.CalculateDailyFee(totalMeter, storage.UnitPrice);
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
        /// <remarks>
        /// 利用乘法计算费用
        /// </remarks>
        private decimal CalculateColdFee2(Contract contract, DateTime start, DateTime end, IBillingProcess billingProcess)
        {
            decimal totalFee = 0;
            int days = end.Subtract(start).Days + 1;

            var startStorages = BusinessFactory<StoreBusiness>.Instance.GetInDay(contract.Id, start.AddDays(-1));
            foreach (var storage in startStorages)
            {
                decimal totalMeter = billingProcess.GetStoreMeter(storage);
                totalFee += billingProcess.CalculatePeriodFee(totalMeter, storage.UnitPrice, days);
            }

            var stockIns = RepositoryFactory<StockInDetailsRepository>.Instance.Find(r => r.StockIn.ContractId == contract.Id && r.StockIn.InTime >= start && r.StockIn.InTime <= end && r.Status == (int)EntityStatus.StockIn);
            foreach (var item in stockIns)
            {
                Storage storage = new Storage();
                storage.Count = item.Count;
                storage.StoreWeight = item.InWeight;
                storage.StoreVolume = item.InVolume;

                int day = end.Subtract(item.StockIn.InTime).Days + 1;
                decimal totalMeter = billingProcess.GetStoreMeter(storage);
                totalFee += billingProcess.CalculatePeriodFee(totalMeter, item.Store.UnitPrice, day);
            }

            var stockOuts = RepositoryFactory<StockOutDetailsRepository>.Instance.Find(r => r.StockOut.ContractId == contract.Id && r.StockOut.OutTime >= start && r.StockOut.OutTime <= end && r.Status == (int)EntityStatus.StockOut);
            foreach (var item in stockOuts)
            {
                Storage storage = new Storage();
                storage.Count = item.Count;
                storage.StoreWeight = item.OutWeight;
                storage.StoreVolume = item.OutVolume;

                int day = end.Subtract(item.StockOut.OutTime).Days + 1;
                decimal totalMeter = billingProcess.GetStoreMeter(storage);
                totalFee -= billingProcess.CalculatePeriodFee(totalMeter, item.Store.UnitPrice, day);
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
                bs.StockInId = item.StockInId;
                bs.TakeTime = item.StockIn.InTime;
                bs.UnitPrice = item.UnitPrice;
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
            settle.ColdFee = CalculateColdFee2(contract, start, end, billingProcess);

            return settle;
        }

        /// <summary>
        /// 获取杂项费用
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        public List<MiscSettlement> GetMiscFee(int contractId, DateTime start, DateTime end)
        {
            List<MiscSettlement> data = new List<MiscSettlement>();

            var contract = BusinessFactory<ContractBusiness>.Instance.FindById(contractId);

            int minDays = Convert.ToInt32(contract.Parameter1);

            // get stock out
            var stockOuts = RepositoryFactory<StockOutDetailsRepository>.Instance.Find(r => r.StockOut.ContractId == contractId && r.StockOut.OutTime >= start && r.StockOut.OutTime <= end && r.Status == (int)EntityStatus.StockOut);

            foreach (var item in stockOuts)
            {
                var store = item.Store;

                var siDetail = RepositoryFactory<StockInDetailsRepository>.Instance.FindOne(r => r.StoreId == store.Id);

                int days = item.StockOut.OutTime.Subtract(siDetail.StockIn.InTime).Days;                

                if (days < minDays)
                {
                    IBillingProcess billingProcess = BillingFactory.Create((BillingType)contract.BillingType);

                    MiscSettlement settle = new MiscSettlement();
                    settle.ContractId = contractId;
                    settle.ContractName = contract.Name;
                    settle.StartTime = start;
                    settle.EndTime = end;
                    settle.FeeName = this.feeName;
                    settle.Remark = string.Format("出库单号:{0}", item.StockOut.FlowNumber);

                    StockFlow flow = new StockFlow();
                    flow.FlowCount = item.Count;
                    flow.FlowWeight = item.OutWeight;
                    flow.FlowVolume = item.OutVolume;

                    decimal totalMeter = billingProcess.GetFlowMeter(flow);
                    settle.TotalFee = billingProcess.CalculatePeriodFee(totalMeter, store.UnitPrice, minDays - days);

                    data.Add(settle);
                }
            }

            return data;
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
                totalFee += last.DailyFee;
                last.TotalFee = totalFee;

                records.AddRange(record);
            }

            return records;
        }
        #endregion //Method
    }
}
