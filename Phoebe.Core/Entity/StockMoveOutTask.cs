using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Phoebe.Core.Entity
{
    using Phoebe.Base.Framework;
    using SqlSugar;

    /// <summary>
    /// 移出任务类
    /// </summary>
    [SugarTable("StockMoveOutTask")]
    public class StockMoveOutTask : IBaseEntity<string>
    {
        #region Property
        /// <summary>
        /// ID
        /// </summary>
        [SugarColumn(ColumnName = "Id", IsPrimaryKey = true)]
        [Display(Name = "ID")]
        public string Id { get; set; }

        /// <summary>
        /// 仓库类型
        /// </summary>
        [Display(Name = "仓库类型")]
        public int WarehouseType { get; set; }

        /// <summary>
        /// 移库类型
        /// </summary>
        [Display(Name = "移库类型")]
        public int Type { get; set; }

        /// <summary>
        /// 库存ID
        /// </summary>
        [Display(Name = "库存ID")]
        public string StoreId { get; set; }

        /// <summary>
        /// 移库任务ID
        /// </summary>
        [Display(Name = "移库任务ID")]
        public string StockOutTaskId { get; set; }

        /// <summary>
        /// 在库数量
        /// </summary>
        [Display(Name = "在库数量")]
        public int StoreCount { get; set; }

        /// <summary>
        /// 移出数量
        /// </summary>
        [Display(Name = "移出数量")]
        public int MoveCount { get; set; }

        /// <summary>
        /// 在库重量
        /// </summary>
        [Display(Name = "在库重量")]
        public decimal StoreWeight { get; set; }

        /// <summary>
        /// 移出重量
        /// </summary>
        [Display(Name = "移出重量")]
        public decimal MoveWeight { get; set; }

        /// <summary>
        /// 任务码
        /// </summary>
        [Display(Name = "任务码")]
        public string TaskCode { get; set; }

        /// <summary>
        /// 托盘码
        /// </summary>
        [Display(Name = "托盘码")]
        public string TrayCode { get; set; }

        /// <summary>
        /// 清点人ID
        /// </summary>
        [Display(Name = "清点人ID")]
        public int UserId { get; set; }

        /// <summary>
        /// 清点人
        /// </summary>
        [Display(Name = "清点人")]
        public string UserName { get; set; }

        /// <summary>
        /// 接单人ID
        /// </summary>
        [Display(Name = "接单人ID")]
        public int ReceiveUserId { get; set; }

        /// <summary>
        /// 接单人
        /// </summary>
        [Display(Name = "接单人")]
        public string ReceiveUserName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime CreateTIme { get; set; }

        /// <summary>
        /// 接单时间
        /// </summary>
        [Display(Name = "接单时间")]
        public DateTime? ReceiveTime { get; set; }

        /// <summary>
        /// 移出时间
        /// </summary>
        [Display(Name = "移出时间")]
        public DateTime? OutTime { get; set; }

        /// <summary>
        /// 清点时间
        /// </summary>
        [Display(Name = "清点时间")]
        public DateTime? CheckTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        public string Remark { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public int Status { get; set; }
        #endregion //Property
    }
}
