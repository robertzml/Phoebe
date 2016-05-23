﻿namespace Phoebe.FormClient
{
    partial class ContractAddForm
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.clcCustomer = new Phoebe.FormClient.CustomerListControl();
            this.txtCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.txtCustomerNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.cmbBillingType = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.ckbIsTiming = new DevExpress.XtraEditors.CheckEdit();
            this.txtSignDate = new DevExpress.XtraEditors.DateEdit();
            this.txtNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.plFill)).BeginInit();
            this.plFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plBottom)).BeginInit();
            this.plBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBillingType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbIsTiming.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSignDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSignDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            this.SuspendLayout();
            // 
            // plFill
            // 
            this.plFill.Appearance.BackColor = System.Drawing.Color.White;
            this.plFill.Appearance.Options.UseBackColor = true;
            this.plFill.Controls.Add(this.groupControl1);
            this.plFill.Size = new System.Drawing.Size(563, 332);
            // 
            // plBottom
            // 
            this.plBottom.Appearance.BackColor = System.Drawing.Color.White;
            this.plBottom.Appearance.Options.UseBackColor = true;
            this.plBottom.Location = new System.Drawing.Point(0, 332);
            this.plBottom.Size = new System.Drawing.Size(563, 63);
            // 
            // btnCanel
            // 
            this.btnCanel.Location = new System.Drawing.Point(462, 18);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(348, 18);
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(563, 332);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "合同信息";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.clcCustomer);
            this.layoutControl1.Controls.Add(this.txtCustomerName);
            this.layoutControl1.Controls.Add(this.txtCustomerNumber);
            this.layoutControl1.Controls.Add(this.txtRemark);
            this.layoutControl1.Controls.Add(this.cmbBillingType);
            this.layoutControl1.Controls.Add(this.ckbIsTiming);
            this.layoutControl1.Controls.Add(this.txtSignDate);
            this.layoutControl1.Controls.Add(this.txtNumber);
            this.layoutControl1.Controls.Add(this.txtName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 21);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(559, 309);
            this.layoutControl1.TabIndex = 17;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // clcCustomer
            // 
            this.clcCustomer.Location = new System.Drawing.Point(342, 12);
            this.clcCustomer.Name = "clcCustomer";
            this.clcCustomer.Size = new System.Drawing.Size(205, 285);
            this.clcCustomer.TabIndex = 16;
            this.clcCustomer.TabStop = false;
            this.clcCustomer.CustomerItemSelected += new Phoebe.FormClient.CustomerListControl.ItemSelectHandle(this.clcCustomer_CustomerItemSelected);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(200, 60);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Properties.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.txtCustomerName.Properties.Appearance.Options.UseBackColor = true;
            this.txtCustomerName.Size = new System.Drawing.Size(138, 20);
            this.txtCustomerName.StyleController = this.layoutControl1;
            this.txtCustomerName.TabIndex = 15;
            // 
            // txtCustomerNumber
            // 
            this.txtCustomerNumber.Location = new System.Drawing.Point(63, 60);
            this.txtCustomerNumber.Name = "txtCustomerNumber";
            this.txtCustomerNumber.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow;
            this.txtCustomerNumber.Properties.Appearance.Options.UseBackColor = true;
            this.txtCustomerNumber.Size = new System.Drawing.Size(82, 20);
            this.txtCustomerNumber.StyleController = this.layoutControl1;
            this.txtCustomerNumber.TabIndex = 2;
            this.txtCustomerNumber.EditValueChanged += new System.EventHandler(this.txtCustomerNumber_EditValueChanged);
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(63, 155);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(275, 142);
            this.txtRemark.StyleController = this.layoutControl1;
            this.txtRemark.TabIndex = 6;
            // 
            // cmbBillingType
            // 
            this.cmbBillingType.Location = new System.Drawing.Point(63, 108);
            this.cmbBillingType.Name = "cmbBillingType";
            this.cmbBillingType.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow;
            this.cmbBillingType.Properties.Appearance.Options.UseBackColor = true;
            this.cmbBillingType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBillingType.Size = new System.Drawing.Size(275, 20);
            this.cmbBillingType.StyleController = this.layoutControl1;
            this.cmbBillingType.TabIndex = 4;
            // 
            // ckbIsTiming
            // 
            this.ckbIsTiming.EditValue = true;
            this.ckbIsTiming.Location = new System.Drawing.Point(63, 132);
            this.ckbIsTiming.Name = "ckbIsTiming";
            this.ckbIsTiming.Properties.Caption = "是";
            this.ckbIsTiming.Size = new System.Drawing.Size(275, 19);
            this.ckbIsTiming.StyleController = this.layoutControl1;
            this.ckbIsTiming.TabIndex = 5;
            // 
            // txtSignDate
            // 
            this.txtSignDate.EditValue = null;
            this.txtSignDate.Location = new System.Drawing.Point(63, 84);
            this.txtSignDate.Name = "txtSignDate";
            this.txtSignDate.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow;
            this.txtSignDate.Properties.Appearance.Options.UseBackColor = true;
            this.txtSignDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSignDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSignDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtSignDate.Size = new System.Drawing.Size(275, 20);
            this.txtSignDate.StyleController = this.layoutControl1;
            this.txtSignDate.TabIndex = 3;
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(63, 12);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow;
            this.txtNumber.Properties.Appearance.Options.UseBackColor = true;
            this.txtNumber.Size = new System.Drawing.Size(275, 20);
            this.txtNumber.StyleController = this.layoutControl1;
            this.txtNumber.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(63, 36);
            this.txtName.Name = "txtName";
            this.txtName.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow;
            this.txtName.Properties.Appearance.Options.UseBackColor = true;
            this.txtName.Size = new System.Drawing.Size(275, 20);
            this.txtName.StyleController = this.layoutControl1;
            this.txtName.TabIndex = 1;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(559, 309);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtNumber;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(330, 24);
            this.layoutControlItem1.Text = "合同编号";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtName;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(330, 24);
            this.layoutControlItem2.Text = "合同名称";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtCustomerNumber;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(137, 24);
            this.layoutControlItem3.Text = "客户代码";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtSignDate;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(330, 24);
            this.layoutControlItem4.Text = "签订日期";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.cmbBillingType;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(330, 24);
            this.layoutControlItem5.Text = "计费方式";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.ckbIsTiming;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(330, 23);
            this.layoutControlItem6.Text = "是否计时";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtRemark;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 143);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(330, 146);
            this.layoutControlItem7.Text = "备注";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtCustomerName;
            this.layoutControlItem8.Location = new System.Drawing.Point(137, 48);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(193, 24);
            this.layoutControlItem8.Text = "客户名称";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.clcCustomer;
            this.layoutControlItem9.Location = new System.Drawing.Point(330, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(209, 289);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // ContractAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 395);
            this.Name = "ContractAddForm";
            this.Text = "添加合同";
            this.Load += new System.EventHandler(this.ContractAddForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.plFill)).EndInit();
            this.plFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plBottom)).EndInit();
            this.plBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBillingType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbIsTiming.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSignDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSignDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtNumber;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private DevExpress.XtraEditors.CheckEdit ckbIsTiming;
        private DevExpress.XtraEditors.ImageComboBoxEdit cmbBillingType;
        private DevExpress.XtraEditors.DateEdit txtSignDate;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtCustomerNumber;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtCustomerName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private CustomerListControl clcCustomer;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
    }
}