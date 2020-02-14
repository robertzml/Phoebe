using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Phoebe.Core.Entity
{
    using Phoebe.Base.Framework;
    using SqlSugar;

    /// <summary>
    /// 费用项目类
    /// </summary>
    [SugarTable("ExpenseItem")]
    public class ExpenseItem : IBaseEntity<int>
    {
        #region Property
        /// <summary>
        /// ID
        /// </summary>
        [SugarColumn(ColumnName = "Id", IsPrimaryKey = true, IsIdentity = true)]
        [Display(Name = "ID")]
        public int Id { get; set; }

        /// <summary>
        /// 代码
        /// </summary>
        [Display(Name = "代码")]
        public string Code { get; set; }

        /// <summary>
        /// 费用项目
        /// </summary>
        [Required]
        [Display(Name = "费用项目")]
        public string Name { get; set; }

        /// <summary>
        /// 计费方式
        /// </summary>
        [Display(Name = "计费方式")]
        public int Type { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        public string Remark { get; set; }
        #endregion //Property
    }
}
