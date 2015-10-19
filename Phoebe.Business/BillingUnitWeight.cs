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
            if (cargo == null)
                return 0;

            if (cargo.Status == (int)EntityStatus.CargoNotIn || cargo.Status == (int)EntityStatus.CargoStockInReady)
                return 0;

            decimal totalFee = 0;

            if (cargo.OutTime <= start)
                return 0;

            var stockIns = cargo.StockIns.Where(r => r.Status == (int)EntityStatus.StockIn && r.ConfirmTime >= start && r.ConfirmTime <= end);
            var stockOuts = cargo.StockOuts.Where(r => r.Status == (int)EntityStatus.StockOut && r.ConfirmTime >= start && r.ConfirmTime <= end);

            var transferIns = from r in this.context.Transfers
                              where r.NewCargoID == cargo.ID && r.Status == (int)EntityStatus.Transfer && r.ConfirmTime >= start && r.ConfirmTime <= end
                              select r;

            var transferOuts = from r in this.context.Transfers
                               where r.OldCargoID == cargo.ID && r.Status == (int)EntityStatus.Transfer && r.ConfirmTime >= start && r.ConfirmTime <= end
                               select r;

            if (cargo.Billing.IsTiming)
            {
                int days = 0;
                if (cargo.InTime < start)
                    days = end.Subtract(start).Days;
                else
                    days = end.Subtract(cargo.InTime.Value).Days;

                totalFee = days * cargo.Billing.UnitPrice * Convert.ToDecimal(cargo.TotalWeight.Value);

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
