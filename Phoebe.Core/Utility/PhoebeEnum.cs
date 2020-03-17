using System;
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
        Position = 2,

        /// <summary>
        /// 冷冻库出库
        /// </summary>
        [Display(Name = "冷冻库出库")]
        Freeze = 3
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

    /// <summary>
    /// 流水类型
    /// </summary>
    public enum StockFlowType
    {
        /// <summary>
        /// 无
        /// </summary>
        [Display(Name = "无")]
        None = 0,

        /// <summary>
        /// 入库
        /// </summary>
        [Display(Name = "入库")]
        StockIn = 1,

        /// <summary>
        /// 出库
        /// </summary>
        [Display(Name = "出库")]
        StockOut = 2,

        /// <summary>
        /// 移库
        /// </summary>
        [Display(Name = "移库")]
        StockMove = 3,

        /// <summary>
        /// 移入
        /// </summary>
        [Display(Name = "移入")]
        StockMoveIn = 4,

        /// <summary>
        /// 移出
        /// </summary>
        [Display(Name = "移出")]
        StockMoveOut = 5
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
        Ice = 4        
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
        /// 计数
        /// </summary>
        [Display(Name = "计数", Description = "单价:元/件")]
        Count = 2,

        /// <summary>
        /// 非等重
        /// </summary>
        [Display(Name = "非等重", Description = "单价:元/吨")]
        VariousWeight = 3,

        /// <summary>
        /// 仓位
        /// </summary>
        [Display(Name = "仓位", Description = "单价:元/仓位")]
        Position = 4,

        /// <summary>
        /// 板位
        /// </summary>
        [Display(Name = "板位", Description = "单价:元/板位")]
        Board = 5
    }
}
