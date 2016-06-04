using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Phoebe.Base
{
    using DevExpress.XtraEditors;

    /// <summary>
    /// 对话框
    /// </summary>
    public class MessageUtil
    {
        #region Field
        private static readonly string messageBoxTitle = "华润冷链管理系统";
        #endregion //Field

        #region Method
        /// <summary>
        /// 显示提示信息
        /// </summary>
        /// <param name="message">提示信息</param>
        /// <returns></returns>
        public static DialogResult ShowInfo(string message)
        {
            return MessageBox.Show(message, messageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 显示要求信息
        /// </summary>
        /// <param name="message">要求信息</param>
        public static DialogResult ShowClaim(string message)
        {
            return MessageBox.Show(message, messageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
		/// 显示警告信息
		/// </summary>
		/// <param name="message">警告信息</param>
		public static DialogResult ShowWarning(string message)
        {
            return MessageBox.Show(message, messageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// 显示错误信息
        /// </summary>
        /// <param name="message">错误信息</param>
        public static DialogResult ShowError(string message)
        {
            return MessageBox.Show(message, messageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 显示一个YesNo选择对话框
        /// </summary>
        /// <param name="message">询问信息</param>
        public static DialogResult ConfirmYesNo(string message)
        {
            return MessageBox.Show(message, messageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        #endregion //Method
    }
}
