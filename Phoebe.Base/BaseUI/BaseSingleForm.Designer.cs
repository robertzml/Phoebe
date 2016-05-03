namespace Phoebe.Base
{
    partial class BaseSingleForm
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
            this.plFill = new DevExpress.XtraEditors.PanelControl();
            this.plBottom = new DevExpress.XtraEditors.PanelControl();
            this.btnCanel = new DevExpress.XtraEditors.SimpleButton();
            this.btnConfirm = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.plFill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plBottom)).BeginInit();
            this.plBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // plFill
            // 
            this.plFill.Appearance.BackColor = System.Drawing.Color.White;
            this.plFill.Appearance.Options.UseBackColor = true;
            this.plFill.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.plFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plFill.Location = new System.Drawing.Point(0, 0);
            this.plFill.Name = "plFill";
            this.plFill.Size = new System.Drawing.Size(430, 285);
            this.plFill.TabIndex = 0;
            // 
            // plBottom
            // 
            this.plBottom.Appearance.BackColor = System.Drawing.Color.White;
            this.plBottom.Appearance.Options.UseBackColor = true;
            this.plBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.plBottom.Controls.Add(this.btnCanel);
            this.plBottom.Controls.Add(this.btnConfirm);
            this.plBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plBottom.Location = new System.Drawing.Point(0, 285);
            this.plBottom.Name = "plBottom";
            this.plBottom.Size = new System.Drawing.Size(430, 63);
            this.plBottom.TabIndex = 1;
            // 
            // btnCanel
            // 
            this.btnCanel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCanel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCanel.Location = new System.Drawing.Point(306, 19);
            this.btnCanel.Name = "btnCanel";
            this.btnCanel.Size = new System.Drawing.Size(87, 27);
            this.btnCanel.TabIndex = 1;
            this.btnCanel.Text = "取消";
            // 
            // btnConfirm
            // 
            this.btnConfirm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(190, 19);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(87, 27);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "确定";
            // 
            // BaseSingleForm
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCanel;
            this.ClientSize = new System.Drawing.Size(430, 348);
            this.Controls.Add(this.plFill);
            this.Controls.Add(this.plBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BaseSingleForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BaseSingleForm";
            ((System.ComponentModel.ISupportInitialize)(this.plFill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plBottom)).EndInit();
            this.plBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraEditors.PanelControl plFill;
        protected DevExpress.XtraEditors.PanelControl plBottom;
        protected DevExpress.XtraEditors.SimpleButton btnCanel;
        protected DevExpress.XtraEditors.SimpleButton btnConfirm;
    }
}