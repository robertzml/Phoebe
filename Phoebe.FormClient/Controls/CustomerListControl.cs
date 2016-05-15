using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using DevExpress.XtraEditors;
    using Phoebe.Base;
    using Phoebe.Business;
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 客户列表控件
    /// </summary>
    public partial class CustomerListControl : UserControl
    {
        #region Field
        /// <summary>
        /// 客户列表
        /// </summary>
        private List<Customer> customerList = new List<Customer>();

        /// <summary>
        /// 选择编码
        /// </summary>
        private string selectedNumber = "";

        /// <summary>
        /// 选择姓名
        /// </summary>
        private string selectedName = "";

        /// <summary>
        /// 选择ID
        /// </summary>
        private int selectedId = 0;
        #endregion //Field

        #region Constructor
        public CustomerListControl()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 设置数据源
        /// </summary>
        /// <param name="data">客户数据</param>
        public void SetSource(List<Customer> data)
        {
            this.customerList = data;
            UpdateView("");
        }

        /// <summary>
        /// 更新客户列表
        /// </summary>
        /// <param name="prefix">客户编码前缀</param>
        /// <returns></returns>
        public void UpdateView(string prefix)
        {
            this.lvCustomer.BeginUpdate();

            IEnumerable<Customer> customers;
            if (string.IsNullOrEmpty(prefix))
                customers = customerList.OrderBy(r => r.Number);
            else
                customers = customerList.Where(r => r.Number.StartsWith(prefix)).OrderBy(r => r.Number);

            this.lvCustomer.Items.Clear();
            foreach (var item in customers)
            {
                ListViewItem lvi = new ListViewItem(item.Number);
                lvi.Tag = item.Id;

                lvi.SubItems.Add(item.Name);

                this.lvCustomer.Items.Add(lvi);
            }

            this.lvCustomer.EndUpdate();
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 控件载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerListControl_Load(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// 选择客户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvCustomer.SelectedItems.Count != 1)
            {
                this.selectedNumber = "";
                this.selectedName = "";
                this.selectedId = 0;
                return;
            }

            var select = this.lvCustomer.SelectedItems[0];
            this.selectedNumber = select.SubItems[0].Text;
            this.selectedName = select.SubItems[1].Text;
            this.selectedId = Convert.ToInt32(select.Tag);

            if (CustomerItemSelected != null)
                CustomerItemSelected(sender, new EventArgs());//把按钮自身作为参数传递            
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 选择客户ID
        /// </summary>
        public int SelectedId
        {
            get
            {
                return this.selectedId;
            }
        }

        /// <summary>
        /// 选择客户编码
        /// </summary>
        public string SelectedNumber
        {
            get
            {
                return this.selectedNumber;
            }
        }

        /// <summary>
        /// 选择客户姓名
        /// </summary>
        public string SelectedName
        {
            get
            {
                return this.selectedName;
            }
        }
        #endregion //Property

        #region Delegate
        //定义委托
        public delegate void ItemSelectHandle(object sender, EventArgs e);

        //定义事件
        [Description("选择客户")]
        public event ItemSelectHandle CustomerItemSelected;
        #endregion //Delegate
    }
}
