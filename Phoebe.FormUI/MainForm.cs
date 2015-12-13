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
        #endregion //Menu Event
        #endregion //Event
    }
}
