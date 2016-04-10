using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.FormUI
{
    /// <summary>
    /// 报表出库记录类
    /// </summary>
    public class RStockOutDetail
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 货物名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 一级分类
        /// </summary>
        public string FirstCategory { get; set; }

        /// <summary>
        /// 二级分类
        /// </summary>
        public string SecondCategory { get; set; }

        /// <summary>
        /// 三级分类
        /// </summary>
        public string ThirdCategory { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 单位重量
        /// </summary>
        public double UnitWeight { get; set; }

        /// <summary>
        /// 总重量
        /// </summary>
        public double TotalWeight { get; set; }

        /// <summary>
        /// 总体积
        /// </summary>
        public double TotalVolume { get; set; }

        /// <summary>
        /// 在库数量
        /// </summary>
        public int StoreCount { get; set; }

        /// <summary>
        /// 在库重量
        /// </summary>
        public double StoreWeight { get; set; }

        /// <summary>
        /// 仓位
        /// </summary>
        public string Warehouse { get; set; }
    }
}
