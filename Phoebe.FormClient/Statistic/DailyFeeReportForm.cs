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
    /// 费用日报表
    /// </summary>
    public partial class DailyFeeReportForm : BaseForm
    {
        #region Constructor
        public DailyFeeReportForm()
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
        private void DailyFeeReportForm_Load(object sender, EventArgs e)
        {
            this.dpSelect.DateTime = DateTime.Now.Date;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            var date = this.dpSelect.DateTime.Date;

            this.Cursor = Cursors.WaitCursor;

            var data = BusinessFactory<StatisticBusiness>.Instance.GetDailyFee(date);
            this.dfList.DataSource = data;
            this.dfList.FeeDate = date;

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.dfList.PrintPriview();
        }

        /// <summary>
        /// 显示详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetails_Click(object sender, EventArgs e)
        {
            var select = this.dfList.GetCurrentSelect();
            if (select == null)
            {
                MessageUtil.ShowClaim("未选中记录");
                return;
            }

            ChildFormManage.ShowDialogForm(typeof(FeeDetailsForm), new object[] { select.CustomerId, select.Date, select.Date });
        }
        #endregion //Event
    }
}
