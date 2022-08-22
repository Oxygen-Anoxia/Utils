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

namespace AES
{
    public partial class AESfrmFQ : Form
    {
        public AESfrmFQ()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string json = this.textBox1.Text.Trim();
            this.textBox2.Text = AES.JiangSuFuQiang.Help.ToEncryptAes(json.ToString(), "HAYJJWWYTSJJHMYH", CipherMode.CBC, PaddingMode.PKCS7);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = this.textBox2.Text;
            var jm = AES.JiangSuFuQiang.Help.AesDecrypt(str, "HAYJJWWYTSJJHMYH");
            this.textBox1.Text = jm;
        }
    }
}
