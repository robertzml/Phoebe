using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Phoebe.Core.Entity
{
    using Phoebe.Base.Framework;
    using SqlSugar;

    /// <summary>
    /// 编号记录类
    /// </summary>
    public class SequenceRecord : IBaseEntity<string>
    {
        #region Property
        /// <summary>
        /// ID
        /// </summary>
        [SugarColumn(ColumnName = "Id", IsPrimaryKey = true)]
        [Display(Name = "ID")]
        public string Id { get; set; }

        /// <summary>
        /// 模板ID
        /// </summary>
        [SugarColumn(ColumnName = "TemplateId")]
        [Display(Name = "模板ID")]
        public string TemplateId { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        [SugarColumn(ColumnName = "TableName")]
        [Display(Name = "表名")]
        public string TableName { get; set; }

        /// <summary>
        /// 当前日期
        /// </summary>
        [SugarColumn(ColumnName = "CurrentDate")]
        [Display(Name = "当前日期")]
        public DateTime? CurrentDate { get; set; }

        /// <summary>
        /// 当前编号
        /// </summary>
        [SugarColumn(ColumnName = "CurrentSequence")]
        [Display(Name = "当前编号")]
        public int CurrentSequence { get; set; }
        #endregion //Property
    }
}
