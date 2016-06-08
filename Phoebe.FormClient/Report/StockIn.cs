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
        #region Constructor
        public StockIn(RStockInModel model)
        {
            InitializeComponent();

            BindData(model);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="model">数据模型</param>
        private void BindData(RStockInModel model)
        {
            this.DataSource = model.Details;
            this.CustomerName.Value = model.CustomerName;
            this.InTime.Value = model.InTime;
            this.FlowNumber.Value = model.FlowNumber;
            this.User.Value = model.UserName;
        }
        #endregion //Function
    }
}
