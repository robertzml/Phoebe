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
    public partial class CategorySecondAddForm : Form
    {
        #region Field
        private CategoryBusiness categoryBusiness;
        #endregion //Field

        #region Constructor
        public CategorySecondAddForm()
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
            this.comboBoxFirstCategory.DataSource = this.categoryBusiness.GetFirstCategory();
            this.comboBoxFirstCategory.DisplayMember = "Name";
            this.comboBoxFirstCategory.ValueMember = "ID";
        }
        #endregion //Function

        #region Event
        private void CategorySecondAddForm_Load(object sender, EventArgs e)
        {
            InitData();
            InitControl();
        }

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

            SecondCategory second = new SecondCategory
            {
                Name = this.textBoxName.Text.Trim(),
                FirstCategoryID = Convert.ToInt32(this.comboBoxFirstCategory.SelectedValue),
                Remark = this.textBoxRemark.Text
            };

            ErrorCode result = this.categoryBusiness.CreateSecondCategory(second);
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
