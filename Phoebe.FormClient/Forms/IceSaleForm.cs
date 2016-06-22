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
    /// 冰块销售窗体
    /// </summary>
    public partial class IceSaleForm : BaseForm
    {
        #region Constructor
        public IceSaleForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor


        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IceSaleForm_Load(object sender, EventArgs e)
        {
            this.bsCustomer.DataSource = BusinessFactory<CustomerBusiness>.Instance.FindAll();
            this.lkuCustomer.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(EventUtil.LkuCustomer_CustomDisplayText);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var data = BusinessFactory<IceSaleBusiness>.Instance.FindAll();
            this.iceList.DataSource = data;
        }

        /// <summary>
        /// 售出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSell_Click(object sender, EventArgs e)
        {
            ChildFormManage.ShowDialogForm(typeof(IceSellForm));
        }
        #endregion //Event
    }
}
