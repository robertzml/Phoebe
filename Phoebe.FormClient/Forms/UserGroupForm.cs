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
using Phoebe.Business;
using Phoebe.Common;
using Phoebe.Model;

namespace Phoebe.FormClient
{
    /// <summary>
    /// 用户组窗体
    /// </summary>
    public partial class UserGroupForm : BaseForm
    {
        public UserGroupForm()
        {            
            InitializeComponent();
        }

        private void UserGroupForm_Load(object sender, EventArgs e)
        {
            UserBusiness userBusiness = new UserBusiness();
            this.bsUserGroup.DataSource = userBusiness.GetUserGroup(true);
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;

            int status = Convert.ToInt32(gridView1.GetListSourceRowCellValue(rowIndex, "colStatus"));
            
            if (e.Column.FieldName != "colSt")
                return;
            else
                e.Value = ((EntityStatus)status).DisplayName();
        }
    }
}
