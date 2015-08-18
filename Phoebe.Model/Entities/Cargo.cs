using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model
{
    public class CargoMetadata
    {
        /// <summary>
        /// ID
        /// </summary>
        [Display(Name = "ID")]
        public System.Guid ID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [Display(Name = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// 一级分类
        /// </summary>
        [Required]
        [UIHint("FirstCategoryList")]
        [Display(Name = "一级分类")]
        public int FirstCategoryID { get; set; }

        /// <summary>
        /// 二级分类
        /// </summary>
        [Required]
        [Display(Name = "二级分类")]
        public int SecondCategoryID { get; set; }

        /// <summary>
        /// 重量
        /// </summary>
        [Display(Name = "重量")]
        public Nullable<double> Weight { get; set; }

        /// <summary>
        /// 体积
        /// </summary>
        [Display(Name = "体积")]
        public Nullable<double> Volume { get; set; }

        /// <summary>
        /// 所属合同
        /// </summary>
        [Required]
        [UIHint("ContractList")]
        [Display(Name = "所属合同")]
        public int ContractID { get; set; }

        /// <summary>
        /// 登记时间
        /// </summary>
        [Required]
        [Display(Name = "登记时间")]
        public System.DateTime RegisterTime { get; set; }

        /// <summary>
        /// 登记人ID
        /// </summary>
        [Display(Name = "登记人")]
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

    [MetadataType(typeof(CargoMetadata))]
    public partial class Cargo
    {
    }
}