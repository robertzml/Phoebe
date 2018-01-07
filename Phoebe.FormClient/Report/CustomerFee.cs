using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Phoebe.FormClient.Report
{
    using Phoebe.Model.Report;

    /// <summary>
    /// 客户费用报表
    /// </summary>
    public partial class CustomerFee : DevExpress.XtraReports.UI.XtraReport
    {
        #region Constructor
        public CustomerFee(RCustomerFeeModel model)
        {
            InitializeComponent();
            BindData(model);
        }
        #endregion //Constructor

        #region Function
        private void BindData(RCustomerFeeModel model)
        {
            List<RCustomerFeeModel> list = new List<RCustomerFeeModel>();
            list.Add(model);
            this.DataSource = list;
        }
        #endregion //Function
    }
}
