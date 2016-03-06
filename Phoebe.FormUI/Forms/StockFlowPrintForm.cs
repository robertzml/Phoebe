using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phoebe.Model;
using Microsoft.Reporting.WinForms;

namespace Phoebe.FormUI
{
    /// <summary>
    /// 库存流水打印
    /// </summary>
    public partial class StockFlowPrintForm : Form
    {
        #region Field
        /// <summary>
        /// 流水数据
        /// </summary>
        private List<StockFlow> data;

        /// <summary>
        /// 开始日期
        /// </summary>
        private DateTime start;

        /// <summary>
        /// 结束日期
        /// </summary>
        private DateTime end;
        #endregion //Field

        #region Constructor
        public StockFlowPrintForm(List<StockFlow> data, DateTime start, DateTime end)
        {
            InitializeComponent();

            this.data = data;
            this.start = start;
            this.end = end;
        }
        #endregion //Contructor

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockFlowPrintForm_Load(object sender, EventArgs e)
        {
            List<ReportParameter> parameters = new List<ReportParameter>();
            ReportParameter rp1 = new ReportParameter("StartTime", this.start.ToString());
            ReportParameter rp2 = new ReportParameter("EndTime", this.end.ToString());

            parameters.Add(rp1);
            parameters.Add(rp2);

            this.reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("StockFlowSet", data));
            this.reportViewer1.RefreshReport();
        }
        #endregion //Event
    }
}
