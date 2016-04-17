using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phoebe.Business;
using Phoebe.Common;
using Phoebe.Model;

namespace Phoebe.FormUI
{
    public partial class CategoryForm : Form
    {
        #region Field
        private CategoryBusiness categoryBusiness;
        #endregion //Field

        #region Constructor
        public CategoryForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        private void InitData()
        {
            //this.categoryBusiness = new CategoryBusiness();
        }

        private void InitControl()
        {
            UpdateCategoryTree();
        }

        /// <summary>
        /// 更新树形菜单
        /// </summary>
        private void UpdateCategoryTree()
        {
            this.categoryBusiness = new CategoryBusiness();

            this.treeCategory.BeginUpdate();
            this.treeCategory.Nodes.Clear();

            TreeNode top = new TreeNode
            {
                Name = "0",
                Text = "分类",
                Tag = 0
            };
            this.treeCategory.Nodes.Add(top);

            List<FirstCategory> firstCategory = this.categoryBusiness.GetFirstCategory(false);

            foreach (var first in firstCategory)
            {
                TreeNode node = new TreeNode();
                node.Name = first.ID.ToString();
                node.Text = first.Name;
                node.Tag = 1;

                top.Nodes.Add(node);

                UpdateSecondCategory(first, node);
            }

            this.treeCategory.Nodes[0].Expand();
            foreach (TreeNode item in this.treeCategory.Nodes[0].Nodes)
            {
                item.Expand();
            }
            this.treeCategory.EndUpdate();
        }

        /// <summary>
        /// 更新二级分类
        /// </summary>
        /// <param name="first"></param>
        /// <param name="parent"></param>
        private void UpdateSecondCategory(FirstCategory first, TreeNode parent)
        {
            List<SecondCategory> secondCategory = this.categoryBusiness.GetSecondCategoryByFirst(first.ID, false);

            foreach (var item in secondCategory)
            {
                TreeNode node = new TreeNode();
                node.Name = item.ID.ToString();
                node.Text = item.Name;
                node.Tag = 2;

                parent.Nodes.Add(node);
                UpdateThirdCategory(item, node);
            }

            return;
        }

        /// <summary>
        /// 更新三级分类
        /// </summary>
        /// <param name="second"></param>
        /// <param name="parent"></param>
        private void UpdateThirdCategory(SecondCategory second, TreeNode parent)
        {
            List<ThirdCategory> thirdCategory = this.categoryBusiness.GetThirdCategoryBySecond(second.ID, false);

            foreach (var item in thirdCategory)
            {
                TreeNode node = new TreeNode();
                node.Name = item.ID.ToString();
                node.Text = item.Name;
                node.Tag = 3;

                parent.Nodes.Add(node);
            }
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
            InitData();
            InitControl();
        }

        /// <summary>
        /// 选择分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeCategory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = e.Node;
            if ((int)node.Tag == 0)
                return;

            int id = Convert.ToInt32(node.Name);
            int hierarchy = Convert.ToInt32(node.Tag);
            switch (hierarchy)
            {
                case 1:
                    var first = categoryBusiness.GetFirstCategory(id);
                    this.textBoxName.Text = first.Name;
                    this.textBoxNumber.Text = first.Number;
                    break;
                case 2:
                    var second = categoryBusiness.GetSecondCategory(id);
                    this.textBoxName.Text = second.Name;
                    this.textBoxNumber.Text = second.Number;
                    break;
                case 3:
                    var third = categoryBusiness.GetThirdCategory(id);
                    this.textBoxName.Text = third.Name;
                    this.textBoxNumber.Text = third.Number;
                    break;
            }
        }

        /// <summary>
        /// 添加一级分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddFirst_Click(object sender, EventArgs e)
        {
            CategoryFirstAddForm form = new CategoryFirstAddForm();
            form.ShowDialog();
            UpdateCategoryTree();
        }

        /// <summary>
        /// 添加二级分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddSecond_Click(object sender, EventArgs e)
        {
            CategorySecondAddForm form = new CategorySecondAddForm();
            form.ShowDialog();
            UpdateCategoryTree();
        }

        /// <summary>
        /// 添加三级分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddThird_Click(object sender, EventArgs e)
        {
            CategoryThirdAddForm form = new CategoryThirdAddForm();
            form.ShowDialog();
            UpdateCategoryTree();
        }

        /// <summary>
        /// 编辑分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            TreeNode node = this.treeCategory.SelectedNode;
            if (node == null || node.Name == "0")
                return;

            CategoryEditForm form = new CategoryEditForm(Convert.ToInt32(node.Name), Convert.ToInt32(node.Tag));
            form.ShowDialog();
            UpdateCategoryTree();
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            TreeNode node = this.treeCategory.SelectedNode;
            if (node == null || node.Name == "0")
                return;

            DialogResult dr = MessageBox.Show("是否确认删除选中分类", FormConstant.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                ErrorCode result = ErrorCode.Success;
                int id = Convert.ToInt32(node.Name);
                int hierarchy = Convert.ToInt32(node.Tag);
                switch (hierarchy)
                {
                    case 1:
                        result = categoryBusiness.DeleteFirstCategory(id);
                        break;
                    case 2:
                        result = categoryBusiness.DeleteSecondCategory(id);
                        break;
                    case 3:
                        result = categoryBusiness.DeleteThirdCategory(id);
                        break;
                }

                if (result == ErrorCode.Success)
                {
                    MessageBox.Show("删除分类成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateCategoryTree();
                }
                else
                {
                    MessageBox.Show("删除分类失败：" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// 重设货品编码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSetCargoCode_Click(object sender, EventArgs e)
        {
            CargoBusiness cargoBusiness = new CargoBusiness();
            ErrorCode result = cargoBusiness.SetNumber();
            if (result == ErrorCode.Success)
            {
                MessageBox.Show("更新编码成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("更新编码失败：" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion //Event
    }
}
