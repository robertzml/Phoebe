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
        #region Constructor
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Event
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
     
        #region Menu Event
        /// <summary>
        /// 客户管理 - 团体客户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuGroupCustomer_Click(object sender, EventArgs e)
        {
            GroupCustomerForm form = new GroupCustomerForm();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        /// <summary>
        /// 客户管理 - 零散客户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuScatterCustomer_Click(object sender, EventArgs e)
        {
            ScatterCustomerForm form = new ScatterCustomerForm();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        /// <summary>
        /// 仓库管理 - 仓库信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuWarehouseInfo_Click(object sender, EventArgs e)
        {
            WarehouseForm form = new WarehouseForm();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }
        #endregion //Menu Event       

      
        #endregion //Event
    }
}
