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

            flow.StoreCount = 0;
            flow.StoreWeight = 0;
            flow.FlowCount = task.InCount;
            flow.UnitWeight = task.UnitWeight;
            flow.FlowWeight = task.InWeight;

            flow.FlowDate = task.InTime;

            flow.Type = StockFlowType.StockIn;
            flow.WarehouseType = task.WarehouseType;

            return flow;
        }

        /// <summary>
        /// 出库任务转流水记录
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        private StockFlow StockOutToStockFlow(StockOutTaskView task)
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

            flow.StoreCount = task.StoreCount;
            flow.StoreWeight = task.StoreWeight;
            flow.FlowCount = task.OutCount;
            flow.UnitWeight = task.UnitWeight;
            flow.FlowWeight = task.OutWeight;

            flow.FlowDate = task.OutTime;

            flow.Type = StockFlowType.StockOut;
            flow.WarehouseType = task.WarehouseType;

            return flow;
        }
        #endregion //Function

        #region Method
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

            foreach (var item in stockInTasks)
            {
                var flow = StockInToStockFlow(item);
                data.Add(flow);
            }

            StockOutTaskViewBusiness stockOutTaskViewBusiness = new StockOutTaskViewBusiness();
            var stockOutTasks = stockOutTaskViewBusiness.Query(r => r.CustomerId == customerId && r.OutTime >= startTime && r.OutTime <= endTime, db);

            foreach (var item in stockOutTasks)
            {
                var flow = StockOutToStockFlow(item);
                data.Add(flow);
            }

            return data.OrderBy(r => r.FlowDate).ToList();
        }

        /// <summary>
        /// 获取客户货品库存
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public List<CustomerCargoStore> GetCustomerCargoStore(int contractId, DateTime date, bool groupByBatch)
        {
            var db = GetInstance();

            List<CustomerCargoStore> data = new List<CustomerCargoStore>();

            // 获取仓位库存
            StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
            var positionStores = storeViewBusiness.GetInDay(contractId, date, db);

            foreach (var store in positionStores)
            {
                if (groupByBatch)
                {
                    if (data.Any(r => r.CargoId == store.CargoId && r.Batch == store.Batch))
                    {
                        // 累加货品库存
                        var s = data.Single(r => r.CargoId == store.CargoId && r.Batch == store.Batch);
                        s.StoreCount += store.StoreCount;
                        s.StoreWeight += store.StoreWeight;

                        continue;
                    }
                }
                else
                {
                    if (data.Any(r => r.CargoId == store.CargoId))
                    {
                        // 累加货品库存
                        var s = data.Single(r => r.CargoId == store.CargoId);
                        s.StoreCount += store.StoreCount;
                        s.StoreWeight += store.StoreWeight;

                        continue;
                    }
                }

                // 生成新货品库存
                CustomerCargoStore cs = new CustomerCargoStore
                {
                    StorageDate = date,
                    CustomerId = store.CustomerId,
                    CustomerNumber = store.CustomerNumber,
                    CustomerName = store.CustomerName,
                    ContractId = store.ContractId,
                    ContractName = store.ContractName,
                    ContractNumber = store.ContractNumber,
                    CargoId = store.CargoId,
                    CargoName = store.CargoName,
                    CategoryNumber = store.CategoryNumber,
                    CategoryName = store.CategoryName,
                    Specification = store.Specification,
                    Batch = groupByBatch ? store.Batch : "",
                    StoreCount = store.StoreCount,
                    UnitWeight = store.UnitWeight,
                    StoreWeight = store.StoreWeight
                };

                data.Add(cs);
            }

            // 获取普通库存
            NormalStoreViewBusiness normalStoreViewBusiness = new NormalStoreViewBusiness();
            var normalStores = normalStoreViewBusiness.GetInDay(contractId, date, db);

            foreach (var store in normalStores)
            {
                if (groupByBatch)
                {
                    if (data.Any(r => r.CargoId == store.CargoId && r.Batch == store.Batch))
                    {
                        // 累加货品库存
                        var s = data.Single(r => r.CargoId == store.CargoId && r.Batch == store.Batch);
                        s.StoreCount += store.StoreCount;
                        s.StoreWeight += store.StoreWeight;

                        continue;
                    }
                }
                else
                {
                    if (data.Any(r => r.CargoId == store.CargoId))
                    {
                        // 累加货品库存
                        var s = data.Single(r => r.CargoId == store.CargoId);
                        s.StoreCount += store.StoreCount;
                        s.StoreWeight += store.StoreWeight;

                        continue;
                    }
                }

                // 生成新货品库存
                CustomerCargoStore cs = new CustomerCargoStore
                {
                    StorageDate = date,
                    CustomerId = store.CustomerId,
                    CustomerNumber = store.CustomerNumber,
                    CustomerName = store.CustomerName,
                    ContractId = store.ContractId,
                    ContractName = store.ContractName,
                    ContractNumber = store.ContractNumber,
                    CargoId = store.CargoId,
                    CargoName = store.CargoName,
                    CategoryNumber = store.CategoryNumber,
                    CategoryName = store.CategoryName,
                    Specification = store.Specification,
                    Batch = groupByBatch ? store.Batch : "",
                    StoreCount = store.StoreCount,
                    UnitWeight = store.UnitWeight,
                    StoreWeight = store.StoreWeight
                };

                data.Add(cs);
            }

            return data;
        }

        /// <summary>
        /// 获取客户总库存
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<CustomerTotalStore> GetCustomerTotalStore(DateTime date)
        {
            var db = GetInstance();

            List<CustomerTotalStore> data = new List<CustomerTotalStore>();

            // 获取所有客户
            CustomerBusiness customerBusiness = new CustomerBusiness();
            var customers = customerBusiness.FindAll(db);

            StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
            NormalStoreViewBusiness normalStoreViewBusiness = new NormalStoreViewBusiness();

            foreach (var customer in customers)
            {
                // 获取仓位库存               
                var positionStores = storeViewBusiness.GetInDayByCustomer(customer.Id, date, db);

                // 获取普通库存
                var normalStores = normalStoreViewBusiness.GetInDayByCustomer(customer.Id, date, db);

                CustomerTotalStore item = new CustomerTotalStore();
                item.StorageDate = date;
                item.CustomerId = customer.Id;
                item.CustomerName = customer.Name;
                item.CustomerNumber = customer.Number;
                item.TotalCount = positionStores.Sum(r => r.StoreCount) + normalStores.Sum(r => r.StoreCount);
                item.TotalWeight = positionStores.Sum(r => r.StoreWeight) + normalStores.Sum(r => r.StoreWeight);

                if (item.TotalCount > 0 || item.TotalWeight > 0)
                    data.Add(item);
            }

            return data;
        }
        #endregion //Method
    }
}
