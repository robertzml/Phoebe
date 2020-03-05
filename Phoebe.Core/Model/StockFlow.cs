using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.Model
{
    using Phoebe.Core.Utility;

    /// <summary>
    /// 库存流水类
    /// </summary>
    public class StockFlow
    {
        #region Property
        /// <summary>
        /// 单据ID，根据类型变化
        /// </summary>
        public string StockId { get; set; }

        /// <summary>
        /// 流水号
        /// </summary>
        public string FlowNumber { get; set; }

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
        /// 货品ID
        /// </summary>
        public string CargoId { get; set; }

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
        /// 在库数量
        /// </summary>
        public int StoreCount { get; set; }

        /// <summary>
        /// 流水数量
        /// </summary>
        /// <remarks>
        /// 正为入库、移入，负为出库、移出
        /// </remarks>
        public int FlowCount { get; set; }

        /// <summary>
        /// 单位重量(kg)
        /// </summary>
        public decimal UnitWeight { get; set; }

        /// <summary>
        /// 流水重量(吨)
        /// </summary>
        public decimal FlowWeight { get; set; }

        /// <summary>
        /// 流水日期
        /// </summary>
        public DateTime FlowDate { get; set; }

        /// <summary>
        /// 流水类型
        /// </summary>
        public StockFlowType Type { get; set; }
        #endregion //Property
    }
}
