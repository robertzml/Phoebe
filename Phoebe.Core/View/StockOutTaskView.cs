using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Phoebe.Core.View
{
    using Phoebe.Base.Framework;
    using SqlSugar;

    /// <summary>
    /// 出库任务视图类
    /// </summary>
    [SugarTable("StockOutTaskView")]
    public class StockOutTaskView : IBaseEntity<string>
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

        /// <summary>
        /// 出库时间
        /// </summary>
        [Display(Name = "出库时间")]
        public DateTime OutTime { get; set; }

        /// <summary>
        /// 流水单号
        /// </summary>
        [Display(Name = "流水单号")]
        public string FlowNumber { get; set; }

        /// <summary>
        /// 出库类型
        /// </summary>
        [Display(Name = "出库类型")]
        public int StockOutType { get; set; }

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
        /// 客户编号
        /// </summary>
        [Display(Name = "客户编号")]
        public string CustomerNumber { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        [Display(Name = "客户名称")]
        public string CustomerName { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        [Display(Name = "合同编号")]
        public string ContractNumber { get; set; }

        /// <summary>
        /// 合同名称
        /// </summary>
        [Display(Name = "合同名称")]
        public string ContractName { get; set; }

        /// <summary>
        /// 合同类型
        /// </summary>
        [Display(Name = "合同类型")]
        public int ContractType { get; set; }

        /// <summary>
        /// 货品名称
        /// </summary>
        [Display(Name = "货品名称")]
        public string CargoName { get; set; }

        /// <summary>
        /// 类别名称
        /// </summary>
        [Display(Name = "类别名称")]
        public string CategoryName { get; set; }

        /// <summary>
        /// 类别代码
        /// </summary>
        [Display(Name = "类别代码")]
        public string CategoryNumber { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        [Display(Name = "规格")]
        public string Specification { get; set; }

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
