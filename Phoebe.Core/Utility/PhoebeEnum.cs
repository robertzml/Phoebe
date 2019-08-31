using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Phoebe.Core.Utility
{
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
}
