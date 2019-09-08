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
        #region System
        /// <summary>
        /// 正常
        /// </summary>
        [Display(Name = "正常")]
        Normal = 0,

        /// <summary>
        /// 已删除
        /// </summary>
        [Display(Name = "已删除")]
        Deleted = 1,

        /// <summary>
        /// 已禁用
        /// </summary>
        [Display(Name = "已禁用")]
        Disabled = 2,

        /// <summary>
        /// 已作废
        /// </summary>
        [Display(Name = "已作废")]
        Abandon = 3,

        /// <summary>
        /// 已关闭
        /// </summary>
        [Display(Name = "已关闭")]
        Closed = 4,
        #endregion //System

        #region Stock In
        /// <summary>
        /// 71:待入库
        /// </summary>
        [Display(Name = "待入库")]
        StockInReady = 71,
        #endregion //Stock In
    }
}
