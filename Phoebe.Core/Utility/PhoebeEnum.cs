using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Core.Utility
{
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
}
