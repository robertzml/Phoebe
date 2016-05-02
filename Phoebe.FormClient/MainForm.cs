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
using Phoebe.Model;

namespace Phoebe.FormClient
{
    public partial class MainForm : BaseForm
    {
        #region Field
        /// <summary>
        /// 当前用户
        /// </summary>
        private User currentUser;
        #endregion //Field

        #region Constructor
        public MainForm(User user)
        {
            InitializeComponent();
            this.currentUser = user;
        }
        #endregion //Constructor
    }
}
