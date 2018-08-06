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
    /// 用户类
    /// </summary>
    public class User : ObjectEntity<int>
    {
        #region Property
        /// <summary>
        /// 用户名
        /// </summary>
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Display(Name = "密码")]
        public string Password { get; set; }

        /// <summary>
        /// 用户组ID
        /// </summary>
        [Display(Name = "用户组ID")]
        public int UserGroupId { get; set; }

        /// <summary>
        /// 上次登录时间
        /// </summary>
        [Display(Name = "上次登录时间")]
        public DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 本次登录时间
        /// </summary>
        [Display(Name = "本次登录时间")]
        public DateTime CurrentLoginTime { get; set; }
        #endregion //Property
    }
}
