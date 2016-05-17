using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using Phoebe.Base;
    using Phoebe.Business;
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 客户列表窗体
    /// </summary>
    public partial class CustomerForm : BaseForm
    {
        #region Constructor
        public CustomerForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 载入数据
        /// </summary>
        private void LoadData()
        {
            this.bsCustomer.DataSource = BusinessFactory<CustomerBusiness>.Instance.FindAll();
        }

        /// <summary>
        /// 检查权限
        /// </summary>
        protected override void CheckPrivilege()
        {
            if (this.currentUser.Rank > 800)
            {
                this.btnDelete.Visible = true;
            }
            else
            {
                this.btnDelete.Visible = false;
            }
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
            LoadData();
        }

        /// <summary>
        /// 添加客户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ChildFormManage.ShowDialogForm(typeof(CustomerAddForm));
            LoadData();
        }

        /// <summary>
        /// 编辑客户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = this.dgvCustomer.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsCustomer.Count)
                return;

            var customer = this.bsCustomer[rowIndex] as Customer;
            ChildFormManage.ShowDialogForm(typeof(CustomerEditForm), new object[] { customer.Id });

            LoadData();
        }

        /// <summary>
        /// 删除客户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvCustomer.SelectedRowsCount == 0)
            {
                MessageBox.Show("未选中记录", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dr = MessageBox.Show("是否确认删除选中客户", FormConstant.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                int rowIndex = this.dgvCustomer.GetFocusedDataSourceRowIndex();
                if (rowIndex < 0 || rowIndex >= this.bsCustomer.Count)
                    return;

                var customer = this.bsCustomer[rowIndex] as Customer;

                ErrorCode result = BusinessFactory<CustomerBusiness>.Instance.Delete(customer);
                if (result == ErrorCode.Success)
                {
                    MessageBox.Show("删除客户成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("删除客户失败：" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadData();
            }
        }

        /// <summary>
        /// 自定义数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCustomer_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "Type")
            {
                var type = (CustomerType)e.Value;
                e.DisplayText = type.DisplayName();
            }
            else if (e.Column.FieldName == "Status")
            {
                var status = (EntityStatus)e.Value;
                e.DisplayText = status.DisplayName();
            }
        }
        #endregion //Event
    }
}
