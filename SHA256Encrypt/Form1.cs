using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHA256Encrypt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tenantId = this.txt_tenantId.Text.Trim();
            string userId = this.txt_userId.Text.Trim();
            string password = this.txt_password.Text.Trim();
            string vscode = this.txt_vscode.Text.Trim();

            #region 为空验证
            if (string.IsNullOrEmpty(tenantId))
            {
                MessageBox.Show("数据不能为空！");
                this.txt_tenantId.Select();
                return;
            }
            if (string.IsNullOrEmpty(userId))
            {
                MessageBox.Show("数据不能为空！");
                this.txt_userId.Select();
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("数据不能为空！");
                this.txt_password.Select();
                return;
            }
            if (string.IsNullOrEmpty(vscode))
            {
                MessageBox.Show("数据不能为空！");
                this.txt_vscode.Select();
                return;
            }
            #endregion

            string JiaMI = tenantId + userId + password + vscode;
            string res = SHA256EncryptString(JiaMI);
            this.textBox2.Text = res;
        }

        /// <summary>
        /// SHA256加密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        static string SHA256EncryptString(string data)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            byte[] hash = SHA256Managed.Create().ComputeHash(bytes);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                builder.Append(hash[i].ToString("x2"));
            }
            return builder.ToString();
        }


    }
}
