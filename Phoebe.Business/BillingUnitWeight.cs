using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;
using System.Diagnostics.Contracts;
namespace Phoebe.Business
{
    /// <summary>
    /// 件重计费
    /// </summary>
    public class BillingUnitWeight : IBillingProcess
    {
        #region Field
        private PhoebeContext context;
        #endregion //Field

        #region Constructor
        public BillingUnitWeight()
        {
            this.context = new PhoebeContext();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 货品冷藏费计算
        /// </summary>
        /// <param name="cargoID">货品ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        public decimal CalculateColdPrice(Guid cargoID, DateTime start, DateTime end)
        {
            var cargo = this.context.Cargoes.Find(cargoID);

            if (cargo.InTime > end || cargo.OutTime <= start)
                return 0;

            decimal totalFee = 0;

            if (cargo.Contract.IsTiming)
            {
                var stockOuts = from r in this.context.StockOuts
                                where r.CargoID == cargo.ID && r.Status == (int)EntityStatus.StockOut && r.ConfirmTime >= start && r.ConfirmTime <= end
                                select r;

                var transferOuts = from r in this.context.Transfers
                                   where r.OldCargoID == cargo.ID && r.Status == (int)EntityStatus.Transfer && r.ConfirmTime >= start && r.ConfirmTime <= end
                                   select r;

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

                totalFee = days * cargo.Billing.UnitPrice * Convert.ToDecimal(cargo.TotalWeight);

                // get store out
                foreach (var item in stockOuts)
                {
                    if (item.ConfirmTime > end)
                        continue;

                    decimal dailyFee = cargo.Billing.UnitPrice * Convert.ToDecimal(cargo.UnitWeight) * item.StockOutDetails.Sum(r => r.Count) / 1000;
                    totalFee -= (end.Subtract(item.ConfirmTime.Value).Days + 1) * dailyFee;
                }

                // get trans out
                foreach (var item in transferOuts)
                {
                    if (item.ConfirmTime > end)
                        continue;

                    decimal dailyFee = cargo.Billing.UnitPrice * Convert.ToDecimal(cargo.UnitWeight) * item.TransferDetails.Sum(r => r.Count) / 1000;
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
        /// 获取单位重量
        /// </summary>
        /// <param name="cargo">货品</param>
        /// <returns></returns>
        public decimal GetUnitMeter(Cargo cargo)
        {
            return Convert.ToDecimal(cargo.UnitWeight);
        }

        /// <summary>
        /// 计算货品总重量
        /// </summary>
        /// <param name="unitMeter">单位重量(kg)</param>
        /// <param name="count">数量</param>
        /// <returns>总重量(t)</returns>
        public decimal CalculateTotalMeter(decimal unitMeter, int count)
        {
            return unitMeter * count / 1000;
        }

        /// <summary>
        /// 计算货品日冷藏费
        /// </summary>
        /// <param name="totalMeter">总重量(t)</param>
        /// <param name="unitPrice">单价(元/t)</param>
        /// <returns></returns>
        public decimal CalculateDailyFee(decimal totalMeter, decimal unitPrice)
        {
            return totalMeter * unitPrice;
        }
        #endregion //Method
    }
}
