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
    /// 冷藏费清单窗体
    /// </summary>
    public partial class ColdPriceForm : BaseForm
    {
        #region Field
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 冷藏费清单窗体
        /// </summary>
        public ColdPriceForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 更新合同列表
        /// </summary>
        /// <param name="customerId">客户Id</param>
        private void UpdateContractList(int customerId)
        {
            var contracts1 = BusinessFactory<ContractBusiness>.Instance.GetByCustomer(customerId, ContractType.TimingCold);
            var contracts2 = BusinessFactory<ContractBusiness>.Instance.GetByCustomer(customerId, ContractType.UntimingCold);

            List<Contract> contracts = new List<Contract>();
            contracts.AddRange(contracts1);
            contracts.AddRange(contracts2);

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
        }

        /// <summary>
        /// 设置列名称
        /// </summary>
        /// <param name="type">计费方式</param>
        private void SetColumnHeader(BillingType type)
        {
            if (type == BillingType.UnitVolume)
            {
                this.colUnitMeter.Caption = "单位体积(立方)";
                this.colFlowMeter.Caption = "出入库体积(立方)";
                this.colTotalMeter.Caption = "在库体积(立方)";
            }
            else if (type == BillingType.Count)
            {
                this.colUnitMeter.Caption = "单位";
                this.colFlowMeter.Caption = "出入库数量";
                this.colTotalMeter.Caption = "在库数量";
            }
            else
            {
                this.colUnitMeter.Caption = "单位重量(kg)";
                this.colFlowMeter.Caption = "出入库重量(t)";
                this.colTotalMeter.Caption = "在库重量(t)";
            }
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColdPriceForm_Load(object sender, EventArgs e)
        {
            this.dpFrom.DateTime = DateTime.Now.Date;
            this.dpTo.DateTime = DateTime.Now.Date;

            this.bsCustomer.DataSource = BusinessFactory<CustomerBusiness>.Instance.FindAll();
            this.lkuCustomer.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(EventUtil.LkuCustomer_CustomDisplayText);
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

        /// <summary>
        /// 合同选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbContract_EditValueChanged(object sender, EventArgs e)
        {
            if (this.cmbContract.EditValue == null)
            {
                this.txtBillingType.Text = "";
            }
            else
            {
                int contractId = Convert.ToInt32(this.cmbContract.EditValue);
                var contract = BusinessFactory<ContractBusiness>.Instance.FindById(contractId);

                this.txtBillingType.Text = ((BillingType)contract.BillingType).DisplayName();
                this.txtIsTiming.Text = contract.IsTiming ? "是" : "否";
                SetColumnHeader((BillingType)contract.BillingType);
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
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
            if (this.dpFrom.DateTime > this.dpTo.DateTime)
            {
                MessageUtil.ShowClaim("开始日期大于结束日期");
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            int contractId = Convert.ToInt32(this.cmbContract.EditValue);
            var contract = BusinessFactory<ContractBusiness>.Instance.FindById(contractId);

            if (contract.Type != (int)ContractType.TimingCold || contract.Type != (int)ContractType.UntimingCold)
            {
                MessageUtil.ShowClaim("该类合同无冷藏费");
                return;
            }
            
            var records = BusinessFactory<BillingBusiness>.Instance.GetContractColdRecord(contractId, this.dpFrom.DateTime.Date, this.dpTo.DateTime.Date);
            this.bsDailyColdRecord.DataSource = records;

            this.Cursor = Cursors.Default;
        }
        #endregion //Event
    }
}
