using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model
{
    /// <summary>
    /// 实体类 Stauts 属性
    /// </summary>
    public enum EntityStatus
    {
        #region System
        /// <summary>
        /// 0:正常
        /// </summary>
        [Display(Name = "正常")]
        Normal = 0,

        /// <summary>
        /// 1:已删除
        /// </summary>
        [Display(Name = "已删除")]
        Deleted = 1,
        #endregion //System

        #region User
        /// <summary>
        /// 11:用户已禁用
        /// </summary>
        [Display(Name = "已禁用")]
        UserDisable = 11,
        #endregion //User

        #region Contract
        /// <summary>
        /// 21:合同已关闭
        /// </summary>
        [Display(Name = "已关闭")]
        ContractClosed = 21,
        #endregion //Contract

        #region Warehouse

        #endregion //Warehouse


        #region Tray
        /// <summary>
        /// 41:托盘未使用
        /// </summary>
        [Display(Name = "未使用")]
        TrayUnused = 41,

        /// <summary>
        /// 42:托盘使用中
        /// </summary>
        [Display(Name = "使用中")]
        TrayInuse = 42,

        /// <summary>
        /// 43:托盘废弃
        /// </summary>
        [Display(Name = "废弃")]
        TrayAbandon = 43,
        #endregion //Tray


        #region Cargo
        /// <summary>
        /// 51:货品未入库
        /// </summary>
        [Display(Name = "未入库")]
        CargoNotIn = 51,

        /// <summary>
        /// 52:货品准备入库
        /// </summary>
        [Display(Name = "准备入库")]
        CargoStockInReady = 52,

        /// <summary>
        /// 53:货品入库
        /// </summary>
        [Display(Name = "入库")]
        CargoStockIn = 53,

        /// <summary>
        /// 54:货品准备出库
        /// </summary>
        [Display(Name = "准备出库")]
        CargoStockOutReady = 54,

        /// <summary>
        /// 55:货品出库
        /// </summary>
        [Display(Name = "出库")]
        CargoStockOut = 55,

        /// <summary>
        /// 56:货品准备移库
        /// </summary>
        [Display(Name = "准备移库")]
        CargoStockMoveReady = 56,

        /// <summary>
        /// 56:货品已结算
        /// </summary>
        [Display(Name = "货品已结算")]
        CargoSettled = 57,
        #endregion //Cargo

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
        /// 71:准备入库
        /// </summary>
        [Display(Name = "准备入库")]
        StockInReady = 71,

        /// <summary>
        /// 72:入库取消
        /// </summary>
        [Display(Name = "入库取消")]
        StockInCancel = 72,

        /// <summary>
        /// 73:已入库
        /// </summary>
        [Display(Name = "已入库")]
        StockIn = 73,

        /// <summary>
        /// 81:准备出库
        /// </summary>
        [Display(Name = "准备出库")]
        StockOutReady = 81,

        /// <summary>
        /// 82:出库取消
        /// </summary>
        [Display(Name = "出库取消")]
        StockOutCancel = 82,

        /// <summary>
        /// 83:已出库
        /// </summary>
        [Display(Name = "已出库")]
        StockOut = 83,

        /// <summary>
        /// 91:准备移库
        /// </summary>
        [Display(Name = "准备移库")]
        StockMoveReady = 91,

        /// <summary>
        /// 92:移库取消
        /// </summary>
        [Display(Name = "移库取消")]
        StockMoveCancel = 92,

        /// <summary>
        /// 93:已移库
        /// </summary>
        [Display(Name = "已移库")]
        StockMove = 93
        #endregion //Store
    }
}
