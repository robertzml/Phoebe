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
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            this.customerBusiness = new CustomerBusiness();
            this.customerData = this.customerBusiness.Get();
            this.customerBindingSource.DataSource = this.customerData;
            this.customerBindingSource.ResetBindings(true);
        }

        /// <summary>
        /// 编辑客户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (this.customerDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选中记录", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int customerID = Convert.ToInt32(this.customerDataGridView.SelectedRows[0].Cells[this.columnID.Index].Value);
            CustomerEditForm form = new CustomerEditForm(customerID);
            form.ShowDialog();
        }

        /// <summary>
        /// 删除客户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (this.customerDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选中记录", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dr = MessageBox.Show("是否确认删除选中客户", FormConstant.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                Customer customer = this.customerDataGridView.SelectedRows[0].DataBoundItem as Customer;
                ErrorCode result = this.customerBusiness.Delete(customer);
                if (result == ErrorCode.Success)
                {
                    MessageBox.Show("删除客户成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("删除客户失败：" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void customerDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < this.customerBindingSource.Count)
            {
                var customer = this.customerBindingSource[e.RowIndex] as Customer;
                var grid = this.customerDataGridView;

                if (customer.Type == 1)
                    grid.Rows[e.RowIndex].Cells[this.columnType.Index].Value = "团体客户";
                else if (customer.Type == 2)
                    grid.Rows[e.RowIndex].Cells[this.columnType.Index].Value = "零散客户";
            }
        }
        #endregion //Event
    }
}
