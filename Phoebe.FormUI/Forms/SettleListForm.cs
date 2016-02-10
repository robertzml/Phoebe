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
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettleListForm_Load(object sender, EventArgs e)
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
            if (this.comboBoxCustomer.SelectedIndex == -1)
                return;

            Customer customer = this.comboBoxCustomer.SelectedItem as Customer;
            var settles = this.settleBusiness.Get(customer.ID);
            this.settlementBindingSource.DataSource = settles;
        }


        private void settlementDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < this.settlementBindingSource.Count)
            {
                var settlement = this.settlementBindingSource[e.RowIndex] as Settlement;

                if (settlement.User != null)
                {
                    this.settlementDataGridView.Rows[e.RowIndex].Cells[this.columnUser.Index].Value = settlement.User.Name;
                }

                this.settlementDataGridView.Rows[e.RowIndex].Cells[this.columnStatus.Index].Value = ((EntityStatus)settlement.Status).DisplayName();
            }
        }
        #endregion //Event
    }
}
