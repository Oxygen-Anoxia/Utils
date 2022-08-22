using AES.tools;
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
    public partial class AESFrom : Form
    {
        public AESFrom()
        {
            InitializeComponent();
        }

        public static string secretKey = "QAZWSXEDCRFVTGBH";
        public static string secretIV = "QAZWSXEDCRFVTGBH";
        public string token = "2702490990";
        private bool InitKeyIV()
        {
            if (string.IsNullOrEmpty(this.txtKey.Text.Trim()))
            {
                this.txtKey.Focus();
                MessageBox.Show("Key 值不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(this.txtIV.Text.Trim()))
            {
                this.txtKey.Focus();
                MessageBox.Show("IV 值不能为空");
                return false;
            }
            secretKey = this.txtKey.Text.Trim();
            secretIV = this.txtIV.Text.Trim();
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox1.Text.Trim()))
            {
                MessageBox.Show("请输入需要加密的字符串");
                return;
            }
            if (InitKeyIV())
            {
                string text1 = this.textBox1.Text.Trim().ToString();
                //this.textBox2.Text = text1.ToEncryptAes(secretKey, secretIV, System.Security.Cryptography.CipherMode.CBC, System.Security.Cryptography.PaddingMode.PKCS7);
                this.textBox2.Text = AesUtil.ToEncryptAes(text1, secretKey, secretIV, System.Security.Cryptography.CipherMode.CBC, System.Security.Cryptography.PaddingMode.PKCS7);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox2.Text.Trim()))
            {
                MessageBox.Show("请输入需要解密的字符串");
                return;
            }
            if (InitKeyIV())
            {
                string text2 = this.textBox2.Text.Trim().ToString();
                //this.textBox1.Text = text2.ToDecryptAes(secretKey, secretIV, System.Security.Cryptography.CipherMode.CBC, System.Security.Cryptography.PaddingMode.PKCS7);

                this.textBox1.Text = AesUtil.ToDecryptAes(text2, secretKey, secretIV, System.Security.Cryptography.CipherMode.CBC, System.Security.Cryptography.PaddingMode.PKCS7);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox1.Text.Trim()))
            {
                MessageBox.Show("请输入需要加密的字符串");
                return;
            }
            if (InitKeyIV())
            {
                string text1 = this.textBox1.Text.Trim().ToString();
                //string aesData = text1.ToEncryptAes(secretKey, secretIV, System.Security.Cryptography.CipherMode.CBC, System.Security.Cryptography.PaddingMode.PKCS7);
                //this.textBox2.Text = StringExtension.Base64Encode(aesData); 

                //string aesData = AesUtil.ToEncryptAes(text1, secretKey, secretIV, System.Security.Cryptography.CipherMode.CBC, System.Security.Cryptography.PaddingMode.PKCS7);
                //this.textBox2.Text = StringExtension.Base64Encode(aesData);    

                var msg = AesGcm256Util.encrypt(text1, AesGcm256Util.hexToByte(secretKey), AesGcm256Util.hexToByte(secretIV));//加密
                this.textBox2.Text = msg;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox2.Text.Trim()))
            {
                MessageBox.Show("请输入需要解密的字符串");
                return;
            }
            if (InitKeyIV())
            {
                string text2 = this.textBox2.Text.Trim().ToString();
                //string aesData = StringExtension.Base64Decode(text2);
                //this.textBox1.Text = aesData.ToDecryptAes(secretKey, secretIV, System.Security.Cryptography.CipherMode.CBC, System.Security.Cryptography.PaddingMode.PKCS7);

                //string aesData = StringExtension.Base64Decode(text2);
                //this.textBox1.Text = AesUtil.ToDecryptAes(aesData, secretKey, secretIV, System.Security.Cryptography.CipherMode.CBC, System.Security.Cryptography.PaddingMode.PKCS7);

                var msg = AesGcm256Util.decrypt(text2, AesGcm256Util.hexToByte(secretKey), AesGcm256Util.hexToByte(secretIV));//解密
                this.textBox1.Text = msg;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            this.txtTime.Text = time;
            token = this.txtToken.Text.ToString();
            this.txtAuthorization.Text = token + time;
        }

        private void AESFrom_Load(object sender, EventArgs e)
        {
            InitKeyIV();
            this.txtId.Text = Guid.NewGuid().ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(this.textBox1.Text.Trim()))
            {
                MessageBox.Show("请输入需要加密的字符串");
                return;
            }
            if (InitKeyIV())
            {
                string text1 = this.textBox1.Text.Trim().ToString();
                string aesData = clsAEStool2.AESEncrypt(text1, secretKey);
                this.textBox2.Text = aesData;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void btnId_Click(object sender, EventArgs e)
        {
            this.txtId.Text = Guid.NewGuid().ToString();
        }

        private void txtKey_TextChanged(object sender, EventArgs e)
        {

        }


        private void txtIV_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTime_TextChanged(object sender, EventArgs e)
        {

        }


        private void txtToken_TextChanged(object sender, EventArgs e)
        {

        }



        private void txtAuthorization_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }
    }



    static class AesUtil
    {

        //对称加密和分组加密中的四种模式(ECB、CBC、CFB、OFB),这三种的区别，主要来自于密钥的长度，16位密钥=128位，24位密钥=192位，32位密钥=256位。

        /// <summary>
        ///  加密 参数：string
        /// </summary>
        /// <param name="palinData">明文</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="padding">编码方式</param>
        /// <returns>string：密文</returns>
        //public static string Encrypt(string palinData, string key, string iv, PaddingMode padding)


        /// <summary>
        ///加密AES数据
        /// </summary>
        /// <param name="str">被加密字符串</param>
        /// <param name="secretKey">秘钥</param>
        /// <param name="secretIV">IV</param>
        /// <param name="mode">加密模式</param>
        /// <param name="padding">填充方式</param>
        /// <returns></returns>
        public static string ToEncryptAes(string str, string secretKey, string secretIV, CipherMode mode, PaddingMode padding)
        {
            if (string.IsNullOrWhiteSpace(str)) return null;
            //if (!(CheckKey(StringToBinary(PublicKey)) && CheckIv(StringToBinary(Iv)))) return palinData;
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(str);
            var rm = new RijndaelManaged
            {
                IV = EncodingStrOrByte(secretIV),
                Key = EncodingStrOrByte(secretKey),
                Mode = CipherMode.CBC,
                Padding = padding
            };
            ICryptoTransform cTransform = rm.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }


        /// <summary>
        /// 解密AES数据
        /// </summary>
        /// <param name="str">被加密字符串</param>
        /// <param name="secretKey">秘钥</param>
        /// <param name="secretIV">IV</param>
        /// <param name="mode">加密模式</param>
        /// <param name="padding">填充方式</param>
        /// <returns></returns>
        public static string ToDecryptAes(string str, string secretKey, string secretIV, CipherMode mode, PaddingMode padding)
        {
            if (str.IsNullOrWhiteSpace()) return null;
            var toEncryptArray = Convert.FromBase64String(str);
            var rm = new RijndaelManaged
            {
                IV = EncodingStrOrByte(secretIV),
                Key = EncodingStrOrByte(secretKey),
                Mode = mode,
                Padding = padding
            };
            var cTransform = rm.CreateDecryptor();
            var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Encoding.UTF8.GetString(resultArray);

        }


        private static byte[] EncodingStrOrByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
            {
                string temp = hexString.Substring(i * 2, 2).Trim();
                returnBytes[i] = Convert.ToByte(temp, 16);
            }
            return returnBytes;
        }

    }
}
