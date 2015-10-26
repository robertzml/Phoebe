using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model
{
    public class BillingMetadata
    {
        /// <summary>
        /// 货品ID
        /// </summary>
        [Display(Name = "货品")]
        public System.Guid CargoID { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        [Required]
        [Display(Name = "冷藏费单价(元)")]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 装卸费
        /// </summary>
        [Required]
        [Display(Name = "装卸费(元)")]
        public decimal HandlingPrice { get; set; }

        /// <summary>
        /// 结冻费
        /// </summary>
        [Required]
        [Display(Name = "结冻费(元)")]
        public decimal FreezePrice { get; set; }

        /// <summary>
        /// 处置费
        /// </summary>
        [Required]
        [Display(Name = "处置费(元)")]
        public decimal DisposePrice { get; set; }

        /// <summary>
        /// 包装费
        /// </summary>
        [Required]
        [Display(Name = "包装费(元)")]
        public decimal PackingPrice { get; set; }

        /// <summary>
        /// 租赁费
        /// </summary>
        [Required]
        [Display(Name = "租赁费(元)")]
        public decimal RentPrice { get; set; }

        /// <summary>
        /// 其它费用
        /// </summary>
        [Required]
        [Display(Name = "其它费用(元)")]
        public decimal OtherPrice { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataType(DataType.MultilineText)]
        [Display(Name = "备注")]
        public string Remark { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public int Status { get; set; }
    }

    [MetadataType(typeof(BillingMetadata))]
    public partial class Billing
    {
    }
}
