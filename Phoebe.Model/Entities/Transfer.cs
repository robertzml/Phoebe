using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model
{
    public class TransferMetadata
    {
        /// <summary>
        /// ID
        /// </summary>
        [Display(Name = "ID")]
        public System.Guid ID { get; set; }

        /// <summary>
        /// 原货品ID
        /// </summary>
        [Required]
        [Display(Name = "原货品")]
        public System.Guid OldCargoID { get; set; }

        /// <summary>
        /// 新货品ID
        /// </summary>
        [Display(Name = "新货品")]
        public System.Guid NewCargoID { get; set; }

        /// <summary>
        /// 转户时间
        /// </summary>
        [Required]
        [Display(Name = "转户时间")]
        public System.DateTime TransferTime { get; set; }

        /// <summary>
        /// 确认时间
        /// </summary>
        [Display(Name = "确认时间")]
        public Nullable<System.DateTime> ConfirmTime { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        [Display(Name = "操作人")]
        public int UserID { get; set; }

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

    [MetadataType(typeof(TransferMetadata))]
    public partial class Transfer
    {
    }
}
