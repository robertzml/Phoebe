using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 计费业务类
    /// </summary>
    public class BillingBusiness
    {
        #region Field
        private PhoebeContext context;
        #endregion //Field

        #region Constructor
        public BillingBusiness()
        {
            this.context = new PhoebeContext();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 检查货品信息及状态
        /// </summary>
        /// <param name="cargoID">货品ID</param>
        /// <returns></returns>
        private Cargo checkCargo(string cargoID)
        {
            Guid gid;
            if (!Guid.TryParse(cargoID, out gid))
                return null;

            var cargo = this.context.Cargoes.Find(gid);
            if (cargo == null || cargo.Billing == null)
                return null;

            if (cargo.Status == (int)EntityStatus.CargoNotIn || cargo.Status == (int)EntityStatus.CargoStockInReady)
                return null;

            return cargo;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 获取所有费用
        /// </summary>
        /// <param name="cargoID">货品ID</param>
        /// <returns></returns>
        /// <remarks>
        /// 除冷藏费外所有费用
        /// </remarks>
        public decimal GetTotalPrice(string cargoID)
        {
            Guid gid;
            if (!Guid.TryParse(cargoID, out gid))
                return 0;

            var billing = this.context.Billings.Find(gid);
            if (billing == null)
                return 0;

            decimal total = billing.HandlingPrice + billing.FreezePrice + billing.DisposePrice +
                billing.PackingPrice + billing.RentPrice + billing.OtherPrice;

            return total;
        }

        /// <summary>
        /// 计算冷藏费
        /// </summary>
        /// <param name="cargoID">货品ID</param>
        /// <returns></returns>
        public decimal GetColdPrice(string cargoID)
        {
            Cargo cargo = checkCargo(cargoID);
            if (cargo == null)
                return 0;

            IBillingProcess billingProcess = null;
            switch ((BillingType)cargo.Billing.BillingType)
            {
                case BillingType.UnitWeight:
                    billingProcess = new BillingUnitWeight();
                    break;
                default:
                    return 0;
            }

            return billingProcess.CalculateColdPrice(cargo.ID, cargo.InTime.Value, DateTime.Now);
        }

        /// <summary>
        /// 计算冷藏费
        /// </summary>
        /// <param name="cargoID">货品ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public decimal GetColdPrice(string cargoID, DateTime start, DateTime end)
        {
            Cargo cargo = checkCargo(cargoID);
            if (cargo == null)
                return 0;

            IBillingProcess billingProcess = null;
            switch ((BillingType)cargo.Billing.BillingType)
            {
                case BillingType.UnitWeight:
                    billingProcess = new BillingUnitWeight();
                    break;
                default:
                    return 0;
            }

            return billingProcess.CalculateColdPrice(cargo.ID, start, end);
        }
        #endregion //Method
    }
}
