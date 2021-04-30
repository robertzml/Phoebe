using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Phoebe.Core.Entity
{
    using Phoebe.Base.Framework;
    using SqlSugar;

    /// <summary>
    /// 冰块入库类
    /// </summary>
    [SugarTable("IceStock")]
    public class IceStock : IBaseEntity<string>
    {
        #region Property
        /// <summary>
        /// ID
        /// </summary>
        [SugarColumn(ColumnName = "Id", IsPrimaryKey = true)]
        [Display(Name = "ID")]
        public string Id { get; set; }

        /// <summary>
        /// 入库时间
        /// </summary>
        [Required]
        [Display(Name = "入库时间")]
        public DateTime StockTime { get; set; }

        /// <summary>
        /// 流水单号
        /// </summary>
        [Display(Name = "流水单号")]
        public string FlowNumber { get; set; }

        /// <summary>
        /// 冰块类型
        /// </summary>
        [Required]
        [Display(Name = "冰块类型")]
        public int IceType { get; set; }

        /// <summary>
        /// 流水数量
        /// </summary>
        [Display(Name = "流水数量")]
        public int FlowCount { get; set; }

        /// <summary>
        /// 操作人ID
        /// </summary>
        [Display(Name = "操作人ID")]
        public int UserId { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        [Display(Name = "操作人")]
        public string UserName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        public string Remark { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public int Status { get; set; }
        #endregion //Property
    }
}
