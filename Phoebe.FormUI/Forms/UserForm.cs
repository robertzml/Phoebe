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
using Phoebe.Common;
using Phoebe.Model;

namespace Phoebe.FormUI
{
    public partial class UserForm : Form
    {
        #region Field
        private User currentUser;

        private List<User> userData;

        private UserBusiness userBusiness;
        #endregion //Field

        #region Constructor
        public UserForm(User user)
        {
            InitializeComponent();
            this.currentUser = user;
        }
        #endregion //Constructor

        #region Function
        private void InitData()
        {
            this.userBusiness = new UserBusiness();            
            this.userData = this.userBusiness.GetUser(this.currentUser.UserGroupID == UserBusiness.RootGroupID);
        }
        private void InitControl()
        {
            this.userBindingSource.DataSource = this.userData;
        }
        #endregion //Function

        #region Event
        private void UserForm_Load(object sender, EventArgs e)
        {
            InitData();
            InitControl();
        }

        private void userDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < this.userBindingSource.Count)
            {
                var user = (User)this.userBindingSource[e.RowIndex];

                var grid = this.userDataGridView;
                if (user.UserGroup != null)
                {
                    grid.Rows[e.RowIndex].Cells[this.dataGridViewColumnUserGroup.Index].Value = user.UserGroup.Title;
                }
            }
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            UserAddForm form = new UserAddForm();
            form.ShowDialog();
        }
        #endregion //Event

    }
}
