using Phoebe.Business;
using Phoebe.Common;
using Phoebe.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phoebe.FormUI
{
    public partial class WarehouseAddForm : Form
    {
        #region Field
        /// <summary>
        /// 仓库业务对象
        /// </summary>
        WarehouseBusiness warehouseBusiness = new WarehouseBusiness();
        #endregion //Field

        #region Constructor
        public WarehouseAddForm()
        {
            InitializeComponent();
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
        }
        #endregion //Function

        #region Event
        private void WarehouseAddForm_Load(object sender, EventArgs e)
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
                MessageBox.Show("名称不能为空");
                return;
            }

            Warehouse warehouse = new Warehouse();
            warehouse.Name = this.textBoxName.Text.Trim();

            int parentId = Convert.ToInt32(this.comboBoxWarehouse.SelectedValue);

            Warehouse parent = this.warehouseBusiness.Get(parentId);

            warehouse.ParentId = parentId;
            warehouse.Hierarchy = parent.Hierarchy + 1;
            warehouse.Remark = this.textBoxRemark.Text.Trim();
            warehouse.Status = 0;

            ErrorCode result = this.warehouseBusiness.Create(warehouse);

            if (result == ErrorCode.Success)
            {
                MessageBox.Show("添加冷库成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("添加冷库失败。\r\n" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            this.Close();
        }
        #endregion //Event
    }
}
