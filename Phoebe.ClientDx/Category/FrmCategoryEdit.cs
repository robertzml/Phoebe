using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phoebe.ClientDx
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Common;
    using Poseidon.Winform.Base;
    using Phoebe.Core.BL;
    using Phoebe.Core.DL;

    /// <summary>
    /// 编辑分类窗体
    /// </summary>
    public partial class FrmCategoryEdit : BaseSingleForm
    {
        #region Field
        /// <summary>
        /// 关联分类
        /// </summary>
        private Category currentCategory;
        #endregion //Field

        #region Constructor
        public FrmCategoryEdit(int categoryId)
        {
            InitializeComponent();
            InitData(categoryId);
        }
        #endregion //Constructor

        #region Function
        private void InitData(int categoryId)
        {
            this.currentCategory = BusinessFactory<CategoryBusiness>.Instance.FindById(categoryId);
        }

        protected override void InitForm()
        {
            this.txtName.Text = currentCategory.Name;
            this.txtNumber.Text = currentCategory.Number;
            this.txtHierarchy.Text = currentCategory.Hierarchy.ToString();
            this.txtRemark.Text = currentCategory.Remark;

            base.InitForm();
        }

        /// <summary>
        /// 输入检查
        /// </summary>
        /// <returns></returns>
        private Tuple<bool, string> CheckInput()
        {
            string errorMessage = "";

            if (this.txtName.Text.Trim() == "")
            {
                errorMessage = "名称不能为空";
                return new Tuple<bool, string>(false, errorMessage);
            }
            if (this.txtNumber.Text.Trim() == "")
            {
                errorMessage = "代码不能为空";
                return new Tuple<bool, string>(false, errorMessage);
            }

            return new Tuple<bool, string>(true, "");
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="category"></param>
        private void SetEntity(Category category)
        {
            category.Name = this.txtName.Text.Trim();
            category.Number = this.txtNumber.Text.Trim();
            category.Remark = this.txtRemark.Text;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var input = CheckInput();
            if (!input.Item1)
            {
                MessageUtil.ShowError(input.Item2);
                return;
            }

            try
            {
                Category entity = BusinessFactory<CategoryBusiness>.Instance.FindById(this.currentCategory.Id);
                SetEntity(entity);

                var result = BusinessFactory<CategoryBusiness>.Instance.Update(entity);

                if (result.success)
                {
                    MessageUtil.ShowInfo("编辑类别成功");
                    this.Close();
                }
                else
                {
                    MessageUtil.ShowClaim("编辑类别失败: " + result.errorMessage);
                }
            }
            catch (PoseidonException pe)
            {
                Logger.Instance.Exception("编辑类别失败", pe);
                MessageUtil.ShowError(string.Format("保存失败，错误消息:{0}", pe.Message));
            }
        }
        #endregion //Event
    }
}
