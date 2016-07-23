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
    /// 冰块操作窗体
    /// </summary>
    public partial class IceStockForm : BaseForm
    {
        #region Constructor
        public IceStockForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 初始化窗体控件
        /// </summary>
        private void InitControls()
        {
            this.dpTime.DateTime = DateTime.Now.Date;
            this.txtUser.Text = this.currentUser.Name;

            this.lkuCustomer.EditValue = null;
            this.txtRemark.Text = "";
        }

        /// <summary>
        /// 更新合同选择
        /// </summary>
        /// <param name="customerId">客户Id</param>
        private void UpdateContractList(int customerId)
        {
            this.cmbContract.Properties.Items.Clear();
            if (customerId == 0)
            {
                this.cmbContract.EditValue = null;
                return;
            }

            var contracts = BusinessFactory<ContractBusiness>.Instance.GetByCustomer(customerId, ContractType.Ice);
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
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IceStockForm_Load(object sender, EventArgs e)
        {
            this.bsCustomer.DataSource = BusinessFactory<CustomerBusiness>.Instance.FindAll();
            this.lkuCustomer.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(EventUtil.LkuCustomer_CustomDisplayText);

            InitControls();
        }

        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbNew_Click(object sender, EventArgs e)
        {
            InitControls();

            this.isList.DataSource = new List<IceFlow>();
        }

        /// <summary>
        /// 业务类型选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int type = this.cmbType.SelectedIndex;
            this.isList.Clear();
            if (type == 0 || type == 2)
            {
                IceFlow flow = new IceFlow
                {
                    IceType = (int)IceType.Complete
                };
                this.isList.AddNew(flow);
            }
            else if (type == 1)
            {
                IceFlow flow = new IceFlow
                {
                    IceType = (int)IceType.Fragment
                };
                this.isList.AddNew(flow);
            }
        }

        /// <summary>
        /// 客户选择
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
        #endregion //Event


    }
}
