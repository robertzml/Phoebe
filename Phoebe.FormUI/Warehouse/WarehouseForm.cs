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
            var data = this.warehouseBusiness.Get();

            //add top node
            TreeNode top = new TreeNode();
            top.Name = data.Where(r => r.Hierarchy == 1).First().ID.ToString();
            top.Text = data.Where(r => r.Hierarchy == 1).First().Name;
            this.treeWarehouse.Nodes.Add(top);
        }
        #endregion //Function

        #region Event
        private void WarehouseForm_Load(object sender, EventArgs e)
        {
            LoadWarehouse();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {

        }
        #endregion //Event
    }
}
