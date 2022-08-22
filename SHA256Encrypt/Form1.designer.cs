
namespace SHA256Encrypt
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_tenantId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_userId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_vscode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(30, 196);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(519, 213);
            this.textBox2.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(356, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 144);
            this.button1.TabIndex = 3;
            this.button1.Text = "加密";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "租户：";
            // 
            // txt_tenantId
            // 
            this.txt_tenantId.Location = new System.Drawing.Point(92, 25);
            this.txt_tenantId.Name = "txt_tenantId";
            this.txt_tenantId.Size = new System.Drawing.Size(245, 21);
            this.txt_tenantId.TabIndex = 6;
            this.txt_tenantId.Text = "sc20010007";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "账号：";
            // 
            // txt_userId
            // 
            this.txt_userId.Location = new System.Drawing.Point(92, 66);
            this.txt_userId.Name = "txt_userId";
            this.txt_userId.Size = new System.Drawing.Size(245, 21);
            this.txt_userId.TabIndex = 6;
            this.txt_userId.Text = "jpys";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "密码：";
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(92, 107);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(245, 21);
            this.txt_password.TabIndex = 6;
            this.txt_password.Text = "123456";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "vscode：";
            // 
            // txt_vscode
            // 
            this.txt_vscode.Location = new System.Drawing.Point(92, 148);
            this.txt_vscode.Name = "txt_vscode";
            this.txt_vscode.Size = new System.Drawing.Size(245, 21);
            this.txt_vscode.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 425);
            this.Controls.Add(this.txt_vscode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_userId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_tenantId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_tenantId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_userId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_vscode;
    }
}

