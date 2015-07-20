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
using Phoebe.Model;

namespace Phoebe.FormUI
{
    /// <summary>
    /// 仓库信息窗体
    /// </summary>
    public partial class WarehouseForm : Form
    {
        #region Field
        private WarehouseBusiness warehouseBusiness;
        #endregion //Field

        #region Constructor
        public WarehouseForm()
        {
            InitializeComponent();

            this.warehouseBusiness = new WarehouseBusiness();
        }
        #endregion //Constructor

        #region Function
        private void LoadWarehouse()
        {            
            //add top node
            var topWarehouse = this.warehouseBusiness.GetTop();
            TreeNode top = new TreeNode();
            top.Name = topWarehouse.ID.ToString();
            top.Text = topWarehouse.Name;
            this.treeWarehouse.Nodes.Add(top);

            foreach (var item in topWarehouse.ChildrenWarehouse)
            {
                TreeNode child = new TreeNode();
                child.Name = item.ID.ToString();
                child.Text = item.Name;

                top.Nodes.Add(child);
            }
        }

        /// <summary>
        /// 更新树形菜单
        /// </summary>
        private void UpdateTreeView()
        {
            this.treeWarehouse.BeginUpdate();

            this.treeWarehouse.Nodes.Clear();

            LoadWarehouse();

            this.treeWarehouse.ExpandAll();
            this.treeWarehouse.EndUpdate();
        }
        #endregion //Function

        #region Event
        private void WarehouseForm_Load(object sender, EventArgs e)
        {
            UpdateTreeView();            
        }

        /// <summary>
        /// 选择仓库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeWarehouse_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            Warehouse data = this.warehouseBusiness.Get(Convert.ToInt32(node.Name));

            this.textBoxName.Text = data.Name;
            this.textBoxHierarchy.Text = data.Hierarchy.ToString();
            if (data.Hierarchy == 1)
            {
                this.textBoxParent.Text = "";
            }
            else
            {
                this.textBoxParent.Text = data.ParentWarehouse.Name;
            }
            this.textBoxRemark.Text = data.Remark;
        }

        /// <summary>
        /// 添加仓库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            WarehouseAddForm form = new WarehouseAddForm();
            form.ShowDialog();

            UpdateTreeView();
        }

        /// <summary>
        /// 编辑仓库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (this.treeWarehouse.SelectedNode == null)
            {
                MessageBox.Show("未选择仓库", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.treeWarehouse.SelectedNode.Level == 0)
            {
                MessageBox.Show("顶级仓库无法编辑", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            WarehouseEditForm form = new WarehouseEditForm(Convert.ToInt32(this.treeWarehouse.SelectedNode.Name));
            form.ShowDialog();

            UpdateTreeView();
        }
        #endregion //Event
    }
}
