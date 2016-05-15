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
    /// 类别编码控件
    /// </summary>
    public partial class CategoryListControl : UserControl
    {
        #region Field
        /// <summary>
        /// 分类列表
        /// </summary>
        private List<Category> categoryList;

        /// <summary>
        /// 选择编码
        /// </summary>
        private string selectedNumber = "";

        /// <summary>
        /// 选择名称
        /// </summary>
        private string selectedName = "";

        /// <summary>
        /// 选择ID
        /// </summary>
        private int selectedId = 0;
        #endregion //Field

        #region Constructor
        public CategoryListControl()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 设置数据源
        /// </summary>
        /// <param name="data">分类数据</param>
        public void SetDataSource(List<Category> data)
        {
            this.categoryList = data;
            UpdateView("");
        }

        /// <summary>
        /// 更新分类列表
        /// </summary>
        /// <param name="prefix">分类前缀</param>
        public void UpdateView(string prefix)
        {
            this.lvCategory.BeginUpdate();

            IEnumerable<Category> categories;
            if (string.IsNullOrEmpty(prefix))
                categories = this.categoryList.OrderBy(r => r.Number);
            else
                categories = this.categoryList.Where(r => r.Number.StartsWith(prefix)).OrderBy(r => r.Number);

            this.lvCategory.Items.Clear();
            foreach (var item in categories)
            {
                ListViewItem lvi = new ListViewItem(item.Number);
                lvi.Tag = item.Id;

                lvi.SubItems.Add(item.Name);

                this.lvCategory.Items.Add(lvi);
            }

            this.lvCategory.EndUpdate();
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 选择类别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvCategory_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (this.lvCategory.SelectedItems.Count != 1)
            {
                this.selectedNumber = "";
                this.selectedName = "";
                this.selectedId = 0;
                return;
            }

            var select = this.lvCategory.SelectedItems[0];
            this.selectedNumber = select.SubItems[0].Text;
            this.selectedName = select.SubItems[1].Text;
            this.selectedId = Convert.ToInt32(select.Tag);

            if (CategoryItemSelected != null)
                CategoryItemSelected(sender, new EventArgs());
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 选择类别ID
        /// </summary>
        [Description("选择类别ID")]
        public int SelectedId
        {
            get
            {
                return this.selectedId;
            }
        }

        /// <summary>
        /// 选择类别编码
        /// </summary>
        [Description("选择类别编码")]
        public string SelectedNumber
        {
            get
            {
                return this.selectedNumber;
            }
        }

        /// <summary>
        /// 选择类别名称
        /// </summary>
        [Description("选择类别名称")]
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
        [Description("选择类别")]
        public event ItemSelectHandle CategoryItemSelected;
        #endregion //Delegate

    }
}
