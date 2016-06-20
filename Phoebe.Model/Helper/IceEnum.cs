using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Phoebe.Model
{
    /// <summary>
    /// 冰块类型
    /// </summary>
    public enum IceType
    {
        /// <summary>
        /// 整冰
        /// </summary>
        [Display(Name = "整冰")]
        Complete = 1,

        /// <summary>
        /// 碎冰
        /// </summary>
        [Display(Name = "碎冰")]
        Fragment = 2
    }

    /// <summary>
    /// 冰块流水类型
    /// </summary>
    public enum IceFlowType
    {
        /// <summary>
        /// 整冰入库
        /// </summary>
        [Display(Name = "整冰入库")]
        CompleteStockIn = 1,

        /// <summary>
        /// 碎冰入库
        /// </summary>
        [Display(Name = "碎冰入库")]
        FragmentStockIn = 2,

        /// <summary>
        /// 整冰制冰出库
        /// </summary>
        [Display(Name = "整冰制冰出库")]
        CompleteMakeOut = 3,

        /// <summary>
        /// 整冰销售出库
        /// </summary>
        [Display(Name = "整冰销售出库")]
        CompleteSaleOut = 4,

        /// <summary>
        /// 整冰销售出库
        /// </summary>
        [Display(Name = "整冰销售出库")]
        FragmentSaleOut = 5,
    }
}
