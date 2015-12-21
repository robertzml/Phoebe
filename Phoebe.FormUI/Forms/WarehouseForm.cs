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
    /// 仓库窗体
    /// </summary>
    public partial class WarehouseForm : Form
    {
        #region Field
        private WarehouseBusiness warehouseBusiness;

        private List<Warehouse> warehouseData;
        #endregion //Field

        #region Constructor
        public WarehouseForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        private void InitData()
        {
            this.warehouseBusiness = new WarehouseBusiness();
            this.warehouseData = this.warehouseBusiness.Get();
        }

        private void InitControl()
        {
            UpdateWarehouseTree();
        }

        /// <summary>
        /// 递归调用，添加子仓库
        /// </summary>
        /// <param name="node">当前节点</param>
        private void AddCategoryNode(TreeNode node)
        {
            var data = this.warehouseData.Where(r => r.ParentId == Convert.ToInt32(node.Name));

            foreach (var item in data)
            {
                TreeNode child = new TreeNode();
                child.Name = item.ID.ToString();
                child.Text = item.Name;
                node.Nodes.Add(child);

                AddCategoryNode(child);
            }

            return;
        }

        /// <summary>
        /// 更新仓库树
        /// </summary>
        private void UpdateWarehouseTree()
        {
            this.treeViewWarehouse.BeginUpdate();
            this.treeViewWarehouse.Nodes.Clear();

            foreach (var row in this.warehouseData.Where(r => r.Hierarchy == 1))
            {
                TreeNode node = new TreeNode();
                node.Name = row.ID.ToString();
                node.Text = row.Name;

                this.treeViewWarehouse.Nodes.Add(node);

                AddCategoryNode(node);
            }

            this.treeViewWarehouse.Nodes[0].Expand();
            //this.treeViewWarehouse.ExpandAll();
            this.treeViewWarehouse.EndUpdate();
        }
        #endregion //Function

        #region Event
        private void WarehouseForm_Load(object sender, EventArgs e)
        {
            InitData();
            InitControl();
        }

        private void treeViewWarehouse_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            Warehouse w = this.warehouseBusiness.Get(Convert.ToInt32(node.Name));
            this.textBoxName.Text = w.Name;
            this.textBoxNumber.Text = w.Number.ToString();
            this.textBoxHierarchy.Text = w.Hierarchy.ToString();
            this.textBoxRemark.Text = w.Remark;
        }
        #endregion //Event
    }
}
