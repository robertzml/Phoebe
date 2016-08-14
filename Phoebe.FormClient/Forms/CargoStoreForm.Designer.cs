namespace Phoebe.FormClient
{
    partial class CargoStoreForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnFindStore = new DevExpress.XtraEditors.SimpleButton();
            this.btnFindCargo = new DevExpress.XtraEditors.SimpleButton();
            this.cmbContract = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.lkuCustomer = new DevExpress.XtraEditors.LookUpEdit();
            this.bsCustomer = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.cgList = new Phoebe.FormClient.CargoGrid();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.sgList = new Phoebe.FormClient.StoreGrid();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbContract.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkuCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupControl3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1099, 742);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 4);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1093, 172);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "选择";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnFindStore);
            this.layoutControl1.Controls.Add(this.btnFindCargo);
            this.layoutControl1.Controls.Add(this.cmbContract);
            this.layoutControl1.Controls.Add(this.lkuCustomer);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 25);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1089, 145);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnFindStore
            // 
            this.btnFindStore.Location = new System.Drawing.Point(851, 42);
            this.btnFindStore.Name = "btnFindStore";
            this.btnFindStore.Size = new System.Drawing.Size(224, 27);
            this.btnFindStore.StyleController = this.layoutControl1;
            this.btnFindStore.TabIndex = 7;
            this.btnFindStore.Text = "查询库存";
            this.btnFindStore.Click += new System.EventHandler(this.btnFindStore_Click);
            // 
            // btnFindCargo
            // 
            this.btnFindCargo.Location = new System.Drawing.Point(625, 42);
            this.btnFindCargo.Name = "btnFindCargo";
            this.btnFindCargo.Size = new System.Drawing.Size(222, 27);
            this.btnFindCargo.StyleController = this.layoutControl1;
            this.btnFindCargo.TabIndex = 6;
            this.btnFindCargo.Text = "查询货品";
            this.btnFindCargo.Click += new System.EventHandler(this.btnFindCargo_Click);
            // 
            // cmbContract
            // 
            this.cmbContract.Location = new System.Drawing.Point(688, 14);
            this.cmbContract.Name = "cmbContract";
            this.cmbContract.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbContract.Size = new System.Drawing.Size(387, 24);
            this.cmbContract.StyleController = this.layoutControl1;
            this.cmbContract.TabIndex = 5;
            // 
            // lkuCustomer
            // 
            this.lkuCustomer.Location = new System.Drawing.Point(77, 14);
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
            this.lkuCustomer.Size = new System.Drawing.Size(544, 24);
            this.lkuCustomer.StyleController = this.layoutControl1;
            this.lkuCustomer.TabIndex = 4;
            this.lkuCustomer.EditValueChanged += new System.EventHandler(this.lkuCustomer_EditValueChanged);
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
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1089, 145);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lkuCustomer;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(611, 121);
            this.layoutControlItem1.Text = "客户选择";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(60, 18);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cmbContract;
            this.layoutControlItem2.Location = new System.Drawing.Point(611, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(454, 28);
            this.layoutControlItem2.Text = "所属合同";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(60, 18);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnFindCargo;
            this.layoutControlItem3.Location = new System.Drawing.Point(611, 28);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(226, 93);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnFindStore;
            this.layoutControlItem4.Location = new System.Drawing.Point(837, 28);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(228, 93);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.cgList);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(3, 184);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1093, 273);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "货品列表";
            // 
            // cgList
            // 
            this.cgList.DataSource = null;
            this.cgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgList.EnableFind = true;
            this.cgList.EnableGroup = false;
            this.cgList.Location = new System.Drawing.Point(2, 25);
            this.cgList.Margin = new System.Windows.Forms.Padding(5);
            this.cgList.Name = "cgList";
            this.cgList.ShowFooter = false;
            this.cgList.Size = new System.Drawing.Size(1089, 246);
            this.cgList.TabIndex = 0;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.sgList);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(3, 465);
            this.groupControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(1093, 273);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "库存信息";
            // 
            // sgList
            // 
            this.sgList.DataSource = null;
            this.sgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sgList.EnableColumn = true;
            this.sgList.EnableFilter = true;
            this.sgList.EnableFind = false;
            this.sgList.EnableGroup = false;
            this.sgList.Location = new System.Drawing.Point(2, 25);
            this.sgList.Margin = new System.Windows.Forms.Padding(5);
            this.sgList.Name = "sgList";
            this.sgList.ShowContract = false;
            this.sgList.ShowCustomer = false;
            this.sgList.ShowFooter = true;
            this.sgList.Size = new System.Drawing.Size(1089, 246);
            this.sgList.TabIndex = 0;
            // 
            // CargoStoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 742);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "CargoStoreForm";
            this.Text = "货品库存";
            this.Load += new System.EventHandler(this.CargoStoreForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbContract.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkuCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.LookUpEdit lkuCustomer;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.ImageComboBoxEdit cmbContract;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.BindingSource bsCustomer;
        private DevExpress.XtraEditors.SimpleButton btnFindCargo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private CargoGrid cgList;
        private DevExpress.XtraEditors.SimpleButton btnFindStore;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private StoreGrid sgList;
    }
}