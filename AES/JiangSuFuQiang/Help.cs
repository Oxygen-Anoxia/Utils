using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AES.JiangSuFuQiang
{
    public static class Help
    {
        public static async Task<string> PostAsync(string serviceAddress, string strContent, string ContentType, string m_Username, string m_Password)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);

            request.Method = "POST";
            if (string.IsNullOrEmpty(ContentType))
            {
                request.ContentType = "application/json";
            }
            else
            {
                request.ContentType = ContentType;
            }

            string mergedCredentials = string.Format("{0}:{1}", m_Username, m_Password);
            byte[] byteCredentials = UTF8Encoding.UTF8.GetBytes(mergedCredentials);
            string base64Credentials = Convert.ToBase64String(byteCredentials);
            request.Headers.Add("Authorization", "Basic " + base64Credentials);


            using (StreamWriter dataStream = new StreamWriter(request.GetRequestStream()))
            {
                dataStream.Write(strContent);
                dataStream.Close();
            }
            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
            string encoding = response.ContentEncoding;
            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8"; //默认编码  
            }
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
            string retString = reader.ReadToEnd();

            return retString;

            //解析josn
            //JObject jo = JObject.Parse(retString);
            //Response.Write(jo["message"]["mmmm"].ToString());

        }

        public static async Task<string> PostAsync(string url, string data)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "POST";
            request.ContentType = "application/json";
            var buffer = Encoding.UTF8.GetBytes(data);
            request.ContentLength = buffer.Length;

            Stream myRequestStream = request.GetRequestStream();
            myRequestStream.Write(buffer, 0, buffer.Length);
            myRequestStream.Close();
            var response = await request.GetResponseAsync();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        /// <summary>
        /// 将目标字符串进行AES加密
        /// IV和Key均为secretKey
        /// </summary>
        /// <param name="str">被加密字符串</param>
        /// <param name="secretKey">秘钥</param>
        /// <param name="mode">加密模式</param>
        /// <param name="padding">填充方式</param>
        /// <returns></returns>
        public static string ToEncryptAes(this string str, string secretKey, CipherMode mode, PaddingMode padding)
        {
            var toEncryptArray = Encoding.UTF8.GetBytes(str);

            var rm = new RijndaelManaged
            {
                IV = Encoding.UTF8.GetBytes(secretKey),
                Key = Encoding.UTF8.GetBytes(secretKey),
                Mode = mode,
                Padding = padding
            };
            //如果对加密方式和上面的参数值不了解 可以查看下面的解密方法 得出参数定义形式
            var cTransform = rm.CreateEncryptor();
            var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        #region AES 解密
        /// <summary>
        ///  AES 解密
        /// </summary>
        /// <param name="str">明文（待解密）</param>
        /// <param name="key">密文</param>
        /// <returns></returns>
        public static string AesDecrypt(string str, string key)
        {
            if (string.IsNullOrEmpty(str)) return null;
            Byte[] toEncryptArray = Convert.FromBase64String(str);
            RijndaelManaged rm = new RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(key),
                //偏移量
                IV = Encoding.UTF8.GetBytes(key),
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform cTransform = rm.CreateDecryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Encoding.UTF8.GetString(resultArray);
        }
        #endregion

    }

    public class modelll
    {
        /// <summary>
        /// 
        /// </summary>
        public string datas { get; set; }

    }

}
