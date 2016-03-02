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
    /// 入库报表窗体
    /// </summary>
    public partial class StockInReportForm : Form
    {
        #region Field
        private StockIn stockIn;
        #endregion //Field

        #region Constructor
        public StockInReportForm(StockIn stockIn)
        {
            InitializeComponent();
            this.stockIn = stockIn;
        }
        #endregion //Constructor

        #region Function

        #endregion //Function

        #region Event
        private void StockInReportForm_Load(object sender, EventArgs e)
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
            this.reportViewer1.RefreshReport();

            //设置打印布局模式,显示物理页面大小
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            //缩放模式为百分比,以100%方式显示
            this.reportViewer1.ZoomMode = ZoomMode.Percent;
            this.reportViewer1.ZoomPercent = 100;
        }
        #endregion //Event
    }
}
