using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Phoebe.Core.Entity
{
    using Phoebe.Base.Framework;
    using SqlSugar;

    /// <summary>
    /// 仓位类
    /// </summary>
    [SugarTable("Position")]
    public class Position : IBaseEntity<int>
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
        /// 是否空闲
        /// </summary>
        [Display(Name = "是否空闲")]
        public bool IsEmpty { get; set; }

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
