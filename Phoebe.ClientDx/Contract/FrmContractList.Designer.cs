namespace Phoebe.ClientDx
{
    partial class FrmContractList
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.contractGrid = new Phoebe.ClientDx.ContractGrid();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnForceDelete = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(892, 542);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnForceDelete);
            this.groupControl1.Controls.Add(this.btnDelete);
            this.groupControl1.Controls.Add(this.btnEdit);
            this.groupControl1.Controls.Add(this.btnAdd);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(886, 94);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "操作";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(36, 38);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(97, 34);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "添加合同";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.contractGrid);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(3, 103);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(886, 436);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "合同列表";
            // 
            // contractGrid
            // 
            this.contractGrid.AllowFilter = true;
            this.contractGrid.AllowGroup = true;
            this.contractGrid.AllowSort = true;
            this.contractGrid.DataSource = null;
            this.contractGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contractGrid.Editable = false;
            this.contractGrid.EnableMasterView = false;
            this.contractGrid.EnableMultiSelect = true;
            this.contractGrid.Location = new System.Drawing.Point(2, 21);
            this.contractGrid.Name = "contractGrid";
            this.contractGrid.ShowAddMenu = false;
            this.contractGrid.ShowDeleteMenu = false;
            this.contractGrid.ShowEditMenu = false;
            this.contractGrid.ShowFindPanel = true;
            this.contractGrid.ShowFooter = true;
            this.contractGrid.ShowLineNumber = true;
            this.contractGrid.ShowMenu = false;
            this.contractGrid.ShowNavigator = false;
            this.contractGrid.Size = new System.Drawing.Size(882, 413);
            this.contractGrid.TabIndex = 0;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(169, 38);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(97, 34);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "编辑合同";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(302, 38);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(97, 34);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除合同";
            // 
            // btnForceDelete
            // 
            this.btnForceDelete.Location = new System.Drawing.Point(435, 38);
            this.btnForceDelete.Name = "btnForceDelete";
            this.btnForceDelete.Size = new System.Drawing.Size(97, 34);
            this.btnForceDelete.TabIndex = 3;
            this.btnForceDelete.Text = "强制删除合同";
            // 
            // FrmContractList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 542);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmContractList";
            this.Text = "合同列表";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private ContractGrid contractGrid;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnForceDelete;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
    }
}