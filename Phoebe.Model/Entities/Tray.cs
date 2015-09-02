using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model
{
    public class TrayMetadata
    {
        /// <summary>
        /// ID
        /// </summary>
        [Display(Name = "ID")]
        public int ID { get; set; }

        /// <summary>
        /// 长度
        /// </summary>
        [Display(Name = "长度")]
        public Nullable<double> Length { get; set; }

        /// <summary>
        /// 宽度
        /// </summary>
        [Display(Name = "宽度")]
        public Nullable<double> Width { get; set; }

        /// <summary>
        /// 所在仓库
        /// </summary>
        [Display(Name = "所在仓库")]
        public Nullable<int> WarehouseID { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        [Display(Name = "添加时间")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 废弃时间
        /// </summary>
        [Display(Name = "废弃时间")]
        public Nullable<System.DateTime> AbandonTime { get; set; }

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

    [MetadataType(typeof(TrayMetadata))]
    public partial class Tray
    {
    }
}
