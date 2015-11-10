using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model
{
    /// <summary>
    /// 库位存储类
    /// </summary>
    public class Storage
    {
        /// <summary>
        /// 库位ID
        /// </summary>
        [Display(Name = "库位ID")]
        public int WarehouseID { get; set; }

        /// <summary>
        /// 库位编号
        /// </summary>
        [Display(Name = "库位编号")]
        public string Number { get; set; }

        /// <summary>
        /// 库存ID
        /// </summary>
        [Display(Name = "库存ID")]
        public System.Guid StockID { get; set; }

        /// <summary>
        /// 货品ID
        /// </summary>
        [Display(Name = "货品ID")]
        public System.Guid CargoID { get; set; }

        /// <summary>
        /// 合同ID
        /// </summary>
        [Display(Name = "合同ID")]
        public int ContractID { get; set; }

        /// <summary>
        /// 货品名称
        /// </summary>
        [Display(Name = "货品名称")]
        public string CargoName { get; set; }

        /// <summary>
        /// 所属合同
        /// </summary>
        [Display(Name = "所属合同")]
        public string ContractName { get; set; }

        /// <summary>
        /// 一级分类ID
        /// </summary>
        [Display(Name = "一级分类ID")]
        public int FirstCategoryID { get; set; }

        /// <summary>
        /// 一级分类
        /// </summary>
        [Display(Name = "一级分类")]
        public string FirstCategoryName { get; set; }

        /// <summary>
        /// 二级分类ID
        /// </summary>
        [Display(Name = "二级分类ID")]
        public int SecondCategoryID { get; set; }

        /// <summary>
        /// 二级分类
        /// </summary>
        [Display(Name = "二级分类")]
        public string SecondCategoryName { get; set; }

        /// <summary>
        /// 三级分类ID
        /// </summary>
        [Display(Name = "三级分类ID")]
        public int ThirdCategoryID { get; set; }

        /// <summary>
        /// 三级分类
        /// </summary>
        [Display(Name = "三级分类")]
        public string ThirdCategoryName { get; set; }

        /// <summary>
        /// 在库数量
        /// </summary>
        [Display(Name = "在库数量")]
        public int Count { get; set; }

        /// <summary>
        /// 入库时间
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "入库时间")]
        public System.DateTime InTime { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        [Display(Name = "来源")]
        public int Source { get; set; }
    }
}
