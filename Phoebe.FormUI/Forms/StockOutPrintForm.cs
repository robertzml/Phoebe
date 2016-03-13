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
    /// 出库单打印
    /// </summary>
    public partial class StockOutPrintForm : Form
    {
        #region Field
        private StockOut stockOut;
        #endregion //Field

        #region Constructor
        public StockOutPrintForm(StockOut stockOut)
        {
            InitializeComponent();

            this.stockOut = stockOut;
        }
        #endregion //Constructor

        #region Event
        private void StockOutPrintForm_Load(object sender, EventArgs e)
        {
            List<RStockOutDetail> details = new List<RStockOutDetail>();

            int number = 1;
            foreach (var item in this.stockOut.StockOutDetails)
            {
                RStockOutDetail detail = new RStockOutDetail();
                detail.Number = number++;
                detail.Name = item.Cargo.Name;
                detail.FirstCategory = item.Cargo.FirstCategory.Name;
                detail.SecondCategory = item.Cargo.SecondCategory.Name;
                detail.ThirdCategory = item.Cargo.ThirdCategory == null ? "" : item.Cargo.ThirdCategory.Name;
                detail.Count = item.Count;
                detail.UnitWeight = item.Cargo.UnitWeight;
                detail.TotalWeight = item.OutWeight;
                detail.TotalVolume = item.Cargo.TotalVolume;
                detail.Warehouse = item.WarehouseNumber;

                details.Add(detail);
            }


            var contract = this.stockOut.Contract;

            List<ReportParameter> parameters = new List<ReportParameter>();
            ReportParameter rp1 = new ReportParameter("OutTime", this.stockOut.OutTime.ToString());
            ReportParameter rp2 = new ReportParameter("FlowNumber", this.stockOut.FlowNumber);
            ReportParameter rp3 = new ReportParameter("CustomerName", contract.Customer.Name);
            ReportParameter rp4 = new ReportParameter("ContractNumber", contract.Number);

            parameters.Add(rp1);
            parameters.Add(rp2);
            parameters.Add(rp3);
            parameters.Add(rp4);

            this.reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("StockOutSet", details));

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
                Right = 30
            };
            pageSettings.Landscape = false;
            this.reportViewer1.SetPageSettings(pageSettings);

            this.reportViewer1.RefreshReport();
        }
        #endregion //Event
    }
}
