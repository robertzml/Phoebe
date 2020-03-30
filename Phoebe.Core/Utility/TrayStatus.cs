using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Phoebe.Core.Utility
{
    /// <summary>
    /// 托盘库存状态
    /// </summary>
    public enum TrayStoreStatus
    {
        /// <summary>
        /// 异常
        /// </summary>
        [Display(Name = "异常")]
        Error = 0,

        /// <summary>
        /// 在库
        /// </summary>
        [Display(Name = "在库")]
        InStore = 1,

        /// <summary>
        /// 出库
        /// </summary>
        [Display(Name = "出库")]
        OutStore = 2,
    }

    /// <summary>
    /// 托盘搬运状态
    /// </summary>
    public enum TrayCarryStatus
    {
        /// <summary>
        /// 异常
        /// </summary>
        [Display(Name = "异常")]
        Error = 0,

        /// <summary>
        /// 准备上架
        /// </summary>
        [Display(Name = "准备上架")]
        CarryInReady = 1,

        /// <summary>
        /// 准备下架
        /// </summary>
        [Display(Name = "准备下架")]
        CarryOutReady = 2,

        /// <summary>
        /// 已下架
        /// </summary>
        [Display(Name = "已下架")]
        CarryOutLeave = 3,

        /// <summary>
        /// 准备放回
        /// </summary>
        [Display(Name = "准备放回")]
        CarryInBack = 4,

        /// <summary>
        /// 非搬运状态
        /// </summary>
        [Display(Name = "非搬运状态")]
        NotUse = 5
    }
}
