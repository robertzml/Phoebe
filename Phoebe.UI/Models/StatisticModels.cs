using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Phoebe.UI.Models
{
    /// <summary>
    /// 客户流水输入模型
    /// </summary>
    public class CustomerFlowInput
    {
        /// <summary>
        /// 客户类型
        /// </summary>
        [Required]
        [UIHint("CustomerType")]
        [Display(Name = "客户类型")]
        public int CustomerType { get; set; }

        /// <summary>
        /// 客户ID
        /// </summary>
        [Required]
        [Display(Name = "客户选择")]
        public int CustomerID { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "开始日期")]
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "结束日期")]
        public DateTime DateTo { get; set; }
    }

    /// <summary>
    /// 合同流水输入模型
    /// </summary>
    public class ContractFlowInput
    {
        /// <summary>
        /// 合同
        /// </summary>
        [Required]
        [Display(Name = "合同选择")]
        public int ContractID { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "开始日期")]
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "结束日期")]
        public DateTime DateTo { get; set; }
    }

    /// <summary>
    /// 合同库存统计输入模型
    /// </summary>
    public class ContractStoreInput
    {
        /// <summary>
        /// 合同
        /// </summary>
        [Required]
        [Display(Name = "合同选择")]
        public int ContractID { get; set; }

        /// <summary>
        /// 日期选择
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "日期选择")]
        public DateTime Date { get; set; }
    }

    /// <summary>
    /// 库存汇总输入模型
    /// </summary>
    public class StoreSummaryInput
    {
        /// <summary>
        /// 日期选择
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "日期选择")]
        public DateTime Date { get; set; }
    }
}