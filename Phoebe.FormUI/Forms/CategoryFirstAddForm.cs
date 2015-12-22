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
    public partial class CategoryFirstAddForm : Form
    {
        #region Field
        private CategoryBusiness categoryBusiness;
        #endregion //Field

        #region Constructor
        public CategoryFirstAddForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        private void InitData()
        {
            this.categoryBusiness = new CategoryBusiness();
        }
        #endregion //Function

        #region Event
        private void CategoryFirstAddForm_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (this.textBoxName.Text.Trim() == "")
            {
                MessageBox.Show("名称不能为空", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FirstCategory first = new FirstCategory
            {
                Name = this.textBoxName.Text,
                Remark = this.textBoxRemark.Text
            };

            ErrorCode result = this.categoryBusiness.CreateFirstCategory(first);
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
