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
    /// <summary>
    /// 仓库编辑窗体
    /// </summary>
    public partial class WarehouseEditForm : Form
    {
        #region Field
        /// <summary>
        /// 仓库业务对象
        /// </summary>
        private WarehouseBusiness warehouseBusiness = new WarehouseBusiness();

        /// <summary>
        /// 当前仓库
        /// </summary>
        private Warehouse warehouse;
        #endregion //Field

        #region Constructor
        public WarehouseEditForm(int warehouseId)
        {
            InitializeComponent();

            this.warehouse = this.warehouseBusiness.Get(warehouseId);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitControls()
        {
            var warehouses = this.warehouseBusiness.Get().Where(r => r.Hierarchy <= 2).OrderBy(s => s.Hierarchy);
            this.comboBoxWarehouse.DataSource = warehouses.ToList();
            this.comboBoxWarehouse.ValueMember = "ID";
            this.comboBoxWarehouse.DisplayMember = "Name";

            this.comboBoxWarehouse.SelectedValue = this.warehouse.ParentId;
            this.textBoxName.Text = this.warehouse.Name;
            this.textBoxRemark.Text = this.warehouse.Remark;
        }
        #endregion //Function

        #region Event
        private void WarehouseEditForm_Load(object sender, EventArgs e)
        {
            InitControls();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (this.textBoxName.Text == "")
            {
                MessageBox.Show("名称不能为空", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int parentId = Convert.ToInt32(this.comboBoxWarehouse.SelectedValue);
            Warehouse parent = this.warehouseBusiness.Get(parentId);

            this.warehouse.Name = this.textBoxName.Text.Trim();
            warehouse.ParentId = parentId;
            warehouse.Hierarchy = parent.Hierarchy + 1;
            this.warehouse.Remark = this.textBoxRemark.Text.Trim();

            ErrorCode result = this.warehouseBusiness.Save();

            if (result == ErrorCode.Success)
            {
                MessageBox.Show("编辑冷库成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("编辑冷库成功。\r\n" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            this.Close();
        }
        #endregion //Event

        
    }
}
