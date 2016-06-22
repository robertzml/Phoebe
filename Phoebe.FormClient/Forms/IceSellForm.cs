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
    /// 冰块售出窗体
    /// </summary>
    public partial class IceSellForm : BaseSingleForm
    {
        #region Constructor
        public IceSellForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 设置对象
        /// </summary>
        /// <param name="iceSale"></param>
        private void SetEntity(IceSale iceSale)
        {
            iceSale.IceType = (int)this.cmbIceType.EditValue;
            iceSale.CustomerId = (int)this.lkuCustomer.EditValue;
            iceSale.SaleTime = this.dpTime.DateTime.Date;
            iceSale.SaleCount = Convert.ToInt32(this.spCount.Value);
            iceSale.SaleWeight = this.spWeight.Value;
            iceSale.SaleFee = this.spFee.Value;
            iceSale.UserId = this.currentUser.Id;
            iceSale.CreateTime = DateTime.Now;
            iceSale.Remark = this.txtRemark.Text;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IceSellForm_Load(object sender, EventArgs e)
        {
            this.bsCustomer.DataSource = BusinessFactory<CustomerBusiness>.Instance.FindAll();
            this.lkuCustomer.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(EventUtil.LkuCustomer_CustomDisplayText);

            this.cmbIceType.Properties.Items.AddEnum(typeof(IceType));
            this.cmbIceType.SelectedIndex = 0;

            this.dpTime.DateTime = DateTime.Now.Date;

            this.txtUser.Text = this.currentUser.Name;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.lkuCustomer.EditValue == null)
            {
                MessageUtil.ShowClaim("请选择客户");
                return;
            }
            if (this.spCount.Value <= 0)
            {
                MessageUtil.ShowInfo("售出数量必须大于0");
                return;
            }
            if (this.spWeight.Value <= 0)
            {
                MessageUtil.ShowInfo("售出重量必须大于0");
                return;
            }

            IceSale iceSale = new IceSale();
            SetEntity(iceSale);

            var result = BusinessFactory<IceSaleBusiness>.Instance.Create(iceSale);
            if (result == ErrorCode.Success)
            {
                MessageUtil.ShowInfo("添加冰块销售成功");
                this.Close();
            }
            else
            {
                MessageUtil.ShowError("添加冰块销售失败：" + result.DisplayName());
            }
        }
        #endregion //Event
    }
}
