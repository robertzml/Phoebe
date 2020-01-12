using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Phoebe.Core.View
{
    using Phoebe.Base.Framework;
    using SqlSugar;

    /// <summary>
    /// 货品视图类
    /// </summary>
    [SugarTable("CargoView")]
    public class CargoView : IBaseEntity<string>
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
        [Display(Name = "货品名称")]
        public string Name { get; set; }

        /// <summary>
        /// 所属客户
        /// </summary>
        [Display(Name = "所属客户")]
        public int CustomerId { get; set; }

        /// <summary>
        /// 类别ID
        /// </summary>
        [Display(Name = "类别ID")]
        public int CategoryId { get; set; }

        /// <summary>
        /// 单位重量
        /// </summary>
        [Display(Name = "单位重量")]
        public decimal UnitWeight { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        [Display(Name = "规格")]
        public string Specification { get; set; }

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

        /// <summary>
        /// 类别名称
        /// </summary>
        [Display(Name = "类别名称")]
        public string CategoryName { get; set; }

        /// <summary>
        /// 类别代码
        /// </summary>
        [Display(Name = "类别代码")]
        public string CategoryNumber { get; set; }

        /// <summary>
        /// 客户编号
        /// </summary>
        [Display(Name = "客户编号")]
        public string CustomerNumber { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        [Display(Name = "客户名称")]
        public string CustomerName { get; set; }
        #endregion //Property
    }
}
