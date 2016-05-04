using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phoebe.Base;
using Phoebe.Common;
using Phoebe.Model;

namespace Phoebe.FormClient
{
    public partial class MainForm : BaseForm
    {
        #region Field
       
        #endregion //Field

        #region Constructor
        public MainForm()
        {
            InitializeComponent();            
        }
        #endregion //Constructor

        #region Function
        private void InitControl()
        {
            this.barUserName.Caption = this.currentUser.Name;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            InitControl();
        }


        #region Menu Event
        /// <summary>
        /// 用户管理 - 用户组列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuUserGroupList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserGroupForm form = new UserGroupForm();
            form.MdiParent = this;
            form.Show();
        }
        #endregion //Menu Event
        #endregion //Event
    }
}
