using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Model.Report
{
    /// <summary>
    /// 冰块销售报表模型
    /// </summary>
    public class RIceSaleModel
    {
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 销售日期
        /// </summary>
        public DateTime SaleTime { get; set; }

        /// <summary>
        /// 销售流水号
        /// </summary>
        public string FlowNumber { get; set; }

        /// <summary>
        /// 操作员
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 销售记录
        /// </summary>
        public List<RIceSaleDetailsModel> IceSales { get; set; }
    }
}
