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

        /// <summary>
        /// 数据转换
        /// </summary>
        /// <param name="iceFlows">冰块流水记录</param>
        /// <returns></returns>
        private List<IceStoreFlow> ConvertToFlow(List<IceFlow> iceFlows)
        {
            List<IceStoreFlow> data = new List<IceStoreFlow>();

            foreach (var item in iceFlows)
            {
                if (item.FlowType == (int)IceFlowType.IceSale)
                {
                    var iceSales = item.IceSales;

                    foreach (var sale in iceSales)
                    {
                        IceStoreFlow sf = new IceStoreFlow();
                        sf.FlowType = item.FlowType;
                        sf.FlowNumber = item.FlowNumber;
                        sf.FlowTime = item.FlowTime;
                        sf.UserName = item.User.Name;
                        sf.CreateTime = item.CreateTime;
                        sf.Remark = item.Remark;
                        sf.IceType = sale.IceType;
                        sf.FlowCount = sale.SaleCount;
                        sf.UnitWeight = sale.UnitWeight;
                        sf.FlowWeight = sale.SaleWeight;

                        data.Add(sf);
                    }
                }
                else
                {
                    var iceStock = item.IceStocks.First();

                    IceStoreFlow sf = new IceStoreFlow();
                    sf.FlowType = item.FlowType;
                    sf.FlowNumber = item.FlowNumber;
                    sf.FlowTime = item.FlowTime;
                    sf.UserName = item.User.Name;
                    sf.CreateTime = item.CreateTime;
                    sf.Remark = item.Remark;
                    sf.IceType = iceStock.IceType;
                    sf.FlowCount = iceStock.FlowCount;
                    sf.UnitWeight = iceStock.UnitWeight;
                    sf.FlowWeight = iceStock.FlowWeight;

                    data.Add(sf);

                }
            }

            return data;
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
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStores();
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
                var flows = BusinessFactory<IceFlowBusiness>.Instance.Get(this.dpFrom.DateTime, this.dpTo.DateTime);
                var data = ConvertToFlow(flows);
                this.isfList.DataSource = data;
            }
            else
            {
                IceFlowType flowType = (IceFlowType)this.cmbFlowType.SelectedIndex;
                var flows = BusinessFactory<IceFlowBusiness>.Instance.Get(this.dpFrom.DateTime, this.dpTo.DateTime, flowType);
                var data = ConvertToFlow(flows);
                this.isfList.DataSource = data;
            }
        }
        #endregion //Event
    }
}
