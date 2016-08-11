using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model.Report
{
    /// <summary>
    /// 冰块销售报表模型
    /// </summary>
    public class RIceSaleDetailsModel
    {
        /// <summary>
        /// 冰块类型
        /// </summary>
        public string IceType { get; set; }

        /// <summary>
        /// 销售数量
        /// </summary>
        public int SaleCount { get; set; }

        /// <summary>
        /// 单位重量(kg)
        /// </summary>
        public decimal UnitWeight { get; set; }

        /// <summary>
        /// 销售重量(kg)
        /// </summary>
        public decimal SaleWeight { get; set; }

        /// <summary>
        /// 单价(元/袋)
        /// </summary>
        public decimal SaleUnitPrice { get; set; }

        /// <summary>
        /// 总价(元)
        /// </summary>
        public decimal SaleFee { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
