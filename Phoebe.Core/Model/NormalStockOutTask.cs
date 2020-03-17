using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.Model
{
    /// <summary>
    /// 普通库出库任务
    /// </summary>
    public class NormalStockOutTask
    {
        /// <summary>
        /// 库存ID
        /// </summary>
        public string StoreId { get; set; }

        /// <summary>
        /// 货品ID
        /// </summary>
        public string CargoId { get; set; }

        /// <summary>
        /// 出库数量
        /// </summary>
        public int OutCount { get; set; }

        /// <summary>
        /// 出库重量
        /// </summary>
        public decimal OutWeight { get; set; }
    }
}
