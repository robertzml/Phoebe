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
    /// 库存表格
    /// </summary>
    public partial class StoreGrid : UserControl
    {
        #region Field
        /// <summary>
        /// 是否允许分组
        /// </summary>
        private bool enableGroup = false;

        /// <summary>
        /// 是否允许Filter
        /// </summary>
        private bool enableFilter = false;

        /// <summary>
        /// 是否允许查找
        /// </summary>
        private bool enableFind = false;

        /// <summary>
        /// 是否显示Footer
        /// </summary>
        private bool showFooter = false;

        /// <summary>
        /// 是否启用列编辑
        /// </summary>
        private bool enableColumn = false;

        /// <summary>
        /// 是否显示客户
        /// </summary>
        private bool showCustomer = false;

        /// <summary>
        /// 是否显示合同
        /// </summary>
        private bool showContract = false;
        #endregion //Field

        #region Constructor
        public StoreGrid()
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
            this.bsStore.Clear();
        }

        /// <summary>
        /// 获取选中数据
        /// </summary>
        /// <returns></returns>
        public Store GetCurrentSelect()
        {
            int rowIndex = this.dgvStore.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsStore.Count)
                return null;
            else
                return this.bsStore[rowIndex] as Store;
        }

        /// <summary>
        /// 更新列表绑定数据显示
        /// </summary>
        public void UpdateBindingData()
        {
            this.bsStore.ResetBindings(false);
        }
        #endregion //Method

        #region  Event
        /// <summary>
        /// 控件载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StoreGrid_Load(object sender, EventArgs e)
        {
            this.dgvStore.OptionsCustomization.AllowFilter = this.enableFilter;
            this.dgvStore.OptionsFilter.AllowFilterEditor = this.enableFilter;

            this.dgvStore.OptionsFind.AllowFindPanel = this.enableFind;
            this.dgvStore.OptionsFind.AlwaysVisible = this.enableFind;

            this.dgvStore.OptionsCustomization.AllowGroup = this.enableGroup;
            this.dgvStore.OptionsMenu.EnableGroupPanelMenu = this.enableGroup;

            this.dgvStore.OptionsCustomization.AllowQuickHideColumns = this.enableColumn;
            this.dgvStore.OptionsMenu.EnableColumnMenu = this.enableColumn;

            this.dgvStore.OptionsView.ShowFooter = this.showFooter;
            this.dgvStore.OptionsMenu.EnableFooterMenu = this.showFooter;

            this.colCustomerNumber.Visible = this.showCustomer;
            this.colCustomerName.Visible = this.showCustomer;
            this.colContractName.Visible = this.showContract;
        }

        /// <summary>
        /// 格式化数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStore_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsStore.Count)
                return;

            var store = this.bsStore[rowIndex] as Store;

            if (e.Column.FieldName == "Source")
            {
                if (store.Source == 0)
                    e.DisplayText = "入库";
                else
                    e.DisplayText = "移库";
            }
            else if (e.Column.FieldName == "Destination")
            {
                if (store.Destination != null)
                {
                    if (store.Destination.Value == 0)
                        e.DisplayText = "出库";
                    else
                        e.DisplayText = "移库";
                }
            }
            else if (e.Column.FieldName == "UserId")
            {
                e.DisplayText = store.User.Name;
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
        private void dgvStore_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsStore.Count)
                return;

            var store = this.bsStore[rowIndex] as Store;

            if (e.Column.FieldName == "colCustomerNumber" && e.IsGetData)
                e.Value = store.Cargo.Contract.Customer.Number;
            if (e.Column.FieldName == "colCustomerName" && e.IsGetData)
                e.Value = store.Cargo.Contract.Customer.Name;
            if (e.Column.FieldName == "colContractName" && e.IsGetData)
                e.Value = store.Cargo.Contract.Name;
            if (e.Column.FieldName == "colCategoryNumber" && e.IsGetData)
                e.Value = store.Cargo.Category.Number;
            if (e.Column.FieldName == "colCategoryName" && e.IsGetData)
                e.Value = store.Cargo.Category.Name;
            if (e.Column.FieldName == "colUnitWeight" && e.IsGetData)
                e.Value = store.Cargo.UnitWeight;
            if (e.Column.FieldName == "colUnitVolume" && e.IsGetData)
                e.Value = store.Cargo.UnitVolume;
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<Store> DataSource
        {
            get
            {
                return this.bsStore.DataSource as List<Store>;
            }
            set
            {
                this.dgvStore.BeginDataUpdate();
                this.bsStore.DataSource = value;
                this.dgvStore.EndDataUpdate();
            }
        }

        /// <summary>
        /// 是否允许分组
        /// </summary>
        [Description("是否允许分组")]
        public bool EnableGroup
        {
            get
            {
                return this.enableGroup;
            }
            set
            {
                this.enableGroup = value;
            }
        }

        /// <summary>
        /// 是否允许Filter
        /// </summary>
        [Description("是否允许Filter")]
        public bool EnableFilter
        {
            get
            {
                return this.enableFilter;
            }
            set
            {
                this.enableFilter = value;
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

        /// <summary>
        /// 是否显示Footer
        /// </summary>
        [Description("是否显示Footer")]
        public bool ShowFooter
        {
            get
            {
                return this.showFooter;
            }
            set
            {
                this.showFooter = value;
            }
        }

        /// <summary>
        /// 是否启用列编辑
        /// </summary>
        [Description("是否启用列编辑")]
        public bool EnableColumn
        {
            get
            {
                return this.enableColumn;
            }
            set
            {
                this.enableColumn = value;
            }
        }

        /// <summary>
        /// 是否显示客户
        /// </summary>
        [Description("是否显示客户")]
        public bool ShowCustomer
        {
            get
            {
                return this.showCustomer;
            }
            set
            {
                this.showCustomer = value;
            }
        }

        /// <summary>
        /// 是否显示合同
        /// </summary>
        [Description("是否显示合同")]
        public bool ShowContract
        {
            get
            {
                return this.showContract;
            }
            set
            {
                this.showContract = value;
            }
        }
        #endregion //Property
    }
}
