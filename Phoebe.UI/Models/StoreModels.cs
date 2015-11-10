using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Phoebe.UI.Models
{
    /// <summary>
    /// 库存快照输入模型
    /// </summary>
    public class StoreSnapshootInput
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
    /// 库存历史输入模型
    /// </summary>
    public class StoreHistoryInput
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