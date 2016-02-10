using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 计数计费
    /// </summary>
    public class BillingCount : IBillingProcess
    {
        #region Field
        private PhoebeContext context;
        #endregion //Field

        #region Constructor
        public BillingCount()
        {
            this.context = new PhoebeContext();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 货品冷藏费计算
        /// </summary>
        /// <param name="cargo">货品对象</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        public decimal CalculateColdPrice(Cargo cargo, DateTime start, DateTime end)
        {
            if (cargo.InTime > end || cargo.OutTime <= start)
                return 0;

            decimal totalFee = 0;

            if (cargo.Contract.IsTiming)
            {
                DateTime inTime = cargo.InTime.Value;

                int days = 0;
                if (inTime < start)
                    days = end.Subtract(start).Days + 1;
                else
                    days = end.Subtract(inTime).Days + 1;

                totalFee = days * cargo.UnitPrice * cargo.Count;

                // get store out
                var stockOuts = from r in this.context.StockOutDetails
                                where r.CargoID == cargo.ID && r.Status == (int)EntityStatus.StockOut &&
                                    r.StockOut.OutTime >= start && r.StockOut.OutTime <= end
                                select r;
                foreach (var item in stockOuts)
                {
                    decimal dailyFee = cargo.UnitPrice * item.Count;
                    totalFee -= (end.Subtract(item.StockOut.OutTime).Days + 1) * dailyFee;
                }

                // get move out
                var stockMoves = from r in this.context.StockMoveDetails
                                 where r.SourceCargoID == cargo.ID && r.Status == (int)EntityStatus.StockMove &&
                                    r.StockMove.MoveTime >= start && r.StockMove.MoveTime <= end
                                 select r;
                foreach (var item in stockMoves)
                {
                    if (item.Count == item.StoreCount)
                        continue;
                    decimal dailyFee = cargo.UnitPrice * item.Count;
                    totalFee -= (end.Subtract(item.StockMove.MoveTime).Days + 1) * dailyFee;
                }
            }
            else
            {
                totalFee = 0;
            }

            return totalFee;
        }

        /// <summary>
        /// 合同冷藏费计算
        /// </summary>
        /// <param name="contract">合同对象</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public decimal CalculateContractColdPrice(Contract contract, DateTime start, DateTime end)
        {
            var cargos = contract.Cargoes.Where(r => r.Status != (int)EntityStatus.CargoNotIn);

            decimal totalFee = 0;

            foreach (var cargo in cargos)
            {
                decimal fee = CalculateColdPrice(cargo, start, end);
                totalFee += fee;
            }

            return totalFee;
        }

        /// <summary>
        /// 计算货品日冷藏费
        /// </summary>
        /// <param name="totalMeter">总件数</param>
        /// <param name="unitPrice">单价(元/件)</param>
        /// <returns></returns>
        public decimal CalculateDailyFee(decimal totalMeter, decimal unitPrice)
        {
            return totalMeter * unitPrice;
        }

        /// <summary>
        /// 获取单位
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
        /// <param name="unitMeter">单位计量</param>
        /// <returns></returns>
        public decimal GetFlowMeter(StockFlow flow, decimal unitMeter)
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
        /// <param name="unitMeter">单位计量</param>
        /// <returns></returns>
        public decimal GetStoreMeter(Storage storage, decimal unitMeter)
        {
            return storage.Count;
        }
        #endregion //Method
    }
}
