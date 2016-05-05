using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using Phoebe.Base;
    using Phoebe.Business;
    using Phoebe.Model;

    public partial class CustomerForm : BaseForm
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            var customer = BusinessFactory<CustomerBusiness>.Instance.FindById(1);
        }
    }
}
