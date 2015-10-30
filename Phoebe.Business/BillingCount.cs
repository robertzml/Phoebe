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

            var stockOuts = from r in this.context.StockOuts
                            where r.CargoID == cargo.ID && r.Status == (int)EntityStatus.StockOut && r.ConfirmTime >= start && r.ConfirmTime <= end
                            select r;

            var transferOuts = from r in this.context.Transfers
                               where r.OldCargoID == cargo.ID && r.Status == (int)EntityStatus.Transfer && r.ConfirmTime >= start && r.ConfirmTime <= end
                               select r;

            if (cargo.Contract.IsTiming)
            {
                DateTime inTime = cargo.InTime.Value;

                // check is transfer
                bool isTransfer = this.context.Transfers.Any(r => r.NewCargoID == cargo.ID && r.Status == (int)EntityStatus.Transfer);
                if (isTransfer)
                {
                    inTime = this.context.Transfers.Single(r => r.NewCargoID == cargo.ID).ConfirmTime.Value;
                }

                int days = 0;
                if (inTime < start)
                    days = end.Subtract(start).Days + 1;
                else
                    days = end.Subtract(inTime).Days + 1;

                totalFee = days * cargo.Billing.UnitPrice * cargo.Count;

                // get store out
                foreach (var item in stockOuts)
                {
                    if (item.ConfirmTime > end)
                        continue;

                    decimal dailyFee = cargo.Billing.UnitPrice * item.StockOutDetails.Sum(r => r.Count);
                    totalFee -= (end.Subtract(item.ConfirmTime.Value).Days + 1) * dailyFee;
                }

                // get trans out
                foreach (var item in transferOuts)
                {
                    if (item.ConfirmTime > end)
                        continue;

                    decimal dailyFee = cargo.Billing.UnitPrice * item.TransferDetails.Sum(r => r.Count);
                    totalFee -= (end.Subtract(item.ConfirmTime.Value).Days + 1) * dailyFee;
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
            var cargos = contract.Cargoes.Where(r => r.Status != (int)EntityStatus.CargoNotIn && r.Status != (int)EntityStatus.CargoStockInReady);

            decimal totalFee = 0;

            foreach (var cargo in cargos)
            {
                decimal fee = CalculateColdPrice(cargo, start, end);
                totalFee += fee;
            }

            return totalFee;
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
        /// 计算货品总数
        /// </summary>
        /// <param name="unitMeter">单位</param>
        /// <param name="count">数量</param>
        /// <returns>总件数</returns>
        public decimal CalculateTotalMeter(decimal unitMeter, int count)
        {
            return count;
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
        #endregion //Method
    }
}
