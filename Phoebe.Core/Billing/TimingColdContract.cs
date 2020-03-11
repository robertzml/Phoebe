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

            record.TotalMeter = billingProcess.GetTotalMeter(stores);
            record.DailyFee = billingProcess.CalculateDailyFee(record.TotalMeter, contract.UnitPrice);

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
        /// 获取冷藏费用
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public ColdSettlement GetColdFee(int contractId, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
        #endregion //Override
    }
}
