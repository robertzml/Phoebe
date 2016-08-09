using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Model
{
    /// <summary>
    /// 冰块业务记录类
    /// </summary>
    public class IceRecord
    {
        /// <summary>
        /// 冰块类型
        /// </summary>
        public int IceType { get; set; }

        /// <summary>
        /// 流水数量
        /// </summary>
        public int FlowCount { get; set; }

        /// <summary>
        /// 单位重量(kg)
        /// </summary>
        public decimal UnitWeight { get; set; }

        /// <summary>
        /// 流水重量(kg)
        /// </summary>
        public decimal FlowWeight { get; set; }

        /// <summary>
        /// 销售单价
        /// </summary>
        public decimal SaleUnitPrice { get; set; }

        /// <summary>
        /// 销售总价
        /// </summary>
        public decimal SaleFee { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
