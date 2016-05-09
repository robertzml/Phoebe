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
        /// <summary>
        /// 31:仓库空闲
        /// </summary>
        [Display(Name = "空闲")]
        WarehouseFree = 31,

        /// <summary>
        /// 32:仓库废弃
        /// </summary>
        [Display(Name = "废弃")]
        WarehouseReserve = 32,
        #endregion //Warehouse        

        #region Cargo

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
        #endregion //Store

        #region Stock
        /// <summary>
        /// 71:准备入库
        /// </summary>
        [Display(Name = "准备入库")]
        StockInReady = 71,

        /// <summary>
        /// 72:已入库
        /// </summary>
        [Display(Name = "已入库")]
        StockIn = 72,

        /// <summary>
        /// 81:准备出库
        /// </summary>
        [Display(Name = "准备出库")]
        StockOutReady = 81,

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
        /// 93:已移库
        /// </summary>
        [Display(Name = "已移库")]
        StockMove = 93,
        #endregion //Stock       

        #region Settlement
        /// <summary>
        /// 111:结算单已结算
        /// </summary>
        [Display(Name = "已结算")]
        Settled = 111,

        /// <summary>
        /// 112:结算单已取消
        /// </summary>
        [Display(Name = "已取消")]
        SettleCancel = 112,
        #endregion //Settlement

        #region Billing
        /// <summary>
        /// 123:基本费用未初始化
        /// </summary>
        [Display(Name = "未初始化")]
        BillingNotInit = 123,
        #endregion //Billing

        #region Payment
        /// <summary>
        /// 130:已付款
        /// </summary>
        [Display(Name = "已付款")]
        PaymentPaid = 130
        #endregion //Payment
    }
}
