using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model
{
    /// <summary>
    /// 分类流水类
    /// </summary>
    public class CategoryFlow
    {
        /// <summary>
        /// 一级分类
        /// </summary>
        [Display(Name = "一级分类")]
        public string FirstCategoryName { get; set; }

        /// <summary>
        /// 二级分类
        /// </summary>
        [Display(Name = "二级分类")]
        public string SecondCategoryName { get; set; }

        /// <summary>
        /// 三级分类
        /// </summary>
        [Display(Name = "三级分类")]
        public string ThirdCategoryName { get; set; }

        /// <summary>
        /// 流水数量
        /// </summary>
        /// <remarks>
        /// 正为入库、转入，负为出库、转出
        /// </remarks>
        [Display(Name = "流水数量")]
        public int Count { get; set; }

        /// <summary>
        /// 重量
        /// </summary>
        [Display(Name = "重量(吨)")]
        public double Weight { get; set; }

        /// <summary>
        /// 流水日期
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "流水日期")]
        public System.DateTime FlowDate { get; set; }

        /// <summary>
        /// 流水类型
        /// </summary>
        [Display(Name = "流水类型")]
        public CategoryFlowType Type { get; set; }
    }

    /// <summary>
    /// 流水类型
    /// </summary>
    public enum CategoryFlowType
    {
        /// <summary>
        /// 入库
        /// </summary>
        [Display(Name = "入库")]
        StockIn = 1,

        /// <summary>
        /// 出库
        /// </summary>
        [Display(Name = "出库")]
        StockOut = 2
    }
}
