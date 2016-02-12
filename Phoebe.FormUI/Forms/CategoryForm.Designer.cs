namespace Phoebe.FormUI
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
            this.treeCategory = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAddThird = new System.Windows.Forms.Button();
            this.buttonAddSecond = new System.Windows.Forms.Button();
            this.buttonAddFirst = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
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
            this.groupBox1.Size = new System.Drawing.Size(200, 478);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "类别列表";
            // 
            // treeCategory
            // 
            this.treeCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeCategory.Location = new System.Drawing.Point(3, 16);
            this.treeCategory.Name = "treeCategory";
            this.treeCategory.Size = new System.Drawing.Size(194, 459);
            this.treeCategory.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonDelete);
            this.groupBox2.Controls.Add(this.buttonEdit);
            this.groupBox2.Controls.Add(this.buttonAddThird);
            this.groupBox2.Controls.Add(this.buttonAddSecond);
            this.groupBox2.Controls.Add(this.buttonAddFirst);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(203, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(476, 161);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作";
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(30, 105);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Text = "编辑";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonAddThird
            // 
            this.buttonAddThird.Location = new System.Drawing.Point(304, 46);
            this.buttonAddThird.Name = "buttonAddThird";
            this.buttonAddThird.Size = new System.Drawing.Size(96, 25);
            this.buttonAddThird.TabIndex = 2;
            this.buttonAddThird.Text = "添加三级分类";
            this.buttonAddThird.UseVisualStyleBackColor = true;
            this.buttonAddThird.Click += new System.EventHandler(this.buttonAddThird_Click);
            // 
            // buttonAddSecond
            // 
            this.buttonAddSecond.Location = new System.Drawing.Point(167, 46);
            this.buttonAddSecond.Name = "buttonAddSecond";
            this.buttonAddSecond.Size = new System.Drawing.Size(96, 25);
            this.buttonAddSecond.TabIndex = 1;
            this.buttonAddSecond.Text = "添加二级分类";
            this.buttonAddSecond.UseVisualStyleBackColor = true;
            this.buttonAddSecond.Click += new System.EventHandler(this.buttonAddSecond_Click);
            // 
            // buttonAddFirst
            // 
            this.buttonAddFirst.Location = new System.Drawing.Point(30, 46);
            this.buttonAddFirst.Name = "buttonAddFirst";
            this.buttonAddFirst.Size = new System.Drawing.Size(96, 25);
            this.buttonAddFirst.TabIndex = 0;
            this.buttonAddFirst.Text = "添加一级分类";
            this.buttonAddFirst.UseVisualStyleBackColor = true;
            this.buttonAddFirst.Click += new System.EventHandler(this.buttonAddFirst_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(167, 104);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "删除";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // CategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 484);
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
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
    }
}