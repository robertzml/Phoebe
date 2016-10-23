using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 缴费表格控件
    /// </summary>
    public partial class PaymentGrid : UserControl
    {
        #region Field
        /// <summary>
        /// 是否允许查找
        /// </summary>
        private bool enableFind = true;
        #endregion //Field

        #region Constructor
        public PaymentGrid()
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
            this.bsPayment.Clear();
        }

        /// <summary>
        /// 获取选中数据
        /// </summary>
        /// <returns></returns>
        public Payment GetCurrentSelect()
        {
            int rowIndex = this.dgvPayment.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsPayment.Count)
                return null;
            else
                return this.bsPayment[rowIndex] as Payment;
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 控件载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PaymentGrid_Load(object sender, EventArgs e)
        {
            this.dgvPayment.OptionsFind.AllowFindPanel = this.enableFind;
            this.dgvPayment.OptionsFind.AlwaysVisible = this.enableFind;
        }

        /// <summary>
        /// 格式化数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPayment_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsPayment.Count)
                return;

            if (e.Column.FieldName == "CustomerId")
            {
                var payment = this.bsPayment[rowIndex] as Payment;
                e.DisplayText = payment.Customer.Name;
            }
            else if (e.Column.FieldName == "PaidType")
            {
                var payment = this.bsPayment[rowIndex] as Payment;
                e.DisplayText = ((PaymentType)payment.PaidType).DisplayName();
            }
            else if (e.Column.FieldName == "UserId")
            {
                var payment = this.bsPayment[rowIndex] as Payment;
                e.DisplayText = payment.User.Name;
            }
        }

        /// <summary>
        /// 自定义数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPayment_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsPayment.Count)
                return;

            var payment = this.bsPayment[rowIndex] as Payment;

            if (e.Column.FieldName == "colCustomerNumber" && e.IsGetData)
                e.Value = payment.Customer.Number;
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<Payment> DataSource
        {
            get
            {
                return this.bsPayment.DataSource as List<Payment>;
            }
            set
            {
                this.dgvPayment.BeginDataUpdate();
                this.bsPayment.DataSource = value;
                this.dgvPayment.EndDataUpdate();
            }
        }

        /// <summary>
        /// 是否允许查找
        /// </summary>
        [Description("是否允许查找")]
        public bool EnableFind
        {
            get
            {
                return this.enableFind;
            }
            set
            {
                this.enableFind = value;
            }
        }
        #endregion //Property
    }
}
