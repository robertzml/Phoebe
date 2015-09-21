using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model
{
    public class WarehouseMetadata
    {
        /// <summary>
        /// ID
        /// </summary>
        [Display(Name = "ID")]
        public int ID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [Display(Name = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        [Display(Name = "编号")]
        public string Number { get; set; }

        /// <summary>
        /// 上级ID
        /// </summary>
        [Display(Name = "上级仓库")]
        public Nullable<int> ParentId { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        [Display(Name = "级别")]
        public int Hierarchy { get; set; }

        /// <summary>
        /// 是否库位
        /// </summary>
        [Required]
        [Display(Name = "是否库位")]
        public bool IsStorage { get; set; }

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

    [MetadataType(typeof(WarehouseMetadata))]
    public partial class Warehouse
    {
    }
}
