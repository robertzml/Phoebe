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
    using DevExpress.XtraEditors.Controls;

    /// <summary>
    /// 添加分类窗体
    /// </summary>
    public partial class FrmCategoryAdd : BaseSingleForm
    {
        #region Field
        /// <summary>
        /// 分类级别
        /// </summary>
        private int hierarchy;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 添加分类窗体
        /// </summary>
        /// <param name="hierarchy">分类级别</param>
        public FrmCategoryAdd(int hierarchy)
        {
            InitializeComponent();
            this.hierarchy = hierarchy;
        }
        #endregion //Constructor

        #region Function
        protected override void InitForm()
        {
            if (hierarchy == 1)
            {
            }
            else if (hierarchy == 2)
            {
                this.cmbFirstCategory.Enabled = true;
                LoadFirst();
            }
            else if (hierarchy == 3)
            {
                this.cmbFirstCategory.Enabled = true;
                this.cmbSecondCategory.Enabled = true;
                LoadFirst();
                this.cmbFirstCategory.SelectedIndexChanged += new System.EventHandler(this.cmbFirstCategory_SelectedIndexChanged);
            }
            base.InitForm();
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

        /// <summary>
        /// 载入二级分类
        /// </summary>
        /// <param name="firstId">一级分类ID</param>
        private void LoadSecond(int firstId)
        {
            this.cmbSecondCategory.Properties.Items.Clear();
            var second = BusinessFactory<CategoryBusiness>.Instance.GetChildCategory(firstId);
            foreach (var item in second)
            {
                ImageComboBoxItem i = new ImageComboBoxItem();
                i.Description = item.Name;
                i.Value = item.Id;

                this.cmbSecondCategory.Properties.Items.Add(i);
            }
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

            if (this.hierarchy == 2 || this.hierarchy == 3)
            {
                if (this.cmbFirstCategory.SelectedItem == null)
                {
                    errorMessage = "请选择一级分类";
                    return new Tuple<bool, string>(false, errorMessage);
                }
            }

            if (this.hierarchy == 3)
            {
                if (this.cmbSecondCategory.SelectedItem == null)
                {
                    errorMessage = "请选择二级分类";
                    return new Tuple<bool, string>(false, errorMessage);
                }
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

            category.Hierarchy = this.hierarchy;
            if (this.hierarchy == 2)
            {
                category.ParentId = Convert.ToInt32(this.cmbFirstCategory.EditValue);
            }
            else if (this.hierarchy == 3)
            {
                category.ParentId = Convert.ToInt32(this.cmbSecondCategory.EditValue);
            }
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 选择一级分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbFirstCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int firstId = Convert.ToInt32(this.cmbFirstCategory.EditValue);
            LoadSecond(firstId);
        }

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
                Category entity = new Category();
                SetEntity(entity);

                BusinessFactory<CategoryBusiness>.Instance.Create(entity);

                MessageUtil.ShowInfo("添加类别成功");
                this.Close();
            }
            catch (PoseidonException pe)
            {
                Logger.Instance.Exception("添加类别失败", pe);
                MessageUtil.ShowError(string.Format("保存失败，错误消息:{0}", pe.Message));
            }
        }
        #endregion //Event
    }
}
