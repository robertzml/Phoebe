using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Model
{
    /// <summary>
    /// 客户期费用类
    /// </summary>
    public class PeriodFee
    {
        /// <summary>
        /// 客户ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 客户编号
        /// </summary>
        public string CustomerNumber { get; set; }

        /// <summary>
        /// 客户姓名
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime End { get; set; }

        /// <summary>
        /// 基本费用
        /// </summary>
        public decimal BaseFee { get; set; }

        /// <summary>
        /// 冷藏费用
        /// </summary>
        public decimal ColdFee { get; set; }

        /// <summary>
        /// 其它费用
        /// </summary>
        public decimal MiscFee { get; set; }

        /// <summary>
        /// 费用
        /// </summary>
        public decimal TotalFee { get; set; }
    }
}
