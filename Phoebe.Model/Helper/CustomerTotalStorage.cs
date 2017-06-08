using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model
{
    /// <summary>
    /// 客户库存汇总类
    /// </summary>
    public class CustomerTotalStorage
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
        /// 客户姓名
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 客户编号
        /// </summary>
        public string CustomerNumber { get; set; }

        /// <summary>
        /// 在库数量
        /// </summary>
        public int StoreCount { get; set; }

        /// <summary>
        /// 在库重量(吨)
        /// </summary>
        public decimal StoreWeight { get; set; }

        /// <summary>
        /// 在库体积(立方)
        /// </summary>
        public decimal StoreVolume { get; set; }
    }
}
