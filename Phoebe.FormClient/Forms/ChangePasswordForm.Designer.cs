namespace Phoebe.FormClient
{
    partial class ChangePasswordForm
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtOldPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtNewPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtConfirmPassword = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.plFill)).BeginInit();
            this.plFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plBottom)).BeginInit();
            this.plBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // plFill
            // 
            this.plFill.Appearance.BackColor = System.Drawing.Color.White;
            this.plFill.Appearance.Options.UseBackColor = true;
            this.plFill.Controls.Add(this.txtConfirmPassword);
            this.plFill.Controls.Add(this.txtNewPassword);
            this.plFill.Controls.Add(this.txtOldPassword);
            this.plFill.Controls.Add(this.labelControl3);
            this.plFill.Controls.Add(this.labelControl2);
            this.plFill.Controls.Add(this.labelControl1);
            this.plFill.Size = new System.Drawing.Size(355, 160);
            // 
            // plBottom
            // 
            this.plBottom.Appearance.BackColor = System.Drawing.Color.White;
            this.plBottom.Appearance.Options.UseBackColor = true;
            this.plBottom.Location = new System.Drawing.Point(0, 160);
            this.plBottom.Size = new System.Drawing.Size(355, 63);
            // 
            // btnCanel
            // 
            this.btnCanel.Location = new System.Drawing.Point(231, 19);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(115, 19);
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(49, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "原密码";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(49, 69);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "新密码";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(37, 110);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "密码确认";
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Location = new System.Drawing.Point(108, 25);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.Properties.PasswordChar = '*';
            this.txtOldPassword.Size = new System.Drawing.Size(198, 20);
            this.txtOldPassword.TabIndex = 3;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(108, 66);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Properties.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(198, 20);
            this.txtNewPassword.TabIndex = 4;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(108, 107);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Properties.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(198, 20);
            this.txtConfirmPassword.TabIndex = 5;
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 223);
            this.Name = "ChangePasswordForm";
            this.Text = "修改密码";
            ((System.ComponentModel.ISupportInitialize)(this.plFill)).EndInit();
            this.plFill.ResumeLayout(false);
            this.plFill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plBottom)).EndInit();
            this.plBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtConfirmPassword;
        private DevExpress.XtraEditors.TextEdit txtNewPassword;
        private DevExpress.XtraEditors.TextEdit txtOldPassword;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}