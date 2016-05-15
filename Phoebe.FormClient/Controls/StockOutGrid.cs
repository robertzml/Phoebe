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
    using Phoebe.Base;
    using Phoebe.Business;
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 出库货品列表
    /// </summary>
    public partial class StockOutGrid : UserControl
    {
        #region Field
        /// <summary>
        /// 是否能编辑
        /// </summary>
        private bool canEdit = true;

        /// <summary>
        /// 是否显示Footer
        /// </summary>
        private bool showFooter = true;
        #endregion //Field

        #region Constructor
        public StockOutGrid()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Event
        /// <summary>
        /// 控件载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockOutGrid_Load(object sender, EventArgs e)
        {
            this.dgvStockOut.OptionsView.ShowFooter = this.showFooter;
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 是否能编辑
        /// </summary>
        public bool CanEdit
        {
            get
            {
                return this.canEdit;
            }
            set
            {
                this.canEdit = value;
            }
        }

        /// <summary>
        /// 是否显示Footer
        /// </summary>
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
