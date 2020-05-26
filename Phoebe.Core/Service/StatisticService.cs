using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Core.Service
{
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.Billing;
    using Phoebe.Core.BL;
    using Phoebe.Core.DL;
    using Phoebe.Core.Entity;
    using Phoebe.Core.View;
    using Phoebe.Core.Model;
    using Phoebe.Core.Utility;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 统计服务类
    /// </summary>
    public class StatisticService : AbstractService
    {
        #region Function
        /// <summary>
        /// 入库任务转流水记录
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        private StockFlow StockInToStockFlow(StockInTaskView task)
        {
            StockFlow flow = new StockFlow();
            flow.StockId = task.Id;
            flow.FlowNumber = task.FlowNumber;

            flow.CustomerId = task.CustomerId;
            flow.CustomerName = task.CustomerName;
            flow.CustomerNumber = task.CustomerNumber;
            flow.ContractId = task.ContractId;
            flow.ContractName = task.ContractName;

            flow.CargoId = task.CargoId;
            flow.CargoName = task.CargoName;
            flow.CategoryName = task.CategoryName;
            flow.CategoryNumber = task.CategoryNumber;

            flow.Specification = task.Specification;
            flow.Batch = task.Batch;

            flow.StoreCount = 0;
            flow.FlowCount = task.InCount;
            flow.UnitWeight = task.UnitWeight;
            flow.FlowWeight = task.InWeight;

            flow.FlowDate = task.InTime;

            flow.Type = StockFlowType.StockIn;

            return flow;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 获取合同一段时间内所有费用记录
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <param name="contractId">合同ID</param>
        /// <param name="startTime">开始日期</param>
        /// <param name="endTime">结束日期</param>
        /// <returns></returns>
        public (bool success, string errorMessage, List<ExpenseRecord> data) GetPeriodExpense(int customerId, int contractId, DateTime startTime, DateTime endTime)
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

            StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
            NormalStoreViewBusiness normalStoreViewBusiness = new NormalStoreViewBusiness();
            ExpenseItemBusiness expenseItemBusiness = new ExpenseItemBusiness();

            IContract contractBill = ContractFactory.Create((ContractType)contract.Type);
            IBillingProcess billingProcess = BillingFactory.Create((BillingType)contract.BillingType);

            List<ExpenseRecord> data = new List<ExpenseRecord>();

            // 计算冷藏费
            decimal totalColdFee = 0m;
            for (DateTime step = startTime.Date; step <= endTime.Date; step = step.AddDays(1))
            {
                var stores = storeViewBusiness.GetInDay(contractId, step, db);
                var totalMeter = billingProcess.GetTotalMeter(stores);
                var dailyFee = billingProcess.CalculateDailyFee(totalMeter, contract.UnitPrice);

                totalColdFee += dailyFee;

                var normalStores = normalStoreViewBusiness.GetInDay(contractId, step, db);
                var totalNormalMeter = billingProcess.GetTotalMeter(normalStores);
                var normalDailyFee = billingProcess.CalculateDailyFee(totalNormalMeter, contract.UnitPrice);

                totalColdFee += normalDailyFee;
            }

            ExpenseRecord coldRecord = new ExpenseRecord();
            var coldItem = expenseItemBusiness.Single(r => r.Code == PhoebeConstant.ColdFeeNumber, db);
            coldRecord.Code = coldItem.Code;
            coldRecord.Name = coldItem.Name;
            coldRecord.Type = coldItem.Type;
            coldRecord.Amount = totalColdFee;

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

        /// <summary>
        /// 获取客户出入库流水
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <param name="startTime">开始日期</param>
        /// <param name="endTime">结束日期</param>
        /// <returns></returns>
        public List<StockFlow> GetCustomerStockFlow(int customerId, DateTime startTime, DateTime endTime)
        {
            var db = GetInstance();

            List<StockFlow> data = new List<StockFlow>();

            StockInTaskViewBusiness stockInTaskViewBusiness = new StockInTaskViewBusiness();
            var stockInTasks = stockInTaskViewBusiness.Query(r => r.CustomerId == customerId && r.InTime >= startTime && r.InTime <= endTime, db);



            return data;
        }
        #endregion //Method
    }
}
