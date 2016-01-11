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

        #region Function

        #endregion //Function

        #region Method
        #region Stock In
        /// <summary>
        /// 获取所有入库记录
        /// </summary>
        /// <returns></returns>
        public List<StockIn> GetStockIn()
        {
            var data = this.context.StockIns.OrderByDescending(r => r.InTime).ToList();
            return data;
        }

        /// <summary>
        /// 获取入库记录
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public StockIn GetStockIn(string id)
        {
            Guid gid;
            if (!Guid.TryParse(id, out gid))
                return null;

            return this.context.StockIns.Find(gid);
        }

        /// <summary>
        /// 获取入库记录
        /// </summary>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public List<StockIn> GetStockInByStatus(EntityStatus status)
        {
            return this.context.StockIns.Where(r => r.Status == (int)status).ToList();
        }

        /// <summary>
        /// 货品入库
        /// </summary>
        /// <param name="data">入库信息</param>
        /// <param name="details">入库详细</param>
        /// <param name="billing">计费信息</param>
        /// <param name="cargos">货品信息</param>
        /// <returns></returns>
        public ErrorCode StockIn(StockIn data, List<StockInDetail> details, Billing billing, List<Cargo> cargos)
        {
            try
            {
                // add stock in             
                this.context.StockIns.Add(data);

                // add cargos            
                this.context.Cargoes.AddRange(cargos);

                // add billing            
                this.context.Billings.Add(billing);

                // add stock in details     
                this.context.StockInDetails.AddRange(details);

                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }
        #endregion //Stock In
        #endregion //Method
    }
}
