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
using Phoebe.Common;
using Phoebe.Model;

namespace Phoebe.FormUI
{
    /// <summary>
    /// 结算列表窗体
    /// </summary>
    public partial class SettleListForm : Form
    {
        #region Field
        private SettleBusiness settleBusiness;

        private CustomerBusiness customerBusiness;
        #endregion //Field

        #region Constructor
        public SettleListForm()
        {
            InitializeComponent();
        }
        #endregion //Constrcutor

        #region Function
        private void InitData()
        {
            this.settleBusiness = new SettleBusiness();
            this.customerBusiness = new CustomerBusiness();
        }

        private void InitControl()
        {
            this.comboBoxCustomer.DataSource = this.customerBusiness.Get();
            this.comboBoxCustomer.DisplayMember = "Name";
            this.comboBoxCustomer.ValueMember = "ID";
        }
        #endregion //Function

        #region Event
        private void SettleListForm_Load(object sender, EventArgs e)
        {
            InitData();
            InitControl();
        }
        #endregion //Event
    }
}
