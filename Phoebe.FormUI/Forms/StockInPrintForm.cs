using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phoebe.Model;
using Microsoft.Reporting.WinForms;

namespace Phoebe.FormUI
{
    /// <summary>
    /// 入库单打印窗体
    /// </summary>
    public partial class StockInPrintForm : Form
    {
        #region Field
        private StockIn stockIn;
        #endregion //Field

        #region Constructor
        public StockInPrintForm(StockIn stockIn)
        {
            InitializeComponent();

            this.stockIn = stockIn;
        }
        #endregion //Constructor

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockInPrintForm_Load(object sender, EventArgs e)
        {
            List<RStockInDetail> details = new List<RStockInDetail>();

            int number = 1;
            foreach (var item in this.stockIn.StockInDetails)
            {
                RStockInDetail detail = new RStockInDetail();
                detail.Number = number++;
                detail.Name = item.Cargo.Name;
                detail.FirstCategory = item.Cargo.FirstCategory.Name;
                detail.SecondCategory = item.Cargo.SecondCategory.Name;
                detail.ThirdCategory = item.Cargo.ThirdCategory == null ? "" : item.Cargo.ThirdCategory.Name;
                detail.Count = item.Count;
                detail.UnitWeight = item.Cargo.UnitWeight;
                detail.TotalWeight = item.InWeight;
                detail.TotalVolume = item.Cargo.TotalVolume;
                detail.Warehouse = item.WarehouseNumber;

                details.Add(detail);
            }

            var contract = this.stockIn.Contract;

            List<ReportParameter> parameters = new List<ReportParameter>();
            ReportParameter rp1 = new ReportParameter("InTime", this.stockIn.InTime.ToString());
            ReportParameter rp2 = new ReportParameter("FlowNumber", this.stockIn.FlowNumber);
            ReportParameter rp3 = new ReportParameter("CustomerName", contract.Customer.Name);
            ReportParameter rp4 = new ReportParameter("ContractNumber", contract.Number);

            parameters.Add(rp1);
            parameters.Add(rp2);
            parameters.Add(rp3);
            parameters.Add(rp4);

            this.reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("StockInSet", details));

            var pageSettings = this.reportViewer1.GetPageSettings();
            pageSettings.PaperSize = new PaperSize
            {
                Height = 366,
                Width = 953
            };
            pageSettings.Margins = new Margins
            {
                Top = 20,
                Bottom = 20,
                Left = 40,
                Right = 40
            };
            pageSettings.Landscape = false;
            this.reportViewer1.SetPageSettings(pageSettings);

            this.reportViewer1.RefreshReport();
        }
        #endregion //Event
    }
}
