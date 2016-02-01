using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 统计业务
    /// </summary>
    public class StatisticBusiness
    {
        #region Field
        private PhoebeContext context;
        #endregion //Field

        #region Constructor
        public StatisticBusiness()
        {
            this.context = new PhoebeContext();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取日入库
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public List<StockFlow> GetDailyFlowIn(DateTime date)
        {
            List<StockFlow> data = new List<StockFlow>();



            return data;
        }
        #endregion //Method
    }
}
