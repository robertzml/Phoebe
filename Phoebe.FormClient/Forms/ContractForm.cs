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
    /// 合同列表窗体
    /// </summary>
    public partial class ContractForm : BaseForm
    {
        #region Constructor
        public ContractForm()
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
            this.bsContract.DataSource = BusinessFactory<ContractBusiness>.Instance.FindAll();
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
            LoadData();
        }

        /// <summary>
        /// 自定义数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvContract_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsContract.Count)
                return;

            if (e.Column.FieldName == "CustomerId")
            {
                var contract = this.bsContract[rowIndex] as Contract;
                e.DisplayText = contract.Customer.Name;
            }
            else if (e.Column.FieldName == "BillingType")
            {
                var type = (BillingType)e.Value;
                e.DisplayText = type.DisplayName();
            }
            else if (e.Column.FieldName == "UserId")
            {
                var contract = this.bsContract[rowIndex] as Contract;
                e.DisplayText = contract.User.Name;
            }
            else if (e.Column.FieldName == "Status")
            {
                var status = (EntityStatus)e.Value;
                e.DisplayText = status.DisplayName();
            }
        }

        /// <summary>
        /// 添加合同
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ChildFormManage.ShowDialogForm(typeof(ContractAddForm));
            LoadData();
        }

        /// <summary>
        /// 编辑合同
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = this.dgvContract.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsContract.Count)
                return;

            var contract = this.bsContract[rowIndex] as Contract;
            ChildFormManage.ShowDialogForm(typeof(ContractEditForm), new object[] { contract.Id });

            LoadData();
        }

        /// <summary>
        /// 删除合同
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvContract.SelectedRowsCount == 0)
            {
                MessageBox.Show("未选中记录", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dr = MessageBox.Show("是否确认删除选中合同", FormConstant.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int rowIndex = this.dgvContract.GetFocusedDataSourceRowIndex();
                if (rowIndex < 0 || rowIndex >= this.bsContract.Count)
                    return;

                var contract = this.bsContract[rowIndex] as Contract;

                ErrorCode result = BusinessFactory<ContractBusiness>.Instance.Delete(contract);
                if (result == ErrorCode.Success)
                {
                    MessageBox.Show("删除合同成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("删除合同失败：" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadData();
            }
        }
        #endregion //Event
    }
}
