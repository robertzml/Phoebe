using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Core.Billing
{
    using SqlSugar;
    using Phoebe.Core.DL;
    using Phoebe.Core.Model;
    using Phoebe.Core.Entity;
    using Phoebe.Core.View;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 计时冷藏合同
    /// </summary>
    public class TimingColdContract : IContract
    {
        #region Function
        /// <summary>
        /// 获取日冷藏费记录
        /// </summary>
        /// <param name="contract"></param>
        /// <param name="date"></param>
        /// <param name="billingProcess"></param>
        /// <returns></returns>
        private List<DailyColdRecord> GetDailyColdRecord(ContractView contract, DateTime date, IBillingProcess billingProcess, SqlSugarClient db)
        {
            List<DailyColdRecord> records = new List<DailyColdRecord>();

            StockInTaskViewBusiness stockInTaskViewBusiness = new StockInTaskViewBusiness();
            var stockInTasks = stockInTaskViewBusiness.FindByDate(contract.Id, date, db);

            foreach (var item in stockInTasks)
            {
                DailyColdRecord r = new DailyColdRecord();
                r.RecordDate = date;
                r.CargoName = item.CargoName;
                r.Count = item.InCount;

                r.UnitMeter = billingProcess.GetUnitMeter(item);
                r.FlowMeter = billingProcess.GetFlowMeter(item);
                r.FlowType = StockFlowType.StockIn;

                records.Add(r);
            }

            StockOutTaskViewBusiness stockOutTaskViewBusiness = new StockOutTaskViewBusiness();
            var stockOutTasks = stockOutTaskViewBusiness.FindByDate(contract.Id, date, db);

            foreach (var item in stockOutTasks)
            {
                DailyColdRecord r = new DailyColdRecord();
                r.RecordDate = date;
                r.CargoName = item.CargoName;
                r.Count = item.OutCount;

                r.UnitMeter = billingProcess.GetUnitMeter(item);
                r.FlowMeter = billingProcess.GetFlowMeter(item);
                r.FlowType = StockFlowType.StockOut;

                records.Add(r);
            }

            DailyColdRecord record;
            if (records.Count != 0)
                record = records.Last();
            else
            {
                record = new DailyColdRecord();
                record.RecordDate = date;
                record.FlowType = StockFlowType.None;
            }

            // 获取每日库存记录
            var stores = db.Queryable<StoreView>()
               .Where(r => r.ContractId == contract.Id && r.InTime <= date && (r.OutTime == null || r.OutTime > date))
               .ToList();
            var totalMeter = billingProcess.GetTotalMeter(stores);
            var dailyFee = billingProcess.CalculateDailyFee(totalMeter, contract.UnitPrice);

            // 获取每日普通库存记录
            var normalStores = db.Queryable<NormalStoreView>()
                .Where(r => r.ContractId == contract.Id && r.InTime <= date && (r.OutTime == null || r.OutTime > date))
                .ToList();
            var totalNormalMeter = billingProcess.GetTotalMeter(normalStores);
            var totalDailyFee = billingProcess.CalculateDailyFee(totalNormalMeter, contract.UnitPrice);

            record.TotalMeter = totalMeter + totalNormalMeter;
            record.DailyFee = dailyFee + totalDailyFee;

            if (records.Count == 0)
                records.Add(record);

            return records;
        }
        #endregion //Function

        #region Override
        /// <summary>
        /// 获取合同日冷藏费记录 
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public List<DailyColdRecord> GetColdRecord(int contractId, DateTime startTime, DateTime endTime, SqlSugarClient db)
        {
            List<DailyColdRecord> records = new List<DailyColdRecord>();

            var contract = db.Queryable<ContractView>().InSingle(contractId);

            IBillingProcess billingProcess = BillingFactory.Create((BillingType)contract.BillingType);

            decimal totalFee = 0;

            for (DateTime step = startTime.Date; step <= endTime.Date; step = step.AddDays(1))
            {
                var record = GetDailyColdRecord(contract, step, billingProcess, db);

                var last = record.Last();
                totalFee += last.DailyFee;
                last.TotalFee = totalFee;

                records.AddRange(record);
            }

            return records;
        }

        /// <summary>
        /// 获取库存冷藏费用
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="storeMeter">库存计量</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <param name="isOut">是否出库</param>
        /// <returns></returns>
        public ColdSettlement GetStoreColdFee(int contractId, decimal storeMeter, DateTime start, DateTime end, bool isOut, SqlSugarClient db)
        {
            ColdSettlement settle = new ColdSettlement();

            var contract = db.Queryable<ContractView>().InSingle(contractId);

            settle.ContractId = contract.Id;
            settle.ContractName = contract.Name;
            settle.StartTime = start;
            settle.EndTime = end;
            settle.Days = end.Subtract(start).Days;

            if (!isOut) //未出库则结束日计算冷藏费
                settle.Days += 1;

            settle.UnitPrice = contract.UnitPrice;
            settle.TotalMeter = storeMeter;

            IBillingProcess billingProcess = BillingFactory.Create((BillingType)contract.BillingType);
            settle.ColdFee = billingProcess.CalculatePeriodFee(storeMeter, settle.UnitPrice, settle.Days);
            settle.ColdFee = Math.Round(settle.ColdFee, 3);

            return settle;
        }

        /// <summary>
        /// 计算冷藏费差价
        /// </summary>
        /// <param name="contract">合同</param>
        /// <param name="store">出库库存记录</param>
        /// <param name="backStore">放回的库存记录</param>
        /// <param name="db"></param>
        /// <returns></returns>
        /// <remarks>
        /// 在出库确认时计算冷藏费差价
        /// </remarks>
        public (int days, decimal meter, decimal fee) CalculateDiffColdFee(Contract contract, NormalStoreView store, NormalStoreView backStore, SqlSugarClient db)
        {
            int minDay = Convert.ToInt32(contract.Parameter1);

            int diff = minDay - (store.OutTime.Value - store.InitialTime).Days;

            if (diff > 0)
            {
                IBillingProcess billingProcess = BillingFactory.Create((BillingType)contract.BillingType);
                var storeMeter = billingProcess.GetStoreMeter(store);

                decimal backMeter = 0;
                if (backStore != null)
                    backMeter = billingProcess.GetStoreMeter(backStore);

                var fee = billingProcess.CalculatePeriodFee(storeMeter - backMeter, contract.UnitPrice, diff);

                return (diff, storeMeter - backMeter, fee);
            }
            else
                return (0, 0, 0);
        }

        /// <summary>
        /// 计算冷藏费差价
        /// </summary>
        /// <param name="contract">合同</param>
        /// <param name="store">出库库存记录</param>
        /// <param name="backStore">放回的库存记录</param>
        /// <param name="db"></param>
        /// <returns></returns>
        /// <remarks>
        /// 在出库确认时计算冷藏费差价
        /// </remarks>
        public (int days, decimal meter, decimal fee) CalculateDiffColdFee(Contract contract, StoreView store, StoreView backStore, SqlSugarClient db)
        {
            int minDay = Convert.ToInt32(contract.Parameter1);

            int diff = minDay - (store.OutTime.Value - store.InitialTime).Days;

            if (diff > 0)
            {
                IBillingProcess billingProcess = BillingFactory.Create((BillingType)contract.BillingType);
                var storeMeter = billingProcess.GetStoreMeter(store);

                decimal backMeter = 0;
                if (backStore != null)
                    backMeter = billingProcess.GetStoreMeter(backStore);

                var fee = billingProcess.CalculatePeriodFee(storeMeter - backMeter, contract.UnitPrice, diff);

                return (diff, storeMeter - backMeter, fee);
            }
            else
                return (0, 0, 0);
        }
        #endregion //Override
    }
}
