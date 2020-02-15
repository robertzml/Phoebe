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
        #endregion //Property
    }
}
