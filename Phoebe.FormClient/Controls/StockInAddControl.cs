using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using Phoebe.Base;
    using Phoebe.Business;
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 新建入库界面
    /// </summary>
    public partial class StockInAddControl : UserControl
    {
        #region Field
        /// <summary>
        /// 登录用户
        /// </summary>
        private LoginUser currentUser;
        #endregion //Field

        #region Constructor
        public StockInAddControl(LoginUser user)
        {
            InitializeComponent();

            this.currentUser = user;
        }
        #endregion //Constructor

        #region Function
        private void LoadCustomers()
        {
            var customers = BusinessFactory<CustomerBusiness>.Instance.FindAll();

            this.lvCustomer.BeginUpdate();
            foreach(var item in customers)
            {
                ListViewItem lvi = new ListViewItem(item.Number);
                
                lvi.SubItems.Add(item.Name);

                this.lvCustomer.Items.Add(lvi);
            }
            this.lvCustomer.EndUpdate();
        }
        #endregion //Function

        #region Event
        private void StockInAddControl_Load(object sender, EventArgs e)
        {
            this.txtUser.Text = this.currentUser.Name;

            LoadCustomers();
        }
        

        private void txtCustomerNumber_EditValueChanged(object sender, EventArgs e)
        {

        }
        #endregion //Event
    }
}
