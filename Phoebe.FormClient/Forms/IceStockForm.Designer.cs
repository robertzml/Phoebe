namespace Phoebe.FormClient
{
    partial class IceStockForm
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
            this.dpFlowTime = new DevExpress.XtraEditors.DateEdit();
            this.spFlowWeight = new DevExpress.XtraEditors.SpinEdit();
            this.spFlowCount = new DevExpress.XtraEditors.SpinEdit();
            this.txtIceType = new DevExpress.XtraEditors.TextEdit();
            this.txtFlowType = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.dpFlowTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFlowTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spFlowWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spFlowCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIceType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFlowType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // plFill
            // 
            this.plFill.Appearance.BackColor = System.Drawing.Color.White;
            this.plFill.Appearance.Options.UseBackColor = true;
            this.plFill.Controls.Add(this.groupControl1);
            this.plFill.Size = new System.Drawing.Size(356, 285);
            // 
            // plBottom
            // 
            this.plBottom.Appearance.BackColor = System.Drawing.Color.White;
            this.plBottom.Appearance.Options.UseBackColor = true;
            this.plBottom.Size = new System.Drawing.Size(356, 63);
            // 
            // btnCanel
            // 
            this.btnCanel.Location = new System.Drawing.Point(255, 18);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(148, 18);
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(356, 285);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "库存操作";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtRemark);
            this.layoutControl1.Controls.Add(this.txtUser);
            this.layoutControl1.Controls.Add(this.dpFlowTime);
            this.layoutControl1.Controls.Add(this.spFlowWeight);
            this.layoutControl1.Controls.Add(this.spFlowCount);
            this.layoutControl1.Controls.Add(this.txtIceType);
            this.layoutControl1.Controls.Add(this.txtFlowType);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 21);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(352, 262);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(78, 156);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(262, 94);
            this.txtRemark.StyleController = this.layoutControl1;
            this.txtRemark.TabIndex = 10;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(78, 132);
            this.txtUser.Name = "txtUser";
            this.txtUser.Properties.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.txtUser.Properties.Appearance.Options.UseBackColor = true;
            this.txtUser.Properties.ReadOnly = true;
            this.txtUser.Size = new System.Drawing.Size(262, 20);
            this.txtUser.StyleController = this.layoutControl1;
            this.txtUser.TabIndex = 9;
            // 
            // dpFlowTime
            // 
            this.dpFlowTime.EditValue = null;
            this.dpFlowTime.Location = new System.Drawing.Point(78, 108);
            this.dpFlowTime.Name = "dpFlowTime";
            this.dpFlowTime.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dpFlowTime.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow;
            this.dpFlowTime.Properties.Appearance.Options.UseBackColor = true;
            this.dpFlowTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFlowTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFlowTime.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dpFlowTime.Size = new System.Drawing.Size(262, 20);
            this.dpFlowTime.StyleController = this.layoutControl1;
            this.dpFlowTime.TabIndex = 8;
            // 
            // spFlowWeight
            // 
            this.spFlowWeight.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spFlowWeight.Location = new System.Drawing.Point(78, 84);
            this.spFlowWeight.Name = "spFlowWeight";
            this.spFlowWeight.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow;
            this.spFlowWeight.Properties.Appearance.Options.UseBackColor = true;
            this.spFlowWeight.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spFlowWeight.Properties.Mask.EditMask = "n3";
            this.spFlowWeight.Properties.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.spFlowWeight.Size = new System.Drawing.Size(262, 20);
            this.spFlowWeight.StyleController = this.layoutControl1;
            this.spFlowWeight.TabIndex = 7;
            // 
            // spFlowCount
            // 
            this.spFlowCount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spFlowCount.Location = new System.Drawing.Point(78, 60);
            this.spFlowCount.Name = "spFlowCount";
            this.spFlowCount.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow;
            this.spFlowCount.Properties.Appearance.Options.UseBackColor = true;
            this.spFlowCount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spFlowCount.Properties.IsFloatValue = false;
            this.spFlowCount.Properties.Mask.EditMask = "N00";
            this.spFlowCount.Properties.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.spFlowCount.Size = new System.Drawing.Size(262, 20);
            this.spFlowCount.StyleController = this.layoutControl1;
            this.spFlowCount.TabIndex = 6;
            // 
            // txtIceType
            // 
            this.txtIceType.Location = new System.Drawing.Point(78, 36);
            this.txtIceType.Name = "txtIceType";
            this.txtIceType.Properties.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.txtIceType.Properties.Appearance.Options.UseBackColor = true;
            this.txtIceType.Properties.ReadOnly = true;
            this.txtIceType.Size = new System.Drawing.Size(262, 20);
            this.txtIceType.StyleController = this.layoutControl1;
            this.txtIceType.TabIndex = 5;
            // 
            // txtFlowType
            // 
            this.txtFlowType.Location = new System.Drawing.Point(78, 12);
            this.txtFlowType.Name = "txtFlowType";
            this.txtFlowType.Properties.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.txtFlowType.Properties.Appearance.Options.UseBackColor = true;
            this.txtFlowType.Properties.ReadOnly = true;
            this.txtFlowType.Size = new System.Drawing.Size(262, 20);
            this.txtFlowType.StyleController = this.layoutControl1;
            this.txtFlowType.TabIndex = 4;
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
            this.layoutControlItem7});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(352, 262);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtFlowType;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(332, 24);
            this.layoutControlItem1.Text = "流水类型";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(63, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtIceType;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(332, 24);
            this.layoutControlItem2.Text = "冰块类型";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(63, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.spFlowCount;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(332, 24);
            this.layoutControlItem3.Text = "流水数量";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(63, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.spFlowWeight;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(332, 24);
            this.layoutControlItem4.Text = "流水重量(t)";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(63, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.dpFlowTime;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(332, 24);
            this.layoutControlItem5.Text = "日期";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(63, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtUser;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(332, 24);
            this.layoutControlItem6.Text = "操作人";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(63, 14);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtRemark;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 144);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(332, 98);
            this.layoutControlItem7.Text = "备注";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(63, 14);
            // 
            // IceStockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 348);
            this.Name = "IceStockForm";
            this.Text = "IceStockForm";
            this.Load += new System.EventHandler(this.IceStockForm_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.dpFlowTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFlowTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spFlowWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spFlowCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIceType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFlowType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private DevExpress.XtraEditors.TextEdit txtUser;
        private DevExpress.XtraEditors.DateEdit dpFlowTime;
        private DevExpress.XtraEditors.SpinEdit spFlowWeight;
        private DevExpress.XtraEditors.SpinEdit spFlowCount;
        private DevExpress.XtraEditors.TextEdit txtIceType;
        private DevExpress.XtraEditors.TextEdit txtFlowType;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}