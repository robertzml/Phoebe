using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phoebe.ClientDx
{
    using DevExpress.XtraPrinting;
    using Poseidon.Base.Framework;

    /// <summary>
    /// 实体表格控件
    /// </summary>
    /// <remarks>
    /// 绑定实体类
    /// </remarks>
    public partial class WinIntGrid<T> : DevExpress.XtraEditors.XtraUserControl where T : class, IBaseEntity<int>
    {
        #region Field
        /// <summary>
        /// 是否能编辑
        /// </summary>
        protected bool editable = false;

        /// <summary>
        /// 是否能筛选
        /// </summary>
        protected bool allowFilter = true;

        /// <summary>
        /// 是否能分组
        /// </summary>
        protected bool allowGroup = true;

        /// <summary>
        /// 是否能排序
        /// </summary>
        protected bool allowSort = true;

        /// <summary>
        /// 是否启用多选
        /// </summary>
        protected bool enableMultiSelect = false;

        /// <summary>
        /// 是否启用Master View
        /// </summary>
        protected bool enableMasterView = false;

        /// <summary>
        /// 是否显示行号
        /// </summary>
        protected bool showLineNumber = true;

        /// <summary>
        /// 是否显示Footer
        /// </summary>
        protected bool showFooter = false;

        /// <summary>
        /// 是否显示菜单
        /// </summary>
        protected bool showMenu = false;

        /// <summary>
        /// 是否显示新增菜单
        /// </summary>
        protected bool showAddMenu = false;

        /// <summary>
        /// 是否显示编辑菜单
        /// </summary>
        protected bool showEditMenu = false;

        /// <summary>
        /// 是否显示删除菜单
        /// </summary>
        protected bool showDeleteMenu = false;

        /// <summary>
        /// 是否显示导航
        /// </summary>
        protected bool showNavigator = false;

        /// <summary>
        /// 增加右键菜单
        /// </summary>
        private ContextMenuStrip appendedMenu;
        #endregion //Field

        #region Constructor
        public WinIntGrid()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 更新列表绑定数据显示
        /// </summary>
        public void UpdateBindingData()
        {
            this.bsEntity.ResetBindings(false);
        }

        /// <summary>
        /// 清空数据
        /// </summary>
        public void Clear()
        {
            this.bsEntity.Clear();
        }

        /// <summary>
        /// 获取选中数据
        /// </summary>
        /// <returns></returns>
        public T GetCurrentSelect()
        {
            int rowIndex = this.dgvEntity.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsEntity.Count)
                return default(T);
            else
                return this.bsEntity[rowIndex] as T;
        }

        /// <summary>
        /// 选择行
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <remarks>
        /// 选择指定对象行，使用ID判断
        /// </remarks>
        public void SelectRow(T entity)
        {
            var ds = this.bsEntity.DataSource as List<T>;
            var index = ds.FindIndex(r => r.Id == entity.Id);
            var rowIndex = this.dgvEntity.GetRowHandle(index);
            this.dgvEntity.FocusedRowHandle = rowIndex;
        }

        /// <summary>
        /// 完成编辑
        /// </summary>
        public void CloseEditor()
        {
            this.dgvEntity.CloseEditor();
        }

        /// <summary>
        /// 重新适配列宽
        /// </summary>
        public void BestFitColumns()
        {
            this.dgvEntity.BestFitColumns();
        }

        /// <summary>
        /// 追加菜单项
        /// </summary>
        /// <param name="menu">菜单</param>
        public void AppendMenu(ContextMenuStrip menu)
        {
            appendedMenu = menu;
            int i = 0;
            for (i = 0; appendedMenu.Items.Count > 0; i++)
            {
                this.contextMenu.Items.Insert(i, appendedMenu.Items[0]);
            }
            this.contextMenu.Items.Insert(i, new ToolStripSeparator());
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 控件载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WinEntityGrid_Load(object sender, EventArgs e)
        {
            if (this.showLineNumber)
                this.dgvEntity.IndicatorWidth = 40;
            else
                this.dgvEntity.IndicatorWidth = 10;

            this.dgvEntity.OptionsBehavior.Editable = this.editable;
            this.dgvEntity.OptionsView.ShowFooter = this.showFooter;
            this.dgvEntity.OptionsCustomization.AllowFilter = this.allowFilter;
            this.dgvEntity.OptionsCustomization.AllowGroup = this.allowGroup;
            this.dgvEntity.OptionsCustomization.AllowSort = this.allowSort;
            this.dgvEntity.OptionsDetail.EnableMasterViewMode = this.enableMasterView;
            this.dgvEntity.OptionsSelection.MultiSelect = this.enableMultiSelect;

            this.dataNavigator.Visible = this.showNavigator;
        }

        /// <summary>
        /// 显示行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvEntity_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (this.showLineNumber)
            {
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                if (e.Info.IsRowIndicator)
                {
                    if (e.RowHandle >= 0)
                    {
                        e.Info.DisplayText = (e.RowHandle + 1).ToString();
                    }
                }
            }
        }

        /// <summary>
        /// 选择行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvEntity_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            RowSelected?.Invoke(sender, e);
        }

        /// <summary>
        /// 显示菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {
            this.menuAdd.Visible = this.showAddMenu;
            this.menuEdit.Visible = this.showEditMenu;
            this.menuDelete.Visible = this.showDeleteMenu;

            this.menuSep1.Visible = this.ShowAddMenu || this.showEditMenu || this.showDeleteMenu;
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuPrint_Click(object sender, EventArgs e)
        {
            this.dgcEntity.ShowRibbonPrintPreview();
        }

        /// <summary>
        /// 导出到Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuExportToExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                XlsxExportOptionsEx op = new XlsxExportOptionsEx();
                op.ExportType = DevExpress.Export.ExportType.DataAware;
                op.CustomizeCell += op_CustomizeCell;
                this.dgvEntity.ExportToXlsx(dialog.FileName, op);
            }
        }

        /// <summary>
        /// 导出Excel格式化事件
        /// </summary>
        /// <param name="e"></param>
        private void op_CustomizeCell(DevExpress.Export.CustomizeCellEventArgs e)
        {
            ExportToExcelCustomCell?.Invoke(e);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAdd_Click(object sender, EventArgs e)
        {
            MenuAdd?.Invoke(sender, e);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuEdit_Click(object sender, EventArgs e)
        {
            MenuEdit?.Invoke(sender, e);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDelete_Click(object sender, EventArgs e)
        {
            MenuDelete?.Invoke(sender, e);
        }
        #endregion //Event

        #region Delegate
        /// <summary>
        /// 行选择事件
        /// </summary>
        [Description("行选择事件")]
        public event Action<object, EventArgs> RowSelected;

        /// <summary>
        /// 导出Excel格式化事件
        /// </summary>
        [Description("导出Excel格式化事件"), Category("菜单")]
        public event Action<DevExpress.Export.CustomizeCellEventArgs> ExportToExcelCustomCell;

        /// <summary>
        /// 新增项
        /// </summary>
        [Description("新增项"), Category("菜单")]
        public event Action<object, EventArgs> MenuAdd;

        /// <summary>
        /// 编辑项
        /// </summary>
        [Description("编辑项"), Category("菜单")]
        public event Action<object, EventArgs> MenuEdit;

        /// <summary>
        /// 删除项
        /// </summary>
        [Description("删除项"), Category("菜单")]
        public event Action<object, EventArgs> MenuDelete;
        #endregion //Delegate

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<T> DataSource
        {
            get
            {
                return this.bsEntity.DataSource as List<T>;
            }
            set
            {
                this.dgvEntity.BeginDataUpdate();
                this.bsEntity.DataSource = value;
                this.dgvEntity.EndDataUpdate();
            }
        }

        /// <summary>
        /// 是否能编辑
        /// </summary>
        [Category("功能"), Description("是否能编辑"), Browsable(true)]
        public bool Editable
        {
            get
            {
                return this.editable;
            }
            set
            {
                this.editable = value;
            }
        }

        /// <summary>
        /// 是否能筛选
        /// </summary>
        [Category("功能"), Description("是否能筛选"), Browsable(true)]
        public bool AllowFilter
        {
            get
            {
                return this.allowFilter;
            }
            set
            {
                this.allowFilter = value;
            }
        }

        /// <summary>
        /// 是否能分组
        /// </summary>
        [Category("功能"), Description("是否能分组"), Browsable(true)]
        public bool AllowGroup
        {
            get
            {
                return this.allowGroup;
            }
            set
            {
                this.allowGroup = value;
            }
        }

        /// <summary>
        /// 是否能排序
        /// </summary>
        [Category("功能"), Description("是否能排序"), Browsable(true)]
        public bool AllowSort
        {
            get
            {
                return this.allowSort;
            }
            set
            {
                this.allowSort = value;
            }
        }

        /// <summary>
        /// 是否启用Master View
        /// </summary>
        [Category("功能"), Description("是否启用Master View"), Browsable(true)]
        public bool EnableMasterView
        {
            get
            {
                return this.enableMasterView;
            }
            set
            {
                this.enableMasterView = value;
            }
        }

        /// <summary>
        /// 是否启用多选
        /// </summary>
        [Category("功能"), Description("是否启用多选"), Browsable(true)]
        public bool EnableMultiSelect
        {
            get
            {
                return enableMultiSelect;
            }

            set
            {
                enableMultiSelect = value;
            }
        }

        /// <summary>
        /// 是否显示行号
        /// </summary>
        [Category("界面"), Description("是否显示行号"), Browsable(true)]
        public bool ShowLineNumber
        {
            get
            {
                return this.showLineNumber;
            }
            set
            {
                this.showLineNumber = value;
            }
        }

        /// <summary>
        /// 是否显示Footer
        /// </summary>
        [Category("界面"), Description("是否显示Footer"), Browsable(true)]
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
        /// 是否显示导航条
        /// </summary>
        [Category("界面"), Description("是否显示导航条"), Browsable(true)]
        public bool ShowNavigator
        {
            get
            {
                return this.showNavigator;
            }
            set
            {
                this.showNavigator = value;
            }
        }

        /// <summary>
        /// 是否显示右键菜单
        /// </summary>
        [Category("界面"), Description("是否显示右键菜单"), Browsable(true)]
        public bool ShowMenu
        {
            get
            {
                return this.showMenu;
            }
            set
            {
                this.showMenu = value;
            }
        }

        /// <summary>
        /// 是否显示新建菜单
        /// </summary>
        [Category("菜单"), Description("是否显示新建菜单"), Browsable(true)]
        public bool ShowAddMenu
        {
            get
            {
                return this.showAddMenu;
            }
            set
            {
                this.showAddMenu = value;
            }
        }

        /// <summary>
        /// 是否显示编辑菜单
        /// </summary>
        [Category("菜单"), Description("是否显示编辑菜单"), Browsable(true)]
        public bool ShowEditMenu
        {
            get
            {
                return showEditMenu;
            }

            set
            {
                showEditMenu = value;
            }
        }

        /// <summary>
        /// 是否显示删除菜单
        /// </summary>
        [Category("菜单"), Description("是否显示删除菜单"), Browsable(true)]
        public bool ShowDeleteMenu
        {
            get
            {
                return showDeleteMenu;
            }

            set
            {
                showDeleteMenu = value;
            }
        }
        #endregion //Property
    }
}
