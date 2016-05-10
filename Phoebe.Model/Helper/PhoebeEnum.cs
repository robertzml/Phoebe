using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Phoebe.Model
{
    /// <summary>
    /// 客户类型
    /// </summary>
    public enum CustomerType
    {
        /// <summary>
        /// 团体客户
        /// </summary>
        [Display(Name = "团体客户")]
        Group = 1,

        /// <summary>
        /// 零散客户
        /// </summary>
        [Display(Name = "零散客户")]
        Scatter = 2
    }

    /// <summary>
    /// 计费方式
    /// </summary>
    public enum BillingType
    {
        /// <summary>
        /// 件重
        /// </summary>
        [Display(Name = "件重", Description = "单价:元/吨")]
        UnitWeight = 1,

        /// <summary>
        /// 件体积
        /// </summary>
        [Display(Name = "件体积", Description = "单价:元/立方")]
        UnitVolume = 2,

        /// <summary>
        /// 计数
        /// </summary>
        [Display(Name = "计数", Description = "单价:元/件")]
        Count = 3,

        /// <summary>
        /// 非等重
        /// </summary>
        [Display(Name = "非等重", Description = "单价:元/吨")]
        VariousWeight = 4
    }

    /// <summary>
    /// 货品分组方式
    /// </summary>
    public enum CargoGroupType
    {
        /// <summary>
        /// 件重
        /// </summary>
        [Display(Name = "件重")]
        UnitWeight = 1,

        /// <summary>
        /// 件体积
        /// </summary>
        [Display(Name = "件体积")]
        UnitVolume = 2,

        /// <summary>
        /// 计数
        /// </summary>
        [Display(Name = "计数")]
        Count = 3,

        /// <summary>
        /// 非等重
        /// </summary>
        [Display(Name = "非等重")]
        VariousWeight = 4
    }

    /// <summary>
    /// 来源类型
    /// </summary>
    public enum SourceType
    {
        /// <summary>
        /// 入库
        /// </summary>
        [Display(Name = "入库")]
        StockIn = 0,

        /// <summary>
        /// 移库
        /// </summary>
        [Display(Name = "移库")]
        StockMove = 1
    }

    /// <summary>
    /// 目的地类型
    /// </summary>
    public enum DestinationType
    {
        /// <summary>
        /// 出库
        /// </summary>
        [Display(Name = "出库")]
        StockOut = 0,

        /// <summary>
        /// 移库
        /// </summary>
        [Display(Name = "移库")]
        StockMove = 1
    }
}
