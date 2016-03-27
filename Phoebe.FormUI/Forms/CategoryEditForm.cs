﻿using System;
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
    /// 分类编辑窗体
    /// </summary>
    public partial class CategoryEditForm : Form
    {
        #region Field
        private CategoryBusiness categoryBusiness;

        private int categoryId;

        private int hierarchy;
        #endregion //Field

        #region Constructor
        public CategoryEditForm(int categoryId, int hierarchy)
        {
            InitializeComponent();
            this.categoryId = categoryId;
            this.hierarchy = hierarchy;
        }
        #endregion //Constructor

        #region Function
        private void InitData()
        {
            this.categoryBusiness = new CategoryBusiness();
        }

        private void InitControl()
        {
            switch (this.hierarchy)
            {
                case 1:
                    {
                        var category = this.categoryBusiness.GetFirstCategory(this.categoryId);
                        this.textBoxName.Text = category.Name;
                        this.textBoxNumber.Text = category.Number;
                        this.textBoxRemark.Text = category.Remark;
                        this.textBoxNumber.MaxLength = 2;
                        break;
                    }
                case 2:
                    {
                        var category = this.categoryBusiness.GetSecondCategory(this.categoryId);
                        this.textBoxName.Text = category.Name;
                        this.textBoxNumber.Text = category.Number;
                        this.textBoxRemark.Text = category.Remark;
                        this.textBoxNumber.MaxLength = 4;
                        break;
                    }
                case 3:
                    {
                        var category = this.categoryBusiness.GetThirdCategory(this.categoryId);
                        this.textBoxName.Text = category.Name;
                        this.textBoxNumber.Text = category.Number;
                        this.textBoxRemark.Text = category.Remark;
                        this.textBoxNumber.MaxLength = 7;
                        break;
                    }
            }

            this.textBoxHierarchy.Text = this.hierarchy.ToString();
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
            if (this.textBoxName.Text == "")
            {
                MessageBox.Show("名称不能为空", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.textBoxNumber.Text == "")
            {
                MessageBox.Show("代码不能为空", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ErrorCode result = ErrorCode.Error;
            switch (this.hierarchy)
            {
                case 1:
                    {
                        if (this.textBoxNumber.Text.Length != 2)
                        {
                            MessageBox.Show("代码必须为2位", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        var category = this.categoryBusiness.GetFirstCategory(this.categoryId);
                        category.Name = this.textBoxName.Text;
                        category.Number = this.textBoxNumber.Text;
                        category.Remark = this.textBoxRemark.Text;
                        result = this.categoryBusiness.EditFirstCategory(category);
                        break;
                    }
                case 2:
                    {
                        if (this.textBoxNumber.Text.Length != 4)
                        {
                            MessageBox.Show("代码必须为4位", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        var category = this.categoryBusiness.GetSecondCategory(this.categoryId);
                        category.Name = this.textBoxName.Text;
                        category.Number = this.textBoxNumber.Text;
                        category.Remark = this.textBoxRemark.Text;
                        result = this.categoryBusiness.EditSecondCategory(category);
                        break;
                    }
                case 3:
                    {
                        if (this.textBoxNumber.Text.Length != 7)
                        {
                            MessageBox.Show("代码必须为7位", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        var category = this.categoryBusiness.GetThirdCategory(this.categoryId);
                        category.Name = this.textBoxName.Text;
                        category.Number = this.textBoxNumber.Text;
                        category.Remark = this.textBoxRemark.Text;
                        result = this.categoryBusiness.EditThirdCategory(category);
                        break;
                    }
            }

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
