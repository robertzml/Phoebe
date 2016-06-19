using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;

namespace Phoebe.FormClient.Report
{
    using DevExpress.XtraReports.UI;
    using Phoebe.Model.Report;

    /// <summary>
    /// 缴费收据打印
    /// </summary>
    public partial class Payment : DevExpress.XtraReports.UI.XtraReport
    {
        #region Constructor
        public Payment(RPaymentModel model)
        {
            InitializeComponent();
            BindData(model);
        }
        #endregion //Constructor

        #region Function
        private void BindData(RPaymentModel model)
        {
            List<RPaymentModel> list = new List<RPaymentModel>();
            list.Add(model);
            this.DataSource = list;
        }
        #endregion //Function
    }
}
