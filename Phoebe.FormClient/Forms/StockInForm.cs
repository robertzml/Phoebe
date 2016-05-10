using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using Phoebe.Base;
    using Phoebe.Business;
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 货品入库窗体
    /// </summary>
    public partial class StockInForm : BaseForm
    {
        #region Constructor
        public StockInForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor


        #region Event
        private void StockInForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 新建入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbNew_Click(object sender, EventArgs e)
        {
            ChildFormManage.LoadContentControl(this.plBody, typeof(StockInAddControl), new object[]{ this.currentUser });         
        }
        
        /// <summary>
        /// 保存入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbSave_Click(object sender, EventArgs e)
        {

        }
        #endregion //Event
    }
}
