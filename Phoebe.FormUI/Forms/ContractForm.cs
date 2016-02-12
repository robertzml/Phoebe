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
    /// 合同列表窗体
    /// </summary>
    public partial class ContractForm : Form
    {
        #region Field
        private CustomerBusiness customerBusiness;

        private ContractBusiness contractBusiness;
        #endregion//Field

        #region Constructor
        public ContractForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        private void InitData()
        {
            this.customerBusiness = new CustomerBusiness();
            this.contractBusiness = new ContractBusiness();
        }

        private void InitControl()
        {
            var customers = this.customerBusiness.Get();
            customers.Insert(0, new Customer { ID = 0, Name = "--请选择--" });
            this.comboBoxCustomer.DataSource = customers;
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
        private void ContractForm_Load(object sender, EventArgs e)
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

            if (this.comboBoxCustomer.SelectedIndex == 0)
            {
                this.contractBindingSource.DataSource = this.contractBusiness.Get();
            }
            else
            {
                var customer = this.comboBoxCustomer.SelectedItem as Customer;
                this.contractBindingSource.DataSource = this.contractBusiness.GetByCustomer(customer.ID);
            }
        }

        /// <summary>
        /// 删除合同
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (this.contractDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选中记录", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dr = MessageBox.Show("是否确认删除选中合同", FormConstant.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Contract contract = this.contractDataGridView.SelectedRows[0].DataBoundItem as Contract;
                ErrorCode result = this.contractBusiness.Delete(contract);
                if (result == ErrorCode.Success)
                {
                    MessageBox.Show("删除合同成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("删除合同失败：" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            this.contractBusiness = new ContractBusiness();            
            this.contractBindingSource.DataSource = this.contractBusiness.Get();
        }

        private void contractDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < this.contractBindingSource.Count)
            {
                var contract = this.contractBindingSource[e.RowIndex] as Contract;

                var grid = this.contractDataGridView;
                if (contract.Customer != null)
                {
                    grid.Rows[e.RowIndex].Cells[this.columnCustomerName.Index].Value = contract.Customer.Name;
                }
                grid.Rows[e.RowIndex].Cells[this.columnBillingType.Index].Value = ((BillingType)contract.BillingType).DisplayName();
                grid.Rows[e.RowIndex].Cells[this.columnBillingInfo.Index].Value = ((BillingType)contract.BillingType).DisplayDescription();

                if (contract.User != null)
                {
                    grid.Rows[e.RowIndex].Cells[this.columnUser.Index].Value = contract.User.Name;
                }
            }
        }
        #endregion //Event
    }
}
