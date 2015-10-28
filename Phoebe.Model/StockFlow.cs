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
        /// 所属合同
        /// </summary>
        [Display(Name = "所属合同")]
        public string ContractName { get; set; }

        /// <summary>
        /// 流水数量
        /// </summary>
        /// <remarks>
        /// 正为入库、转入，负为出库、转出
        /// </remarks>
        [Display(Name = "流水数量")]
        public int Count { get; set; }

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
    }

    /// <summary>
    /// 流水类型
    /// </summary>
    public enum StockFlowType
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
        StockOut = 2,

        /// <summary>
        /// 转入
        /// </summary>
        [Display(Name = "转入")]
        TransferIn = 3,

        /// <summary>
        /// 转出
        /// </summary>
        [Display(Name = "转出")]
        TransferOut = 4
    }
}
