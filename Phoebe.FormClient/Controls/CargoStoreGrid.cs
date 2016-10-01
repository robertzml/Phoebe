using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using DevExpress.XtraPrinting;
    using Phoebe.Base;
    using Phoebe.Model;

    /// <summary>
    /// 货品库存表格控件
    /// </summary>
    public partial class CargoStoreGrid : UserControl
    {
        #region Field
        /// <summary>
        /// 库存日期
        /// </summary>
        private DateTime storageDate;
        #endregion //Field

        #region Constructor
        public CargoStoreGrid()
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
        public CargoStore GetCurrentSelect()
        {
            int rowIndex = this.dgvCargo.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsCargo.Count)
                return null;
            else
                return this.bsCargo[rowIndex] as CargoStore;
        }

        /// <summary>
        /// 更新列表绑定数据显示
        /// </summary>
        public void UpdateBindingData()
        {
            this.bsCargo.ResetBindings(false);
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        public void PrintPriview()
        {
            if (!this.dgcCargo.IsPrintingAvailable)
            {
                MessageUtil.ShowClaim("打印程序出错");
                return;
            }

            // Open the Preview window.
            this.dgvCargo.ShowPrintPreview();
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 打印初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCargo_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            PrintingSystemBase pb = e.PrintingSystem as PrintingSystemBase;
            pb.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;

            PageHeaderFooter phf = e.Link.PageHeaderFooter as PageHeaderFooter;

            // Clear the PageHeaderFooter's contents.
            phf.Header.Content.Clear();

            // Add custom information to the link's header.
            phf.Header.Content.AddRange(new string[] { "", "货品报表", this.storageDate.ToShortDateString() });
            phf.Header.Font = new System.Drawing.Font(phf.Header.Font.FontFamily, 16);
            phf.Header.LineAlignment = BrickAlignment.Near;

            phf.Footer.Content.Clear();
            phf.Footer.Content.AddRange(new string[] { "", "", "打印时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") });

            phf.Footer.LineAlignment = BrickAlignment.Far;
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<CargoStore> DataSource
        {
            get
            {
                return this.bsCargo.DataSource as List<CargoStore>;
            }
            set
            {
                this.dgvCargo.BeginDataUpdate();
                this.bsCargo.DataSource = value;
                this.dgvCargo.EndDataUpdate();
            }
        }

        /// <summary>
        /// 库存日期
        /// </summary>
        public DateTime StorageDate
        {
            get
            {
                return this.storageDate;
            }
            set
            {
                this.storageDate = value;
            }
        }
        #endregion //Property
    }
}
