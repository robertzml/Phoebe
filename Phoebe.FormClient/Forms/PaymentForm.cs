using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using DevExpress.XtraReports.UI;
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
            this.pyList.DataSource = data;
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
            var payment = this.pyList.GetCurrentSelect();
            if (payment == null)
            {
                MessageUtil.ShowClaim("未选中记录");
                return;
            }

            if (MessageUtil.ConfirmYesNo("是否确认删除选中缴费记录") == DialogResult.Yes)
            {
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

        /// <summary>
        /// 打印收据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            var payment = this.pyList.GetCurrentSelect();
            if (payment == null)
            {
                MessageUtil.ShowClaim("未选中记录");
                return;
            }

            var model = ModelTranslate.PaymentToReport(payment);

            Report.Payment report = new Report.Payment(model);

            ReportPrintTool tool = new ReportPrintTool(report);
            tool.ShowPreview();
        }
        #endregion //Event
    }
}
