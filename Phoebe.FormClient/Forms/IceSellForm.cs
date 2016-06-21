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
        }
        #endregion //Event
    }
}
