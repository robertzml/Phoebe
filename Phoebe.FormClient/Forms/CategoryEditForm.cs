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
    /// 分类编辑窗体
    /// </summary>
    public partial class CategoryEditForm : BaseSingleForm
    {
        #region Field
        /// <summary>
        /// 分类ID
        /// </summary>
        private int categoryId;

        /// <summary>
        /// 关联分类
        /// </summary>
        private Category bindCategory;
        #endregion //Field

        #region Constructor
        public CategoryEditForm(int categoryId)
        {
            InitializeComponent();
            this.categoryId = categoryId;
        }
        #endregion //Constructor

        #region Function
        private void SetControl(Category category)
        {
            this.txtName.Text = category.Name;
            this.txtNumber.Text = category.Number;
            this.txtHierarchy.Text = category.Hierarchy.ToString();
            this.txtRemark.Text = category.Remark;
        }

        private void SetEntity(Category category)
        {
            category.Name = this.txtName.Text.Trim();
            category.Number = this.txtNumber.Text.Trim();
            category.Remark = this.txtRemark.Text;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CategoryEditForm_Load(object sender, EventArgs e)
        {
            this.bindCategory = BusinessFactory<CategoryBusiness>.Instance.FindById(this.categoryId);
            SetControl(bindCategory);
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

            SetEntity(this.bindCategory);

            ErrorCode result = BusinessFactory<CategoryBusiness>.Instance.Update(this.bindCategory);
            if (result == ErrorCode.Success)
            {
                MessageBox.Show("编辑分类成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("编辑分类失败：" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion //Event
    }
}
