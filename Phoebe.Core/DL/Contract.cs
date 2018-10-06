using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Core.DL
{
    using Poseidon.Base.Framework;

    /// <summary>
    /// 合同类
    /// </summary>
    public class Contract : ObjectEntity<int>
    {
        #region Property
        /// <summary>
        /// 合同编号
        /// </summary>
        [Display(Name = "合同编号")]
        public string Number { get; set; }

        /// <summary>
        /// 客户ID
        /// </summary>
        [Display(Name = "客户ID")]
        public int CustomerId { get; set; }

        /// <summary>
        /// 合同类型
        /// </summary>
        [Display(Name = "合同类型")]
        public int Type { get; set; }

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
        /// 登记人ID
        /// </summary>
        [Display(Name = "登记人ID")]
        public int UserId { get; set; }
        #endregion //Property
    }
}
