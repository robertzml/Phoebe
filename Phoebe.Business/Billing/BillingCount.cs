using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Business
{
    using Phoebe.Base;
    using Phoebe.Business.DAL;
    using Phoebe.Model;

    /// <summary>
    /// 计数计费
    /// </summary>
    public class BillingCount : IBillingProcess
    {
        #region Method
        /// <summary>
        /// 获取单位计量
        /// </summary>
        /// <param name="cargo">货品</param>
        /// <returns></returns>
        public decimal GetUnitMeter(Cargo cargo)
        {
            return 1;
        }

        /// <summary>
        /// 获取出入库数量
        /// </summary>
        /// <param name="flow">流水记录</param>
        /// <returns></returns>
        public decimal GetFlowMeter(StockFlow flow)
        {
            if (flow.Type == StockFlowType.StockOut || flow.Type == StockFlowType.StockMoveOut)
                return -flow.Count;
            else
                return flow.Count;
        }

        /// <summary>
        /// 获取在库数量
        /// </summary>
        /// <param name="storage">库存记录</param>
        /// <returns></returns>
        public decimal GetStoreMeter(Storage storage)
        {
            return storage.Count;
        }

        /// <summary>
        /// 计算日冷藏费
        /// </summary>
        /// <param name="totalMeter">总数量</param>
        /// <param name="unitPrice">单价</param>
        /// <returns></returns>
        public decimal CalculateDailyFee(decimal totalMeter, decimal unitPrice)
        {
            return totalMeter * unitPrice;
        }

        /// <summary>
        /// 计算合同冷藏费
        /// </summary>
        /// <param name="contract">合同对象</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        public decimal CalculateColdFee(Contract contract, DateTime start, DateTime end)
        {
            if (!contract.IsTiming)
                return 0;

            //find store
            var stores = RepositoryFactory<StoreRepository>.Instance.Find(r => r.Cargo.ContractId == contract.Id && r.InTime <= end && (r.OutTime == null || r.OutTime > start));
            if (stores.Count() == 0)
                return 0;

            decimal totalFee = 0;
            foreach (var item in stores)
            {
                DateTime inTime = item.MoveTime;

                int days = 0;
                if (inTime < start)
                    days = end.Subtract(start).Days + 1;
                else
                    days = end.Subtract(inTime).Days + 1;

                var billing = BusinessFactory<BillingBusiness>.Instance.GetByStore(item);
                totalFee += days * billing.UnitPrice * item.TotalCount;

                // get store out
                var stockOuts = RepositoryFactory<StockOutDetailsRepository>.Instance.Find(r => r.StoreId == item.Id && r.Status == (int)EntityStatus.StockOut &&
                    r.StockOut.OutTime >= start && r.StockOut.OutTime <= end);
                foreach (var so in stockOuts)
                {
                    decimal dailyFee = billing.UnitPrice * so.Count;
                    totalFee -= (end.Subtract(so.StockOut.OutTime).Days + 1) * dailyFee;
                }
            }

            return totalFee;
        }
        #endregion //Method
    }
}
