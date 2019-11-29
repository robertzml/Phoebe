using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Phoebe.Core
{
    using Phoebe.Base.Framework;
    using SqlSugar;

    /// <summary>
    /// 移入任务类
    /// </summary>
    [SugarTable("StockMoveInTask")]
    public class StockMoveInTask : IBaseEntity<string>
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
        /// 移出任务ID
        /// </summary>
        [Display(Name = "移出任务ID")]
        public string StockMoveOutTaskId { get; set; }

        /// <summary>
        /// 移入数量
        /// </summary>
        [Display(Name = "移入数量")]
        public int MoveCount { get; set; }

        /// <summary>
        /// 移入重量
        /// </summary>
        [Display(Name = "移入重量")]
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
        /// 清点时间
        /// </summary>
        [Display(Name = "清点时间")]
        public DateTime? CheckTime { get; set; }

        /// <summary>
        /// 移入时间
        /// </summary>
        [Display(Name = "移入时间")]
        public DateTime? InTime { get; set; }

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
