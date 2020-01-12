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
    [SugarTable("StockInTask")]
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
        /// 入库数量
        /// </summary>
        [Display(Name = "入库数量")]
        public int InCount { get; set; }

        /// <summary>
        /// 单位重量
        /// </summary>
        [Display(Name = "单位重量")]
        public decimal UnitWeight { get; set; }

        /// <summary>
        /// 入库重量
        /// </summary>
        [Display(Name = "入库重量")]
        public decimal InWeight { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        [Display(Name = "批次")]
        public string Batch { get; set; }

        /// <summary>
        /// 产地
        /// </summary>
        [Display(Name = "产地")]
        public string OriginPlace { get; set; }

        /// <summary>
        /// 保质期
        /// </summary>
        [Display(Name = "保质期")]
        public int Durability { get; set; }

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
        #endregion //Method
    }
}
