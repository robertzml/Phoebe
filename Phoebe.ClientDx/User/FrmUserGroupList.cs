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
    /// 用户组列表窗体
    /// </summary>
    public partial class FrmUserGroupList : BaseMdiForm
    {
        #region Constructor
        public FrmUserGroupList()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        protected override void InitForm()
        {
            var data = BusinessFactory<UserGroupBusiness>.Instance.FindAll().ToList();
            this.userGroupGrid.DataSource = data;

            base.InitForm();
        }
        #endregion //Function
    }
}
