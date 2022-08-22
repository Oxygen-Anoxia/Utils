
namespace LDAP_Winform
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCheck = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.txtLDAP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLUserName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLPwd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(121, 315);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(130, 48);
            this.btnCheck.TabIndex = 0;
            this.btnCheck.Text = "btnCheck";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(121, 70);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(194, 23);
            this.txtUserName.TabIndex = 1;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(121, 26);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(194, 23);
            this.txtFilter.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "UserName:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "txtFilter：";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(121, 114);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(194, 23);
            this.txtPwd.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "txtPwd:";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(337, 26);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(339, 266);
            this.txtLog.TabIndex = 1;
            // 
            // txtLDAP
            // 
            this.txtLDAP.Location = new System.Drawing.Point(121, 165);
            this.txtLDAP.Name = "txtLDAP";
            this.txtLDAP.Size = new System.Drawing.Size(194, 23);
            this.txtLDAP.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "txtLDAP：";
            // 
            // txtLUserName
            // 
            this.txtLUserName.Location = new System.Drawing.Point(121, 212);
            this.txtLUserName.Name = "txtLUserName";
            this.txtLUserName.Size = new System.Drawing.Size(194, 23);
            this.txtLUserName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "txtLUserName：";
            // 
            // txtLPwd
            // 
            this.txtLPwd.Location = new System.Drawing.Point(121, 269);
            this.txtLPwd.Name = "txtLPwd";
            this.txtLPwd.Size = new System.Drawing.Size(194, 23);
            this.txtLPwd.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 272);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "txtLPwd：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 384);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtLPwd);
            this.Controls.Add(this.txtLUserName);
            this.Controls.Add(this.txtLDAP);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.btnCheck);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox txtLDAP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLUserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLPwd;
        private System.Windows.Forms.Label label6;
    }
}

