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
    /// 货品总报表
    /// </summary>
    public partial class TotalStorageReportForm : BaseForm
    {
        #region Constructor
        public TotalStorageReportForm()
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
        private void TotalStorageReportForm_Load(object sender, EventArgs e)
        {
            this.dpTime.DateTime = DateTime.Now.Date;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            var date = this.dpTime.DateTime.Date;

            this.Cursor = Cursors.WaitCursor;

            var data = BusinessFactory<StatisticBusiness>.Instance.GetTotalStorage(date);
            this.dtsList.DataSource = data;
            this.dtsList.StorageDate = date;

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.dtsList.PrintPriview();
        }
        #endregion //Event
    }
}
