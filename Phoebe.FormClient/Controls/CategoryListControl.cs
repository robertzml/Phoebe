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
        public void SetSource(List<Category> data)
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
    }
}
