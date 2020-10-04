using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Phoebe.Core.Entity
{
    using Phoebe.Base.Framework;
    using SqlSugar;

    /// <summary>
    /// 货品类
    /// </summary>
    [SugarTable("Cargo")]
    public class Cargo : IBaseEntity<string>
    {
        #region Property
        /// <summary>
        /// ID
        /// </summary>
        [SugarColumn(ColumnName = "Id", IsPrimaryKey = true)]
        [Display(Name = "ID")]
        public string Id { get; set; }

        /// <summary>
        /// 货品名称
        /// </summary>
        [Required]
        [Display(Name = "货品名称")]
        public string Name { get; set; }

        /// <summary>
        /// 所属客户
        /// </summary>
        [Required]
        [Display(Name = "所属客户")]
        public int CustomerId { get; set; }

        /// <summary>
        /// 类别ID
        /// </summary>
        [Display(Name = "类别ID")]
        public int CategoryId { get; set; }      

        /// <summary>
        /// 规格
        /// </summary>
        [Display(Name = "规格")]
        public string Specification { get; set; }

        /// <summary>
        /// 资产单价
        /// </summary>
        [Display(Name = "资产单价")]
        public decimal AssetUnit { get; set; }

        /// <summary>
        /// 登记时间
        /// </summary>
        [Display(Name = "登记时间")]
        public DateTime RegisterTime { get; set; }

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
