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
        /// 货品ID
        /// </summary>
        [Display(Name = "货品")]
        public System.Guid CargoID { get; set; }

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
