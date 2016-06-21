using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    /// 冰块库存窗体
    /// </summary>
    public partial class IceStoreForm : BaseForm
    {
        #region Constructor
        public IceStoreForm()
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
        private void IceStoreForm_Load(object sender, EventArgs e)
        {
            LoadStores();

            this.dpFrom.DateTime = DateTime.Now.AddMonths(-1).Date; 
            this.dpTo.DateTime = DateTime.Now.Date;
            this.cmbFlowType.SelectedIndex = 0;
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

            if (this.cmbFlowType.SelectedIndex == 0)
            {
                var data = BusinessFactory<IceFlowBusiness>.Instance.Get(this.dpFrom.DateTime, this.dpTo.DateTime);
                this.iceList.DataSource = data;
            }
            else
            {
                IceFlowType flowType = (IceFlowType)this.cmbFlowType.SelectedIndex;
                var data = BusinessFactory<IceFlowBusiness>.Instance.Get(this.dpFrom.DateTime, this.dpTo.DateTime, flowType);
                this.iceList.DataSource = data;
            }
        }

        /// <summary>
        /// 整冰入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCompleteStockIn_Click(object sender, EventArgs e)
        {
            ChildFormManage.ShowDialogForm(typeof(IceStockForm), new object[] { IceFlowType.CompleteStockIn, IceType.Complete });

            LoadStores();
        }

        /// <summary>
        /// 碎冰入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFragmentStockIn_Click(object sender, EventArgs e)
        {
            ChildFormManage.ShowDialogForm(typeof(IceStockForm), new object[] { IceFlowType.FragmentStockIn, IceType.Fragment });

            LoadStores();
        }

        /// <summary>
        /// 整冰制冰出库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCompleteMakeOut_Click(object sender, EventArgs e)
        {
            ChildFormManage.ShowDialogForm(typeof(IceStockForm), new object[] { IceFlowType.CompleteMakeOut, IceType.Complete });

            LoadStores();
        }
        #endregion //Event
    }
}
