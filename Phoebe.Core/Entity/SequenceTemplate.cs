using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Phoebe.Core.Entity
{
    using Phoebe.Base.Framework;
    using SqlSugar;

    /// <summary>
    /// 自动编号模板类
    /// </summary>
    [SugarTable("SequenceTemplate")]
    public class SequenceTemplate : IBaseEntity<string>
    {
        #region Property
        /// <summary>
        /// ID
        /// </summary>
        [SugarColumn(ColumnName = "Id", IsPrimaryKey = true)]
        [Display(Name = "ID")]
        public string Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(ColumnName = "Name")]
        [Display(Name = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        [SugarColumn(ColumnName = "TableName")]
        [Display(Name = "表名")]
        public string TableName { get; set; }

        /// <summary>
        /// 字段名
        /// </summary>
        [SugarColumn(ColumnName = "FieldName")]
        [Display(Name = "字段名")]
        public string FieldName { get; set; }

        /// <summary>
        /// 格式
        /// </summary>
        [SugarColumn(ColumnName = "Format")]
        [Display(Name = "格式")]
        public string Format { get; set; }

        /// <summary>
        /// 包含日期
        /// </summary>
        [SugarColumn(ColumnName = "IncludeDate")]
        [Display(Name = "包含日期")]
        public bool IncludeDate { get; set; }

        /// <summary>
        /// 初始值
        /// </summary>
        [SugarColumn(ColumnName = "Initial")]
        [Display(Name = "初始值")]
        public int Initial { get; set; }

        /// <summary>
        /// 步进
        /// </summary>
        [SugarColumn(ColumnName = "Step")]
        [Display(Name = "步进")]
        public int Step { get; set; }

        /// <summary>
        /// 附加参数个数
        /// </summary>
        [SugarColumn(ColumnName = "ExtParamNum")]
        [Display(Name = "附加参数个数")]
        public int ExtParamNum { get; set; }

        /// <summary>
        /// 严格递增
        /// </summary>
        [SugarColumn(ColumnName = "Strict")]
        [Display(Name = "严格递增")]
        public bool Strict { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnName = "Remark")]
        [Display(Name = "备注")]
        public string Remark { get; set; }
        #endregion //Property
    }
}
