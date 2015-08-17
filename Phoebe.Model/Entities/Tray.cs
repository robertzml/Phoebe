using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model.Entities
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
