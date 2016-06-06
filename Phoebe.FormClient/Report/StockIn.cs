using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace Phoebe.FormClient.Report
{
    using DevExpress.XtraReports.UI;
    using Phoebe.Model.Report;

    /// <summary>
    /// 入库单打印
    /// </summary>
    public partial class StockIn : DevExpress.XtraReports.UI.XtraReport
    {
        public StockIn(RStockInModel model)
        {
            InitializeComponent();

            BindData(model);
        }

        private void BindData(RStockInModel model)
        {
            this.DataSource = model.Details;
            this.CustomerName.Value = model.CustomerName;
            this.UserName.Value = model.UserName;
         
        }
    }
}
