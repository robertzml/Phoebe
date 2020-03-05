using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.Service
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.Entity;
    using Phoebe.Core.View;
    using Phoebe.Core.Model;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 库存服务类
    /// </summary>
    public class StoreService : AbstractService
    {
        #region Function
        /// <summary>
        /// 设置库存流水
        /// </summary>
        /// <param name="stockInTask">入库任务</param>
        /// <param name="date">流水日期</param>
        /// <param name="flowType">流水类型</param>
        /// <returns></returns>
        private StockFlow SetStockFlow(StockInTaskView stockInTask, DateTime date, StockFlowType flowType)
        {
            StockFlow stockFlow = new StockFlow();
            stockFlow.StockId = stockInTask.Id;
            stockFlow.FlowNumber = stockInTask.FlowNumber;

            stockFlow.CustomerId = stockInTask.CustomerId;
            stockFlow.CustomerNumber = stockInTask.CustomerNumber;
            stockFlow.CustomerName = stockInTask.CustomerName;

            stockFlow.ContractId = stockInTask.ContractId;
            stockFlow.ContractName = stockInTask.ContractName;

            stockFlow.CargoId = stockInTask.CargoId;
            stockFlow.CategoryNumber = stockInTask.CategoryNumber;
            stockFlow.CategoryName = stockInTask.CategoryName;
            stockFlow.Specification = stockInTask.Specification;

            stockFlow.FlowCount = stockInTask.InCount;
            stockFlow.UnitWeight = stockInTask.UnitWeight;
            stockFlow.FlowWeight = stockInTask.InWeight;

            stockFlow.FlowDate = date;
            stockFlow.Type = flowType;

            return stockFlow;
        }
        #endregion //Function

        #region Flow
        /// <summary>
        /// 获取合同库存流水
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="date">日期</param>
        /// <param name="includeMove">是否包含移库</param>
        /// <returns></returns>
        public (bool success, string errorMessage, List<StockFlow> data) GetDayFlow(int contractId, DateTime date, bool includeMove = true)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                date = date.Date;

                List<StockFlow> data = new List<StockFlow>();

                // 获取入库记录
                var stockInTasks = db.Queryable<StockInTaskView>()
                    .Where(r => r.ContractId == contractId && r.InTime == date && r.Status == (int)EntityStatus.StockInFinish)
                    .ToList();
                foreach (var item in stockInTasks)
                {
                    //var flow = SetStockFlow(item.Store, item.Id, item.StockIn.FlowNumber, 0, item.Count, item.InWeight, item.InVolume, item.StockIn.InTime, StockFlowType.StockIn);
                    //data.Add(flow);
                }

                db.Ado.CommitTran();
                return (true, "", null);
            }
            catch (Exception e)
            {
                return (false, e.Message, null);
            }
        }
        #endregion //Flow
    }
}
