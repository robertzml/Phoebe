using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Phoebe.Core.View
{
    using Phoebe.Base.Framework;
    using SqlSugar;

    /// <summary>
    /// 库存视图类
    /// </summary>
    [SugarTable("StoreView")]
    public class StoreView : IBaseEntity<string>
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
        /// 仓位ID
        /// </summary>
        [Display(Name = "仓位ID")]
        public int PositionId { get; set; }

        /// <summary>
        /// 托盘码
        /// </summary>
        [Display(Name = "托盘码")]
        public string TrayCode { get; set; }      

        /// <summary>
        /// 在库数量
        /// </summary>
        [Display(Name = "在库数量")]
        public int StoreCount { get; set; }

        /// <summary>
        /// 在库重量
        /// </summary>
        [Display(Name = "在库重量")]
        public decimal StoreWeight { get; set; }

        /// <summary>
        /// 单位重量
        /// </summary>
        [Display(Name = "单位重量")]
        public decimal UnitWeight { get; set; }

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
        /// 入库单ID
        /// </summary>
        [Display(Name = "入库单ID")]
        public string StockInId { get; set; }

        /// <summary>
        /// 前序库存ID
        /// </summary>
        [Display(Name = "前序库存ID")]
        public string PrevStoreId { get; set; }

        /// <summary>
        /// 搬运入库任务ID
        /// </summary>
        [Display(Name = "搬运入库任务ID")]
        public string CarryInTaskId { get; set; }

        /// <summary>
        /// 搬运出库任务ID
        /// </summary>
        [Display(Name = "搬运出库任务ID")]
        public string CarryOutTaskId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

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
        /// 货品名称
        /// </summary>
        [Display(Name = "货品名称")]
        public string CargoName { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        [Display(Name = "规格")]
        public string Specification { get; set; }

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
        /// 客户名称
        /// </summary>
        [Display(Name = "客户名称")]
        public string CustomerName { get; set; }

        /// <summary>
        /// 客户编号
        /// </summary>
        [Display(Name = "客户编号")]
        public string CustomerNumber { get; set; }

        /// <summary>
        /// 合同名称
        /// </summary>
        [Display(Name = "合同名称")]
        public string ContractName { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        [Display(Name = "合同编号")]
        public string ContractNumber { get; set; }

        /// <summary>
        /// 合同类型
        /// </summary>
        [Display(Name = "合同类型")]
        public int ContractType { get; set; }

        /// <summary>
        /// 签订日期
        /// </summary>
        [Display(Name = "签订日期")]
        public DateTime SignDate { get; set; }

        /// <summary>
        /// 关闭日期
        /// </summary>
        [Display(Name = "关闭日期")]
        public DateTime? CloseDate { get; set; }

        /// <summary>
        /// 计费方式
        /// </summary>
        [Display(Name = "计费方式")]
        public int BillingType { get; set; }

        /// <summary>
        /// 冷藏费单价
        /// </summary>
        [Display(Name = "冷藏费单价")]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 参数1
        /// </summary>
        [Display(Name = "参数1")]
        public string Parameter1 { get; set; }

        /// <summary>
        /// 参数2
        /// </summary>
        [Display(Name = "参数2")]
        public string Parameter2 { get; set; }

        /// <summary>
        /// 参数3
        /// </summary>
        [Display(Name = "参数3")]
        public string Parameter3 { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        [Display(Name = "仓库ID")]
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
        public string PositionNumber { get; set; }

        /// <summary>
        /// 副编号
        /// </summary>
        [Display(Name = "副编号")]
        public string VicePositionNumber { get; set; }

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
        /// 货架码
        /// </summary>
        [Display(Name = "货架码")]
        public string ShelfCode { get; set; }
        #endregion //Property
    }
}
