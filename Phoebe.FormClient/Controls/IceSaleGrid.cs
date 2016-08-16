using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 冰块销售表格控件
    /// </summary>
    public partial class IceSaleGrid : UserControl
    {
        #region Constructor
        public IceSaleGrid()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 清空数据
        /// </summary>
        public void Clear()
        {
            this.bsIceSale.Clear();
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 格式化数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvIce_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsIceSale.Count)
                return;

            var iceSale = this.bsIceSale[rowIndex] as IceSale;
            if (e.Column.FieldName == "IceType")
            {
                e.DisplayText = ((IceType)iceSale.IceType).DisplayName();
            }
        }

        /// <summary>
        /// 自定义数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvIce_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsIceSale.Count)
                return;

            var iceSale = this.bsIceSale[rowIndex] as IceSale;

            if (e.Column.FieldName == "colCustomerNumber" && e.IsGetData)
                e.Value = iceSale.IceFlow.Contract.Customer.Number;
            if (e.Column.FieldName == "colCustomerName" && e.IsGetData)
                e.Value = iceSale.IceFlow.Contract.Customer.Name;
            if (e.Column.FieldName == "colUser" && e.IsGetData)
                e.Value = iceSale.IceFlow.User.Name;
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<IceSale> DataSource
        {
            get
            {
                return this.bsIceSale.DataSource as List<IceSale>;
            }
            set
            {
                this.dgvIce.BeginDataUpdate();
                this.bsIceSale.DataSource = value;
                this.dgvIce.EndDataUpdate();
            }
        }
        #endregion //Property
    }
}
