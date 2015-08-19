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
}
