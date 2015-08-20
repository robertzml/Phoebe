using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 仓储业务类
    /// </summary>
    public class StoreBusiness
    {
        #region Field
        private PhoebeContext context;
        #endregion //Field

        #region Constructor
        public StoreBusiness()
        {
            this.context = new PhoebeContext();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 货品入库
        /// </summary>
        /// <param name="data">入库数据</param>
        /// <param name="cargos">货品数据</param>
        /// <returns></returns>
        public ErrorCode StockIn(StockIn data, string[] cargos)
        {
            try
            {
                data.ID = Guid.NewGuid();
                data.InTime = DateTime.Now;
                data.Status = (int)EntityStatus.StockInReady;

                this.context.StockIns.Add(data);

                for (int i = 0; i < cargos.Length; i++)
                {
                    StockInDetail detail = new StockInDetail
                    {
                        StockInID = data.ID,
                        CargoID = new Guid(cargos[i]),
                        Status = 0
                    };
                    this.context.StockInDetails.Add(detail);
                }

                // change cargo status
                for (int i = 0; i < cargos.Length; i++)
                {
                    Guid gid = new Guid(cargos[i]);
                    Cargo cargo = this.context.Cargoes.Find(gid);
                    cargo.Status = (int)EntityStatus.CargoStockInReady;
                }

                // change tray status
                Tray tray = this.context.Trays.Find(data.TrayID);
                tray.Status = (int)EntityStatus.TrayInuse;

                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }
        #endregion //Method
    }
}
