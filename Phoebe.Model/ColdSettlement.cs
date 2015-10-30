using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model
{
    /// <summary>
    /// 冷藏费结算类
    /// </summary>
    public class ColdSettlement
    {
        /// <summary>
        /// 合同ID
        /// </summary>
        [Display(Name = "合同ID")]
        public int ContractID { get; set; }

        /// <summary>
        /// 合同名称
        /// </summary>
        [Display(Name = "合同名称")]
        public string ContractName { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        [Display(Name = "开始日期")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        [Display(Name = "结束日期")]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 冷藏费用
        /// </summary>
        [Display(Name = "冷藏费用")]
        public decimal ColdPrice { get; set; }
    }
}
