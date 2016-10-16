using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;

namespace Phoebe.FormClient.Report
{
    using DevExpress.XtraReports.UI;
    using Phoebe.Model.Report;

    /// <summary>
    /// 出库单打印
    /// </summary>
    public partial class StockOut : DevExpress.XtraReports.UI.XtraReport
    {
        #region Constructor
        public StockOut(RStockOutModel model)
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
        private void BindData(RStockOutModel model)
        {
            this.DataSource = model.Details;
            this.CustomerName.Value = model.CustomerName;
            this.OutTime.Value = model.OutTime;
            this.FlowNumber.Value = model.FlowNumber;
            this.CarNumber.Value = model.CarNumber;
            this.DebtFee.Value = model.DebtFee;
            this.User.Value = model.UserName;
        }
        #endregion //Function
    }
}
