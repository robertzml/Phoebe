using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.Model
{
    /// <summary>
    /// 客户库存记录类
    /// </summary>
    /// <remarks>
    /// 客户库存日报表用，不分类，计总数
    /// </remarks>
    public class CustomerTotalStore
    {
        /// <summary>
        /// 库存日期
        /// </summary>
        public DateTime StorageDate { get; set; }

        /// <summary>
        /// 客户ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 客户编码
        /// </summary>
        public string CustomerNumber { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 在库总数量
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 在库重量(吨)
        /// </summary>
        public decimal TotalWeight { get; set; }
    }
}
