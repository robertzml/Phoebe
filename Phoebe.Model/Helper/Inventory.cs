using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Model
{
    /// <summary>
    /// 库存盘点类
    /// </summary>
    public class Inventory
    {
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
        /// 类别ID
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 类别编码
        /// </summary>
        public string CategoryNumber { get; set; }

        /// <summary>
        /// 类别名称
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 单位重量
        /// </summary>
        public decimal UnitWeight { get; set; } 

        /// <summary>
        /// 单位体积
        /// </summary>
        public decimal UnitVolume { get; set; }

        /// <summary>
        /// 期初时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 期初数量
        /// </summary>
        public int StartCount { get; set; }

        /// <summary>
        /// 期初重量
        /// </summary>
        public decimal StartWeight { get; set; }

        /// <summary>
        /// 期末时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 期末数量
        /// </summary>
        public int EndCount { get; set; }

        /// <summary>
        /// 期末重量
        /// </summary>
        public decimal EndWeight { get; set; }
    }
}
