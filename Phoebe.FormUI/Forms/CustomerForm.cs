using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phoebe.Business;

namespace Phoebe.FormUI
{
    /// <summary>
    /// 客户列表窗体
    /// </summary>
    public partial class CustomerForm : Form
    {
        #region Constructor
        public CustomerForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Event
        private void CustomerForm_Load(object sender, EventArgs e)
        {
            CustomerBusiness business = new CustomerBusiness();

            this.customerBindingSource.DataSource = business.Get();
        }
        #endregion //Event
    }
}
