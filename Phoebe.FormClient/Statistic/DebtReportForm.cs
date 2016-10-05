using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
    /// 实时欠费报表
    /// </summary>
    public partial class DebtReportForm : BaseForm
    {
        #region Constructor
        public DebtReportForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Event
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            List<Debt> data = new List<Debt>();

            var customers = BusinessFactory<CustomerBusiness>.Instance.FindAll();

            foreach(var item in customers)
            {
                var debt = BusinessFactory<SettlementBusiness>.Instance.GetDebt(item.Id);
                data.Add(debt);
            }

            this.dtList.DataSource = data;
            sw.Stop();

            this.txtTime.Text = sw.ElapsedMilliseconds.ToString() + "ms";
            this.Cursor = Cursors.Default;
        }
        
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.dtList.PrintPriview();
        }
        #endregion //Event
    }
}
