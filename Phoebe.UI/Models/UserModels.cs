using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Phoebe.UI.Models
{
    public class CreateUserModel
    {
        /// <summary>
        /// 登录名
        /// </summary>
        [Required]
        [Display(Name = "登录名")]
        public string Username { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [MinLength(3)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        /// <summary>
        /// 密码确认
        /// </summary>
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "两次输入密码不一致")]
        [Display(Name = "密码确认")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// 用户组ID
        /// </summary>
        [Required]
        [UIHint("UserGroupList")]
        [Display(Name = "用户组")]
        public int UserGroupID { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [Display(Name = "姓名")]
        public string Name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataType(DataType.MultilineText)]
        [Display(Name = "备注")]
        public string Remark { get; set; }
    }

    /// <summary>
    /// 登录模型
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "请输入用户名")]
        [Display(Name = "用户名")]
        public string Username { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "请输入密码")]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        /// <summary>
        /// 记住我
        /// </summary>
        [Display(Name = "记住我?")]
        public bool RememberMe { get; set; }
    }
}