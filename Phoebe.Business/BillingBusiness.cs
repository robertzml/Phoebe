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
        /// 获取所有基本费用
        /// </summary>
        /// <param name="cargoID">货品ID</param>
        /// <returns></returns>
        /// <remarks>
        /// 除冷藏费外所有费用
        /// </remarks>
        public decimal GetTotalBasePrice(string cargoID)
        {
            Guid gid;
            if (!Guid.TryParse(cargoID, out gid))
                return 0;

            var billing = this.context.Billings.Find(gid);
            if (billing == null)
                return 0;

            decimal total = billing.HandlingPrice + billing.FreezePrice + billing.DisposePrice +
                billing.PackingPrice + billing.RentPrice + billing.OtherPrice;

            return total;
        }

        /// <summary>
        /// 计算冷藏费
        /// </summary>
        /// <param name="cargoID">货品ID</param>
        /// <returns></returns>
        public decimal CalculateColdPrice(string cargoID)
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

            return billingProcess.CalculateColdPrice(cargo.ID, cargo.InTime.Value, DateTime.Now);
        }

        /// <summary>
        /// 计算冷藏费
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
        /// 获取日冷藏费记录
        /// </summary>
        /// <param name="contractID">合同ID</param>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public List<DailyColdRecord> GetDailyColdRecord(int contractID, DateTime date)
        {
            List<DailyColdRecord> records = new List<DailyColdRecord>();
            StoreBusiness storeBusiness = new StoreBusiness();
            var stores = storeBusiness.GetInDay(contractID, date);
            var flows = storeBusiness.GetDaysFlow(contractID, date);

            foreach (var flow in flows)
            {
                DailyColdRecord frecord = new DailyColdRecord();
                frecord.RecordDate = date;

                frecord.CargoName = flow.CargoName;
                frecord.Count = flow.Count;

                IBillingProcess billingProcess = null;

                var cargo = this.context.Cargoes.Find(flow.CargoID);
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
                IBillingProcess billingProcess = null;
                decimal totalMeter = 0;
                var cargo = this.context.Cargoes.Find(item.CargoID);

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

                decimal unitMeter = billingProcess.GetUnitMeter(cargo);
                totalMeter = billingProcess.CalculateTotalMeter(unitMeter, item.Count);

                record.TotalMeter += totalMeter;
                record.DailyFee += billingProcess.CalculateDailyFee(totalMeter, cargo.Billing.UnitPrice);
            }

            if (flows.Count == 0)
                records.Add(record);

            return records;
        }
        #endregion //Method
    }
}
