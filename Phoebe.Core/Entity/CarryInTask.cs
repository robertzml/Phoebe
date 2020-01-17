using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Phoebe.Core.Entity
{
    using Phoebe.Base.Framework;
    using SqlSugar;

    /// <summary>
    /// 搬运入库任务类
    /// </summary>
    [SugarTable("CarryInTask")]
    public class CarryInTask : IBaseEntity<string>
    {
        #region Property
        /// <summary>
        /// ID
        /// </summary>
        [SugarColumn(ColumnName = "Id", IsPrimaryKey = true)]
        [Display(Name = "ID")]
        public string Id { get; set; }

        /// <summary>
        /// 搬运类型
        /// </summary>
        [Display(Name = "搬运类型")]
        public int Type { get; set; }

        /// <summary>
        /// 所属客户
        /// </summary>
        [Display(Name = "所属客户")]
        public int CustomerId { get; set; }

        /// <summary>
        /// 所属合同
        /// </summary>
        [Display(Name = "所属合同")]
        public int ContractId { get; set; }

        /// <summary>
        /// 货品ID
        /// </summary>
        [Display(Name = "货品ID")]
        public string CargoId { get; set; }

        /// <summary>
        /// 库存ID
        /// </summary>
        [Display(Name = "库存ID")]
        public string StoreId { get; set; }

        /// <summary>
        /// 入库任务ID
        /// </summary>
        [Display(Name = "入库任务ID")]
        public string StockInTaskId { get; set; }

        /// <summary>
        /// 出库任务ID
        /// </summary>
        [Display(Name = "出库任务ID")]
        public string StockOutTaskId { get; set; }

        /// <summary>
        /// 入库数量
        /// </summary>
        [Display(Name = "入库数量")]
        public int MoveCount { get; set; }

        /// <summary>
        /// 入库重量
        /// </summary>
        [Display(Name = "入库重量")]
        public decimal MoveWeight { get; set; }

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
        /// 存放位置
        /// </summary>
        [Display(Name = "存放位置")]
        public string Place { get; set; }

        /// <summary>
        /// 清点人ID
        /// </summary>
        [Display(Name = "清点人ID")]
        public int CheckUserId { get; set; }

        /// <summary>
        /// 清点人
        /// </summary>
        [Display(Name = "清点人")]
        public string CheckUserName { get; set; }

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
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 清点时间
        /// </summary>
        [Display(Name = "清点时间")]
        public DateTime? CheckTime { get; set; }

        /// <summary>
        /// 接单时间
        /// </summary>
        [Display(Name = "接单时间")]
        public DateTime? ReceiveTime { get; set; }

        /// <summary>
        /// 移入时间
        /// </summary>
        [Display(Name = "移入时间")]
        public DateTime? MoveTime { get; set; }

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
        #endregion //Property
    }
}
