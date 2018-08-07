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
    /// 客户类
    /// </summary>
    public class Customer : ObjectEntity<int>
    {
        #region Property
        /// <summary>
        /// 代码
        /// </summary>
        [Display(Name = "代码")]
        public string Number { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Display(Name = "地址")]
        public string Address { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [Display(Name = "电话")]
        public string Telephone { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [Display(Name = "联系人")]
        public string Contact { get; set; }

        /// <summary>
        /// 联系人电话
        /// </summary>
        [Display(Name = "联系人电话")]
        public string ContactTelephone { get; set; }

        /// <summary>
        /// 客户类型
        /// </summary>
        [Display(Name = "客户类型")]
        public int Type { get; set; }
        #endregion //Property
    }
}
