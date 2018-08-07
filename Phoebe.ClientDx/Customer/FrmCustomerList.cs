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
    using Phoebe.Base;
    using Phoebe.Core.BL;
    using Phoebe.Core.DL;

    /// <summary>
    /// 客户列表窗体
    /// </summary>
    public partial class FrmCustomerList : BaseMdiForm
    {
        #region Constructor
        public FrmCustomerList()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        protected override void InitForm()
        {
            LoadData();
            base.InitForm();
        }

        protected override void CheckPrivilege()
        {
            var u = this.currentUser as PhoebeLoginUser;
            if (u.Rank > 800)
            {
                this.btnDelete.Visible = true;
            }
            else
            {
                this.btnDelete.Visible = false;
            }
            base.CheckPrivilege();
        }

        /// <summary>
        /// 载入数据
        /// </summary>
        private void LoadData()
        {
            var data = BusinessFactory<CustomerBusiness>.Instance.FindAll();
            this.customerGrid.DataSource = data.ToList();
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 添加客户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ChildFormManage.ShowDialogForm(typeof(FrmCustomerAdd));
            LoadData();
        }

        /// <summary>
        /// 编辑客户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            var data = this.customerGrid.GetCurrentSelect();
            if (data == null)
                return;

            ChildFormManage.ShowDialogForm(typeof(FrmCustomerEdit), new object[] { data.Id });
            LoadData();
        }
        #endregion //Event
    }
}
