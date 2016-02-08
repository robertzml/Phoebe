using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model
{
    /// <summary>
    /// 库存流水类
    /// </summary>
    public class StockFlow
    {
        /// <summary>
        /// 客户ID
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 合同ID
        /// </summary>
        [Display(Name = "合同ID")]
        public int ContractID { get; set; }

        /// <summary>
        /// 合同名称
        /// </summary>
        public string ContractName { get; set; }

        /// <summary>
        /// 货品ID
        /// </summary>
        [Display(Name = "货品ID")]
        public System.Guid CargoID { get; set; }

        /// <summary>
        /// 货品名称
        /// </summary>
        [Display(Name = "货品名称")]
        public string CargoName { get; set; }

        /// <summary>
        /// 一级分类ID
        /// </summary>
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
        /// 流水数量
        /// </summary>
        /// <remarks>
        /// 正为入库、移入，负为出库、移出
        /// </remarks>
        [Display(Name = "流水数量")]
        public int Count { get; set; }

        /// <summary>
        /// 单位重量(kg)
        /// </summary>
        public double UnitWeight { get; set; }

        /// <summary>
        /// 流水重量(吨)
        /// </summary>
        [Display(Name = "流水重量(吨)")]
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
        public StockFlowType Type { get; set; }

        /// <summary>
        /// 数量变化
        /// </summary>
        /// <remarks>
        /// 整库移库时为否，冷藏费无更改
        /// </remarks>
        public bool CountChange { get; set; }
    }

    /// <summary>
    /// 流水类型
    /// </summary>
    public enum StockFlowType
    {
        /// <summary>
        /// 无
        /// </summary>
        [Display(Name = "无")]
        None = 0,

        /// <summary>
        /// 入库
        /// </summary>
        [Display(Name = "入库")]
        StockIn = 1,

        /// <summary>
        /// 出库
        /// </summary>
        [Display(Name = "出库")]
        StockOut = 2,

        /// <summary>
        /// 移入
        /// </summary>
        [Display(Name = "移入")]
        StockMoveIn = 3,

        /// <summary>
        /// 移出
        /// </summary>
        [Display(Name = "移出")]
        StockMoveOut = 4
    }
}
