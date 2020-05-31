using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.Service
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.Billing;
    using Phoebe.Core.BL;
    using Phoebe.Core.DL;
    using Phoebe.Core.Entity;
    using Phoebe.Core.View;
    using Phoebe.Core.Model;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 计费服务类
    /// </summary>
    public class ExpenseService : AbstractService
    {
        #region Cold Fee
        /// <summary>
        /// 获取合同日冷藏费记录
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <param name="contractId">合同ID</param>
        /// <param name="startTime">开始日期</param>
        /// <param name="endTime">结束日期</param>
        /// <returns></returns>
        public (bool success, string errorMessage, List<DailyColdRecord> data) GetDailyColdFee(int customerId, int contractId, DateTime startTime, DateTime endTime)
        {
            try
            {
                var db = GetInstance();

                var contractViewBusiness = new ContractViewBusiness();
                var contract = contractViewBusiness.FindById(contractId, db);

                if (contract.CustomerId != customerId)
                {
                    return (false, "合同不属于该客户", null);
                }
                if (contract.Type == (int)ContractType.Freeze || contract.Type == (int)ContractType.Freeze)
                {
                    return (false, "该合同没有冷藏费", null);
                }
                if (startTime > endTime)
                {
                    return (false, "开始日期大于结束日期", null);
                }

                var contractBill = ContractFactory.Create((ContractType)contract.Type);

                var data = contractBill.GetColdRecord(contractId, startTime, endTime, db);

                return (true, "", data);
            }
            catch (Exception e)
            {
                return (false, e.Message, null);
            }
        }

        /// <summary>
        /// 获取库存冷藏费
        /// </summary>
        /// <param name="storeId">库存ID</param>
        /// <param name="current">当前日期</param>
        /// <param name="storeType">库存类型</param>
        /// <returns></returns>
        public ColdSettlement GetStoreColdFee(string storeId, DateTime current, int storeType)
        {
            var db = GetInstance();

            if (storeType == (int)StoreType.Normal) // 普通库
            {
                NormalStoreViewBusiness normalStoreViewBusiness = new NormalStoreViewBusiness();
                var store = normalStoreViewBusiness.FindById(storeId);

                var contractViewBusiness = new ContractViewBusiness();
                var contract = contractViewBusiness.FindById(store.ContractId, db);

                IContract contractBill = ContractFactory.Create((ContractType)contract.Type);
                IBillingProcess billingProcess = BillingFactory.Create((BillingType)contract.BillingType);

                var storeMeter = billingProcess.GetStoreMeter(store);

                bool isOut = false; // 是否出库
                if (store.OutTime <= current)
                {
                    current = store.OutTime.Value;
                    isOut = true;
                }

                var settle = contractBill.GetStoreColdFee(contract.Id, storeMeter, store.InTime, current, isOut, db);
                return settle;
            }
            else if (storeType == (int)StoreType.Position) // 仓位库
            {
                StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
                var store = storeViewBusiness.FindById(storeId);

                var contractViewBusiness = new ContractViewBusiness();
                var contract = contractViewBusiness.FindById(store.ContractId, db);

                IContract contractBill = ContractFactory.Create((ContractType)contract.Type);
                IBillingProcess billingProcess = BillingFactory.Create((BillingType)contract.BillingType);

                var storeMeter = billingProcess.GetStoreMeter(store);

                bool isOut = false; // 是否出库
                if (store.OutTime <= current)
                {
                    current = store.OutTime.Value;
                    isOut = true;
                }

                var settle = contractBill.GetStoreColdFee(contract.Id, storeMeter, store.InTime, current, isOut, db);
                return settle;
            }

            return null;
        }

        /// <summary>
        /// 获取合同一段时间冷藏费
        /// </summary>
        /// <param name="contractView"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public ColdSettlement GetPeriodColdFee(ContractView contract, DateTime startTime, DateTime endTime, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
            NormalStoreViewBusiness normalStoreViewBusiness = new NormalStoreViewBusiness();

            IContract contractBill = ContractFactory.Create((ContractType)contract.Type);
            IBillingProcess billingProcess = BillingFactory.Create((BillingType)contract.BillingType);

            // 计算冷藏费
            decimal totalColdFee = 0m;
            for (DateTime step = startTime.Date; step <= endTime.Date; step = step.AddDays(1))
            {
                var stores = storeViewBusiness.GetInDay(contract.Id, step, db);
                var totalMeter = billingProcess.GetTotalMeter(stores);
                var dailyFee = billingProcess.CalculateDailyFee(totalMeter, contract.UnitPrice);

                totalColdFee += dailyFee;

                var normalStores = normalStoreViewBusiness.GetInDay(contract.Id, step, db);
                var totalNormalMeter = billingProcess.GetTotalMeter(normalStores);
                var normalDailyFee = billingProcess.CalculateDailyFee(totalNormalMeter, contract.UnitPrice);

                totalColdFee += normalDailyFee;
            }

            ColdSettlement settle = new ColdSettlement();
            settle.ContractId = contract.Id;
            settle.ContractName = contract.Name;
            settle.StartTime = startTime;
            settle.EndTime = endTime;
            settle.UnitPrice = contract.UnitPrice;
            settle.ColdFee = totalColdFee;

            return settle;
        }
        #endregion // Cold Fee

        #region Billings
        /// <summary>
        /// 获取客户一段时间内入库费用
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <param name="startTime">开始日期</param>
        /// <param name="endTime">结束日期</param>
        /// <returns></returns>
        public List<InBillingView> GetPeriodInBilling(int customerId, DateTime startTime, DateTime endTime)
        {
            try
            {
                var db = GetInstance();

                ContractViewBusiness contractViewBusiness = new ContractViewBusiness();
                var contracts = contractViewBusiness.Query(r => r.CustomerId == customerId, db);

                List<InBillingView> data = new List<InBillingView>();

                InBillingViewBusiness inBillingViewBusiness = new InBillingViewBusiness();
                foreach (var contract in contracts)
                {
                    var billings = inBillingViewBusiness.FindPeriod(contract.Id, startTime, endTime);
                    data.AddRange(billings);
                }

                return data;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取客户一段时间内出库费用
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <param name="startTime">开始日期</param>
        /// <param name="endTime">结束日期</param>
        /// <returns></returns>
        public List<OutBillingView> GetPeriodOutBilling(int customerId, DateTime startTime, DateTime endTime)
        {
            try
            {
                var db = GetInstance();

                ContractViewBusiness contractViewBusiness = new ContractViewBusiness();
                var contracts = contractViewBusiness.Query(r => r.CustomerId == customerId, db);

                List<OutBillingView> data = new List<OutBillingView>();

                OutBillingViewBusiness outBillingViewBusiness = new OutBillingViewBusiness();
                foreach (var contract in contracts)
                {
                    var billings = outBillingViewBusiness.FindPeriod(contract.Id, startTime, endTime);
                    data.AddRange(billings);
                }

                return data;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion //Billings
    }
}
