using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using Phoebe.Base;
    using Phoebe.Business;
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 出入库报表窗体
    /// </summary>
    public partial class StockFlowReportForm : BaseForm
    {
        #region Constructor
        public StockFlowReportForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor


        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockFlowReportForm_Load(object sender, EventArgs e)
        {
            this.bsCustomer.DataSource = BusinessFactory<CustomerBusiness>.Instance.FindAll();
            this.lkuCustomer.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(EventUtil.LkuCustomer_CustomDisplayText);

            this.bsCategory.DataSource = BusinessFactory<CategoryBusiness>.Instance.GetAll();
            this.lkuCategory.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(EventUtil.LkuCategory_CustomDisplayText);

            this.dpFrom.DateTime = DateTime.Now.AddDays(-7).Date;
            this.dpTo.DateTime = DateTime.Now.Date;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!this.chkIn.Checked && !this.chkOut.Checked)
            {
                MessageUtil.ShowClaim("请选择类型");
                return;
            }

            if (this.dpFrom.DateTime > this.dpTo.DateTime)
            {
                MessageUtil.ShowClaim("开始日期不能晚于结束日期");
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            List<StockFlow> data = new List<StockFlow>();

            if (this.chkIn.Checked)
            {
                List<StockFlow> inFlow;
                if (this.lkuCustomer.EditValue == null)
                {
                    inFlow = BusinessFactory<StoreBusiness>.Instance.GetFlowIn(this.dpFrom.DateTime.Date, this.dpTo.DateTime.Date, 0);
                }
                else
                {
                    inFlow = BusinessFactory<StoreBusiness>.Instance.GetFlowIn(this.dpFrom.DateTime.Date, this.dpTo.DateTime.Date, (int)this.lkuCustomer.EditValue);
                }

                data.AddRange(inFlow);
            }

            if (this.chkOut.Checked)
            {
                List<StockFlow> outFlow;
                if (this.lkuCustomer.EditValue == null)
                {
                    outFlow = BusinessFactory<StoreBusiness>.Instance.GetFlowOut(this.dpFrom.DateTime.Date, this.dpTo.DateTime.Date, 0);
                }
                else
                {
                    outFlow = BusinessFactory<StoreBusiness>.Instance.GetFlowOut(this.dpFrom.DateTime.Date, this.dpTo.DateTime.Date, (int)this.lkuCustomer.EditValue);
                }

                data.AddRange(outFlow);
            }

            //filter category
            if (this.lkuCategory.EditValue != null)
            {
                var select = this.lkuCategory.GetSelectedDataRow() as Category;
                var category = BusinessFactory<CategoryBusiness>.Instance.GetByParent(select.Number);

                data = data.Where(r => category.Select(s => s.Id).Contains(r.CategoryId)).ToList();
            }

            data = data.OrderBy(r => r.FlowDate).ToList();

            this.sfgList.DataSource = data;

            this.txtInCount.Text = data.Where(r => r.Type == StockFlowType.StockIn).Sum(r => r.FlowCount).ToString();
            this.txtInWeight.Text = data.Where(r => r.Type == StockFlowType.StockIn).Sum(r => r.FlowWeight).ToString("f3") + " 吨";
            this.txtOutCount.Text = data.Where(r => r.Type == StockFlowType.StockOut).Sum(r => r.FlowCount).ToString();
            this.txtOutWeight.Text = data.Where(r => r.Type == StockFlowType.StockOut).Sum(r => r.FlowWeight).ToString("f3") + " 吨";

            this.Cursor = Cursors.Default;
        }
        #endregion //Event
    }
}
