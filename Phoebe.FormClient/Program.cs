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

            LoginForm login = new LoginForm();
            if (login.ShowDialog() == DialogResult.OK)
            {
                Program.GC.CurrentUser = Program.GC.ConvertToLoginUser(login.User);
                Cache.Instance.Add("CurrentUser", Program.GC.CurrentUser); //缓存用户信息

                Application.Run(new MainForm());
            }
        }
    }
}
