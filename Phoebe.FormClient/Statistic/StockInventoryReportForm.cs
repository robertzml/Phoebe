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
    /// 库存盘点报表
    /// </summary>
    public partial class StockInventoryReportForm : BaseForm
    {
        #region Constructor
        public StockInventoryReportForm()
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
        private void StockInventoryReportForm_Load(object sender, EventArgs e)
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
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.customerLookup.GetSelectedId() == 0)
            {
                MessageUtil.ShowClaim("请选择客户");
                return;
            }

            if (this.dpFrom.DateTime > this.dpTo.DateTime)
            {
                MessageUtil.ShowClaim("开始日期不能晚于结束日期");
                return;
            }

            var data = BusinessFactory<StoreBusiness>.Instance.GetInventory(this.dpFrom.DateTime.Date, this.dpTo.DateTime.Date, this.customerLookup.GetSelectedId());

            this.ingList.DataSource = data;
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.ingList.PrintPriview();
        }
        #endregion //Event
    }
}
