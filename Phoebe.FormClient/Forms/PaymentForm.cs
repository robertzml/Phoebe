using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using Phoebe.Base;
    using Phoebe.Business;
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 缴费管理窗体
    /// </summary>
    public partial class PaymentForm : BaseForm
    {
        #region Constructor
        public PaymentForm()
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
            var data = BusinessFactory<PaymentBusiness>.Instance.FindAll();
            this.bsPayment.DataSource = data;
        }

        /// <summary>
        /// 检查权限
        /// </summary>
        protected override void CheckPrivilege()
        {
            if (this.currentUser.Rank > 800)
            {
                this.btnDelete.Visible = true;
            }
            else
            {
                this.btnDelete.Visible = false;
            }
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PaymentForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// 格式化数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPayment_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsPayment.Count)
                return;

            if (e.Column.FieldName == "CustomerId")
            {
                var payment = this.bsPayment[rowIndex] as Payment;
                e.DisplayText = payment.Customer.Name;
            }
            else if (e.Column.FieldName == "UserId")
            {
                var payment = this.bsPayment[rowIndex] as Payment;
                e.DisplayText = payment.User.Name;
            }
        }

        /// <summary>
        /// 客户缴费
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ChildFormManage.ShowDialogForm(typeof(PaymentAddForm));
            LoadData();
        }


        /// <summary>
        /// 删除缴费
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvPayment.SelectedRowsCount == 0)
            {
                MessageUtil.ShowClaim("未选中记录");
                return;
            }

            if (MessageUtil.ConfirmYesNo("是否确认删除选中缴费记录") == DialogResult.Yes)
            {
                int rowIndex = this.dgvPayment.GetFocusedDataSourceRowIndex();
                if (rowIndex < 0 || rowIndex >= this.bsPayment.Count)
                    return;

                var payment = this.bsPayment[rowIndex] as Payment;

                ErrorCode result = BusinessFactory<PaymentBusiness>.Instance.Delete(payment);
                if (result == ErrorCode.Success)
                {
                    MessageUtil.ShowInfo("删除缴费成功");
                }
                else
                {
                    MessageUtil.ShowWarning("删除缴费失败：" + result.DisplayName());
                }

                LoadData();
            }
        }
        #endregion //Event
    }
}
