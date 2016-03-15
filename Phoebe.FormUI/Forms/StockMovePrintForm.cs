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
    /// 移库打印窗体
    /// </summary>
    public partial class StockMovePrintForm : Form
    {
        #region Field
        private StockMove stockMove;
        #endregion //Field

        #region Constructor
        public StockMovePrintForm(StockMove stockMove)
        {
            InitializeComponent();
            this.stockMove = stockMove;
        }
        #endregion //Constructor

        #region Event
        private void StockMovePrintForm_Load(object sender, EventArgs e)
        {
            List<RStockMoveDetail> details = new List<RStockMoveDetail>();

            int number = 1;
            foreach (var item in this.stockMove.StockMoveDetails)
            {
                RStockMoveDetail detail = new RStockMoveDetail();
                detail.Number = number++;
                detail.Name = item.SourceCargo.Name;
                detail.FirstCategory = item.SourceCargo.FirstCategory.Name;
                detail.SecondCategory = item.SourceCargo.SecondCategory.Name;
                detail.ThirdCategory = item.SourceCargo.ThirdCategory == null ? "" : item.SourceCargo.ThirdCategory.Name;
                detail.Count = item.Count;
                detail.UnitWeight = item.SourceCargo.UnitWeight;
                detail.TotalWeight = item.MoveWeight;
                detail.TotalVolume = item.SourceCargo.TotalVolume;
                detail.SourceWarehouse = item.SourceCargo.WarehouseNumber;
                detail.NewWarehouse = item.WarehouseNumber;

                details.Add(detail);
            }

            var contract = this.stockMove.Contract;

            List<ReportParameter> parameters = new List<ReportParameter>();
            ReportParameter rp1 = new ReportParameter("MoveTime", this.stockMove.MoveTime.ToString());
            ReportParameter rp2 = new ReportParameter("FlowNumber", this.stockMove.FlowNumber);
            ReportParameter rp3 = new ReportParameter("CustomerName", contract.Customer.Name);
            ReportParameter rp4 = new ReportParameter("ContractNumber", contract.Number);

            parameters.Add(rp1);
            parameters.Add(rp2);
            parameters.Add(rp3);
            parameters.Add(rp4);

            this.reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("StockMoveSet", details));

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
                Left = 20,
                Right = 20
            };
            pageSettings.Landscape = false;
            this.reportViewer1.SetPageSettings(pageSettings);

            this.reportViewer1.RefreshReport();
        }
        #endregion //Event
    }
}
