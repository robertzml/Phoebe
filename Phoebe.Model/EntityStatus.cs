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
        CargoNotIn = 51
        #endregion //Cargo

    }
}
