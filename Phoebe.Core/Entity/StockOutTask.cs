using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Phoebe.Core.Entity
{
    using Phoebe.Base.Framework;
    using SqlSugar;

    /// <summary>
    /// 出库任务类
    /// </summary>
    [SugarTable("StockOutTask")]
    public class StockOutTask : IBaseEntity<string>
    {
        #region Property
        /// <summary>
        /// ID
        /// </summary>
        [SugarColumn(ColumnName = "Id", IsPrimaryKey = true)]
        [Display(Name = "ID")]
        public string Id { get; set; }

        /// <summary>
        /// 出库ID
        /// </summary>
        [Display(Name = "出库ID")]
        public string StockOutId { get; set; }

        /// <summary>
        /// 任务码
        /// </summary>
        [Display(Name = "任务码")]
        public string TaskCode { get; set; }

        /// <summary>
        /// 货品ID
        /// </summary>
        [Display(Name = "货品ID")]
        public string CargoId { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        [Display(Name = "库存数量")]
        public int StoreCount { get; set; }

        /// <summary>
        /// 出库数量
        /// </summary>
        [Display(Name = "出库数量")]
        public int OutCount { get; set; }

        /// <summary>
        /// 库存重量
        /// </summary>
        [Display(Name = "库存重量")]
        public decimal StoreWeight { get; set; }

        /// <summary>
        /// 出库重量
        /// </summary>
        [Display(Name = "出库重量")]
        public decimal OutWeight { get; set; }

        /// <summary>
        /// 单位重量
        /// </summary>
        [Display(Name = "单位重量")]
        public decimal UnitWeight { get; set; }

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
        /// 创建人ID
        /// </summary>
        [Display(Name = "创建人ID")]
        public int UserId { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name = "创建人")]
        public string UserName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

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
