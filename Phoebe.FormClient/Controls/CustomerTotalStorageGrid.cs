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
    using Phoebe.Model;

    /// <summary>
    /// 货品库存汇总表格控件
    /// </summary>
    public partial class CustomerTotalStorageGrid : UserControl
    {
        #region Field
        /// <summary>
        /// 库存日期
        /// </summary>
        private DateTime storageDate;
        #endregion //Field

        #region Constructor
        public CustomerTotalStorageGrid()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method
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
        private void dgvStorage_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            PrintingSystemBase pb = e.PrintingSystem as PrintingSystemBase;
            pb.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;

            PageHeaderFooter phf = e.Link.PageHeaderFooter as PageHeaderFooter;

            // Clear the PageHeaderFooter's contents.
            phf.Header.Content.Clear();

            // Add custom information to the link's header.
            phf.Header.Content.AddRange(new string[] { "", "海安润思达食品有限公司客户库存实时表", this.storageDate.ToShortDateString() });
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
        public List<CustomerTotalStorage> DataSource
        {
            get
            {
                return this.bsStorage.DataSource as List<CustomerTotalStorage>;
            }
            set
            {
                this.dgvStorage.BeginDataUpdate();
                this.bsStorage.DataSource = value;
                this.dgvStorage.EndDataUpdate();
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
