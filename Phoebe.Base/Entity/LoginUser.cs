using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Base
{
    /// <summary>
    /// 登录用户
    /// </summary>
    public class LoginUser
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }       

        /// <summary>
        /// 用户组ID
        /// </summary>
        public int UserGroupId { get; set; }

        /// <summary>
        /// 用户组代码
        /// </summary>
        public string UserGroupName { get; set; }

        /// <summary>
        /// 用户组名称
        /// </summary>
        public string UserGroupTitle { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        public int Rank { get; set; }

        /// <summary>
        /// 是否Root
        /// </summary>
        public bool IsRoot { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 上次登录时间
        /// </summary>
        public System.DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 本次登录时间
        /// </summary>
        public System.DateTime CurrentLoginTime { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
    }
}
