using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phoebe.Business;
using Phoebe.Model;

namespace Phoebe.FormUI
{
    public partial class UserGroupForm : Form
    {
        #region Field
        private User currentUser;

        private List<UserGroup> userGroupData;

        private UserBusiness userBusiness;
        #endregion //Field

        #region Constructor
        public UserGroupForm(User user)
        {
            InitializeComponent();
            this.currentUser = user;
        }
        #endregion //Constructor

        #region Function
        private void InitData()
        {
            this.userBusiness = new UserBusiness();
            this.userGroupData = this.userBusiness.GetUserGroup(this.currentUser.UserGroupID == UserBusiness.RootGroupID);
        }
        private void InitControl()
        {
            this.userGroupBindingSource.DataSource = this.userGroupData;
        }
        #endregion //Function

        #region Event
        private void UserGroupForm_Load(object sender, EventArgs e)
        {
            InitData();
            InitControl();
        }
        #endregion //Event
    }
}
