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
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            WarehouseAddForm form = new WarehouseAddForm();
            form.ShowDialog();

            UpdateTreeView();
        }
        #endregion //Event
    }
}
