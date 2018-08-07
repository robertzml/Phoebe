using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Base
{
    using Poseidon.Base.System;

    public class PhoebeLoginUser : ILoginUser
    {
        #region Property
        /// <summary>
        /// 用户ID
        /// </summary>
        [Display(Name = "ID")]
        public string Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名")]
        public string Name { get; set; }

        /// <summary>
        /// 用户组ID
        /// </summary>
        [Display(Name = "用户组ID")]
        public int UserGroupId { get; set; }

        /// <summary>
        /// 用户组名称
        /// </summary>
        [Display(Name = "用户组名称")]
        public string UserGroupName { get; set; }

        /// <summary>
        /// 用户组代码
        /// </summary>
        [Display(Name = "用户组代码")]
        public string UserGroupTitle { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        [Display(Name = "级别")]
        public int Rank { get; set; }

        /// <summary>
        /// 是否Root
        /// </summary>
        [Display(Name = "是否Root")]
        public bool IsRoot { get; set; }

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

        /// <summary>
        /// 备注 
        /// </summary>
        [Display(Name = "备注")]
        public string Remark { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public int Status { get; set; }
        #endregion //Property
    }
}
