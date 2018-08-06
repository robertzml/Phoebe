namespace Phoebe.ClientDx
{
    partial class FrmUserGroupList
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
            this.userGroupGrid = new Phoebe.ClientDx.UserGroupGrid();
            this.SuspendLayout();
            // 
            // userGroupGrid
            // 
            this.userGroupGrid.AllowFilter = false;
            this.userGroupGrid.AllowGroup = false;
            this.userGroupGrid.AllowSort = false;
            this.userGroupGrid.DataSource = null;
            this.userGroupGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userGroupGrid.Editable = false;
            this.userGroupGrid.EnableMasterView = false;
            this.userGroupGrid.EnableMultiSelect = true;
            this.userGroupGrid.Location = new System.Drawing.Point(0, 0);
            this.userGroupGrid.Name = "userGroupGrid";
            this.userGroupGrid.ShowAddMenu = false;
            this.userGroupGrid.ShowDeleteMenu = false;
            this.userGroupGrid.ShowEditMenu = false;
            this.userGroupGrid.ShowFooter = false;
            this.userGroupGrid.ShowLineNumber = true;
            this.userGroupGrid.ShowMenu = false;
            this.userGroupGrid.ShowNavigator = false;
            this.userGroupGrid.Size = new System.Drawing.Size(770, 467);
            this.userGroupGrid.TabIndex = 0;
            // 
            // FrmUserGroupList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 467);
            this.Controls.Add(this.userGroupGrid);
            this.Name = "FrmUserGroupList";
            this.Text = "用户组列表";
            this.ResumeLayout(false);

        }

        #endregion

        private UserGroupGrid userGroupGrid;
    }
}