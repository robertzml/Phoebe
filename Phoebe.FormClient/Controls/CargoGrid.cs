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
    /// 货品表格控件
    /// </summary>
    public partial class CargoGrid : UserControl
    {
        #region Field
        /// <summary>
        /// 是否允许分组
        /// </summary>
        private bool enableGroup = false;

        /// <summary>
        /// 是否允许查找
        /// </summary>
        private bool enableFind = false;

        /// <summary>
        /// 是否显示Footer
        /// </summary>
        private bool showFooter = false;
        #endregion //Field

        #region Constructor
        public CargoGrid()
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
            this.bsCargo.Clear();
        }

        /// <summary>
        /// 获取选中数据
        /// </summary>
        /// <returns></returns>
        public Cargo GetCurrentSelect()
        {
            int rowIndex = this.dgvCargo.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsCargo.Count)
                return null;
            else
                return this.bsCargo[rowIndex] as Cargo;
        }
        #endregion //Method

        #region Event
        private void CargoGrid_Load(object sender, EventArgs e)
        {
            this.dgvCargo.OptionsCustomization.AllowGroup = this.enableGroup;
            this.dgvCargo.OptionsMenu.EnableGroupPanelMenu = this.enableGroup;

            this.dgvCargo.OptionsFind.AllowFindPanel = this.enableFind;
            this.dgvCargo.OptionsFind.AlwaysVisible = this.enableFind;

            this.dgvCargo.OptionsView.ShowFooter = this.showFooter;
            this.dgvCargo.OptionsMenu.EnableFooterMenu = this.showFooter;
        }

        /// <summary>
        /// 格式化数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCargo_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsCargo.Count)
                return;

            if (e.Column.FieldName == "ContractId")
            {
                var cargo = this.bsCargo[rowIndex] as Cargo;
                e.DisplayText = cargo.Contract.Name;
            }
            else if (e.Column.FieldName == "GroupType")
            {
                var cargo = this.bsCargo[rowIndex] as Cargo;
                e.DisplayText = ((BillingType)cargo.GroupType).DisplayName();
            }
        }

        /// <summary>
        /// 自定义数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCargo_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsCargo.Count)
                return;

            var cargo = this.bsCargo[rowIndex] as Cargo;

            if (e.Column.FieldName == "colCategoryNumber" && e.IsGetData)
                e.Value = cargo.Category.Number;
            if (e.Column.FieldName == "colCategoryName" && e.IsGetData)
                e.Value = cargo.Category.Name;
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<Cargo> DataSource
        {
            get
            {
                return this.bsCargo.DataSource as List<Cargo>;
            }
            set
            {
                this.dgvCargo.BeginDataUpdate();
                this.bsCargo.DataSource = value;
                this.dgvCargo.EndDataUpdate();
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
        #endregion //Property
    }
}
