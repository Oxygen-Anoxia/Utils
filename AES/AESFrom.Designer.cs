
namespace AES
{
    partial class AESFrom
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AESFrom));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAuthorization = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox2 = new System.Windows.Forms.RichTextBox();
            this.btnId = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 179);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 70);
            this.button1.TabIndex = 0;
            this.button1.Text = "AES加密";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(24, 267);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 70);
            this.button2.TabIndex = 0;
            this.button2.Text = "AES解密";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(24, 454);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 70);
            this.button3.TabIndex = 0;
            this.button3.Text = "AES+Base64加密";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(24, 542);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(98, 70);
            this.button4.TabIndex = 0;
            this.button4.Text = "AES+Base64解密";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Key:";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(151, 13);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(335, 21);
            this.txtKey.TabIndex = 3;
            this.txtKey.Text = "84702E415A73CE27077B5F726E7BDBB0";
            this.txtKey.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "IV:";
            // 
            // txtIV
            // 
            this.txtIV.Location = new System.Drawing.Point(151, 63);
            this.txtIV.Name = "txtIV";
            this.txtIV.Size = new System.Drawing.Size(335, 21);
            this.txtIV.TabIndex = 3;
            this.txtIV.Text = "1C7AA98593AA69F4AAE119BD5C01D9ED";
            this.txtIV.TextChanged += new System.EventHandler(this.txtIV_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(511, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "当前时间";
            // 
            // txtTime
            // 
            this.txtTime.Enabled = false;
            this.txtTime.Location = new System.Drawing.Point(513, 63);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(196, 21);
            this.txtTime.TabIndex = 3;
            this.txtTime.TextChanged += new System.EventHandler(this.txtTime_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "token:";
            // 
            // txtToken
            // 
            this.txtToken.Enabled = false;
            this.txtToken.Location = new System.Drawing.Point(151, 118);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(113, 21);
            this.txtToken.TabIndex = 3;
            this.txtToken.Text = "2702490990";
            this.txtToken.TextChanged += new System.EventHandler(this.txtToken_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(308, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "Authorization";
            // 
            // txtAuthorization
            // 
            this.txtAuthorization.Location = new System.Drawing.Point(424, 115);
            this.txtAuthorization.Name = "txtAuthorization";
            this.txtAuthorization.Size = new System.Drawing.Size(285, 21);
            this.txtAuthorization.TabIndex = 3;
            this.txtAuthorization.Text = "2702490990";
            this.txtAuthorization.TextChanged += new System.EventHandler(this.txtAuthorization_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(151, 179);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(558, 248);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(151, 445);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(558, 189);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // btnId
            // 
            this.btnId.Location = new System.Drawing.Point(151, 148);
            this.btnId.Name = "btnId";
            this.btnId.Size = new System.Drawing.Size(98, 25);
            this.btnId.TabIndex = 0;
            this.btnId.Text = "获取id";
            this.btnId.UseVisualStyleBackColor = true;
            this.btnId.Click += new System.EventHandler(this.btnId_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(268, 150);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(285, 21);
            this.txtId.TabIndex = 3;
            this.txtId.TextChanged += new System.EventHandler(this.txtId_TextChanged);
            // 
            // AESFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 663);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtAuthorization);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtToken);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnId);
            this.Controls.Add(this.button1);
            this.Name = "AESFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AES加密&解密";
            this.Load += new System.EventHandler(this.AESFrom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAuthorization;
        private System.Windows.Forms.RichTextBox textBox1;
        private System.Windows.Forms.RichTextBox textBox2;
        private System.Windows.Forms.Button btnId;
        private System.Windows.Forms.TextBox txtId;
    }
}