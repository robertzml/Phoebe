using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phoebe.ClientDx
{
    using Poseidon.Common;
    using Poseidon.Winform.Base;

    static class Program
    {
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
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            GlobalAction.Initialize();

            LoginForm login = new LoginForm();
            if (login.ShowDialog() == DialogResult.OK)
            {
                GlobalAction.CurrentUser = GlobalAction.ConvertToLoginUser(login.User, login.UserGroup);
                Cache.Instance.Add("CurrentUser", GlobalAction.CurrentUser); //缓存用户信息
                Logger.Instance.Debug("用户登录成功");

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
            Logger.Instance.Exception("未处理异常", ex.Exception);

            string message = string.Format("{0}\r\n操作发生错误，您需要退出系统么？", ex.Exception.Message);
            if (MessageUtil.ConfirmYesNo(message) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
