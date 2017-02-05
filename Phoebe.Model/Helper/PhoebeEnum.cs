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
    /// 合同类型
    /// </summary>
    public enum ContractType
    {
        /// <summary>
        /// 计时冷藏合同
        /// </summary>
        [Display(Name = "计时冷藏合同")]
        TimingCold = 1,

        /// <summary>
        /// 非计时冷藏合同
        /// </summary>
        [Display(Name = "非计时冷藏合同")]
        UntimingCold = 2,

        /// <summary>
        /// 速冻合同
        /// </summary>
        [Display(Name = "速冻合同")]
        Freeze = 3,

        /// <summary>
        /// 冰块合同
        /// </summary>
        [Display(Name = "冰块合同")]
        Ice = 4,

        /// <summary>
        /// 最短时间合同
        /// </summary>
        [Display(Name = "最短时间合同")]
        MinDuration = 5
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

    /// <summary>
    /// 费用类型
    /// </summary>
    public enum ExpenseType
    {
        /// <summary>
        /// 基本费用
        /// </summary>
        [Display(Name = "基本费用")]
        Base = 1,

        /// <summary>
        /// 冷藏费用
        /// </summary>
        [Display(Name = "冷藏费用")]
        Cold = 2,

        /// <summary>
        /// 杂项费用
        /// </summary>
        [Display(Name = "杂项费用")]
        Misc = 3
    }

    /// <summary>
    /// 缴费方式
    /// </summary>
    public enum PaymentType
    {
        [Display(Name = "现金")]
        Cash = 1,

        [Display(Name = "刷卡")]
        Credit = 2,

        [Display(Name = "转账")]
        Transfer = 3,

        [Display(Name = "支票")]
        Cheque = 4
    }
}
