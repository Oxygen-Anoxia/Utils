
namespace LDAP_Winform
{
    partial class frmAD
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
            this.lblDomainName = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPwd = new System.Windows.Forms.Label();
            this.lblRootOU = new System.Windows.Forms.Label();
            this.txtDomainName = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtRootOU = new System.Windows.Forms.TextBox();
            this.btnSyns = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDomainName
            // 
            this.lblDomainName.AutoSize = true;
            this.lblDomainName.Location = new System.Drawing.Point(122, 82);
            this.lblDomainName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDomainName.Name = "lblDomainName";
            this.lblDomainName.Size = new System.Drawing.Size(44, 17);
            this.lblDomainName.TabIndex = 0;
            this.lblDomainName.Text = "域名：";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(104, 138);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(56, 17);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "用户名：";
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(116, 183);
            this.lblPwd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(44, 17);
            this.lblPwd.TabIndex = 2;
            this.lblPwd.Text = "密码：";
            // 
            // lblRootOU
            // 
            this.lblRootOU.AutoSize = true;
            this.lblRootOU.Location = new System.Drawing.Point(55, 241);
            this.lblRootOU.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRootOU.Name = "lblRootOU";
            this.lblRootOU.Size = new System.Drawing.Size(107, 17);
            this.lblRootOU.TabIndex = 3;
            this.lblRootOU.Text = "根组织单位(OU)：";
            // 
            // txtDomainName
            // 
            this.txtDomainName.Location = new System.Drawing.Point(177, 78);
            this.txtDomainName.Margin = new System.Windows.Forms.Padding(4);
            this.txtDomainName.Name = "txtDomainName";
            this.txtDomainName.Size = new System.Drawing.Size(233, 23);
            this.txtDomainName.TabIndex = 1;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(177, 183);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(4);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '•';
            this.txtPwd.Size = new System.Drawing.Size(233, 23);
            this.txtPwd.TabIndex = 3;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(177, 132);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(233, 23);
            this.txtUserName.TabIndex = 2;
            // 
            // txtRootOU
            // 
            this.txtRootOU.Location = new System.Drawing.Point(177, 238);
            this.txtRootOU.Margin = new System.Windows.Forms.Padding(4);
            this.txtRootOU.Name = "txtRootOU";
            this.txtRootOU.Size = new System.Drawing.Size(233, 23);
            this.txtRootOU.TabIndex = 4;
            // 
            // btnSyns
            // 
            this.btnSyns.Location = new System.Drawing.Point(323, 320);
            this.btnSyns.Margin = new System.Windows.Forms.Padding(4);
            this.btnSyns.Name = "btnSyns";
            this.btnSyns.Size = new System.Drawing.Size(88, 33);
            this.btnSyns.TabIndex = 8;
            this.btnSyns.Text = "同步";
            this.btnSyns.UseVisualStyleBackColor = true;
            this.btnSyns.Click += new System.EventHandler(this.btnSyns_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(177, 320);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 33);
            this.button1.TabIndex = 8;
            this.button1.Text = "本地测试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmAD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 400);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSyns);
            this.Controls.Add(this.txtRootOU);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtDomainName);
            this.Controls.Add(this.lblRootOU);
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblDomainName);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AD域同步";
            this.Load += new System.EventHandler(this.frmAD_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDomainName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.Label lblRootOU;
        private System.Windows.Forms.TextBox txtDomainName;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtRootOU;
        private System.Windows.Forms.Button btnSyns;
        private System.Windows.Forms.Button button1;
    }
}