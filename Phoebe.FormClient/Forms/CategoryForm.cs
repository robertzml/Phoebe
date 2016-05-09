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
        /// <summary>
        /// 载入分类树
        /// </summary>
        private void LoadTree()
        {
            this.tvCategory.BeginUpdate();
            this.tvCategory.Nodes.Clear();

            TreeNode top = new TreeNode
            {
                Name = "0",
                Text = "分类",
                Tag = 0
            };
            this.tvCategory.Nodes.Add(top);

            var firstCategory = BusinessFactory<CategoryBusiness>.Instance.GetFirstCategory().OrderBy(r => r.Number);

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
            var children = BusinessFactory<CategoryBusiness>.Instance.GetChildCategory(parentId).OrderBy(r => r.Number);

            foreach (var item in children)
            {
                TreeNode node = new TreeNode();
                node.Name = item.Id.ToString();
                node.Text = item.Name;
                node.Tag = level;

                parentNode.Nodes.Add(node);

                if (level == 2)
                    LoadChildNode(item.Id, 3, node);
            }

            return;
        }

        private void SetControl(Category category)
        {
            this.txtName.Text = category.Name.ToString();
            this.txtHierarchy.Text = category.Hierarchy.ToString();
            this.txtNumber.Text = category.Number.ToString();
            this.txtRemark.Text = category.Remark.ToString();
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
        /// 选择分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvCategory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = e.Node;
            if ((int)node.Tag == 0)
                return;

            int id = Convert.ToInt32(node.Name);

            var category = BusinessFactory<CategoryBusiness>.Instance.FindById(id);
            SetControl(category);
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

        /// <summary>
        /// 添加三级分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddThird_Click(object sender, EventArgs e)
        {
            ChildFormManage.ShowDialogForm(typeof(CategoryAddForm), new object[] { 3 });
            LoadTree();
        }
        
        /// <summary>
        /// 编辑分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            TreeNode node = this.tvCategory.SelectedNode;
            if (node == null || node.Name == "0")
                return;

            ChildFormManage.ShowDialogForm(typeof(CategoryEditForm), new object[] { Convert.ToInt32(node.Name) });
            LoadTree();
        }
        #endregion //Event
    }
}
