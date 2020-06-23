using System;
using System.Collections.Generic;
using System.Linq;
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
    using System.Runtime.InteropServices.WindowsRuntime;

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
        /// <remarks>
        /// 老算法，每日取库存记录
        /// </remarks>
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

        /// <summary>
        /// 获取合同一段时间冷藏费
        /// </summary>
        /// <param name="contract"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        /// <remarks>
        /// 新算法，先取出时间段内所有库存，再用乘法计算
        /// </remarks>
        public ColdSettlement GetPeriodColdFeeMulti(ContractView contract, DateTime startTime, DateTime endTime, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
            NormalStoreViewBusiness normalStoreViewBusiness = new NormalStoreViewBusiness();

            IContract contractBill = ContractFactory.Create((ContractType)contract.Type);
            IBillingProcess billingProcess = BillingFactory.Create((BillingType)contract.BillingType);

            var totalColdFee = 0m;

            // 计算仓位库库存
            var stores = storeViewBusiness
                .Query(r => r.ContractId == contract.Id && (r.OutTime == null || r.OutTime > startTime) && r.InTime <= endTime, db);
            foreach (var store in stores)
            {
                var coldFee = billingProcess.CalculatePeriodColdFee(store, contract.UnitPrice, startTime, endTime);
                totalColdFee += coldFee;
            }

            // 计算普通库库存
            var normalStores = normalStoreViewBusiness
                .Query(r => r.ContractId == contract.Id && (r.OutTime == null || r.OutTime > startTime) && r.InTime <= endTime, db);
            foreach (var store in normalStores)
            {
                var coldFee = billingProcess.CalculatePeriodColdFee(store, contract.UnitPrice, startTime, endTime);
                totalColdFee += coldFee;
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

        /// <summary>
        /// 获取客户一段时间冷藏费
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <param name="startTime">开始日期</param>
        /// <param name="endTime">结束日期</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public List<ColdSettlement> GetPeriodColdFeeByCustomer(int customerId, DateTime startTime, DateTime endTime, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            List<ColdSettlement> data = new List<ColdSettlement>();

            try
            {
                ContractViewBusiness contractViewBusiness = new ContractViewBusiness();
                var contracts = contractViewBusiness.Query(r => r.CustomerId == customerId, db);

                foreach (var contract in contracts)
                {
                    var settle = GetPeriodColdFee(contract, startTime, endTime, db);
                    data.Add(settle);
                }

                return data;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取客户一段时间冷藏费
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <param name="startTime">开始日期</param>
        /// <param name="endTime">结束日期</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public List<ColdSettlement> GetPeriodColdFeeMultiByCustomer(int customerId, DateTime startTime, DateTime endTime, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            List<ColdSettlement> data = new List<ColdSettlement>();

            try
            {
                ContractViewBusiness contractViewBusiness = new ContractViewBusiness();
                var contracts = contractViewBusiness.Query(r => r.CustomerId == customerId, db);

                foreach (var contract in contracts)
                {
                    var settle = GetPeriodColdFeeMulti(contract, startTime, endTime, db);
                    data.Add(settle);
                }

                return data;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion // Cold Fee

        #region Expense Record
        /// <summary>
        /// 获取合同一段时间内所有费用项目
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <param name="contractId">合同ID</param>
        /// <param name="startTime">开始日期</param>
        /// <param name="endTime">结束日期</param>
        /// <returns></returns>
        public (bool success, string errorMessage, List<ExpenseRecord> data) GetExpenseRecord(int customerId, int contractId, DateTime startTime, DateTime endTime)
        {
            var db = GetInstance();

            var contractViewBusiness = new ContractViewBusiness();
            var contract = contractViewBusiness.FindById(contractId, db);

            if (contract.CustomerId != customerId)
            {
                return (false, "合同不属于该客户", null);
            }
            if (startTime > endTime)
            {
                return (false, "开始日期大于结束日期", null);
            }

            List<ExpenseRecord> data = new List<ExpenseRecord>();

            // 计算冷藏费
            var coldSettlement = GetPeriodColdFeeMulti(contract, startTime, endTime, db);

            ExpenseItemBusiness expenseItemBusiness = new ExpenseItemBusiness();
            ExpenseRecord coldRecord = new ExpenseRecord();
            var coldItem = expenseItemBusiness.Single(r => r.Code == PhoebeConstant.ColdFeeNumber, db);
            coldRecord.Code = coldItem.Code;
            coldRecord.Name = coldItem.Name;
            coldRecord.Type = coldItem.Type;
            coldRecord.Amount = coldSettlement.ColdFee;
            data.Add(coldRecord);

            // 获取其它费用
            InBillingViewBusiness inBillingViewBusiness = new InBillingViewBusiness();
            OutBillingViewBusiness outBillingViewBusiness = new OutBillingViewBusiness();

            var inBillings = inBillingViewBusiness.FindPeriod(contractId, startTime, endTime, db);
            var outBillings = outBillingViewBusiness.FindPeriod(contractId, startTime, endTime, db);

            var expenseItems = expenseItemBusiness.Query(r => r.Code != PhoebeConstant.ColdFeeNumber, db).OrderBy(r => r.Code).ToList();
            foreach (var expenseItem in expenseItems)
            {
                ExpenseRecord record = new ExpenseRecord();
                record.Code = expenseItem.Code;
                record.Name = expenseItem.Name;
                record.Type = expenseItem.Type;

                record.Amount = inBillings.Where(r => r.Code == expenseItem.Code).Sum(r => r.Amount)
                    + outBillings.Where(r => r.Code == expenseItem.Code).Sum(r => r.Amount);

                data.Add(record);
            }

            return (true, "", data);
        }
        #endregion  // Expense Record

        #region Debt
        /// <summary>
        /// 获取客户欠款信息
        /// </summary>
        /// <param name="customer">客户</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public Debt GetDebt(Customer customer, DateTime start, DateTime end, SqlSugarClient db = null)
        {
            try
            {
                if (db == null)
                    db = GetInstance();

                Debt debt = new Debt();
                debt.CustomerId = customer.Id;
                debt.CustomerNumber = customer.Number;
                debt.CustomerName = customer.Name;
                debt.StartTime = start;
                debt.EndTime = end;
                debt.SettleFee = 0;
                debt.UnSettleFee = 0;

                // 获取已结算记录
                SettlementBusiness settlementBusiness = new SettlementBusiness();
                var settles = settlementBusiness.Query(r => r.CustomerId == customer.Id && r.EndTime <= end, db)
                    .OrderByDescending(r => r.EndTime);
                if (settles.Count() != 0)
                {
                    debt.SettleFee = settles.Sum(r => r.DueFee);

                    var last = settles.First();
                    start = last.EndTime.AddDays(1);
                }

                if (start < end)
                {
                    // 获取入库费用
                    InBillingViewBusiness inBillingViewBusiness = new InBillingViewBusiness();
                    var inBillings = inBillingViewBusiness.FindPeriodByCustomer(customer.Id, start, end, db);
                    debt.UnSettleFee += inBillings.Sum(r => r.Amount);

                    // 获取出库费用
                    OutBillingViewBusiness outBillingViewBusiness = new OutBillingViewBusiness();
                    var outBillings = outBillingViewBusiness.FindPeriodByCustomer(customer.Id, start, end, db);
                    debt.UnSettleFee += outBillings.Sum(r => r.Amount);

                    // 获取冷藏费用
                    var coldSettlement = GetPeriodColdFeeMultiByCustomer(customer.Id, start, end, db);
                    debt.UnSettleFee += coldSettlement.Sum(r => r.ColdFee);
                }

                // 获取付款数据
                PaymentBusiness paymentBusiness = new PaymentBusiness();
                var payments = paymentBusiness.Query(r => r.CustomerId == customer.Id && r.PaidTime <= end);
                if (payments.Count() != 0)
                    debt.PaidFee = payments.Sum(r => r.PaidFee);

                debt.SumFee = debt.SettleFee + debt.UnSettleFee;
                debt.DebtFee = debt.SumFee - debt.PaidFee;

                return debt;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// 获取客户实时欠费
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <returns></returns>
        public Debt GetDebt(int customerId)
        {
            var db = GetInstance();

            // 获取客户信息
            CustomerBusiness customerBusiness = new CustomerBusiness();
            var customer = customerBusiness.FindById(customerId, db);

            // 获取合同信息
            ContractViewBusiness contractViewBusiness = new ContractViewBusiness();
            var contracts = contractViewBusiness.Query(r => r.CustomerId == customerId, db);
            if (contracts.Count == 0)   // 没有合同
            {
                Debt debt = new Debt();

                debt.CustomerId = customerId;
                debt.CustomerNumber = customer.Number;
                debt.CustomerName = customer.Name;

                return debt;
            }

            DateTime start = contracts.Min(r => r.SignDate);
            DateTime end = DateTime.Now.Date;

            var deb = this.GetDebt(customer, start, end, db);
            return deb;
        }
        #endregion //Debt

        #region Customer Fee
        /// <summary>
        /// 获取客户费用情况
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public CustomerFee GetCustomerFee(int customerId, DateTime start, DateTime end, SqlSugarClient db = null)
        {
            try
            {
                if (db == null)
                    db = GetInstance();

                var customerFee = new CustomerFee();

                CustomerBusiness customerBusiness = new CustomerBusiness();
                var customer = customerBusiness.FindById(customerId, db);

                customerFee.CustomerId = customer.Id;
                customerFee.CustomerNumber = customer.Number;
                customerFee.CustomerName = customer.Name;
                customerFee.StartTime = start;
                customerFee.EndTime = end;
                customerFee.BaseFee = 0;

                // 获取合同信息
                ContractViewBusiness contractViewBusiness = new ContractViewBusiness();
                var contracts = contractViewBusiness.Query(r => r.CustomerId == customerId, db);

                if (contracts.Count == 0)
                    return customerFee;

                DateTime beginTime = contracts.Min(r => r.SignDate);
                DateTime lastTime = start.AddDays(-1);

                // 获取以前欠款
                var debt = GetDebt(customer, beginTime, lastTime, db);
                customerFee.StartDebt = debt.DebtFee;

                // 获取当前冷藏费用
                var coldSettlement = GetPeriodColdFeeMultiByCustomer(customer.Id, start, end, db);
                customerFee.ColdFee = coldSettlement.Sum(r => r.ColdFee);

                // 获取当前入库费用
                InBillingViewBusiness inBillingViewBusiness = new InBillingViewBusiness();
                var inBillings = inBillingViewBusiness.FindPeriodByCustomer(customerId, start, end, db);
                customerFee.BaseFee += inBillings.Sum(r => r.Amount);

                // 获取当前出库费用
                OutBillingViewBusiness outBillingViewBusiness = new OutBillingViewBusiness();
                var outBillings = outBillingViewBusiness.FindPeriodByCustomer(customerId, start, end, db);
                customerFee.BaseFee += outBillings.Sum(r => r.Amount);

                customerFee.TotalFee = customerFee.StartDebt + customerFee.BaseFee + customerFee.ColdFee + customerFee.MiscFee;

                // 获取缴费
                PaymentBusiness paymentBusiness = new PaymentBusiness();
                var payments = paymentBusiness.Query(r => r.CustomerId == customerId && r.PaidTime >= start && r.PaidTime <= end, db);
                if (payments.Count() != 0)
                    customerFee.ReceiveFee = payments.Sum(r => r.PaidFee);

                // 获取当前结算
                SettlementBusiness settlementBusiness = new SettlementBusiness();

                var currSettle = settlementBusiness.Query(r => r.CustomerId == customerId && r.EndTime >= start && r.EndTime <= end, db);
                if (currSettle.Count() != 0)
                {
                    customerFee.Discount = currSettle.Sum(r => r.Remission);
                }

                customerFee.EndDebt = customerFee.TotalFee - customerFee.ReceiveFee - customerFee.Discount;

                return customerFee;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion //Customer Fee
    }
}
