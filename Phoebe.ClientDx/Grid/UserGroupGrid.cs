using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phoebe.ClientDx
{
    using Poseidon.Winform.Base;
    using Phoebe.Core.DL;

    /// <summary>
    /// 用户组表格控件
    /// </summary>
    public partial class UserGroupGrid : WinIntGrid<UserGroup>
    {
        #region Constructor
        public UserGroupGrid()
        {
            InitializeComponent();
        }
        #endregion //Constructor
    }
}
