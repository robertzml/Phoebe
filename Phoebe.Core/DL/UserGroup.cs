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
    /// 用户组表
    /// </summary>
    public class UserGroup : ObjectEntity<int>
    {
        #region Property
        /// <summary>
        /// 代号
        /// </summary>
        [Display(Name = "代号")]
        public string Title { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        [Display(Name = "级别")]
        public int Rank { get; set; }
        #endregion //Property
    }
}
