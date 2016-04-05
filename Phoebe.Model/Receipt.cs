using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model
{
    /// <summary>
    /// 实时对账模型类
    /// </summary>
    public class Receipt
    {
        /// <summary>
        /// 客户ID
        /// </summary>
        [Display(Name = "客户ID")]
        public int CustomerID { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        [Display(Name = "客户名称")]
        public string CustomerName { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        [DataType(DataType.Date)]
        [Display(Name = "开始日期")]
        public System.DateTime StartTime { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        [DataType(DataType.Date)]
        [Display(Name = "结束日期")]
        public System.DateTime EndTime { get; set; }

        /// <summary>
        /// 已结算费用
        /// </summary>
        [Display(Name = "已结算费用(元)")]
        public decimal SettleFee { get; set; }

        /// <summary>
        /// 未结算费用
        /// </summary>
        [Display(Name = "未结算费用(元)")]
        public decimal RealFee { get; set; }

        /// <summary>
        /// 实付款
        /// </summary>
        [Display(Name = "实付款(元)")]
        public decimal PaidFee { get; set; }

        /// <summary>
        /// 差额
        /// </summary>
        [Display(Name = "差额(元)")]
        public decimal Difference { get; set; }
    }
}
