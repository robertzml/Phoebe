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
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 库存记录表格
    /// </summary>
    public partial class StorageGrid : UserControl
    {
        #region Constructor
        public StorageGrid()
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
            this.bsStorage.Clear();
        }

        /// <summary>
        /// 获取选中数据
        /// </summary>
        /// <returns></returns>
        public Storage GetCurrentSelect()
        {
            int rowIndex = this.dgvStorage.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsStorage.Count)
                return null;
            else
                return this.bsStorage[rowIndex] as Storage;
        }

        /// <summary>
        /// 更新列表绑定数据显示
        /// </summary>
        public void UpdateBindingData()
        {
            this.bsStorage.ResetBindings(false);
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        public void PrintPriview()
        {
            if (!this.dgcStorage.IsPrintingAvailable)
            {
                MessageUtil.ShowClaim("打印程序出错");
                return;
            }

            // Open the Preview window.
            this.dgvStorage.ShowPrintPreview();
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 打印初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStorage_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            PrintingSystemBase pb = e.PrintingSystem as PrintingSystemBase;
            pb.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;

            PageHeaderFooter phf = e.Link.PageHeaderFooter as PageHeaderFooter;

            // Clear the PageHeaderFooter's contents.
            phf.Header.Content.Clear();

            // Add custom information to the link's header.
            phf.Header.Content.AddRange(new string[] { "", "库存日报表", DateTime.Now.ToShortDateString() });
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
        public List<Storage> DataSource
        {
            get
            {
                return this.bsStorage.DataSource as List<Storage>;
            }
            set
            {
                this.dgvStorage.BeginDataUpdate();
                this.bsStorage.DataSource = value;
                this.dgvStorage.EndDataUpdate();
            }
        }
        #endregion //Property
    }
}
