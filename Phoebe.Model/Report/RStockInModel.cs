using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model.Report
{
    /// <summary>
    /// 入库单报表模型
    /// </summary>
    public class RStockInModel
    {
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 入库日期
        /// </summary>
        public DateTime InTime { get; set; }

        /// <summary>
        /// 入库流水号
        /// </summary>
        public string FlowNumber { get; set; }

        /// <summary>
        /// 车号
        /// </summary>
        public string CarNumber { get; set; }

        /// <summary>
        /// 操作员
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 入库记录
        /// </summary>
        public List<RStockInDetailsModel> Details { get; set; }
    }
}
