using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Phoebe.Core.Utility
{
    /// <summary>
    /// 托盘状态
    /// </summary>
    public enum TrayStatus
    {
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
}
