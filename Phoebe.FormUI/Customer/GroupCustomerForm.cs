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
    public partial class GroupCustomerForm : Form
    {
        public GroupCustomerForm()
        {
            InitializeComponent();
        }

        private void GroupCustomerForm_Load(object sender, EventArgs e)
        {
            CustomerBusiness business = new CustomerBusiness();

            this.groupCustomerBindingSource.DataSource = business.GetGroupCustomers();
        }
    }
}
