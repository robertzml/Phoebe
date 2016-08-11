using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Phoebe.FormClient.Report
{
    using DevExpress.XtraReports.UI;
    using Phoebe.Model.Report;

    /// <summary>
    /// 冰块销售打印
    /// </summary>
    public partial class IceSale : DevExpress.XtraReports.UI.XtraReport
    {
        #region Constructor
        public IceSale(RIceSaleModel model)
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
        private void BindData(RIceSaleModel model)
        {
            this.DataSource = model.IceSales;
            this.CustomerName.Value = model.CustomerName;
            this.SaleTime.Value = model.SaleTime;
            this.FlowNumber.Value = model.FlowNumber;
            this.User.Value = model.UserName;
        }
        #endregion //Function
    }
}
