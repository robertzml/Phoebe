using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

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
        /// 冷藏费计算
        /// </summary>
        /// <param name="cargoID">货品ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        public decimal CalculateColdPrice(string cargoID, DateTime start, DateTime end)
        {
            Guid gid;
            if (!Guid.TryParse(cargoID, out gid))
                return 0;

            var cargo = this.context.Cargoes.Find(gid);
            if (cargo == null || cargo.Billing == null)
                return 0;

            if (cargo.Status == (int)EntityStatus.CargoNotIn || cargo.Status == (int)EntityStatus.CargoStockInReady)
                return 0;

            if (cargo.InTime > end || cargo.OutTime <= start)
                return 0;

            decimal totalFee = 0;

            var stockOuts = from r in this.context.StockOuts
                            where r.CargoID == cargo.ID && r.Status == (int)EntityStatus.StockOut && r.ConfirmTime >= start && r.ConfirmTime <= end
                            select r;

            if (cargo.Billing.IsTiming)
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

                totalFee = days * cargo.Billing.UnitPrice * Convert.ToDecimal(cargo.TotalWeight.Value);

                // get store out
                foreach (var item in stockOuts)
                {
                    if (item.ConfirmTime > end)
                        continue;

                    decimal dailyFee = cargo.Billing.UnitPrice * Convert.ToDecimal(cargo.UnitWeight.Value) * item.StockOutDetails.Sum(r => r.Count) / 1000;
                    totalFee -= (end.Subtract(item.ConfirmTime.Value).Days + 1) * dailyFee;
                }

            }
            else
            {
                totalFee = cargo.Billing.UnitPrice * Convert.ToDecimal(cargo.TotalWeight.Value);
            }

            return totalFee;
        }
        #endregion //Method
    }
}
