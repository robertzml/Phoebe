﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Phoebe.Core.Utility
{
    /// <summary>
    /// 仓库类型
    /// </summary>
    public enum WarehouseType
    {
        /// <summary>
        /// 普通库
        /// </summary>
        [Display(Name = "普通库")]
        Normal = 1,

        /// <summary>
        /// 仓位库
        /// </summary>
        [Display(Name = "仓位库")]
        Position = 2,

        /// <summary>
        /// 急冻库
        /// </summary>
        [Display(Name = "急冻库")]
        Freeze = 3
    }

    /// <summary>
    /// 货架类型
    /// </summary>
    public enum ShelfType
    {
        /// <summary>
        /// 普通货架
        /// </summary>
        [Display(Name = "普通货架")]
        Normal = 1,

        /// <summary>
        /// 仓位货架
        /// </summary>
        [Display(Name = "仓位货架")]
        Position = 2,

        /// <summary>
        /// 虚拟货架
        /// </summary>
        [Display(Name = "虚拟货架")]
        Virtual = 3
    }

    /// <summary>
    /// 入库类型
    /// </summary>
    public enum StockInType
    {
        /// <summary>
        /// 普通库入库
        /// </summary>
        [Display(Name = "普通库入库")]
        Normal = 1,

        /// <summary>
        /// 仓位库入库
        /// </summary>
        [Display(Name = "仓位库入库")]
        Position = 2,

        /// <summary>
        /// 冷冻库入库
        /// </summary>
        [Display(Name = "冷冻库入库")]
        Freeze = 3
    }

    /// <summary>
    /// 出库类型
    /// </summary>
    public enum StockOutType
    {
        /// <summary>
        /// 普通库出库
        /// </summary>
        [Display(Name = "普通库出库")]
        Normal = 1,

        /// <summary>
        /// 仓位库出库
        /// </summary>
        [Display(Name = "仓位库出库")]
        Position = 2
    }

    /// <summary>
    /// 搬运入库类型
    /// </summary>
    public enum CarryInTaskType
    {
        /// <summary>
        /// 入库搬运
        /// </summary>
        [Display(Name = "入库搬运")]
        In = 1,

        /// <summary>
        /// 临时搬运
        /// </summary>
        [Display(Name = "临时搬运")]
        Temp = 2
    }

    /// <summary>
    /// 搬运出库类型
    /// </summary>
    public enum CarryOutTaskType
    {
        /// <summary>
        /// 出库搬运
        /// </summary>
        [Display(Name = "出库搬运")]
        Out = 1,

        /// <summary>
        /// 临时搬运
        /// </summary>
        [Display(Name = "临时搬运")]
        Temp = 2
    }
}
