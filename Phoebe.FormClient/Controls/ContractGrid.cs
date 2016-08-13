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
    /// 合同表格控件
    /// </summary>
    public partial class ContractGrid : UserControl
    {
        #region Constructor
        public ContractGrid()
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
            this.bsContract.Clear();
        }

        /// <summary>
        /// 获取选中数据
        /// </summary>
        /// <returns></returns>
        public Contract GetCurrentSelect()
        {
            int rowIndex = this.dgvContract.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsContract.Count)
                return null;
            else
                return this.bsContract[rowIndex] as Contract;
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 格式化数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvContract_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsContract.Count)
                return;

            if (e.Column.FieldName == "CustomerId")
            {
                var contract = this.bsContract[rowIndex] as Contract;
                e.DisplayText = contract.Customer.Name;
            }
            else if (e.Column.FieldName == "Type")
            {
                var type = (ContractType)e.Value;
                e.DisplayText = type.DisplayName();
            }
            else if (e.Column.FieldName == "BillingType")
            {
                var type = (BillingType)e.Value;
                e.DisplayText = type.DisplayName();
            }
            else if (e.Column.FieldName == "UserId")
            {
                var contract = this.bsContract[rowIndex] as Contract;
                e.DisplayText = contract.User.Name;
            }
            else if (e.Column.FieldName == "Status")
            {
                var status = (EntityStatus)e.Value;
                e.DisplayText = status.DisplayName();
            }
        }

        /// <summary>
        /// 自定义数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvContract_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsContract.Count)
                return;

            var contract = this.bsContract[rowIndex] as Contract;

            if (e.Column.FieldName == "colBillingDescription" && e.IsGetData)
                e.Value = ((BillingType)contract.BillingType).DisplayDescription();
            if (e.Column.FieldName == "colCustomerNumber" && e.IsGetData)
                e.Value = contract.Customer.Number;
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<Contract> DataSource
        {
            get
            {
                return this.bsContract.DataSource as List<Contract>;
            }
            set
            {
                this.dgvContract.BeginDataUpdate();
                this.bsContract.DataSource = value;
                this.dgvContract.EndDataUpdate();
            }
        }
        #endregion //Property
    }
}
