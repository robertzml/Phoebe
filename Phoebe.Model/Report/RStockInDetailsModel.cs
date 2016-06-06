using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model.Report
{
    /// <summary>
    /// 报表入库记录类
    /// </summary>
    public class RStockInDetailsModel
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 一级分类
        /// </summary>
        public string CategoryNumber { get; set; }

        public string CategoryName { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 单位重量
        /// </summary>
        public decimal UnitWeight { get; set; }

        /// <summary>
        /// 总重量
        /// </summary>
        public decimal TotalWeight { get; set; }

        /// <summary>
        /// 总体积
        /// </summary>
        public decimal TotalVolume { get; set; }

        /// <summary>
        /// 仓位
        /// </summary>
        public string Warehouse { get; set; }
    }
}
