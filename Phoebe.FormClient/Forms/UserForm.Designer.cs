namespace Phoebe.FormClient
{
    partial class UserForm
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
            this.dgcUser = new DevExpress.XtraGrid.GridControl();
            this.dgvUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bsUser = new System.Windows.Forms.BindingSource(this.components);
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserGroupId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastLoginTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentLoginTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnEnable = new DevExpress.XtraEditors.SimpleButton();
            this.btnDisable = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgcUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dgcUser);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 85);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(793, 380);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "用户";
            // 
            // dgcUser
            // 
            this.dgcUser.DataSource = this.bsUser;
            this.dgcUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcUser.Location = new System.Drawing.Point(2, 21);
            this.dgcUser.MainView = this.dgvUser;
            this.dgcUser.Name = "dgcUser";
            this.dgcUser.Size = new System.Drawing.Size(789, 357);
            this.dgcUser.TabIndex = 0;
            this.dgcUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvUser});
            // 
            // dgvUser
            // 
            this.dgvUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colUserName,
            this.colUserGroupId,
            this.colName,
            this.colLastLoginTime,
            this.colCurrentLoginTime,
            this.colRemark,
            this.colStatus});
            this.dgvUser.GridControl = this.dgcUser;
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvUser.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvUser.OptionsBehavior.Editable = false;
            this.dgvUser.OptionsCustomization.AllowGroup = false;
            this.dgvUser.OptionsCustomization.AllowQuickHideColumns = false;
            this.dgvUser.OptionsFind.AllowFindPanel = false;
            this.dgvUser.OptionsMenu.EnableColumnMenu = false;
            this.dgvUser.OptionsMenu.EnableFooterMenu = false;
            this.dgvUser.OptionsMenu.EnableGroupPanelMenu = false;
            this.dgvUser.OptionsView.ShowGroupPanel = false;
            this.dgvUser.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.dgvUser_CustomColumnDisplayText);
            // 
            // bsUser
            // 
            this.bsUser.DataSource = typeof(Phoebe.Model.User);
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsFilter.AllowFilter = false;
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            // 
            // colUserName
            // 
            this.colUserName.Caption = "用户名";
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.OptionsFilter.AllowFilter = false;
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 1;
            // 
            // colUserGroupId
            // 
            this.colUserGroupId.AppearanceCell.Options.UseTextOptions = true;
            this.colUserGroupId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colUserGroupId.AppearanceHeader.Options.UseTextOptions = true;
            this.colUserGroupId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colUserGroupId.Caption = "用户组";
            this.colUserGroupId.FieldName = "UserGroupId";
            this.colUserGroupId.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colUserGroupId.Name = "colUserGroupId";
            this.colUserGroupId.Visible = true;
            this.colUserGroupId.VisibleIndex = 2;
            // 
            // colName
            // 
            this.colName.Caption = "姓名";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsFilter.AllowFilter = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 3;
            // 
            // colLastLoginTime
            // 
            this.colLastLoginTime.Caption = "上次登录时间";
            this.colLastLoginTime.DisplayFormat.FormatString = "yyyy/MM/dd HH:mm:ss";
            this.colLastLoginTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colLastLoginTime.FieldName = "LastLoginTime";
            this.colLastLoginTime.Name = "colLastLoginTime";
            this.colLastLoginTime.OptionsFilter.AllowFilter = false;
            this.colLastLoginTime.Visible = true;
            this.colLastLoginTime.VisibleIndex = 4;
            // 
            // colCurrentLoginTime
            // 
            this.colCurrentLoginTime.Caption = "本次登录时间";
            this.colCurrentLoginTime.DisplayFormat.FormatString = "yyyy/MM/dd HH:mm:ss";
            this.colCurrentLoginTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCurrentLoginTime.FieldName = "CurrentLoginTime";
            this.colCurrentLoginTime.Name = "colCurrentLoginTime";
            this.colCurrentLoginTime.OptionsFilter.AllowFilter = false;
            this.colCurrentLoginTime.Visible = true;
            this.colCurrentLoginTime.VisibleIndex = 5;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.OptionsFilter.AllowFilter = false;
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 6;
            // 
            // colStatus
            // 
            this.colStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colStatus.Caption = "状态";
            this.colStatus.FieldName = "Status";
            this.colStatus.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 7;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnDisable);
            this.groupControl2.Controls.Add(this.btnEnable);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(793, 85);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "操作";
            // 
            // btnEnable
            // 
            this.btnEnable.Location = new System.Drawing.Point(39, 40);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(75, 23);
            this.btnEnable.TabIndex = 0;
            this.btnEnable.Text = "启用";
            this.btnEnable.Visible = false;
            this.btnEnable.Click += new System.EventHandler(this.btnEnable_Click);
            // 
            // btnDisable
            // 
            this.btnDisable.Location = new System.Drawing.Point(138, 40);
            this.btnDisable.Name = "btnDisable";
            this.btnDisable.Size = new System.Drawing.Size(75, 23);
            this.btnDisable.TabIndex = 1;
            this.btnDisable.Text = "禁用";
            this.btnDisable.Visible = false;
            this.btnDisable.Click += new System.EventHandler(this.btnDisable_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 465);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControl2);
            this.Name = "UserForm";
            this.Text = "用户列表";
            this.Load += new System.EventHandler(this.UserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgcUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl dgcUser;
        private System.Windows.Forms.BindingSource bsUser;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvUser;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colUserGroupId;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastLoginTime;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentLoginTime;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnDisable;
        private DevExpress.XtraEditors.SimpleButton btnEnable;
    }
}