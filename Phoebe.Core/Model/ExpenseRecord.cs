using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Phoebe.Core.Model
{
    /// <summary>
    /// 收费记录类
    /// </summary>
    public class ExpenseRecord
    {
        #region Property
        /// <summary>
        /// 代码
        /// </summary>
        [Display(Name = "代码")]
        public string Code { get; set; }

        /// <summary>
        /// 费用项目
        /// </summary>
        [Display(Name = "费用项目")]
        public string Name { get; set; }

        /// <summary>
        /// 计费方式
        /// </summary>
        [Display(Name = "计费方式")]
        public int Type { get; set; }

        /// <summary>
        /// 费用
        /// </summary>
        [Display(Name = "费用")]
        public decimal Amount { get; set; }
        #endregion //Property
    }
}
