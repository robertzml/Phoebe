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
    /// 客户货品报表窗体
    /// </summary>
    public partial class CustomerCargoReportForm : BaseForm
    {
        #region Constructor
        public CustomerCargoReportForm()
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
        private void CustomerCargoReportForm_Load(object sender, EventArgs e)
        {
            this.customerLookup.Init();

            this.dpDate.DateTime = DateTime.Now.Date;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.customerLookup.GetSelectedId() == 0)
            {
                MessageUtil.ShowClaim("请选择客户");
                return;
            }

            var date = this.dpDate.DateTime.Date;
            int customerId = this.customerLookup.GetSelectedId();

            this.Cursor = Cursors.WaitCursor;

            var data = BusinessFactory<StatisticBusiness>.Instance.GetCargoStore(customerId, date);
            this.sgList.DataSource = data;

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.sgList.StorageDate = this.dpDate.DateTime.Date;
            this.sgList.PrintPriview();
        }
        #endregion //Event
    }
}
