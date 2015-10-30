using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Phoebe.Model;

namespace Phoebe.UI.Models
{
    /// <summary>
    /// 结算输入模型
    /// </summary>
    public class SettleInput
    {
        [Required]
        [UIHint("CustomerType")]
        [Display(Name = "客户类型")]
        public int CustomerType { get; set; }

        /// <summary>
        /// 客户ID
        /// </summary>
        [Required]
        [Display(Name = "选择客户")]
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
    /// 结算处理模型
    /// </summary>
    public class SettleProcess
    {
        /// <summary>
        /// 基本费用结算
        /// </summary>
        public List<Billing> Billings { get; set; }

        /// <summary>
        /// 冷藏费用结算
        /// </summary>
        public List<ColdSettlement> ColdSettles { get; set; }
    }

    /// <summary>
    /// 合同冷藏费输入模型
    /// </summary>
    public class ContractColdInput
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
    /// 货品冷藏费输入模型
    /// </summary>
    public class CargoColdInput
    {
        /// <summary>
        /// 合同
        /// </summary>
        [Required]
        [Display(Name = "合同选择")]
        public int ContractID { get; set; }

        /// <summary>
        /// 货品
        /// </summary>
        [Required]
        [Display(Name = "货品选择")]
        public string CargoID { get; set; }

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
}