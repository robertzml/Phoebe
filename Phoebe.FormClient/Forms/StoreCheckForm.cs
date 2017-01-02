using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using Phoebe.Base;
    using Phoebe.Business;
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 库存检查窗体
    /// </summary>
    public partial class StoreCheckForm : BaseForm
    {
        #region Constructor
        public StoreCheckForm()
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
        private void StoreCheckForm_Load(object sender, EventArgs e)
        {
            this.bsCustomer.DataSource = BusinessFactory<CustomerBusiness>.Instance.FindAll();
            this.lkuCustomer.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(EventUtil.LkuCustomer_CustomDisplayText);
        }

        /// <summary>
        /// 列出库存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowStores_Click(object sender, EventArgs e)
        {
            if (this.lkuCustomer.EditValue != null)
            {
                int customerId = Convert.ToInt32(this.lkuCustomer.EditValue);

                var stores = BusinessFactory<StoreBusiness>.Instance.GetByCustomer(customerId);

                if (!this.chkStoreIn.Checked)
                    stores = stores.Where(r => r.Status != (int)EntityStatus.StoreIn).ToList();
                if (!this.chkStoreOut.Checked)
                    stores = stores.Where(r => r.Status != (int)EntityStatus.StoreOut).ToList();

                this.stgList.DataSource = stores;
            }
        }


        /// <summary>
        /// 开始检查
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartCheck_Click(object sender, EventArgs e)
        {
            if (this.lkuCustomer.EditValue != null)
            {
                int customerId = Convert.ToInt32(this.lkuCustomer.EditValue);

                if (this.chkStoreStatus.Checked)
                {
                    var stores = BusinessFactory<StoreBusiness>.Instance.CheckStoreStatus(customerId);
                    this.stgList.DataSource = stores;
                }

                if (this.chkFlowCount.Checked)
                {
                    var stores = BusinessFactory<StoreBusiness>.Instance.CheckFlowCount(customerId);
                    this.stgList.DataSource = stores;
                }
            }
            else
            {
                var customers = BusinessFactory<CustomerBusiness>.Instance.FindAll();

                List<Store> errorStores = new List<Store>();

                foreach (var item in customers)
                {
                    if (this.chkStoreStatus.Checked)
                    {
                        var err = BusinessFactory<StoreBusiness>.Instance.CheckStoreStatus(item.Id);
                        errorStores.AddRange(err);
                    }
                }

                this.stgList.DataSource = errorStores;
            }

        }
        
        /// <summary>
        /// 显示流水
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowFlow_Click(object sender, EventArgs e)
        {
            var store = this.stgList.GetCurrentSelect();
            if (store == null)
            {
                MessageUtil.ShowClaim("未选择记录");
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            var flow = BusinessFactory<StoreBusiness>.Instance.GetStoreFlow(store.Id).OrderBy(r => r.FlowNumber).ToList();
            this.sfgList.DataSource = flow;

            this.Cursor = Cursors.Default;
        }
        #endregion //Event
    }
}
