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
    /// 添加二级分类窗体
    /// </summary>
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
        private void CategorySecondAddForm_Load(object sender, EventArgs e)
        {
            InitData();
            InitControl();
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
            if (this.textBoxNumber.Text.Trim() == "")
            {
                MessageBox.Show("代码不能为空", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.textBoxNumber.Text.Length != 4)
            {
                MessageBox.Show("代码必须为4位", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                Number = this.textBoxNumber.Text,
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
