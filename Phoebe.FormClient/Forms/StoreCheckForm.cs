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
            this.customerLookup.Init();
        }

        /// <summary>
        /// 列出库存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowStores_Click(object sender, EventArgs e)
        {
            if (this.customerLookup.GetSelectedId() != 0)
            {
                int customerId = this.customerLookup.GetSelectedId();

                var stores = BusinessFactory<StoreBusiness>.Instance.GetByCustomer(customerId);

                if (!this.chkStoreIn.Checked)
                    stores = stores.Where(r => r.Status != (int)EntityStatus.StoreIn).ToList();
                if (!this.chkStoreOut.Checked)
                    stores = stores.Where(r => r.Status != (int)EntityStatus.StoreOut).ToList();

                this.stgList.DataSource = stores;
            }
            else
            {
                MessageUtil.ShowClaim("请选择客户");
            }
        }


        /// <summary>
        /// 开始检查
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartCheck_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.stgList.Clear();
            this.sfgList.Clear();

            if (this.customerLookup.GetSelectedId() != 0)
            {
                int customerId = this.customerLookup.GetSelectedId();

                if (this.chkStoreStatus.Checked)
                {
                    var stores = BusinessFactory<StoreBusiness>.Instance.CheckStoreStatus(customerId);
                    this.stgList.DataSource = stores;
                }
                else if (this.chkFlowCount.Checked)
                {
                    var stores = BusinessFactory<StoreBusiness>.Instance.CheckFlowCount(customerId);
                    this.stgList.DataSource = stores;
                }
                else if (this.chkOrder.Checked)
                {
                    var stores = BusinessFactory<StoreBusiness>.Instance.CheckFlowOrder(customerId);
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
                    else if (this.chkFlowCount.Checked)
                    {
                        var err = BusinessFactory<StoreBusiness>.Instance.CheckFlowCount(item.Id);
                        errorStores.AddRange(err);
                    }
                    else if (this.chkOrder.Checked)
                    {
                        var err = BusinessFactory<StoreBusiness>.Instance.CheckFlowOrder(item.Id);
                        errorStores.AddRange(err);
                    }
                }

                this.stgList.DataSource = errorStores;
            }

            this.Cursor = Cursors.Default;
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

        /// <summary>
        /// 删除流水
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteFlow_Click(object sender, EventArgs e)
        {
            var flow = this.sfgList.GetCurrentSelect();
            if (flow == null)
            {
                MessageUtil.ShowClaim("未选择流水记录");
                return;
            }

            if (MessageUtil.ConfirmYesNo("是否确认删除该流水记录，删除后无法恢复。") == DialogResult.Yes)
            {
                var result = BusinessFactory<StoreBusiness>.Instance.DeleteStockFlow(flow);
                if (result == ErrorCode.Success)
                {
                    MessageUtil.ShowInfo("删除流水记录成功");
                }
                else
                {
                    MessageUtil.ShowWarning("删除流水失败：" + result.DisplayName());
                }
            }
        }

        /// <summary>
        /// 修正流水
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFixFlow_Click(object sender, EventArgs e)
        {
            var store = this.stgList.GetCurrentSelect();
            if (store == null)
            {
                MessageUtil.ShowClaim("未选择记录");
                return;
            }

            ErrorCode result = BusinessFactory<StoreBusiness>.Instance.FixStore(store.Id);
            if (result == ErrorCode.Success)
            {
                var flow = BusinessFactory<StoreBusiness>.Instance.GetStoreFlow(store.Id).OrderBy(r => r.FlowDate).ToList();
                this.sfgList.DataSource = flow;

                MessageUtil.ShowInfo("流水修正成功");
            }
            else
            {
                MessageUtil.ShowWarning("流水修正失败：" + result.DisplayName());
            }
        }
        #endregion //Event
    }
}
