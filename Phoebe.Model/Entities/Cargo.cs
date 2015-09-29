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
        /// 三级分类
        /// </summary>
        [Display(Name = "三级分类")]
        public Nullable<int> ThirdCategoryID { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [Required]
        [Display(Name = "数量")]
        public int Count { get; set; }

        /// <summary>
        /// 单位重量
        /// </summary>
        [Display(Name = "单位重量")]
        public Nullable<double> UnitWeight { get; set; }

        /// <summary>
        /// 总重量
        /// </summary>
        [Display(Name = "总重量")]
        public Nullable<double> TotalWeight { get; set; }

        /// <summary>
        /// 单位体积
        /// </summary>
        [Display(Name = "单位体积")]
        public Nullable<double> UnitVolume { get; set; }

        /// <summary>
        /// 总体积
        /// </summary>
        [Display(Name = "总体积")]
        public Nullable<double> TotalVolume { get; set; }

        /// <summary>
        /// 在库数量
        /// </summary>
        [Display(Name = "在库数量")]
        public int StoreCount { get; set; }

        /// <summary>
        /// 产地
        /// </summary>
        [Display(Name = "产地")]
        public string OriginPlace { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        [Display(Name = "规格")]
        public string Specification { get; set; }

        /// <summary>
        /// 保质期
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "保质期必须为大于0的整数")]
        [Display(Name = "保质期")]
        public int ShelfLife { get; set; }

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
        /// 入库时间
        /// </summary>
        [Display(Name = "入库时间")]
        public Nullable<System.DateTime> InTime { get; set; }

        /// <summary>
        /// 出库时间
        /// </summary>
        [Display(Name = "出库时间")]
        public Nullable<System.DateTime> OutTime { get; set; }

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