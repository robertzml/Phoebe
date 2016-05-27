using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using Phoebe.Base;
    using Phoebe.Business;
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 结算记录窗体
    /// </summary>
    public partial class SettleListForm : BaseForm
    {
        #region Constructor
        public SettleListForm()
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
            var data = BusinessFactory<SettlementBusiness>.Instance.FindAll();
            this.bsSettlement.DataSource = data;
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
            LoadData();
        }

        /// <summary>
        /// 格式化数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSettlement_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsSettlement.Count)
                return;

            if (e.Column.FieldName == "CustomerId")
            {
                var contract = this.bsSettlement[rowIndex] as Contract;
                e.DisplayText = contract.Customer.Name;
            }
            else if (e.Column.FieldName == "UserId")
            {
                var contract = this.bsSettlement[rowIndex] as Contract;
                e.DisplayText = contract.User.Name;
            }
        }

        /// <summary>
        /// 删除结算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvSettlement.SelectedRowsCount == 0)
            {
                MessageBox.Show("未选中记录", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dr = MessageBox.Show("是否确认删除选中结算", FormConstant.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int rowIndex = this.dgvSettlement.GetFocusedDataSourceRowIndex();
                if (rowIndex < 0 || rowIndex >= this.bsSettlement.Count)
                    return;

                var settlement = this.bsSettlement[rowIndex] as Settlement;

                ErrorCode result = BusinessFactory<SettlementBusiness>.Instance.Delete(settlement);
                if (result == ErrorCode.Success)
                {
                    MessageBox.Show("删除结算成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("删除结算失败：" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadData();
            }
        }
        #endregion //Event
    }
}
