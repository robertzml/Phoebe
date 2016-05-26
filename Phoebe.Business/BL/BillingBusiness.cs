using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Phoebe.Business
{
    using Phoebe.Base;
    using Phoebe.Model;
    using Phoebe.Business.DAL;

    /// <summary>
    /// 计费业务类
    /// </summary>
    public class BillingBusiness : BaseBusiness<Billing>
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IBaseDataAccess<Billing> dal;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 计费业务类
        /// </summary>
        public BillingBusiness() : base()
        {
            this.dal = RepositoryFactory<BillingRepository>.Instance;
            base.Init(this.dal);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 获取库存对应计费信息
        /// </summary>
        /// <param name="storage">库存对象</param>
        /// <returns></returns>
        private Billing GetByStorage(Storage storage)
        {
            var store = BusinessFactory<StoreBusiness>.Instance.FindById(storage.StoreId);

            // find the origin store
            while ((SourceType)store.Source != SourceType.StockIn)
            {
                var smd = RepositoryFactory<StockMoveDetailsRepository>.Instance.FindOne(r => r.NewStoreId == store.Id);
                store = smd.SourceStore;
            }

            var sid = RepositoryFactory<StockInDetailsRepository>.Instance.FindOne(r => r.StoreId == store.Id);
            var billing = this.dal.FindById(sid.StockInId);
            return billing;
        }

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
                frecord.Count = flow.Count;

                var cargo = BusinessFactory<CargoBusiness>.Instance.FindById(flow.CargoId);

                frecord.UnitMeter = billingProcess.GetUnitMeter(cargo);
                frecord.FlowMeter = billingProcess.GetFlowMeter(flow);
                frecord.FlowType = flow.Type;

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
                var cargo = BusinessFactory<CargoBusiness>.Instance.FindById(storage.CargoId);

                decimal unitMeter = billingProcess.GetUnitMeter(cargo);
                decimal totalMeter = billingProcess.GetStoreMeter(storage);

                record.TotalMeter += totalMeter;
                var billing = GetByStorage(storage);
                record.DailyFee += billingProcess.CalculateDailyFee(totalMeter, billing.UnitPrice);
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
                var storages = BusinessFactory<StoreBusiness>.Instance.GetInDay(contract.Id, step);

                foreach (var storage in storages)
                {
                    var cargo = BusinessFactory<CargoBusiness>.Instance.FindById(storage.CargoId);

                    decimal unitMeter = billingProcess.GetUnitMeter(cargo);
                    decimal totalMeter = billingProcess.GetStoreMeter(storage);
                    var billing = GetByStorage(storage);

                    totalFee += billingProcess.CalculateDailyFee(totalMeter, billing.UnitPrice);
                }
            }

            return totalFee;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 获取库存的计费信息
        /// </summary>
        /// <param name="store">库存对象</param>
        /// <returns></returns>
        public Billing GetByStore(Store store)
        {
            // find the origin store
            while ((SourceType)store.Source != SourceType.StockIn)
            {
                var smd = RepositoryFactory<StockMoveDetailsRepository>.Instance.FindOne(r => r.NewStoreId == store.Id);
                store = smd.SourceStore;
            }

            var sid = RepositoryFactory<StockInDetailsRepository>.Instance.FindOne(r => r.StoreId == store.Id);
            var billing = this.dal.FindById(sid.StockInId);
            return billing;
        }

        /// <summary>
        /// 获取合同的计费信息
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <returns></returns>
        public List<Billing> GetByContract(int contractId)
        {
            return this.dal.Find(r => r.ContractId == contractId).ToList();
        }

        /// <summary>
        /// 获取合同日冷藏费记录 
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public List<DailyColdRecord> GetContractColdRecord(int contractId, DateTime start, DateTime end)
        {
            List<DailyColdRecord> records = new List<DailyColdRecord>();
            var contract = BusinessFactory<ContractBusiness>.Instance.FindById(contractId);
            if (contract == null || !contract.IsTiming)
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

        /// <summary>
        /// 按客户获取基本费用
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public List<Billing> CalculateBaseFee(int customerId, DateTime start, DateTime end)
        {
            var billings = this.dal.Find(r => r.Status == (int)EntityStatus.Normal && r.StockIn.InTime >= start && r.StockIn.InTime <= end &&
                r.Contract.CustomerId == customerId);

            return billings.ToList();
        }

        /// <summary>
        /// 按客户获取冷藏费用
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public List<ColdSettlement> CalculateColdFee(int customerId, DateTime start, DateTime end)
        {
            List<ColdSettlement> data = new List<ColdSettlement>();

            var contracts = BusinessFactory<ContractBusiness>.Instance.GetByCustomer(customerId);

            foreach (var contract in contracts)
            {
                IBillingProcess billingProcess = BillingFactory.Create((BillingType)contract.BillingType);

                ColdSettlement settle = new ColdSettlement();
                settle.StartTime = start;
                settle.EndTime = end;
                settle.ContractId = contract.Id;
                settle.ContractName = contract.Name;
                settle.ColdFee = CalculateColdFee(contract, start, end, billingProcess);

                data.Add(settle);
            }

            return data;
        }
        #endregion //Method
    }
}
