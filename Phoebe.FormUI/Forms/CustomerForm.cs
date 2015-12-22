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
using Phoebe.Model;

namespace Phoebe.FormUI
{
    /// <summary>
    /// 客户列表窗体
    /// </summary>
    public partial class CustomerForm : Form
    {
        #region Field
        private CustomerBusiness customerBusiness;

        private List<Customer> customerData;
        #endregion //Field

        #region Constructor
        public CustomerForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        private void InitData()
        {
            this.customerBusiness = new CustomerBusiness();
            this.customerData = this.customerBusiness.Get();
        }

        private void InitControl()
        {
            this.customerBindingSource.DataSource = this.customerData;
            this.comboBoxType.SelectedIndex = 0;
        }
        #endregion //Function

        #region Event
        private void CustomerForm_Load(object sender, EventArgs e)
        {
            InitData();
            InitControl();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonQuery_Click(object sender, EventArgs e)
        {
            var data = this.customerData;
            if (this.comboBoxType.SelectedIndex != 0)
            {
                data = data.Where(r => r.Type == this.comboBoxType.SelectedIndex).ToList();
            }

            this.customerBindingSource.DataSource = data;
        }
        #endregion //Event
    }
}
