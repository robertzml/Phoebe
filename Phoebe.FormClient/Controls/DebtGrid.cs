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
    /// 实时欠费表格控件
    /// </summary>
    public partial class DebtGrid : UserControl
    {
        #region Constructor
        public DebtGrid()
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
            this.bsDebt.Clear();
        }

        /// <summary>
        /// 获取选中数据
        /// </summary>
        /// <returns></returns>
        public Debt GetCurrentSelect()
        {
            int rowIndex = this.dgvDebt.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsDebt.Count)
                return null;
            else
                return this.bsDebt[rowIndex] as Debt;
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        public void PrintPriview()
        {
            if (!this.dgcDebt.IsPrintingAvailable)
            {
                MessageUtil.ShowClaim("打印程序出错");
                return;
            }

            // Open the Preview window.
            this.dgvDebt.ShowPrintPreview();
        }
        #endregion //Method

        #region Event
        private void dgvDebt_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            PrintingSystemBase pb = e.PrintingSystem as PrintingSystemBase;
            pb.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;

            PageHeaderFooter phf = e.Link.PageHeaderFooter as PageHeaderFooter;

            // Clear the PageHeaderFooter's contents.
            phf.Header.Content.Clear();

            // Add custom information to the link's header.
            phf.Header.Content.AddRange(new string[] { "", "实时欠费报表" });
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
        public List<Debt> DataSource
        {
            get
            {
                return this.bsDebt.DataSource as List<Debt>;
            }
            set
            {
                this.dgvDebt.BeginDataUpdate();
                this.bsDebt.DataSource = value;
                this.dgvDebt.EndDataUpdate();
            }
        }
        #endregion //Property
    }
}
