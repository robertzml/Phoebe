using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phoebe.FormUI
{
    /// <summary>
    /// 主窗体
    /// </summary>
    public partial class MainForm : Form
    {
        #region Contructor
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Event
        #region Menu Event
        /// <summary>
        /// 客户 - 客户列表
        /// </summary>
        private void menuCustomerList_Click(object sender, EventArgs e)
        {
            CustomerForm form = new CustomerForm();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        /// <summary>
        /// 客户 - 添加客户
        /// </summary>
        private void menuCustomerAdd_Click(object sender, EventArgs e)
        {
            CustomerAddForm form = new CustomerAddForm();
            form.ShowDialog();
        }
        #endregion //Menu Event

        #endregion //Event


    }
}
