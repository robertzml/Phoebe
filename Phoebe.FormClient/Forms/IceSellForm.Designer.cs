namespace Phoebe.FormClient
{
    partial class IceSellForm
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
            this.components = new System.ComponentModel.Container();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.txtUser = new DevExpress.XtraEditors.TextEdit();
            this.dpTime = new DevExpress.XtraEditors.DateEdit();
            this.spFee = new DevExpress.XtraEditors.SpinEdit();
            this.spWeight = new DevExpress.XtraEditors.SpinEdit();
            this.spCount = new DevExpress.XtraEditors.SpinEdit();
            this.cmbIceType = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.lkuCustomer = new DevExpress.XtraEditors.LookUpEdit();
            this.bsCustomer = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.dpTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spFee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbIceType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkuCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            this.SuspendLayout();
            // 
            // plFill
            // 
            this.plFill.Appearance.BackColor = System.Drawing.Color.White;
            this.plFill.Appearance.Options.UseBackColor = true;
            this.plFill.Controls.Add(this.groupControl1);
            this.plFill.Size = new System.Drawing.Size(391, 315);
            // 
            // plBottom
            // 
            this.plBottom.Appearance.BackColor = System.Drawing.Color.White;
            this.plBottom.Appearance.Options.UseBackColor = true;
            this.plBottom.Location = new System.Drawing.Point(0, 315);
            this.plBottom.Size = new System.Drawing.Size(391, 63);
            // 
            // btnCanel
            // 
            this.btnCanel.Location = new System.Drawing.Point(290, 18);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(183, 18);
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(391, 315);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "售出信息";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtRemark);
            this.layoutControl1.Controls.Add(this.txtUser);
            this.layoutControl1.Controls.Add(this.dpTime);
            this.layoutControl1.Controls.Add(this.spFee);
            this.layoutControl1.Controls.Add(this.spWeight);
            this.layoutControl1.Controls.Add(this.spCount);
            this.layoutControl1.Controls.Add(this.cmbIceType);
            this.layoutControl1.Controls.Add(this.lkuCustomer);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 21);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(387, 292);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(78, 180);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(297, 100);
            this.txtRemark.StyleController = this.layoutControl1;
            this.txtRemark.TabIndex = 11;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(78, 156);
            this.txtUser.Name = "txtUser";
            this.txtUser.Properties.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.txtUser.Properties.Appearance.Options.UseBackColor = true;
            this.txtUser.Properties.ReadOnly = true;
            this.txtUser.Size = new System.Drawing.Size(297, 20);
            this.txtUser.StyleController = this.layoutControl1;
            this.txtUser.TabIndex = 10;
            // 
            // dpTime
            // 
            this.dpTime.EditValue = null;
            this.dpTime.Location = new System.Drawing.Point(78, 132);
            this.dpTime.Name = "dpTime";
            this.dpTime.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dpTime.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow;
            this.dpTime.Properties.Appearance.Options.UseBackColor = true;
            this.dpTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpTime.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dpTime.Size = new System.Drawing.Size(297, 20);
            this.dpTime.StyleController = this.layoutControl1;
            this.dpTime.TabIndex = 9;
            // 
            // spFee
            // 
            this.spFee.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spFee.Location = new System.Drawing.Point(78, 108);
            this.spFee.Name = "spFee";
            this.spFee.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow;
            this.spFee.Properties.Appearance.Options.UseBackColor = true;
            this.spFee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spFee.Properties.Mask.EditMask = "n2";
            this.spFee.Properties.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.spFee.Size = new System.Drawing.Size(297, 20);
            this.spFee.StyleController = this.layoutControl1;
            this.spFee.TabIndex = 8;
            // 
            // spWeight
            // 
            this.spWeight.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spWeight.Location = new System.Drawing.Point(78, 84);
            this.spWeight.Name = "spWeight";
            this.spWeight.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow;
            this.spWeight.Properties.Appearance.Options.UseBackColor = true;
            this.spWeight.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spWeight.Properties.Mask.EditMask = "n3";
            this.spWeight.Properties.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.spWeight.Size = new System.Drawing.Size(297, 20);
            this.spWeight.StyleController = this.layoutControl1;
            this.spWeight.TabIndex = 7;
            // 
            // spCount
            // 
            this.spCount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spCount.Location = new System.Drawing.Point(78, 60);
            this.spCount.Name = "spCount";
            this.spCount.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow;
            this.spCount.Properties.Appearance.Options.UseBackColor = true;
            this.spCount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spCount.Properties.IsFloatValue = false;
            this.spCount.Properties.Mask.EditMask = "N00";
            this.spCount.Properties.MaxValue = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.spCount.Size = new System.Drawing.Size(297, 20);
            this.spCount.StyleController = this.layoutControl1;
            this.spCount.TabIndex = 6;
            // 
            // cmbIceType
            // 
            this.cmbIceType.Location = new System.Drawing.Point(78, 36);
            this.cmbIceType.Name = "cmbIceType";
            this.cmbIceType.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow;
            this.cmbIceType.Properties.Appearance.Options.UseBackColor = true;
            this.cmbIceType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbIceType.Size = new System.Drawing.Size(297, 20);
            this.cmbIceType.StyleController = this.layoutControl1;
            this.cmbIceType.TabIndex = 5;
            // 
            // lkuCustomer
            // 
            this.lkuCustomer.Location = new System.Drawing.Point(78, 12);
            this.lkuCustomer.Name = "lkuCustomer";
            this.lkuCustomer.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow;
            this.lkuCustomer.Properties.Appearance.Options.UseBackColor = true;
            this.lkuCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkuCustomer.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Number", "编号", 53, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "姓名", 41, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lkuCustomer.Properties.DataSource = this.bsCustomer;
            this.lkuCustomer.Properties.DisplayMember = "Number";
            this.lkuCustomer.Properties.DropDownRows = 10;
            this.lkuCustomer.Properties.NullText = "请选择客户";
            this.lkuCustomer.Properties.ShowFooter = false;
            this.lkuCustomer.Properties.ValueMember = "Id";
            this.lkuCustomer.Size = new System.Drawing.Size(297, 20);
            this.lkuCustomer.StyleController = this.layoutControl1;
            this.lkuCustomer.TabIndex = 4;
            // 
            // bsCustomer
            // 
            this.bsCustomer.DataSource = typeof(Phoebe.Model.Customer);
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
            this.layoutControlItem8});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(387, 292);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lkuCustomer;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(367, 24);
            this.layoutControlItem1.Text = "客户选择";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(63, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cmbIceType;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(367, 24);
            this.layoutControlItem2.Text = "冰块类型";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(63, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.spCount;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(367, 24);
            this.layoutControlItem3.Text = "售出数量";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(63, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.spWeight;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(367, 24);
            this.layoutControlItem4.Text = "售出重量(t)";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(63, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.spFee;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(367, 24);
            this.layoutControlItem5.Text = "金额(元)";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(63, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.dpTime;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(367, 24);
            this.layoutControlItem6.Text = "售出日期";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(63, 14);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtUser;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 144);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(367, 24);
            this.layoutControlItem7.Text = "操作员";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(63, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtRemark;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 168);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(367, 104);
            this.layoutControlItem8.Text = "备注";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(63, 14);
            // 
            // IceSellForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 378);
            this.Name = "IceSellForm";
            this.Text = "冰块售出";
            this.Load += new System.EventHandler(this.IceSellForm_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.dpTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spFee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbIceType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkuCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.ImageComboBoxEdit cmbIceType;
        private DevExpress.XtraEditors.LookUpEdit lkuCustomer;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SpinEdit spFee;
        private DevExpress.XtraEditors.SpinEdit spWeight;
        private DevExpress.XtraEditors.SpinEdit spCount;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.DateEdit dpTime;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.TextEdit txtUser;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private System.Windows.Forms.BindingSource bsCustomer;
    }
}