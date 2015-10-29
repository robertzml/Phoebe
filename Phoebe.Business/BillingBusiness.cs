using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        /// 检查货品信息及状态
        /// </summary>
        /// <param name="cargoID">货品ID</param>
        /// <returns></returns>
        private Cargo checkCargo(string cargoID)
        {
            Guid gid;
            if (!Guid.TryParse(cargoID, out gid))
                return null;

            var cargo = this.context.Cargoes.Find(gid);
            if (cargo == null || cargo.Billing == null)
                return null;

            if (cargo.Status == (int)EntityStatus.CargoNotIn || cargo.Status == (int)EntityStatus.CargoStockInReady)
                return null;

            return cargo;
        }

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
            var stores = storeBusiness.GetInDay(cargo.ID, date);
            var flows = storeBusiness.GetDaysFlow(cargo.ID, date);

            // set daily flow
            foreach (var flow in flows)
            {
                DailyColdRecord frecord = new DailyColdRecord();
                frecord.RecordDate = date;

                frecord.CargoName = flow.CargoName;
                frecord.Count = flow.Count;
                frecord.UnitMeter = billingProcess.GetUnitMeter(cargo);
                frecord.StoreMeter = billingProcess.CalculateTotalMeter(frecord.UnitMeter, flow.Count);

                records.Add(frecord);
            }

            DailyColdRecord record;
            if (flows.Count != 0)
                record = records.Last();
            else
            {
                record = new DailyColdRecord();
                record.RecordDate = date;
            }

            foreach (var item in stores)
            {
                decimal unitMeter = billingProcess.GetUnitMeter(cargo);
                decimal totalMeter = billingProcess.CalculateTotalMeter(unitMeter, item.Count);

                record.TotalMeter += totalMeter;
                record.DailyFee += billingProcess.CalculateDailyFee(totalMeter, cargo.Billing.UnitPrice);
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
            var stores = storeBusiness.GetInDay(contract.ID, date);
            var flows = storeBusiness.GetDaysFlow(contract.ID, date);

            foreach (var flow in flows)
            {
                DailyColdRecord frecord = new DailyColdRecord();
                frecord.RecordDate = date;
                frecord.CargoName = flow.CargoName;
                frecord.Count = flow.Count;

                var cargo = this.context.Cargoes.Find(flow.CargoID);

                frecord.UnitMeter = billingProcess.GetUnitMeter(cargo);
                frecord.StoreMeter = billingProcess.CalculateTotalMeter(frecord.UnitMeter, flow.Count);

                records.Add(frecord);
            }

            DailyColdRecord record;
            if (flows.Count != 0)
                record = records.Last();
            else
            {
                record = new DailyColdRecord();
                record.RecordDate = date;
            }

            foreach (var item in stores)
            {
                decimal totalMeter = 0;
                var cargo = this.context.Cargoes.Find(item.CargoID);

                decimal unitMeter = billingProcess.GetUnitMeter(cargo);
                totalMeter = billingProcess.CalculateTotalMeter(unitMeter, item.Count);

                record.TotalMeter += totalMeter;
                record.DailyFee += billingProcess.CalculateDailyFee(totalMeter, cargo.Billing.UnitPrice);
            }

            if (flows.Count == 0)
                records.Add(record);

            return records;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 获取计费
        /// </summary>
        /// <param name="cargoID">货品ID</param>
        /// <returns></returns>
        public Billing Get(string cargoID)
        {
            Guid gid;
            if (!Guid.TryParse(cargoID, out gid))
                return null;

            return this.context.Billings.Find(gid);
        }

        /// <summary>
        /// 编辑计费
        /// </summary>
        /// <param name="data">计费数据</param>
        /// <returns></returns>
        public ErrorCode Edit(Billing data)
        {
            try
            {
                this.context.Entry(data).State = EntityState.Modified;
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 计算货品冷藏费
        /// </summary>
        /// <param name="cargoID">货品ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public decimal CalculateColdPrice(string cargoID, out DateTime start, out DateTime end)
        {
            Cargo cargo = checkCargo(cargoID);
            start = end = DateTime.Now.Date;
            if (cargo == null)
                return 0;

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
                default:
                    return 0;
            }

            // check cargo is trans in
            var trans = this.context.Transfers.SingleOrDefault(r => r.NewCargoID == cargo.ID && r.Status == (int)EntityStatus.Transfer);
            if (trans == null)
                start = cargo.InTime.Value;
            else
                start = trans.ConfirmTime.Value;

            if (cargo.OutTime == null)
                end = DateTime.Now.Date;
            else
                end = cargo.OutTime.Value;

            return billingProcess.CalculateColdPrice(cargo.ID, start, end);
        }

        /// <summary>
        /// 计算货品冷藏费
        /// </summary>
        /// <param name="cargoID">货品ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public decimal CalculateColdPrice(string cargoID, DateTime start, DateTime end)
        {
            Cargo cargo = checkCargo(cargoID);
            if (cargo == null)
                return 0;

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
                default:
                    return 0;
            }

            return billingProcess.CalculateColdPrice(cargo.ID, start, end);
        }

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
        #endregion //Method
    }
}
