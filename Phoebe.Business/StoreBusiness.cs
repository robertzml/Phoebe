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
        /// 获取入库月份分组
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 用于树形导航分组
        /// </remarks>
        public string[] GetStockInMonthGroup()
        {
            var m = this.context.StockIns.GroupBy(r => r.MonthTime).Select(g => g.Key).OrderByDescending(s => s);
            return m.ToArray();
        }

        /// <summary>
        /// 按月度获取入库记录
        /// </summary>
        /// <param name="monthTime">月份</param>
        /// <returns></returns>
        public List<StockIn> GetStockInByMonth(string monthTime)
        {
            var data = this.context.StockIns.Where(r => r.MonthTime == monthTime).OrderByDescending(r => r.InTime);
            return data.ToList();
        }

        /// <summary>
        /// 获取最新流水单号
        /// </summary>
        /// <param name="inTime">入库时间</param>
        /// <returns></returns>
        public string GetLastStockInFlowNumber(DateTime inTime)
        {
            var data = this.context.StockIns.Where(r => r.InTime == inTime).OrderByDescending(r => r.FlowNumber);
            if (data.Count() == 0)
                return string.Format("{0}{1}{2}0001",
                    inTime.Year, inTime.Month.ToString().PadLeft(2, '0'), inTime.Day.ToString().PadLeft(2, '0'));
            else
            {
                int newNumber = Convert.ToInt32(data.First().FlowNumber.Substring(8)) + 1;
                return string.Format("{0}{1}{2}{3}", inTime.Year, inTime.Month.ToString().PadLeft(2, '0'),
                    inTime.Day.ToString().PadLeft(2, '0'), newNumber.ToString().PadLeft(4, '0'));
            }
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

        /// <summary>
        /// 入库确认
        /// </summary>
        /// <param name="id">入库ID</param>
        /// <returns></returns>
        public ErrorCode StockInConfirm(Guid id)
        {
            try
            {
                StockIn si = this.context.StockIns.Find(id);
                if (si == null)
                    return ErrorCode.ObjectNotFound;
                
                si.Status = (int)EntityStatus.StockIn;

                // add stock information
                foreach (var item in si.StockInDetails)
                {
                    // change stock in details and cargo status
                    item.Status = (int)EntityStatus.StockIn;
                    item.Cargo.InTime = si.InTime;
                    item.Cargo.Status = (int)EntityStatus.CargoStockIn;

                    Stock stock = new Stock();
                    stock.ID = Guid.NewGuid();
                    stock.WarehouseID = item.WarehouseID;
                    stock.Count = item.Count;
                    stock.CargoID = item.CargoID;
                    stock.InTime = si.InTime;
                    stock.Source = 0;
                    stock.Status = (int)EntityStatus.StoreIn;

                    this.context.Stocks.Add(stock);

                    item.StockID = stock.ID;

                    this.context.SaveChanges();
                }

                return ErrorCode.Success;
            }
            catch(Exception)
            {
                return ErrorCode.Exception;
            }
        }
        #endregion //Stock In
        #endregion //Method
    }
}
