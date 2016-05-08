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
    /// 分类窗体
    /// </summary>
    public partial class CategoryForm : BaseForm
    {
        #region Constructor
        public CategoryForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        private void LoadTree()
        {
            var categories = BusinessFactory<CategoryBusiness>.Instance.FindAll();

            this.tvCategory.BeginUpdate();
            this.tvCategory.Nodes.Clear();

            TreeNode top = new TreeNode
            {
                Name = "0",
                Text = "分类",
                Tag = 0
            };
            this.tvCategory.Nodes.Add(top);

            var firstCategory = categories.Where(r => r.Hierarchy == 1).OrderBy(r => r.Number);

            foreach (var first in firstCategory)
            {
                TreeNode node = new TreeNode();
                node.Name = first.Id.ToString();
                node.Text = first.Name;
                node.Tag = 1;

                top.Nodes.Add(node);

                LoadChildNode(first.Id, 2, node);
            }

            this.tvCategory.Nodes[0].Expand();
            foreach (TreeNode item in this.tvCategory.Nodes[0].Nodes)
            {
                item.Expand();
            }
            this.tvCategory.EndUpdate();
        }

        /// <summary>
        /// 载入子节点
        /// </summary>
        /// <param name="parentId">上级ID</param>
        /// <param name="level">级别</param>
        /// <param name="parentNode">上级节点</param>
        private void LoadChildNode(int parentId, int level, TreeNode parentNode)
        {
            var children = BusinessFactory<CategoryBusiness>.Instance.GetChildCategory(parentId);

            foreach (var item in children)
            {
                TreeNode node = new TreeNode();
                node.Name = item.Id.ToString();
                node.Text = item.Name;
                node.Tag = level;

                parentNode.Nodes.Add(node);

            }

            return;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CategoryForm_Load(object sender, EventArgs e)
        {
            LoadTree();
        }

        /// <summary>
        /// 添加一级分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFirst_Click(object sender, EventArgs e)
        {
            ChildFormManage.ShowDialogForm(typeof(CategoryAddForm), new object[] { 1 });
            LoadTree();
        }

        /// <summary>
        /// 添加二级分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddSecond_Click(object sender, EventArgs e)
        {
            ChildFormManage.ShowDialogForm(typeof(CategoryAddForm), new object[] { 2 });
            LoadTree();
        }
        #endregion //Event
    }
}
