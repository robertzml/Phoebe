using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Phoebe.Core.View
{
    using Phoebe.Base.Framework;
    using SqlSugar;

    /// <summary>
    /// 仓位视图类
    /// </summary>
    [SugarTable("PositionView")]
    public class PositionView : IBaseEntity<int>
    {
        #region Property
        /// <summary>
        /// ID
        /// </summary>
        [SugarColumn(ColumnName = "Id", IsPrimaryKey = true, IsIdentity = true)]
        [Display(Name = "ID")]
        public int Id { get; set; }

        /// <summary>
        /// 所属仓库
        /// </summary>
        [Display(Name = "所属仓库")]
        public int WarehouseId { get; set; }

        /// <summary>
        /// 所属货架
        /// </summary>
        [Display(Name = "所属货架")]
        public int ShelfId { get; set; }

        /// <summary>
        /// 排数
        /// </summary>
        [Display(Name = "排数")]
        public int Row { get; set; }

        /// <summary>
        /// 层数
        /// </summary>
        [Display(Name = "层数")]
        public int Layer { get; set; }

        /// <summary>
        /// 进数
        /// </summary>
        [Display(Name = "进数")]
        public int Depth { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Display(Name = "编号")]
        public string Number { get; set; }

        /// <summary>
        /// 副编号
        /// </summary>
        [Display(Name = "副编号")]
        public string ViceNumber { get; set; }

        /// <summary>
        /// 主货架码
        /// </summary>
        [Display(Name = "主货架码")]
        public string ShelfCode { get; set; }

        /// <summary>
        /// 副货架码
        /// </summary>
        [Display(Name = "副货架码")]
        public string ViceShelfCode { get; set; }

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

        /// <summary>
        /// 货架编号
        /// </summary>
        [Display(Name = "货架编号")]
        public string ShelfNumber { get; set; }

        /// <summary>
        /// 货架类型
        /// </summary>
        [Display(Name = "货架类型")]
        public int ShelfType { get; set; }

        /// <summary>
        /// 货架入口数
        /// </summary>
        [Display(Name = "货架入口数")]
        public int Entrance { get; set; }

        /// <summary>
        /// 最大排数
        /// </summary>
        [Display(Name = "最大排数")]
        public int MaxRow { get; set; }

        /// <summary>
        /// 最大层数
        /// </summary>
        [Display(Name = "最大层数")]
        public int MaxLayer { get; set; }

        /// <summary>
        /// 最大进数
        /// </summary>
        [Display(Name = "最大进数")]
        public int MaxDepth { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        [Display(Name = "仓库名称")]
        public string WarehouseName { get; set; }

        /// <summary>
        /// 仓库编号
        /// </summary>
        [Display(Name = "仓库编号")]
        public string WarehouseNumber { get; set; }

        /// <summary>
        /// 仓库类型
        /// </summary>
        [Display(Name = "仓库类型")]
        public int WarehouseType { get; set; }
        #endregion //Property
    }
}
