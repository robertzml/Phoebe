﻿using System;
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
    using Poseidon.Winform.Base;
    using Phoebe.Core.BL;
    using Phoebe.Core.DL;

    /// <summary>
    /// 类别管理窗体
    /// </summary>
    public partial class FrmCategoryManage : BaseMdiForm
    {
        #region Constructor
        public FrmCategoryManage()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        protected override void InitForm()
        {
            this.categoryTree.Init();

            base.InitForm();
        }

        /// <summary>
        /// 显示类别信息
        /// </summary>
        /// <param name="category"></param>
        private void DisplayInfo(Category category)
        {
            this.txtName.Text = category.Name;
            this.txtNumber.Text = category.Number;
            this.txtHierarchy.Text = category.Hierarchy.ToString();
            this.txtRemark.Text = category.Remark;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 类别选中
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        private void categoryTree_CategorySelected(object arg1, EventArgs arg2)
        {
            var category = this.categoryTree.GetCurrentSelect();
            if (category == null)
            {

            }
            else
            {
                DisplayInfo(category);
            }
        }
       
        /// <summary>
        /// 编辑类别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            var category = this.categoryTree.GetCurrentSelect();
            if (category == null)
                return;

            ChildFormManage.ShowDialogForm(typeof(FrmCategoryEdit), new object[] { category.Id });
            this.categoryTree.RefreshData();
        }
        #endregion //Event
    }
}
