using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using Phoebe.Base;
    using Phoebe.Business;
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 合同列表窗体
    /// </summary>
    public partial class ContractForm : BaseForm
    {
        #region Constructor
        public ContractForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 载入数据
        /// </summary>
        private void LoadData()
        {
            this.ctList.DataSource = BusinessFactory<ContractBusiness>.Instance.FindAll();
        }

        /// <summary>
        /// 检查权限
        /// </summary>
        protected override void CheckPrivilege()
        {
            if (this.currentUser.Rank > 800)
            {
                this.btnDelete.Visible = true;
                this.btnForceDelete.Visible = true;
            }
            else
            {
                this.btnDelete.Visible = false;
                this.btnForceDelete.Visible = false;
            }
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContractForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// 添加合同
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ChildFormManage.ShowDialogForm(typeof(ContractAddForm));
            LoadData();
        }

        /// <summary>
        /// 编辑合同
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            var contract = this.ctList.GetCurrentSelect();
            if (contract == null)
                return;

            ChildFormManage.ShowDialogForm(typeof(ContractEditForm), new object[] { contract.Id });

            LoadData();
        }

        /// <summary>
        /// 删除合同
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var contract = this.ctList.GetCurrentSelect();
            if (contract == null)
            {
                MessageUtil.ShowClaim("未选中记录");
                return;
            }

            if (MessageUtil.ConfirmYesNo("是否确认删除选中合同") == DialogResult.Yes)
            {
                ErrorCode result = BusinessFactory<ContractBusiness>.Instance.Delete(contract);
                if (result == ErrorCode.Success)
                {
                    MessageUtil.ShowInfo("删除合同成功");
                }
                else
                {
                    MessageUtil.ShowWarning("删除合同失败：" + result.DisplayName());
                }

                LoadData();
            }
        }

        /// <summary>
        /// 强制删除合同
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnForceDelete_Click(object sender, EventArgs e)
        {
            var contract = this.ctList.GetCurrentSelect();
            if (contract == null)
            {
                MessageUtil.ShowClaim("未选中记录");
                return;
            }

            if (MessageUtil.ConfirmYesNo("是否确认强制删除选中合同") == DialogResult.Yes)
            {
                ErrorCode result = BusinessFactory<ContractBusiness>.Instance.ForceDelete(contract);
                if (result == ErrorCode.Success)
                {
                    MessageUtil.ShowInfo("删除合同成功");
                }
                else
                {
                    MessageUtil.ShowWarning("删除合同失败：" + result.DisplayName());
                }

                LoadData();
            }
        }
        #endregion //Event
    }
}
