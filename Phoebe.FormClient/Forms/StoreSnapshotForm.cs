using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using DevExpress.XtraEditors.Controls;
    using Phoebe.Base;
    using Phoebe.Business;
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 库存快照窗体
    /// </summary>
    public partial class StoreSnapshotForm : BaseForm
    {
        #region Field
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 库存快照窗体
        /// </summary>
        public StoreSnapshotForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 更新合同选择
        /// </summary>
        /// <param name="customerId">客户Id</param>
        private void UpdateContractList(int customerId)
        {
            var contracts = BusinessFactory<ContractBusiness>.Instance.GetByCustomer(customerId);

            this.cmbContract.Properties.Items.Clear();
            foreach (var item in contracts)
            {
                ImageComboBoxItem i = new ImageComboBoxItem();
                i.Description = item.Name;
                i.Value = item.Id;

                this.cmbContract.Properties.Items.Add(i);
            }

            if (contracts.Count > 0)
                this.cmbContract.EditValue = contracts[0].Id;
            else
                this.cmbContract.EditValue = null;

            this.sfgList.Clear();
            this.srgList.Clear();
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StoreSnapshootForm_Load(object sender, EventArgs e)
        {
            this.dpTime.DateTime = DateTime.Now.Date;

            this.bsCustomer.DataSource = BusinessFactory<CustomerBusiness>.Instance.FindAll();

            this.lkuCustomer.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(EventUtil.LkuCustomer_CustomDisplayText);
        }

        /// <summary>
        /// 选择客户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lkuCustomer_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lkuCustomer.EditValue == null)
                UpdateContractList(0);
            else
                UpdateContractList(Convert.ToInt32(this.lkuCustomer.EditValue));
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeach_Click(object sender, EventArgs e)
        {
            if (this.lkuCustomer.EditValue == null)
            {
                MessageUtil.ShowClaim("请选择客户");
                return;
            }

            if (this.cmbContract.EditValue == null)
            {
                MessageUtil.ShowClaim("请选择合同");
                return;
            }
            int contractId = Convert.ToInt32(this.cmbContract.EditValue);

            if (this.dpTime.DateTime.Date > DateTime.Now)
            {
                MessageUtil.ShowClaim("日期超过今天");
                return;
            }

            var storage = BusinessFactory<StoreBusiness>.Instance.GetInDay(contractId, this.dpTime.DateTime.Date);
            this.srgList.DataSource = storage;

            var flow = BusinessFactory<StoreBusiness>.Instance.GetDayFlow(contractId, this.dpTime.DateTime.Date);
            this.sfgList.DataSource = flow;
        }
        #endregion //Event
    }
}
