using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model
{
    public class StockMoveMetadata
    {
        /// <summary>
        /// ID
        /// </summary>
        [Display(Name = "ID")]
        public System.Guid ID { get; set; }

        /// <summary>
        /// 移库时间
        /// </summary>
        [Display(Name = "移库时间")]
        public System.DateTime MoveTime { get; set; }

        /// <summary>
        /// 确认时间
        /// </summary>
        [Display(Name = "确认时间")]
        public Nullable<System.DateTime> ConfirmTime { get; set; }

        /// <summary>
        /// 原仓库
        /// </summary>
        [Display(Name = "原仓库")]
        public int SourceWarehouseID { get; set; }

        /// <summary>
        /// 目的仓库
        /// </summary>
        [Required]
        [UIHint("WarehouseCascadeList")]
        [Display(Name = "目的仓库")]
        public int DetinationWarehouseID { get; set; }

        /// <summary>
        /// 托盘
        /// </summary>
        [Required]
        [UIHint("FreeTrayList")]
        [Display(Name = "托盘")]
        public int TrayID { get; set; }

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

    [MetadataType(typeof(StockMoveMetadata))]
    public partial class StockMove
    {
    }
}
