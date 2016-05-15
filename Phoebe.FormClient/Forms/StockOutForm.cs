using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    /// 货品出库窗体
    /// </summary>
    public partial class StockOutForm : BaseForm
    {
        #region Field
        private StockOutAddControl stockOutAdd;
        #endregion //Field

        #region Constructor
        public StockOutForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockOutForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 新建出库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbNew_Click(object sender, EventArgs e)
        {
            this.stockOutAdd = new StockOutAddControl(this.currentUser);
            ChildFormManage.LoadContentControl(this.plBody, this.stockOutAdd);
        }
        #endregion //Event
    }
}
