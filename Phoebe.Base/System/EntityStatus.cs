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

        #region Position
        /// <summary>
        /// 仓位可用
        /// </summary>
        [Display(Name = "可用")]
        Available = 31,

        /// <summary>
        /// 仓位占用
        /// </summary>
        [Display(Name = "占用")]
        Occupy = 32,
        #endregion //Position

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
        /// 63:准备移入
        /// </summary>
        [Display(Name = "准备移入")]
        StoreInReady = 63,

        /// <summary>
        /// 64:准备移出
        /// </summary>
        [Display(Name = "准备移出")]
        StoreOutReady = 64,
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
        StockInFinish = 75,

        /// <summary>
        /// 76:待上架
        /// </summary>
        [Display(Name = "待上架")]
        CarryInReady = 76,

        /// <summary>
        /// 77:已上架
        /// </summary>
        [Display(Name = "已上架")]
        CarryInEnter = 77,
        #endregion //Stock In

        #region Stock Out
        /// <summary>
        /// 81:待出库
        /// </summary>
        [Display(Name = "待出库")]
        StockOutReady = 81,

        /// <summary>
        /// 82:已接单
        /// </summary>
        [Display(Name = "已接单")]
        StockOutReceive = 82,

        /// <summary>
        /// 83:已下架
        /// </summary>
        [Display(Name = "已下架")]
        StockOutLeave = 83,

        /// <summary>
        /// 84:已清点
        /// </summary>
        [Display(Name = "已清点")]
        StockOutCheck = 84,

        /// <summary>
        /// 85:已出库
        /// </summary>
        [Display(Name = "已出库")]
        StockOutFinish = 85,

        /// <summary>
        /// 86:待下架
        /// </summary>
        [Display(Name = "待下架")]
        CarryOutReady = 86,

        /// <summary>
        /// 87:已下架
        /// </summary>
        [Display(Name = "已下架")]
        CarryOutLeave = 87,
        #endregion //Stock Out

        #region Stock Move
        /// <summary>
        /// 91:准备移库
        /// </summary>
        [Display(Name = "准备移库")]
        StockMoveReady = 91,

        /// <summary>
        /// 92:已接单
        /// </summary>
        [Display(Name = "已接单")]
        StockMoveReceive = 92,

        /// <summary>
        /// 93:已下架
        /// </summary>
        [Display(Name = "已下架")]
        StockMoveLeave = 93,

        /// <summary>
        /// 94:已清点
        /// </summary>
        [Display(Name = "已清点")]
        StockMoveCheck = 94,

        /// <summary>
        /// 95:已上架
        /// </summary>
        [Display(Name = "已上架")]
        StockMoveEnter = 95,

        /// <summary>
        /// 96:已移库
        /// </summary>
        [Display(Name = "已移库")]
        StockMoveFinish = 96,
        #endregion //Stock Move

        #region Fee
        /// <summary>
        /// 开始计费
        /// </summary>
        [Display(Name = "开始计费")]
        FeeStart = 101,

        /// <summary>
        /// 计费完成
        /// </summary>
        [Display(Name = "计费完成")]
        FeeEnd = 102
        #endregion //Fee
    }
}
