namespace Phoebe.FormClient
{
    partial class UserGroupForm
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
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.dgcUserGroup = new DevExpress.XtraGrid.GridControl();
            this.dgvUserGroup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bsUserGroup = new System.Windows.Forms.BindingSource(this.components);
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRank = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgcUserGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUserGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.dgcUserGroup);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(793, 465);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "用户组";
            // 
            // dgcUserGroup
            // 
            this.dgcUserGroup.DataSource = this.bsUserGroup;
            this.dgcUserGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcUserGroup.Location = new System.Drawing.Point(2, 21);
            this.dgcUserGroup.MainView = this.dgvUserGroup;
            this.dgcUserGroup.Name = "dgcUserGroup";
            this.dgcUserGroup.Size = new System.Drawing.Size(789, 442);
            this.dgcUserGroup.TabIndex = 0;
            this.dgcUserGroup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvUserGroup});
            // 
            // dgvUserGroup
            // 
            this.dgvUserGroup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colName,
            this.colTitle,
            this.colRank,
            this.colRemark,
            this.colStatus});
            this.dgvUserGroup.GridControl = this.dgcUserGroup;
            this.dgvUserGroup.Name = "dgvUserGroup";
            this.dgvUserGroup.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvUserGroup.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvUserGroup.OptionsBehavior.Editable = false;
            this.dgvUserGroup.OptionsCustomization.AllowFilter = false;
            this.dgvUserGroup.OptionsCustomization.AllowGroup = false;
            this.dgvUserGroup.OptionsCustomization.AllowQuickHideColumns = false;
            this.dgvUserGroup.OptionsFilter.AllowFilterEditor = false;
            this.dgvUserGroup.OptionsFind.AllowFindPanel = false;
            this.dgvUserGroup.OptionsMenu.EnableColumnMenu = false;
            this.dgvUserGroup.OptionsMenu.EnableFooterMenu = false;
            this.dgvUserGroup.OptionsMenu.EnableGroupPanelMenu = false;
            this.dgvUserGroup.OptionsView.ShowGroupPanel = false;
            this.dgvUserGroup.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.dgvUserGroup_CustomColumnDisplayText);
            // 
            // bsUserGroup
            // 
            this.bsUserGroup.DataSource = typeof(Phoebe.Model.UserGroup);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            // 
            // colName
            // 
            this.colName.Caption = "代码";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // colTitle
            // 
            this.colTitle.Caption = "名称";
            this.colTitle.FieldName = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.Visible = true;
            this.colTitle.VisibleIndex = 2;
            // 
            // colRank
            // 
            this.colRank.Caption = "级别";
            this.colRank.FieldName = "Rank";
            this.colRank.Name = "colRank";
            this.colRank.Visible = true;
            this.colRank.VisibleIndex = 3;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 4;
            // 
            // colStatus
            // 
            this.colStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colStatus.Caption = "状态";
            this.colStatus.FieldName = "Status";
            this.colStatus.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 5;
            // 
            // UserGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 465);
            this.Controls.Add(this.groupControl2);
            this.Name = "UserGroupForm";
            this.Text = "用户组列表";
            this.Load += new System.EventHandler(this.UserGroupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgcUserGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUserGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl dgcUserGroup;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvUserGroup;
        private System.Windows.Forms.BindingSource bsUserGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colRank;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    }
}