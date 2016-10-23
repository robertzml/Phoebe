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
    using Phoebe.Common;
    using Phoebe.Model;

    public partial class TestForm : BaseForm
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            //this.customerLookUpEdit1.Properties.DataSource = BusinessFactory<CustomerBusiness>.Instance.FindAll();

            this.radioGroup1.EditValue = 1;
        }
    }
}
