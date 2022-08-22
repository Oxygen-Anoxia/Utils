using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldToSql
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            var key = richBox_Key.Text;
            var vi = richBox_IV.Text;
            if (radioButton1.Checked)//不处理key
            {
                if (!string.IsNullOrWhiteSpace(richTextBox1.Text))
                {
                    var msg = AesGcm256Util.encrypt(richTextBox1.Text, key, vi);//加密
                    richTextBox2.Text = msg;
                }
                if (!string.IsNullOrWhiteSpace(richTextBox2.Text))
                {
                    var msg = AesGcm256Util.decrypt(richTextBox2.Text, key, vi);//解密
                    richTextBox1.Text = msg;
                }
            }
            if (radioButton2.Checked)//处理key
            {
                if (!string.IsNullOrWhiteSpace(richTextBox1.Text))
                {
                    var msg = AesGcm256Util.encrypt(richTextBox1.Text, AesGcm256Util.hexToByte(key), AesGcm256Util.hexToByte(vi));//加密
                    richTextBox2.Text = msg;
                }
                if (!string.IsNullOrWhiteSpace(richTextBox2.Text))
                {
                    var msg = AesGcm256Util.decrypt(richTextBox2.Text, AesGcm256Util.hexToByte(key), AesGcm256Util.hexToByte(vi));//解密
                    richTextBox1.Text = msg;
                }
            }

        }
    }
}
