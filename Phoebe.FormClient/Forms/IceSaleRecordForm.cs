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
    /// 冰块销售记录窗体
    /// </summary>
    public partial class IceSaleRecordForm : BaseForm
    {
        #region Constructor
        public IceSaleRecordForm()
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
        private void IceSaleRecordForm_Load(object sender, EventArgs e)
        {
            this.dpFrom.DateTime = DateTime.Now.Date.AddMonths(-1);
            this.dpTo.DateTime = DateTime.Now.Date;

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
            DateTime from = this.dpFrom.DateTime.Date;
            DateTime to = this.dpTo.DateTime.Date;

            if (from > to)
            {
                MessageUtil.ShowClaim("结束日期早于开始日期");
                return;
            }

            if (this.lkuCustomer.EditValue == null)
            {
                var data = BusinessFactory<IceSaleBusiness>.Instance.Get(from, to);
                this.isList.DataSource = data;
            }
            else
            {
                int customerId = (int)this.lkuCustomer.EditValue;

                var data = BusinessFactory<IceSaleBusiness>.Instance.GetByCustomer(customerId, from, to);
                this.isList.DataSource = data;
            }
        }
        #endregion //Event
    }
}
