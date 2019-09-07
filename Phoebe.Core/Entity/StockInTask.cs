using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Phoebe.Core.Entity
{
    using Phoebe.Base.Framework;
    using SqlSugar;

    /// <summary>
    /// 入库任务类
    /// </summary>
    public class StockInTask : IBaseEntity<string>
    {
        #region Property
        /// <summary>
        /// ID
        /// </summary>
        [SugarColumn(ColumnName = "Id", IsPrimaryKey = true)]
        [Display(Name = "ID")]
        public string Id { get; set; }

        /// <summary>
        /// 入库ID
        /// </summary>
        [Display(Name = "入库ID")]
        public string StockInId { get; set; }

        /// <summary>
        /// 库存ID
        /// </summary>
        [Display(Name = "库存ID")]
        public string StoreId { get; set; }

        /// <summary>
        /// 入库数量
        /// </summary>
        [Display(Name = "入库数量")]
        public int InCount { get; set; }

        /// <summary>
        /// 入库重量
        /// </summary>
        [Display(Name = "入库重量")]
        public decimal InWeight { get; set; }

        /// <summary>
        /// 任务码
        /// </summary>
        [Display(Name = "任务码")]
        public string TaskCode { get; set; }

        /// <summary>
        /// 货架码
        /// </summary>
        [Display(Name = "货架码")]
        public string ShelfCode { get; set; }

        /// <summary>
        /// 托盘码
        /// </summary>
        [Display(Name = "托盘码")]
        public string TrayCode { get; set; }

        /// <summary>
        /// 仓位ID
        /// </summary>
        [Display(Name = "仓位ID")]
        public int PositionId { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        [Display(Name = "仓库ID")]
        public int WarehouseId { get; set; }

        /// <summary>
        /// 存放位置
        /// </summary>
        [Display(Name = "存放位置")]
        public string Place { get; set; }

        /// <summary>
        /// 操作人ID
        /// </summary>
        [Display(Name = "操作人ID")]
        public int UserId { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        [Display(Name = "操作人")]
        public string UserName { get; set; }

        /// <summary>
        /// 接单时间
        /// </summary>
        [Display(Name = "接单时间")]
        public DateTime? ReceiveTime { get; set; }

        /// <summary>
        /// 完成时间
        /// </summary>
        [Display(Name = "完成时间")]
        public DateTime? FinishTime { get; set; }

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
        #endregion //Method
    }
}
