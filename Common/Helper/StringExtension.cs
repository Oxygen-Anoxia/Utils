using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Common.Helper
{
    public static class StringExtension
    {
        #region AES

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
            if (str.IsNullOrWhiteSpace()) return null;
            var toEncryptArray = Encoding.UTF8.GetBytes(str);
            var rm = new RijndaelManaged
            {
                IV = Encoding.UTF8.GetBytes(secretKey),
                Key = Encoding.UTF8.GetBytes(secretKey),
                Mode = mode,
                Padding = padding
            };

            var cTransform = rm.CreateEncryptor();
            var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// 解密AES数据
        /// </summary>
        /// <param name="str"></param>
        /// <param name="secretKey"></param>
        /// <param name="mode"></param>
        /// <param name="padding"></param>
        /// <returns></returns>
        public static string ToDecryptAes(this string str, string secretKey, CipherMode mode, PaddingMode padding)
        {
            if (str.IsNullOrWhiteSpace()) return null;
            var toEncryptArray = Convert.FromBase64String(str);
            var rm = new RijndaelManaged
            {
                IV = Encoding.UTF8.GetBytes(secretKey),
                Key = Encoding.UTF8.GetBytes(secretKey),
                Mode = mode,
                Padding = padding
            };
            var cTransform = rm.CreateDecryptor();
            var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Encoding.UTF8.GetString(resultArray);

        }

        #endregion


        #region SHA1

        public static string ToEncryptSha1(this string str)
        {
            HashAlgorithm iSha = new SHA1CryptoServiceProvider();
            var res = iSha.ComputeHash(Encoding.UTF8.GetBytes(str));
            var resStr = "";

            foreach (var iByte in res)
            {
                resStr = $"{resStr}{iByte:X2}";
            }

            return resStr.ToString();
        }

        #endregion


        public static string ToJsonString(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 判断字符串是否为空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// 首字母小写
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string FirstCharToLower(this string input)
        {
            if (String.IsNullOrEmpty(input))
                return input;
            string str = input.First().ToString().ToLower() + input.Substring(1);
            return str;
        }

        public static int ToInt(this string str)
        {
            return Convert.ToInt32(str);
        }

        public static float ToFloat(this string str)
        {
            float defaultValue = 0;
            return str.IsNullOrWhiteSpace() ? defaultValue : Convert.ToSingle(str);
        }

        /// <summary>
        /// 获取string字节数(utf-8编码)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetUtf8ByteCount(this string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            return bytes.Length;
        }

        /// <summary>
        /// 将二进制字符串转换成byte数组
        /// TODO : 未验证是否可用
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static byte[] ToByteArray(this string str, int length = 0)
        {
            if (str.IsNullOrWhiteSpace() || str.Any(x => x != '0' && x != '1')) return null;

            // 确定byte数组数组长度
            var byteLength = length == 0 ? (int)Math.Ceiling(str.Length / 8.0) : length;
            var res = new byte[byteLength];

            // 补全长度
            var redundant = byteLength * 8 - str.Length;
            for (var i = 0; i < redundant; i++) { str = $"{str}0"; }

            // 将str的值塞入byte数组中
            for (var i = 0; i < byteLength; i++)
            {
                res[i] = Convert.ToByte(str.Substring(i * 8, 8), 2);
            }


            return res;
        }
    }

}
