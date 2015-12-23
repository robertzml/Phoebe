﻿namespace Phoebe.FormUI
{
    partial class CategoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonAddThird = new System.Windows.Forms.Button();
            this.buttonAddSecond = new System.Windows.Forms.Button();
            this.buttonAddFirst = new System.Windows.Forms.Button();
            this.treeCategory = new System.Windows.Forms.TreeView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeCategory);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 441);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "类别列表";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonAddThird);
            this.groupBox2.Controls.Add(this.buttonAddSecond);
            this.groupBox2.Controls.Add(this.buttonAddFirst);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(203, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(476, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作";
            // 
            // buttonAddThird
            // 
            this.buttonAddThird.Location = new System.Drawing.Point(304, 42);
            this.buttonAddThird.Name = "buttonAddThird";
            this.buttonAddThird.Size = new System.Drawing.Size(96, 23);
            this.buttonAddThird.TabIndex = 2;
            this.buttonAddThird.Text = "添加三级分类";
            this.buttonAddThird.UseVisualStyleBackColor = true;
            this.buttonAddThird.Click += new System.EventHandler(this.buttonAddThird_Click);
            // 
            // buttonAddSecond
            // 
            this.buttonAddSecond.Location = new System.Drawing.Point(167, 42);
            this.buttonAddSecond.Name = "buttonAddSecond";
            this.buttonAddSecond.Size = new System.Drawing.Size(96, 23);
            this.buttonAddSecond.TabIndex = 1;
            this.buttonAddSecond.Text = "添加二级分类";
            this.buttonAddSecond.UseVisualStyleBackColor = true;
            this.buttonAddSecond.Click += new System.EventHandler(this.buttonAddSecond_Click);
            // 
            // buttonAddFirst
            // 
            this.buttonAddFirst.Location = new System.Drawing.Point(30, 42);
            this.buttonAddFirst.Name = "buttonAddFirst";
            this.buttonAddFirst.Size = new System.Drawing.Size(96, 23);
            this.buttonAddFirst.TabIndex = 0;
            this.buttonAddFirst.Text = "添加一级分类";
            this.buttonAddFirst.UseVisualStyleBackColor = true;
            this.buttonAddFirst.Click += new System.EventHandler(this.buttonAddFirst_Click);
            // 
            // treeCategory
            // 
            this.treeCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeCategory.Location = new System.Drawing.Point(3, 17);
            this.treeCategory.Name = "treeCategory";
            this.treeCategory.Size = new System.Drawing.Size(194, 421);
            this.treeCategory.TabIndex = 0;
            // 
            // CategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 447);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CategoryForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "类别管理";
            this.Load += new System.EventHandler(this.CategoryForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonAddThird;
        private System.Windows.Forms.Button buttonAddSecond;
        private System.Windows.Forms.Button buttonAddFirst;
        private System.Windows.Forms.TreeView treeCategory;
    }
}