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
    /// 添加三级分类窗体
    /// </summary>
    public partial class CategoryThirdAddForm : Form
    {
        #region Field
        private CategoryBusiness categoryBusiness;
        #endregion //Field

        #region Constructor
        public CategoryThirdAddForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        private void InitData()
        {
            this.categoryBusiness = new CategoryBusiness();
        }

        private void InitControl()
        {
            this.comboBoxFirstCategory.DataSource = this.categoryBusiness.GetFirstCategory(false);
            this.comboBoxFirstCategory.DisplayMember = "Name";
            this.comboBoxFirstCategory.ValueMember = "ID";
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CategoryThirdAddForm_Load(object sender, EventArgs e)
        {
            InitData();
            InitControl();
        }

        /// <summary>
        /// 一级分类选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxFirstCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxFirstCategory.SelectedIndex != -1)
            {
                FirstCategory first = this.comboBoxFirstCategory.SelectedItem as FirstCategory;

                this.comboBoxSecondCategory.DataSource = this.categoryBusiness.GetSecondCategoryByFirst(first.ID, false);
                this.comboBoxSecondCategory.DisplayMember = "Name";
                this.comboBoxSecondCategory.ValueMember = "ID";
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (this.textBoxName.Text.Trim() == "")
            {
                MessageBox.Show("名称不能为空", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.comboBoxFirstCategory.SelectedIndex == -1)
            {
                MessageBox.Show("一级分类不能为空", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.comboBoxSecondCategory.SelectedIndex == -1)
            {
                MessageBox.Show("二级分类不能为空", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ThirdCategory third = new ThirdCategory
            {
                Name = this.textBoxName.Text.Trim(),
                SecondCategoryID = Convert.ToInt32(this.comboBoxSecondCategory.SelectedValue),
                Remark = this.textBoxRemark.Text
            };

            ErrorCode result = this.categoryBusiness.CreateThirdCategory(third);
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
