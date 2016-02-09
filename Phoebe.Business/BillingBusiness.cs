using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 计费业务类
    /// </summary>
    public class BillingBusiness
    {
        #region Field
        private PhoebeContext context;
        #endregion //Field

        #region Constructor
        public BillingBusiness()
        {
            this.context = new PhoebeContext();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 获取货品单日冷藏记录
        /// </summary>
        /// <param name="cargo">货品对象</param>
        /// <param name="date">日期</param>
        /// <param name="billingProcess">计费接口</param>
        /// <returns></returns>
        private List<DailyColdRecord> GetDailyColdRecord(Cargo cargo, DateTime date, IBillingProcess billingProcess)
        {
            List<DailyColdRecord> records = new List<DailyColdRecord>();

            StoreBusiness storeBusiness = new StoreBusiness();
            var storages = storeBusiness.GetInDay(cargo.ID, date);
            var flows = storeBusiness.GetDaysFlow(cargo.ID, date).Where(r => r.CountChange == true).ToList();

            // set daily flow
            foreach (var flow in flows)
            {
                DailyColdRecord frecord = new DailyColdRecord();
                frecord.RecordDate = date;

                frecord.CargoName = flow.CargoName;
                frecord.Count = flow.Count;
                frecord.UnitMeter = billingProcess.GetUnitMeter(cargo);
                frecord.FlowMeter = billingProcess.GetFlowMeter(flow, frecord.UnitMeter);
                frecord.FlowType = flow.Type;

                records.Add(frecord);
            }

            // get the last record or init an empty record
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
                decimal unitMeter = billingProcess.GetUnitMeter(cargo);
                decimal totalMeter = billingProcess.GetStoreMeter(storage, unitMeter);

                record.TotalMeter += totalMeter;
                record.DailyFee += billingProcess.CalculateDailyFee(totalMeter, cargo.UnitPrice);
            }

            if (flows.Count == 0)
                records.Add(record);

            return records;
        }

        /// <summary>
        /// 获取合同单日冷藏记录
        /// </summary>
        /// <param name="contract">合同对象</param>
        /// <param name="date">日期</param>
        /// <param name="billingProcess">计费接口</param>
        /// <returns></returns>
        private List<DailyColdRecord> GetDailyColdRecord(Contract contract, DateTime date, IBillingProcess billingProcess)
        {
            List<DailyColdRecord> records = new List<DailyColdRecord>();

            StoreBusiness storeBusiness = new StoreBusiness();
            var storages = storeBusiness.GetInDay(contract.ID, date);
            var flows = storeBusiness.GetDaysFlow(contract.ID, date).Where(r => r.CountChange == true).ToList();

            foreach (var flow in flows)
            {
                DailyColdRecord frecord = new DailyColdRecord();
                frecord.RecordDate = date;
                frecord.CargoName = flow.CargoName;
                frecord.Count = flow.Count;

                var cargo = this.context.Cargoes.Find(flow.CargoID);

                frecord.UnitMeter = billingProcess.GetUnitMeter(cargo);
                frecord.FlowMeter = billingProcess.GetFlowMeter(flow, frecord.UnitMeter);
                frecord.FlowType = flow.Type;

                records.Add(frecord);
            }

            // get the last record or init an empty record
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
                var cargo = this.context.Cargoes.Find(storage.CargoID);

                decimal unitMeter = billingProcess.GetUnitMeter(cargo);
                decimal totalMeter = billingProcess.GetStoreMeter(storage, unitMeter);

                record.TotalMeter += totalMeter;
                record.DailyFee += billingProcess.CalculateDailyFee(totalMeter, cargo.UnitPrice);
            }

            if (flows.Count == 0)
                records.Add(record);

            return records;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 获取货品日冷藏记录
        /// </summary>
        /// <param name="cargoID">货品ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public List<DailyColdRecord> GetCargoColdRecord(Guid cargoID, DateTime start, DateTime end)
        {
            List<DailyColdRecord> records = new List<DailyColdRecord>();

            var cargo = this.context.Cargoes.Find(cargoID);
            if (!cargo.Contract.IsTiming)
                return records;

            IBillingProcess billingProcess = null;
            switch ((BillingType)cargo.Contract.BillingType)
            {
                case BillingType.UnitWeight:
                    billingProcess = new BillingUnitWeight();
                    break;
                case BillingType.UnitVolume:
                    billingProcess = new BillingUnitVolume();
                    break;
                case BillingType.Count:
                    billingProcess = new BillingCount();
                    break;
            }

            decimal totalFee = 0;
            for (DateTime step = start.Date; step <= end; step = step.AddDays(1))
            {
                var record = GetDailyColdRecord(cargo, step, billingProcess);
                var last = record.Last();

                totalFee += last.DailyFee;
                last.TotalFee = totalFee;

                records.AddRange(record);
            }

            return records;
        }

        /// <summary>
        /// 获取合同日冷藏费记录
        /// </summary>
        /// <param name="contractID">合同ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public List<DailyColdRecord> GetContractColdRecord(int contractID, DateTime start, DateTime end)
        {
            List<DailyColdRecord> records = new List<DailyColdRecord>();
            var contract = this.context.Contracts.Find(contractID);
            if (contract == null || !contract.IsTiming)
                return records;

            IBillingProcess billingProcess = null;
            switch ((BillingType)contract.BillingType)
            {
                case BillingType.UnitWeight:
                    billingProcess = new BillingUnitWeight();
                    break;
                case BillingType.UnitVolume:
                    billingProcess = new BillingUnitVolume();
                    break;
                case BillingType.Count:
                    billingProcess = new BillingCount();
                    break;
            }

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

        /// <summary>
        /// 计算合同冷藏费
        /// </summary>
        /// <param name="contractID">合同ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public decimal CalculateContractColdPrice(int contractID, DateTime start, DateTime end)
        {
            var contract = this.context.Contracts.Find(contractID);
            if (contract == null || !contract.IsTiming)
                return 0;

            IBillingProcess billingProcess = null;
            switch ((BillingType)contract.BillingType)
            {
                case BillingType.UnitWeight:
                    billingProcess = new BillingUnitWeight();
                    break;
                case BillingType.UnitVolume:
                    billingProcess = new BillingUnitVolume();
                    break;
                case BillingType.Count:
                    billingProcess = new BillingCount();
                    break;
                default:
                    return 0;
            }

            return billingProcess.CalculateContractColdPrice(contract, start, end);
        }
        #endregion //Method
    }
}
