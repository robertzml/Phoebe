using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phoebe.Base;
using Phoebe.Common;
using Phoebe.Model;

namespace Phoebe.FormClient
{
    static class Program
    {
        /// <summary>
        /// 全局操作
        /// </summary>
        public static GlobalControl GC = new GlobalControl();

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Skins.SkinManager.EnableMdiFormSkins();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            LoginForm login = new LoginForm();
            if (login.ShowDialog() == DialogResult.OK)
            {
                Program.GC.CurrentUser = Program.GC.ConvertToLoginUser(login.User);
                Cache.Instance.Add("CurrentUser", Program.GC.CurrentUser); //缓存用户信息

                Application.Run(new MainForm());
            }
        }

        /// <summary>
        /// 异常消息处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ex"></param>
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs ex)
        {
            string message = string.Format("{0}\r\n操作发生错误，您需要退出系统么？", ex.Exception.Message);
            if (MessageUtil.ConfirmYesNo(message) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
