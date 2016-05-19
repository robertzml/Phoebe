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
        public int CustomerId { get; set; }

        /// <summary>
        /// 客户编码
        /// </summary>
        public string CustomerNumber { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 合同ID
        /// </summary>
        public int ContractId { get; set; }

        /// <summary>
        /// 合同名称
        /// </summary>
        public string ContractName { get; set; }

        /// <summary>
        /// 类别ID
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 类别编码
        /// </summary>
        public string CategoryNumber { get; set; }

        /// <summary>
        /// 类别名称
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string Specification { get; set; }

        /// <summary>
        /// 流水数量
        /// </summary>
        /// <remarks>
        /// 正为入库、移入，负为出库、移出
        /// </remarks>
        public int Count { get; set; }

        /// <summary>
        /// 单位重量(kg)
        /// </summary>
        public decimal UnitWeight { get; set; }

        /// <summary>
        /// 流水重量(吨)
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// 流水日期
        /// </summary>
        public DateTime FlowDate { get; set; }

        /// <summary>
        /// 流水类型
        /// </summary>
        public StockFlowType Type { get; set; }

        /// <summary>
        /// 数量变化
        /// </summary>
        /// <remarks>
        /// 整库移库时为否，冷藏费无更改，其它流水为真
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
