using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using DevExpress.XtraPrinting;
    using Phoebe.Base;
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 库存盘点表格
    /// </summary>
    public partial class InventoryGrid : UserControl
    {
        #region Constructor
        public InventoryGrid()
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
            this.bsInventory.Clear();
        }

        /// <summary>
        /// 获取选中数据
        /// </summary>
        /// <returns></returns>
        public Inventory GetCurrentSelect()
        {
            int rowIndex = this.dgvInventory.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsInventory.Count)
                return null;
            else
                return this.bsInventory[rowIndex] as Inventory;
        }

        /// <summary>
        /// 更新列表绑定数据显示
        /// </summary>
        public void UpdateBindingData()
        {
            this.bsInventory.ResetBindings(false);
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        public void PrintPriview()
        {
            if (!this.dgcInventory.IsPrintingAvailable)
            {
                MessageUtil.ShowClaim("打印程序出错");
                return;
            }

            // Open the Preview window.
            this.dgvInventory.ShowPrintPreview();
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 打印初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvInventory_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            PrintingSystemBase pb = e.PrintingSystem as PrintingSystemBase;
            pb.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;

            PageHeaderFooter phf = e.Link.PageHeaderFooter as PageHeaderFooter;

            // Clear the PageHeaderFooter's contents.
            phf.Header.Content.Clear();

            // Add custom information to the link's header.
            phf.Header.Content.AddRange(new string[] { "", "库存盘点报表", DateTime.Now.ToShortDateString() });
            phf.Header.Font = new System.Drawing.Font(phf.Header.Font.FontFamily, 16);
            phf.Header.LineAlignment = BrickAlignment.Near;

            phf.Footer.Content.Clear();
            phf.Footer.Content.AddRange(new string[] { "", "", "打印时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") });

            phf.Footer.LineAlignment = BrickAlignment.Far;
        }

        private void dgvInventory_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<Inventory> DataSource
        {
            get
            {
                return this.bsInventory.DataSource as List<Inventory>;
            }
            set
            {
                this.dgvInventory.BeginDataUpdate();
                this.bsInventory.DataSource = value;
                this.dgvInventory.EndDataUpdate();
            }
        }
        #endregion //Property


    }
}
