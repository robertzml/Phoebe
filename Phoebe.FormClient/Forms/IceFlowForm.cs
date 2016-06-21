using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// 冰块流水窗体
    /// </summary>
    public partial class IceFlowForm : BaseForm
    {
        #region Constructor
        public IceFlowForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Constructor
        private void IceFlowForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 整冰入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCompleteStockIn_Click(object sender, EventArgs e)
        {
            ChildFormManage.ShowDialogForm(typeof(IceStockForm), new object[] { IceFlowType.CompleteStockIn, IceType.Complete });
        }
        #endregion //Constructor
    }
}
