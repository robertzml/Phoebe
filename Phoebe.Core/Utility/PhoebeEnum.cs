﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Core.Utility
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
}
