﻿namespace Phoebe.ClientDx
{
    partial class CustomerLookup
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.sluCustomer = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.bsCustomer = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelephone = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.sluCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // sluCustomer
            // 
            this.sluCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sluCustomer.Location = new System.Drawing.Point(0, 0);
            this.sluCustomer.Name = "sluCustomer";
            this.sluCustomer.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow;
            this.sluCustomer.Properties.Appearance.Options.UseBackColor = true;
            this.sluCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sluCustomer.Properties.DataSource = this.bsCustomer;
            this.sluCustomer.Properties.DisplayMember = "Name";
            this.sluCustomer.Properties.NullText = "请选择客户";
            this.sluCustomer.Properties.PopupView = this.searchLookUpEdit1View;
            this.sluCustomer.Properties.ValueMember = "Id";
            this.sluCustomer.Size = new System.Drawing.Size(302, 20);
            this.sluCustomer.TabIndex = 0;
            this.sluCustomer.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.sluCustomer_CustomDisplayText);
            // 
            // bsCustomer
            // 
            this.bsCustomer.DataSource = typeof(Phoebe.Core.DL.Customer);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colNumber,
            this.colName,
            this.colTelephone});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsBehavior.Editable = false;
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colNumber
            // 
            this.colNumber.Caption = "客户编号";
            this.colNumber.FieldName = "Number";
            this.colNumber.Name = "colNumber";
            this.colNumber.Visible = true;
            this.colNumber.VisibleIndex = 0;
            // 
            // colName
            // 
            this.colName.Caption = "客户名称";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // colTelephone
            // 
            this.colTelephone.FieldName = "Telephone";
            this.colTelephone.Name = "colTelephone";
            this.colTelephone.Visible = true;
            this.colTelephone.VisibleIndex = 2;
            // 
            // CustomerLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sluCustomer);
            this.Name = "CustomerLookup";
            this.Size = new System.Drawing.Size(302, 20);
            ((System.ComponentModel.ISupportInitialize)(this.sluCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SearchLookUpEdit sluCustomer;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private System.Windows.Forms.BindingSource bsCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colTelephone;
    }
}
