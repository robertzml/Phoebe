using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Phoebe.FormClient
{
    using Phoebe.Base;
    using Phoebe.Business;
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 客户综合窗体
    /// </summary>
    public partial class CustomerDashboardForm : BaseForm
    {
        #region Field
        /// <summary>
        /// 选中客户
        /// </summary>
        private Customer selectCustomer;

        /// <summary>
        /// 客户列表，缓存页面使用
        /// </summary>
        private List<Customer> customerList;

        /// <summary>
        /// 当前激活控件
        /// </summary>
        private UscBaseCustomer dashboard;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 客户综合窗体
        /// </summary>
        public CustomerDashboardForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 客户变更
        /// </summary>
        /// <param name="customer">选择客户</param>
        private void CustomerChange(Customer customer)
        {
            this.Cursor = Cursors.WaitCursor;

            this.lblCustomer.Text = "当前客户：" + customer.Name;

            if (this.dashboard == null)
            {
                this.dashboard = new UscCustomerInfo();
                ChildFormManage.LoadContentControl(this.plContent, this.dashboard);
                this.dashboard.UpdateControl(customer);
            }
            else
            {
                ChildFormManage.LoadContentControl(this.plContent, this.dashboard);
                this.dashboard.UpdateControl(customer);
            }

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 选择组件
        /// </summary>
        /// <param name="tag">类名</param>
        private void SelectDashboard(string tag)
        {
            this.Cursor = Cursors.WaitCursor;

            this.dashboard = (UscBaseCustomer)Activator.CreateInstance(Type.GetType(Assembly.GetExecutingAssembly().GetName().Name + "." + tag));
            ChildFormManage.LoadContentControl(this.plContent, this.dashboard);
            this.dashboard.UpdateControl(this.selectCustomer);

            this.Cursor = Cursors.Default;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerDashboardForm_Load(object sender, EventArgs e)
        {
            Cache.Instance.Add("CurrentCustomer", null);

            this.customerList = BusinessFactory<CustomerBusiness>.Instance.FindAll();
            this.clcCustomer.SetDataSource(customerList);
        }

        /// <summary>
        /// 输入客户代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCustomerNumber_EditValueChanged(object sender, EventArgs e)
        {
            string number = this.txtCustomerNumber.EditValue.ToString();
            this.clcCustomer.UpdateView(number);

            var customer = BusinessFactory<CustomerBusiness>.Instance.GetByNumber(number);
            if (customer != null)
            {
                this.selectCustomer = customer;
                this.txtCustomerName.Text = customer.Name;
            }
            else
            {
                this.selectCustomer = null;
                this.txtCustomerName.Text = "";
            }
        }

        /// <summary>
        /// 确定客户选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.selectCustomer == null)
            {
                MessageBox.Show("请选择客户", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CustomerChange(this.selectCustomer);
        }

        /// <summary>
        /// 客户选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clcCustomer_CustomerItemSelected(object sender, EventArgs e)
        {
            this.txtCustomerNumber.EditValueChanged -= txtCustomerNumber_EditValueChanged;

            this.txtCustomerNumber.Text = this.clcCustomer.SelectedNumber;
            this.txtCustomerName.Text = this.clcCustomer.SelectedName;

            this.txtCustomerNumber.EditValueChanged += txtCustomerNumber_EditValueChanged;

            int customerId = this.clcCustomer.SelectedId;
            var customer = this.customerList.SingleOrDefault(r => r.Id == customerId);
            this.selectCustomer = customer;

            CustomerChange(customer);
        }

        /// <summary>
        /// 项目选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void accMain_ElementClick(object sender, DevExpress.XtraBars.Navigation.ElementClickEventArgs e)
        {
            if (e.Element.Style == DevExpress.XtraBars.Navigation.ElementStyle.Group || e.Element.Tag == null)
                return;

            if (this.selectCustomer == null)
            {
                MessageBox.Show("请先选择客户", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SelectDashboard(e.Element.Tag.ToString());
            }
        }
        #endregion //Event
    }
}
