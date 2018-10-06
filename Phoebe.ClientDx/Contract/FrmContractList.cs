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
    /// 合同列表窗体
    /// </summary>
    public partial class FrmContractList : BaseMdiForm
    {
        #region Constructor
        public FrmContractList()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        protected override void InitForm()
        {
            this.contractGrid.Init();

            LoadData();
            base.InitForm();
        }

        /// <summary>
        /// 检查权限
        /// </summary>
        protected override void CheckPrivilege()
        {
            var u = this.currentUser as PhoebeLoginUser;
            if (u.Rank > 800)
            {
                this.btnDelete.Visible = true;
                this.btnForceDelete.Visible = true;
            }
            else
            {
                this.btnDelete.Visible = false;
                this.btnForceDelete.Visible = false;
            }
            base.CheckPrivilege();
        }

        /// <summary>
        /// 载入数据
        /// </summary>
        private void LoadData()
        {
            var data = BusinessFactory<ContractBusiness>.Instance.FindAll().ToList();
            this.contractGrid.DataSource = data;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 添加合同
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ChildFormManage.ShowDialogForm(typeof(FrmContractAdd));
            LoadData();
        }

        /// <summary>
        /// 编辑合同
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            var data = this.contractGrid.GetCurrentSelect();
            if (data == null)
                return;

            ChildFormManage.ShowDialogForm(typeof(FrmContractEdit), new object[] { data.Id });
            LoadData();
        }

        /// <summary>
        /// 删除合同
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var data = this.contractGrid.GetCurrentSelect();
            if (data == null)
                return;

            if (MessageUtil.ConfirmYesNo("是否确认删除选中合同") == DialogResult.Yes)
            {
                bool result = BusinessFactory<ContractBusiness>.Instance.Delete(data);
                if (result)
                {
                    MessageUtil.ShowInfo("删除合同成功");
                }
                else
                {
                    MessageUtil.ShowWarning("删除合同失败");
                }

                LoadData();
            }
        }
        #endregion //Event
    }
}
