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
    /// 客户费用报表窗体
    /// </summary>
    public partial class CustomerFeeReportForm : BaseForm
    {
        #region Constructor
        public CustomerFeeReportForm()
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
        private void CustomerFeeReportForm_Load(object sender, EventArgs e)
        {
            this.customerLookup.Init();

            this.dpFrom.DateTime = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date;
            this.dpTo.DateTime = DateTime.Now.Date;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.dpFrom.DateTime > this.dpTo.DateTime)
            {
                MessageUtil.ShowClaim("开始日期不能晚于结束日期");
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            var from = this.dpFrom.DateTime.Date;
            var to = this.dpTo.DateTime.Date;

            this.cfgList.StartDate = from;
            this.cfgList.EndDate = to;

            if (this.customerLookup.GetSelectedId() == 0)
            {
                var data = BusinessFactory<StatisticBusiness>.Instance.GetCustomerFee(from, to);
                this.cfgList.DataSource = data;
            }
            else
            {
                int customerId = this.customerLookup.GetSelectedId();

                var data = BusinessFactory<StatisticBusiness>.Instance.GetCustomerFee(customerId, from, to);

                List<CustomerFee> list = new List<CustomerFee>();
                list.Add(data);

                this.cfgList.DataSource = list;
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.cfgList.PrintPriview();
        }

        /// <summary>
        /// 显示详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShow_Click(object sender, EventArgs e)
        {
            var select = this.cfgList.GetCurrentSelect();
            if (select == null)
            {
                MessageUtil.ShowClaim("未选中记录");
                return;
            }

            ChildFormManage.ShowDialogForm(typeof(FeeDetailsForm), new object[] { select.CustomerId, select.StartTime, select.EndTime });
        }
        #endregion //Event
    }
}
