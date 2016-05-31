namespace Phoebe.FormClient
{
    partial class PaymentAddForm
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
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.txtUser = new DevExpress.XtraEditors.TextEdit();
            this.nmPaidFee = new DevExpress.XtraEditors.SpinEdit();
            this.dpPaidTime = new DevExpress.XtraEditors.DateEdit();
            this.txtCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.txtCustomerNumber = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.clcCustomer = new Phoebe.FormClient.CustomerListControl();
            ((System.ComponentModel.ISupportInitialize)(this.plFill)).BeginInit();
            this.plFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plBottom)).BeginInit();
            this.plBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmPaidFee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpPaidTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpPaidTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // plFill
            // 
            this.plFill.Appearance.BackColor = System.Drawing.Color.White;
            this.plFill.Appearance.Options.UseBackColor = true;
            this.plFill.Controls.Add(this.groupControl1);
            this.plFill.Controls.Add(this.clcCustomer);
            this.plFill.Size = new System.Drawing.Size(639, 306);
            // 
            // plBottom
            // 
            this.plBottom.Appearance.BackColor = System.Drawing.Color.White;
            this.plBottom.Appearance.Options.UseBackColor = true;
            this.plBottom.Location = new System.Drawing.Point(0, 306);
            this.plBottom.Size = new System.Drawing.Size(639, 63);
            // 
            // btnCanel
            // 
            this.btnCanel.Location = new System.Drawing.Point(540, 18);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(433, 18);
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(382, 306);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "缴费信息";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtRemark);
            this.layoutControl1.Controls.Add(this.txtUser);
            this.layoutControl1.Controls.Add(this.nmPaidFee);
            this.layoutControl1.Controls.Add(this.dpPaidTime);
            this.layoutControl1.Controls.Add(this.txtCustomerName);
            this.layoutControl1.Controls.Add(this.txtCustomerNumber);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 21);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(378, 283);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(63, 84);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(303, 187);
            this.txtRemark.StyleController = this.layoutControl1;
            this.txtRemark.TabIndex = 9;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(63, 60);
            this.txtUser.Name = "txtUser";
            this.txtUser.Properties.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.txtUser.Properties.Appearance.Options.UseBackColor = true;
            this.txtUser.Properties.ReadOnly = true;
            this.txtUser.Size = new System.Drawing.Size(118, 20);
            this.txtUser.StyleController = this.layoutControl1;
            this.txtUser.TabIndex = 8;
            // 
            // nmPaidFee
            // 
            this.nmPaidFee.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nmPaidFee.Location = new System.Drawing.Point(236, 36);
            this.nmPaidFee.Name = "nmPaidFee";
            this.nmPaidFee.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow;
            this.nmPaidFee.Properties.Appearance.Options.UseBackColor = true;
            this.nmPaidFee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nmPaidFee.Properties.Mask.EditMask = "######.##";
            this.nmPaidFee.Properties.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nmPaidFee.Size = new System.Drawing.Size(130, 20);
            this.nmPaidFee.StyleController = this.layoutControl1;
            this.nmPaidFee.TabIndex = 7;
            // 
            // dpPaidTime
            // 
            this.dpPaidTime.EditValue = null;
            this.dpPaidTime.Location = new System.Drawing.Point(63, 36);
            this.dpPaidTime.Name = "dpPaidTime";
            this.dpPaidTime.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dpPaidTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpPaidTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpPaidTime.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dpPaidTime.Size = new System.Drawing.Size(118, 20);
            this.dpPaidTime.StyleController = this.layoutControl1;
            this.dpPaidTime.TabIndex = 6;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(236, 12);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Properties.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.txtCustomerName.Properties.Appearance.Options.UseBackColor = true;
            this.txtCustomerName.Properties.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(130, 20);
            this.txtCustomerName.StyleController = this.layoutControl1;
            this.txtCustomerName.TabIndex = 5;
            // 
            // txtCustomerNumber
            // 
            this.txtCustomerNumber.Location = new System.Drawing.Point(63, 12);
            this.txtCustomerNumber.Name = "txtCustomerNumber";
            this.txtCustomerNumber.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow;
            this.txtCustomerNumber.Properties.Appearance.Options.UseBackColor = true;
            this.txtCustomerNumber.Size = new System.Drawing.Size(118, 20);
            this.txtCustomerNumber.StyleController = this.layoutControl1;
            this.txtCustomerNumber.TabIndex = 4;
            this.txtCustomerNumber.EditValueChanged += new System.EventHandler(this.txtCustomerNumber_EditValueChanged);
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
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(378, 283);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtCustomerNumber;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(173, 24);
            this.layoutControlItem1.Text = "客户代码";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtCustomerName;
            this.layoutControlItem2.Location = new System.Drawing.Point(173, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(185, 24);
            this.layoutControlItem2.Text = "客户名称";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dpPaidTime;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(173, 24);
            this.layoutControlItem3.Text = "缴费时间";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.nmPaidFee;
            this.layoutControlItem4.Location = new System.Drawing.Point(173, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(185, 24);
            this.layoutControlItem4.Text = "缴费金额";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtUser;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(173, 24);
            this.layoutControlItem5.Text = "收款人";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtRemark;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(358, 191);
            this.layoutControlItem6.Text = "备注";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(48, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(173, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(185, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // clcCustomer
            // 
            this.clcCustomer.Dock = System.Windows.Forms.DockStyle.Right;
            this.clcCustomer.Location = new System.Drawing.Point(382, 0);
            this.clcCustomer.Name = "clcCustomer";
            this.clcCustomer.Size = new System.Drawing.Size(257, 306);
            this.clcCustomer.TabIndex = 1;
            this.clcCustomer.CustomerItemSelected += new Phoebe.FormClient.CustomerListControl.ItemSelectHandle(this.clcCustomer_CustomerItemSelected);
            // 
            // PaymentAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 369);
            this.Name = "PaymentAddForm";
            this.Text = "客户缴费";
            this.Load += new System.EventHandler(this.PaymentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.plFill)).EndInit();
            this.plFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plBottom)).EndInit();
            this.plBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmPaidFee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpPaidTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpPaidTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private DevExpress.XtraEditors.TextEdit txtUser;
        private DevExpress.XtraEditors.SpinEdit nmPaidFee;
        private DevExpress.XtraEditors.DateEdit dpPaidTime;
        private DevExpress.XtraEditors.TextEdit txtCustomerName;
        private DevExpress.XtraEditors.TextEdit txtCustomerNumber;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private CustomerListControl clcCustomer;
    }
}