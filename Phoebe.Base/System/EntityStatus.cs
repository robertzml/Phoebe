using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Phoebe.Base.System
{
    /// <summary>
    /// 实体状态
    /// </summary>
    [Flags]
    public enum EntityStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        [Display(Name = "正常")]
        Normal = 0x0000,

        /// <summary>
        /// 已删除
        /// </summary>
        [Display(Name = "已删除")]
        Deleted = 0x0001,

        /// <summary>
        /// 已禁用
        /// </summary>
        [Display(Name = "已禁用")]
        Disabled = 0x0002,

        /// <summary>
        /// 已报废
        /// </summary>
        [Display(Name = "已报废")]
        Abandon = 0x0004
    }
}
