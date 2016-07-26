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

        #region Function
        /// <summary>
        /// 载入冰块库存
        /// </summary>
        private void LoadStores()
        {
            var stores = BusinessFactory<IceStoreBusiness>.Instance.FindAll();

            var complete = stores.Single(r => r.Type == (int)IceType.Complete);
            this.txtCompleteCount.Text = complete.Count.ToString();
            this.txtCompleteWeight.Text = complete.Weight.ToString();

            var fragment = stores.Single(r => r.Type == (int)IceType.Fragment);
            this.txtFragmentCount.Text = fragment.Count.ToString();
            this.txtFragmentWeight.Text = fragment.Weight.ToString();
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IceSaleForm_Load(object sender, EventArgs e)
        {
            LoadStores();

            this.dpFrom.DateTime = DateTime.Now.AddMonths(-1).Date;
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
            if (this.dpFrom.DateTime > this.dpTo.DateTime)
            {
                MessageUtil.ShowClaim("结束日期早于开始日期");
                return;
            }

            if (this.lkuCustomer.EditValue == null)
            {
                var data = BusinessFactory<IceSaleBusiness>.Instance.Get(this.dpFrom.DateTime, this.dpTo.DateTime);
                this.iceList.DataSource = data;
            }
            else
            {
                int customerId = Convert.ToInt32(this.lkuCustomer.EditValue);
                //var data = BusinessFactory<IceSaleBusiness>.Instance.Get(this.dpFrom.DateTime, this.dpTo.DateTime).Where(r => r.CustomerId == customerId);
                //this.iceList.DataSource = data.ToList();
            }
        }

        /// <summary>
        /// 售出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSell_Click(object sender, EventArgs e)
        {
            ChildFormManage.ShowDialogForm(typeof(IceSellForm));
            LoadStores();
        }
        #endregion //Event
    }
}
