using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model
{
    /// <summary>
    /// 合同类型
    /// </summary>
    public enum ContractType
    {
        /// <summary>
        /// 长期合同
        /// </summary>
        [Display(Name = "长期合同")]
        Long = 1,

        /// <summary>
        /// 短期合同
        /// </summary>
        [Display(Name = "短期合同")]
        Short = 2
    }

    /// <summary>
    /// 客户类型
    /// </summary>
    public enum CustomerType
    {
        /// <summary>
        /// 团体客户
        /// </summary>
        [Display(Name = "团体客户")]
        Group = 1,

        /// <summary>
        /// 零散客户
        /// </summary>
        [Display(Name = "零散客户")]
        Scatter = 2
    }

    /// <summary>
    /// 计费方式
    /// </summary>
    public enum BillingType
    {
        /// <summary>
        /// 件重
        /// </summary>
        [Display(Name = "件重", Description = "单价:元/吨")]
        UnitWeight = 1,

        /// <summary>
        /// 件体积
        /// </summary>
        [Display(Name = "件体积", Description = "单价:元/立方")]
        UnitVolume = 2,

        /// <summary>
        /// 计数
        /// </summary>
        [Display(Name = "计数", Description = "单价:元/件")]
        Count = 3
    }

    /// <summary>
    /// 费用类型
    /// </summary>
    public enum ExpenseType
    {
        /// <summary>
        /// 基本费用
        /// </summary>
        [Display(Name = "基本费用")]
        Base = 1,

        /// <summary>
        /// 冷藏费用
        /// </summary>
        [Display(Name = "冷藏费用")]
        Cold = 2
    }

    /// <summary>
    /// 来源类型
    /// </summary>
    public enum SourceType
    {
        /// <summary>
        /// 入库
        /// </summary>
        [Display(Name = "入库")]
        StockIn = 0,

        /// <summary>
        /// 移库
        /// </summary>
        [Display(Name = "移库")]
        StockMove = 1
    }

    /// <summary>
    /// 目的地类型
    /// </summary>
    public enum DestinationType
    {
        /// <summary>
        /// 出库
        /// </summary>
        [Display(Name = "出库")]
        StockOut = 0,

        /// <summary>
        /// 移库
        /// </summary>
        [Display(Name = "移库")]
        StockMove = 1
    }
}
