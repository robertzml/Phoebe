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
    /// 库存盘点打印
    /// </summary>
    public partial class StockInventoryPrintForm : Form
    {
        #region Field
        /// <summary>
        /// 盘点数据
        /// </summary>
        private List<Inventory> data;

        private DateTime start;

        private DateTime end;
        #endregion //Field

        #region Constructor
        public StockInventoryPrintForm(List<Inventory> data, DateTime start, DateTime end)
        {
            InitializeComponent();

            this.data = data;
            this.start = start;
            this.end = end;
        }
        #endregion //Constructor

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockInventoryPrintForm_Load(object sender, EventArgs e)
        {
            List<ReportParameter> parameters = new List<ReportParameter>();
            ReportParameter rp1 = new ReportParameter("StartTime", this.start.ToString());
            ReportParameter rp2 = new ReportParameter("EndTime", this.end.ToString());

            parameters.Add(rp1);
            parameters.Add(rp2);

            this.reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("InventorySet", data));
            this.reportViewer1.RefreshReport();
        }
        #endregion //Event
    }
}
