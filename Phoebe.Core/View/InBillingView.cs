using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Phoebe.Core.View
{
    using Phoebe.Base.Framework;
    using SqlSugar;

    /// <summary>
    /// 入库计费视图类
    /// </summary>
    [SugarTable("InBillingView")]
    public class InBillingView : IBaseEntity<string>
    {
        #region Property
        /// <summary>
        /// ID
        /// </summary>
        [SugarColumn(ColumnName = "Id", IsPrimaryKey = true)]
        [Display(Name = "ID")]
        public string Id { get; set; }

        /// <summary>
        /// 入库单ID
        /// </summary>
        [Display(Name = "入库单ID")]
        public string StockInId { get; set; }

        /// <summary>
        /// 费用项目ID
        /// </summary>
        [Display(Name = "费用项目ID")]
        public int ExpenseItemId { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        [Display(Name = "单价")]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [Display(Name = "数量")]
        public decimal Count { get; set; }

        /// <summary>
        /// 总价
        /// </summary>
        [Display(Name = "总价")]
        public decimal Amount { get; set; }

        /// <summary>
        /// 参数1
        /// </summary>
        [Display(Name = "参数1")]
        public string Parameter1 { get; set; }

        /// <summary>
        /// 参数2
        /// </summary>
        [Display(Name = "参数2")]
        public string Parameter2 { get; set; }

        /// <summary>
        /// 参数3
        /// </summary>
        [Display(Name = "参数3")]
        public string Parameter3 { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        public string Remark { get; set; }

        /// <summary>
        /// 代码
        /// </summary>
        [Display(Name = "代码")]
        public string Code { get; set; }

        /// <summary>
        /// 费用项目
        /// </summary>
        [Display(Name = "费用项目")]
        public string Name { get; set; }

        /// <summary>
        /// 计费方式
        /// </summary>
        [Display(Name = "计费方式")]
        public int Type { get; set; }

        /// <summary>
        /// 入库时间
        /// </summary>
        [Display(Name = "入库时间")]
        public DateTime InTime { get; set; }

        /// <summary>
        /// 流水单号
        /// </summary>
        [Display(Name = "流水单号")]
        public string FlowNumber { get; set; }

        /// <summary>
        /// 所属客户
        /// </summary>
        [Display(Name = "所属客户")]
        public int CustomerId { get; set; }

        /// <summary>
        /// 所属合同
        /// </summary>
        [Display(Name = "所属合同")]
        public int ContractId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public int Status { get; set; }

        /// <summary>
        /// 客户代码
        /// </summary>
        [Display(Name = "客户代码")]
        public string CustomerNumber { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        [Display(Name = "客户名称")]
        public string CustomerName { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        [Display(Name = "合同编号")]
        public string ContractNumber { get; set; }

        /// <summary>
        /// 合同名称
        /// </summary>
        [Display(Name = "合同名称")]
        public string ContractName { get; set; }
        #endregion //Property
    }
}
