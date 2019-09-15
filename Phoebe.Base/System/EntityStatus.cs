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

        #region Store
        /// <summary>
        /// 61:在库
        /// </summary>
        [Display(Name = "在库")]
        StoreIn = 61,

        /// <summary>
        /// 62:出库
        /// </summary>
        [Display(Name = "出库")]
        StoreOut = 62,

        /// <summary>
        /// 63:准备入库
        /// </summary>
        [Display(Name = "准备入库")]
        StoreReady = 63,

        /// <summary>
        /// 64:准备移入
        /// </summary>
        [Display(Name = "准备移入")]
        StoreMoveReady = 64,
        #endregion //Store

        #region Stock In
        /// <summary>
        /// 71:待入库
        /// </summary>
        [Display(Name = "待入库")]
        StockInReady = 71,

        /// <summary>
        /// 72:已清点
        /// </summary>
        [Display(Name = "已清点")]
        StockInCheck = 72,

        /// <summary>
        /// 73:已接单
        /// </summary>
        [Display(Name = "已接单")]
        StockInReceive = 73,

        /// <summary>
        /// 74:已上架
        /// </summary>
        [Display(Name = "已上架")]
        StockInEnter = 74,

        /// <summary>
        /// 75:已入库
        /// </summary>
        [Display(Name = "已入库")]
        StockInFinish = 75
        #endregion //Stock In
    }
}
