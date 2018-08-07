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
    /// 类别类
    /// </summary>
    public class Category : ObjectEntity<int>
    {
        #region Property
        /// <summary>
        /// 代码
        /// </summary>
        [Display(Name = "代码")]
        public string Number { get; set; }

        /// <summary>
        /// 上级ID
        /// </summary>
        [Display(Name = "上级ID")]
        public Nullable<int> ParentId { get; set; }

        /// <summary>
        /// 层级
        /// </summary>
        [Display(Name = "层级")]
        public int Hierarchy { get; set; }
        #endregion //Property
    }
}
