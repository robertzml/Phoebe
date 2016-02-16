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
    /// 结算记录窗体
    /// </summary>
    public partial class SettleListForm : Form
    {
        #region Field
        private User currentUser;

        private SettleBusiness settleBusiness;

        private CustomerBusiness customerBusiness;
        #endregion //Field

        #region Constructor
        public SettleListForm(User user)
        {
            InitializeComponent();
            this.currentUser = user;
        }
        #endregion //Constructor

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

            var customer = this.comboBoxCustomer.SelectedItem as Customer;

            var data = this.settleBusiness.Get(customer.ID);
            this.settlementBindingSource.DataSource = data;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (this.comboBoxCustomer.SelectedIndex == -1)
                return;

            if (this.settlementDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选中记录", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dr = MessageBox.Show("是否删除选中结算", FormConstant.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                var settle = this.settlementDataGridView.SelectedRows[0].DataBoundItem as Settlement;
                ErrorCode result = this.settleBusiness.Delete(settle);
                if (result == ErrorCode.Success)
                {
                    MessageBox.Show("删除结算成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("删除结算失败：" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            this.settleBusiness = new SettleBusiness();

            if (this.comboBoxCustomer.SelectedIndex == -1)
                return;

            var customer = this.comboBoxCustomer.SelectedItem as Customer;

            var data = this.settleBusiness.Get(customer.ID);
            this.settlementBindingSource.DataSource = data;
        }

        private void settlementDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < this.settlementBindingSource.Count)
            {
                var settlement = this.settlementBindingSource[e.RowIndex] as Settlement;
                                
                if (settlement.Customer != null)
                {
                    this.settlementDataGridView.Rows[e.RowIndex].Cells[this.columnCustomer.Index].Value = settlement.Customer.Name;
                }
                if (settlement.User != null)
                {
                    this.settlementDataGridView.Rows[e.RowIndex].Cells[this.columnUser.Index].Value = settlement.User.Name;
                }
            }
        }
        #endregion //Event
    }
}
