using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Model.Report
{
    /// <summary>
    /// 出库记录报表类
    /// </summary>
    public class RStockOutDetailsModel
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 分类编码
        /// </summary>
        public string CategoryNumber { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string Specification { get; set; }

        /// <summary>
        /// 出库数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 单位重量
        /// </summary>
        public decimal UnitWeight { get; set; }

        /// <summary>
        /// 出库重量
        /// </summary>
        public decimal OutWeight { get; set; }

        /// <summary>
        /// 在库数量
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 出库体积
        /// </summary>
        public decimal OutVolume { get; set; }

        /// <summary>
        /// 仓位
        /// </summary>
        public string Warehouse { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
