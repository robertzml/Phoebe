﻿using System;
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

        #region Contract
        /// <summary>
        /// 合同已关闭
        /// </summary>
        [Display(Name = "已关闭")]
        ContractClosed = 11,
        #endregion //Contract

        #region Warehouse

        #endregion //Warehouse


        #region Tray
        /// <summary>
        /// 托盘未使用
        /// </summary>
        [Display(Name = "未使用")]
        TrayUnused = 31,

        /// <summary>
        /// 托盘使用中
        /// </summary>
        [Display(Name = "使用中")]
        TrayInuse = 32,

        /// <summary>
        /// 托盘废弃
        /// </summary>
        [Display(Name = "废弃")]
        TrayAbandon = 33,
        #endregion //Tray


        #region Cargo
        /// <summary>
        /// 货品未入库
        /// </summary>
        [Display(Name = "未入库")]
        CargoNotIn = 41
        #endregion //Cargo

    }
}