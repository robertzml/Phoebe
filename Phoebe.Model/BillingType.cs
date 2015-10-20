using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model
{
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
}
