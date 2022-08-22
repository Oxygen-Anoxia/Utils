using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AES.tools
{
    public class clsAEStool2
    {

        static string IV = AESFrom.secretIV;//  "1234567890000000";
        static string key = AESFrom.secretKey;// "ABCDEFG1234567ABCDEFG12345671111";

        /// <summary>
        /// AES加密(无向量)
        /// </summary>
        /// <param name="Data">被加密的明文</param>
        /// <param name="Key">密钥</param>
        /// <returns>密文</returns>
        public static string AESEncrypt(String Data, String Key)
        {
            MemoryStream mStream = new MemoryStream();
            RijndaelManaged aes = new RijndaelManaged();

            byte[] plainBytes = Encoding.UTF8.GetBytes(Data);
            Byte[] bKey = new Byte[32];
            Array.Copy(Encoding.UTF8.GetBytes(Key.PadRight(bKey.Length)), bKey, bKey.Length);
            byte[] _iv = Encoding.UTF8.GetBytes(IV);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.KeySize = 256;
            //aes.Key = _key;
            aes.Key = EncodingStrOrByte(key);
            //aes.IV = _iv;
            aes.IV = EncodingStrOrByte(IV);
            CryptoStream cryptoStream = new CryptoStream(mStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
            try
            {
                cryptoStream.Write(plainBytes, 0, plainBytes.Length);
                cryptoStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            finally
            {
                cryptoStream.Close();
                mStream.Close();
                aes.Clear();
            }

        }
        /// <summary>
        /// AES解密(无向量)
        /// </summary>
        /// <param name="Data">被加密的明文</param>
        /// <param name="Key">密钥</param>
        /// <returns>明文</returns>
        public static string AESDecrypt(String Data, String Key)
        {
            byte[] inputBytes = Base64StringToByteArray(Data);
            byte[] keyBytes = Encoding.UTF8.GetBytes(Key.Substring(0, 32));
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                //aesAlg.Key = keyBytes;
                //aesAlg.IV = Encoding.UTF8.GetBytes(IV.Substring(0, 16));

                aesAlg.Key = EncodingStrOrByte(key);
                aesAlg.IV = EncodingStrOrByte(IV);  

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream(inputBytes))
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srEncrypt = new StreamReader(csEncrypt))
                        {
                            string str = srEncrypt.ReadToEnd();
                            srEncrypt.Close();
                            csEncrypt.Close();
                            msEncrypt.Close();
                            return str;
                        }
                    }

                }
            }
        }
        /// <summary>
        /// 将指定的Base64字符串转换为byte数组
        /// </summary>
        /// <param name="s"></param>
        /// <returns>16进制字符串对应的byte数组</returns>
        public static byte[] Base64StringToByteArray(string s)
        {
            byte[] arr = Convert.FromBase64String(s.Substring(s.IndexOf(",") + 1));
            return arr;
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
