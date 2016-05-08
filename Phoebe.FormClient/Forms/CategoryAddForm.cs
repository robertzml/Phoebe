using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using DevExpress.XtraEditors.Controls;
    using Phoebe.Base;
    using Phoebe.Business;
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 添加分类窗体
    /// </summary>
    public partial class CategoryAddForm : BaseSingleForm
    {
        #region Field
        private int hierarchy;
        #endregion //Field

        #region Constructor
        public CategoryAddForm(int hierarchy)
        {
            InitializeComponent();
            this.hierarchy = hierarchy;
        }
        #endregion //Constructor

        #region Function
        private void SetEntity(Category category)
        {
            category.Name = this.txtName.Text.Trim();
            category.Number = this.txtNumber.Text.Trim();
            category.Hierarchy = this.hierarchy;
            if (this.hierarchy == 2)
            {
                category.ParentId = Convert.ToInt32(this.cmbFirstCategory.EditValue);
            }
            category.Remark = this.txtRemark.Text;
        }

        /// <summary>
        /// 载入一级分类
        /// </summary>
        private void LoadFirst()
        {
            var first = BusinessFactory<CategoryBusiness>.Instance.GetFirstCategory();
            foreach (var item in first)
            {
                ImageComboBoxItem i = new ImageComboBoxItem();
                i.Description = item.Name;
                i.Value = item.Id;

                this.cmbFirstCategory.Properties.Items.Add(i);
            }
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CategoryAddForm_Load(object sender, EventArgs e)
        {
            if (hierarchy == 1)
            {
                this.cmbFirstCategory.Enabled = false;
                this.cmbSecondCategory.Enabled = false;
            }
            else if (hierarchy == 2)
            {
                this.cmbSecondCategory.Enabled = false;
                LoadFirst();
            }
            else if (hierarchy == 3)
            {

            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text.Trim() == "")
            {
                MessageBox.Show("名称不能为空", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.txtNumber.Text.Trim() == "")
            {
                MessageBox.Show("代码不能为空", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.hierarchy == 2 || this.hierarchy == 3)
            {
                if (this.cmbFirstCategory.SelectedItem == null)
                {
                    MessageBox.Show("一级分类不能为空", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            Category category = new Category();
            SetEntity(category);

            ErrorCode result = BusinessFactory<CategoryBusiness>.Instance.Create(category);
            if (result == ErrorCode.Success)
            {
                MessageBox.Show("添加分类成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("添加分类失败：" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion //Event
    }
}
