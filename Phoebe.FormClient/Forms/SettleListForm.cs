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
            this.stList.DataSource = data;
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
        /// 删除结算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var settlement = this.stList.GetCurrentSelect();
            if (settlement == null)
            {
                MessageUtil.ShowClaim("未选择记录");
                return;
            }

            if (MessageUtil.ConfirmYesNo("是否确认删除选中结算") == DialogResult.Yes)
            {
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
