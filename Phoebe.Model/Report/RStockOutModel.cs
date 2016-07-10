using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model.Report
{
    /// <summary>
    /// 出库单报表模型
    /// </summary>
    public class RStockOutModel
    {
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 出库日期
        /// </summary>
        public DateTime OutTime { get; set; }

        /// <summary>
        /// 出库流水号
        /// </summary>
        public string FlowNumber { get; set; }

        /// <summary>
        /// 当前欠费
        /// </summary>
        public decimal DebtFee { get; set; }

        /// <summary>
        /// 操作员
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 出库记录
        /// </summary>
        public List<RStockOutDetailsModel> Details { get; set; }
    }
}
