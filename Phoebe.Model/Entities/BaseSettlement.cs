using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model
{
    public class BaseSettlementMetadata
    {
        /// <summary>
        /// ID
        /// </summary>
        [Display(Name = "ID")]
        public System.Guid ID { get; set; }

        /// <summary>
        /// 结算单编号
        /// </summary>
        [Required]
        [Display(Name = "结算单编号")]
        public string Number { get; set; }

        /// <summary>
        /// 货品ID
        /// </summary>
        [Required]
        [Display(Name = "货品名称")]
        public System.Guid CargoID { get; set; }

        /// <summary>
        /// 费用合计
        /// </summary>
        [Required]
        [Display(Name = "费用合计")]
        public decimal SumPrice { get; set; }

        /// <summary>
        /// 折扣率
        /// </summary>
        [Range(0, 100)]
        [Display(Name = "折扣率%")]
        public int Discount { get; set; }

        /// <summary>
        /// 减免费用
        /// </summary>
        [Display(Name = "减免费用(元)")]
        public decimal Remission { get; set; }

        /// <summary>
        /// 总价
        /// </summary>
        [Required]
        [Display(Name = "总价(元)")]
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// 付款
        /// </summary>
        [Display(Name = "付款")]
        public Nullable<decimal> PaidPrice { get; set; }

        /// <summary>
        /// 结算时间
        /// </summary>
        [DataType(DataType.Date)]
        [Display(Name = "结算时间")]
        public System.DateTime SettleTime { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        [Display(Name = "操作人")]
        public int UserID { get; set; }

        /// <summary>
        /// 确认时间
        /// </summary>
        [Display(Name = "确认时间")]
        public Nullable<System.DateTime> ConfirmTime { get; set; }

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

    [MetadataType(typeof(BaseSettlementMetadata))]
    public partial class BaseSettlement
    {
    }
}
