using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 件体积计费
    /// </summary>
    public class BillingUnitVolume : IBillingProcess
    {
        #region Field
        private PhoebeContext context;
        #endregion //Field

        #region Constructor
        public BillingUnitVolume()
        {
            this.context = new PhoebeContext();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 冷藏费计算
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

                totalFee = days * cargo.UnitPrice * Convert.ToDecimal(cargo.TotalVolume);

                // get store out
                var stockOuts = from r in this.context.StockOutDetails
                                where r.CargoID == cargo.ID && r.Status == (int)EntityStatus.StockOut &&
                                    r.StockOut.OutTime >= start && r.StockOut.OutTime <= end
                                select r;
                foreach (var item in stockOuts)
                {
                    decimal dailyFee = cargo.UnitPrice * Convert.ToDecimal(cargo.UnitVolume) * item.Count;
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
                    decimal dailyFee = cargo.UnitPrice * Convert.ToDecimal(cargo.UnitVolume) * item.Count;
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
        /// 获取单位体积
        /// </summary>
        /// <param name="cargo">货品</param>
        /// <returns></returns>
        public decimal GetUnitMeter(Cargo cargo)
        {
            return Convert.ToDecimal(cargo.UnitVolume);
        }

        /// <summary>
        /// 获取出入库体积
        /// </summary>
        /// <param name="flow">流水记录</param>
        /// <returns></returns>
        public decimal GetFlowMeter(StockFlow flow, decimal unitMeter)
        {
            if (flow.Type == StockFlowType.StockOut || flow.Type == StockFlowType.StockMoveOut)
                return -flow.Count * unitMeter;
            else
                return flow.Count * unitMeter;
        }

        /// <summary>
        /// 获取在库体积
        /// </summary>
        /// <param name="storage">库存记录</param>
        /// <returns></returns>
        public decimal GetStoreMeter(Storage storage, decimal unitMeter)
        {
            return storage.Count * unitMeter;
        }

        /// <summary>
        /// 计算货品日冷藏费
        /// </summary>
        /// <param name="totalMeter">总体积(m3)</param>
        /// <param name="unitPrice">单价(元/m3)</param>
        /// <returns></returns>
        public decimal CalculateDailyFee(decimal totalMeter, decimal unitPrice)
        {
            return totalMeter * unitPrice;
        }
        #endregion //Method
    }
}
