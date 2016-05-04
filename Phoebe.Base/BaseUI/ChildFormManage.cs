using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phoebe.Base
{
    /// <summary>
    /// 子窗体管理
    /// </summary>
    public class ChildFormManage
    {
        #region Constructor
        private ChildFormManage()
        {

        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 唯一加载某个类型的窗体，如果存在则显示，否则创建。
        /// </summary>
        /// <param name="mainDialog">主窗体对象</param>
        /// <param name="formType">待显示的窗体类型</param>
        /// <returns></returns>
        public static Form LoadMdiForm(Form mainDialog, Type formType)
        {
            bool bFound = false;
            Form tableForm = null;
            foreach (Form form in mainDialog.MdiChildren)
            {
                if (form.GetType() == formType)
                {
                    bFound = true;
                    tableForm = form;
                    break;
                }
            }
            if (!bFound)
            {
                tableForm = (Form)Activator.CreateInstance(formType);
                tableForm.MdiParent = mainDialog;
                tableForm.Show();
            }

            tableForm.BringToFront();
            tableForm.Activate();

            return tableForm;
        }

        /// <summary>
        /// 弹出对话框窗体
        /// </summary>
        /// <param name="formType">待显示的窗体类型</param>
        public static void ShowDialogForm(Type formType)
        {
            Form dialogForm = (Form)Activator.CreateInstance(formType);
            dialogForm.ShowDialog();
        }
        #endregion //Method
    }
}
