using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Phoebe.Core.Entity
{
    using Phoebe.Base.Framework;
    using SqlSugar;

    /// <summary>
    /// 库存类
    /// </summary>
    [SugarTable("Store")]
    public class Store : IBaseEntity<string>
    {
        #region Property
        /// <summary>
        /// ID
        /// </summary>
        [SugarColumn(ColumnName = "Id", IsPrimaryKey = true)]
        [Display(Name = "ID")]
        public string Id { get; set; }

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
        /// 所属货品
        /// </summary>
        [Display(Name = "所属货品")]
        public string CargoId { get; set; }

        /// <summary>
        /// 类别ID
        /// </summary>
        [Display(Name = "类别ID")]
        public int CategoryId { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        [Display(Name = "仓库ID")]
        public int WarehouseId { get; set; }

        /// <summary>
        /// 仓位ID
        /// </summary>
        [Display(Name = "仓位ID")]
        public int PositionId { get; set; }

        /// <summary>
        /// 总数量
        /// </summary>
        [Display(Name = "总数量")]
        public int TotalCount { get; set; }

        /// <summary>
        /// 在库数量
        /// </summary>
        [Display(Name = "在库数量")]
        public int StoreCount { get; set; }

        /// <summary>
        /// 总重量
        /// </summary>
        [Display(Name = "总重量")]
        public decimal TotalWeight { get; set; }

        /// <summary>
        /// 在库重量
        /// </summary>
        [Display(Name = "在库重量")]
        public decimal StoreWeight { get; set; }

        /// <summary>
        /// 入库任务ID
        /// </summary>
        [Display(Name = "入库任务ID")]
        public string StockInTaskId { get; set; }

        /// <summary>
        /// 移库任务ID
        /// </summary>
        [Display(Name = "移库任务ID")]
        public string StockMoveTaskId { get; set; }

        /// <summary>
        /// 入库时间
        /// </summary>
        [Display(Name = "入库时间")]
        public DateTime InTime { get; set; }

        /// <summary>
        /// 出库时间
        /// </summary>
        [Display(Name = "出库时间")]
        public DateTime? OutTime { get; set; }

        /// <summary>
        /// 移入时间
        /// </summary>
        [Display(Name = "移入时间")]
        public DateTime MoveTime { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        [Display(Name = "来源")]
        public int Source { get; set; }

        /// <summary>
        /// 目的地
        /// </summary>
        [Display(Name = "目的地")]
        public int Destination { get; set; }

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
