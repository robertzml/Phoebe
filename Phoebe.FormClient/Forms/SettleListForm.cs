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
                var settlement = this.bsSettlement[rowIndex] as Settlement;
                e.DisplayText = settlement.Customer.Name;
            }
            else if (e.Column.FieldName == "UserId")
            {
                var settlement = this.bsSettlement[rowIndex] as Settlement;
                e.DisplayText = settlement.User.Name;
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
                MessageUtil.ShowClaim("未选择记录");
                return;
            }

            if (MessageUtil.ConfirmYesNo("是否确认删除选中结算") == DialogResult.Yes)
            {
                int rowIndex = this.dgvSettlement.GetFocusedDataSourceRowIndex();
                if (rowIndex < 0 || rowIndex >= this.bsSettlement.Count)
                    return;

                var settlement = this.bsSettlement[rowIndex] as Settlement;

                ErrorCode result = BusinessFactory<SettlementBusiness>.Instance.Delete(settlement);
                if (result == ErrorCode.Success)
                {
                    MessageUtil.ShowInfo("删除结算成功");
                }
                else
                {
                    MessageUtil.ShowWarning("删除结算失败：" + result.DisplayName());
                }

                LoadData();
            }
        }
        #endregion //Event
    }
}
