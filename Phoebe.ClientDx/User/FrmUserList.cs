using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phoebe.ClientDx
{
    using Poseidon.Base.Framework;
    using Poseidon.Winform.Base;
    using Phoebe.Core.BL;
    using Phoebe.Core.DL;

    /// <summary>
    /// 用户列表窗体
    /// </summary>
    public partial class FrmUserList : BaseMdiForm
    {
        #region Constructor
        public FrmUserList()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function       
        protected override void InitForm()
        {
            this.userGrid.Init();
            LoadUsers();
            base.InitForm();
        }

        /// <summary>
        /// 载入用户
        /// </summary>
        private void LoadUsers()
        {
            var data = BusinessFactory<UserBusiness>.Instance.FindAll(this.currentUser.IsRoot);
            this.userGrid.DataSource = data;
        }
        #endregion //Function
    }
}
