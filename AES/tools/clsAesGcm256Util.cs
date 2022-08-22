using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AES.tools
{
    /*AES-GCM-256 工具类 加解密方法中已调用 Base64 方法 */
    public class AesGcm256Util
    {
        private static readonly SecureRandom SECURE_RANDOM = new SecureRandom();
        public static readonly int NONCE_BIT_SIZE = 128;//96?
        public static readonly int MAC_BIT_SIZE = 128;
        public static readonly int KEY_BIT_SIZE = 256;

        private AesGcm256Util()
        {
        }

        /// <summary>
        /// 创建密钥 key--32
        /// </summary>
        /// <returns>密钥</returns>
        public static byte[] key()
        {
            byte[] key = new byte[KEY_BIT_SIZE / 8];
            SECURE_RANDOM.NextBytes(key);
            return key;
        }

        /// <summary>
        /// 创建向量--NONCE 16位？？32位？ 
        /// </summary>
        /// <returns>向量</returns>
        public static byte[] iv()
        {
            byte[] iv = new byte[NONCE_BIT_SIZE / 8];
            SECURE_RANDOM.NextBytes(iv);
            return iv;
        }

        /// <summary>
        /// hex2Bytes
        /// </summary>
        /// <param name="hexStr">文本</param>
        /// <returns>字节数组</returns>
        public static byte[] hexToByte(string hexStr)
        {
#if false //Java
 int len = hexStr.Length();
            byte[] data = new byte[len / 2];
            for (int i = 0; i < len; i += 2)
            {
                data[i / 2] = (byte)((Character.digit(hexStr.charAt(i), 16) << 4)+ Character.digit(hexStr.charAt(i + 1), 16));
            }
            return data;

#endif
            var byteArray = new byte[hexStr.Length / 2];
            for (var x = 0; x < byteArray.Length; x++)
            {
                var i = Convert.ToInt32(hexStr.Substring(x * 2, 2), 16);
                byteArray[x] = (byte)i;
            }
            return byteArray;


        }

        /// <summary>
        /// 16进制转换
        /// </summary>
        /// <param name="data">字节数组</param>
        /// <returns>转换结果</returns>
        public static string toHex(byte[] data)
        {
            //StringBuilder ret = new StringBuilder();
            //foreach (byte datum in data)
            //{
            //    string hex = int.toHexString(datum & 0xFF);
            //    if (hex.Length == 1)
            //    {
            //        hex = '0' + hex;
            //    }
            //    ret.Append(hex.ToUpper());
            //}
            //return ret.toString();
            return null;

        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plainText">明文文本</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <returns>加密字符串</returns>
        /// <exception cref="RuntimeException"></exception>
        public static string encrypt(string plainText, byte[] key, byte[] iv)
        {
#if false //java
   String sr;
            try
            {
                byte[] plainBytes = plainText.getBytes(StandardCharsets.UTF_8);

                GCMBlockCipher cipher = new GCMBlockCipher(new AESFastEngine());
                AEADParameters parameters =new AEADParameters(new KeyParameter(key), MAC_BIT_SIZE, iv, null);
                cipher.init(true, parameters);
                byte[] encryptedBytes = new byte[cipher.getOutputSize(plainBytes.length)];
                int retLen = cipher.processBytes(plainBytes, 0, plainBytes.length, encryptedBytes, 0);
                cipher.doFinal(encryptedBytes, retLen);
                sr = Base64.getEncoder().encodeToString(encryptedBytes);
            }
            catch (Exception ex)
            {
                throw new RuntimeException(ex.getMessage());
            }
            return sr;
#endif
            string sr;
            try
            {
                var plainBytes = Encoding.UTF8.GetBytes(plainText);
                var cipher = new GcmBlockCipher(new AesEngine());
                var parameters = new AeadParameters(new KeyParameter(key), MAC_BIT_SIZE, iv, null);
                cipher.Init(true, parameters);
                var encryptedBytes = new byte[cipher.GetOutputSize(plainBytes.Length)];
                var retLen = cipher.ProcessBytes(plainBytes, 0, plainBytes.Length, encryptedBytes, 0);
                cipher.DoFinal(encryptedBytes, retLen);
                sr = Convert.ToBase64String(encryptedBytes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sr;

        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="encryptedText">已加密文本</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <returns>已解密文本</returns>
        public static string decrypt(string encryptedText, byte[] key, byte[] iv)
        {
#if false //JAVA 


            string sr;
            try
            {
                byte[] encryptedBytes = Base64.getDecoder().decode(encryptedText);
                GCMBlockCipher cipher = new GCMBlockCipher(new AESFastEngine());
                AEADParameters parameters = new AEADParameters(new KeyParameter(key), MAC_BIT_SIZE, iv, null);

                cipher.init(false, parameters); 

                byte[] plainBytes = new byte[cipher.getOutputSize(encryptedBytes.length)]; 

                int retLen = cipher.processBytes(encryptedBytes, 0, encryptedBytes.length, plainBytes, 0); 
                cipher.doFinal(plainBytes, retLen);
                sr = new string(plainBytes, StandardCharsets.UTF_8);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sr;
#endif
            string sr;
            try
            {
                var encryptedBytes = Convert.FromBase64String(encryptedText);
                var cipher = new GcmBlockCipher(new AesEngine());
                var parameters = new AeadParameters(new KeyParameter(key), MAC_BIT_SIZE, iv, null);
                cipher.Init(false, parameters);
                var plaintext = new byte[cipher.GetOutputSize(encryptedBytes.Length)];
                var length = cipher.ProcessBytes(encryptedBytes, 0, encryptedBytes.Length, plaintext, 0);
                cipher.DoFinal(plaintext, length);
                sr = Encoding.UTF8.GetString(plaintext);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sr;
        }

        /// <summary>
        /// 加密-重载-不处理key
        /// </summary>
        /// <param name="plainText">明文文本</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <returns>加密字符串</returns>
        /// <exception cref="RuntimeException"></exception>
        public static string encrypt(string plainText, string key, string iv)
        {
#if false //java
   String sr;
            try
            {
                byte[] plainBytes = plainText.getBytes(StandardCharsets.UTF_8);

                GCMBlockCipher cipher = new GCMBlockCipher(new AESFastEngine());
                AEADParameters parameters =new AEADParameters(new KeyParameter(key), MAC_BIT_SIZE, iv, null);
                cipher.init(true, parameters);
                byte[] encryptedBytes = new byte[cipher.getOutputSize(plainBytes.length)];
                int retLen = cipher.processBytes(plainBytes, 0, plainBytes.length, encryptedBytes, 0);
                cipher.doFinal(encryptedBytes, retLen);
                sr = Base64.getEncoder().encodeToString(encryptedBytes);
            }
            catch (Exception ex)
            {
                throw new RuntimeException(ex.getMessage());
            }
            return sr;
#endif
            string sr;
            try
            {
                var plainBytes = Encoding.UTF8.GetBytes(plainText);
                var cipher = new GcmBlockCipher(new AesEngine());
                var parameters = new AeadParameters(new KeyParameter(Encoding.UTF8.GetBytes(key)), MAC_BIT_SIZE, Encoding.UTF8.GetBytes(iv), null);
                cipher.Init(true, parameters);
                var encryptedBytes = new byte[cipher.GetOutputSize(plainBytes.Length)];
                var retLen = cipher.ProcessBytes(plainBytes, 0, plainBytes.Length, encryptedBytes, 0);
                cipher.DoFinal(encryptedBytes, retLen);
                sr = Convert.ToBase64String(encryptedBytes);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return sr;

        }

        /// <summary>
        /// 解密-重载-不处理key
        /// </summary>
        /// <param name="encryptedText">已加密文本</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <returns>已解密文本</returns>
        public static string decrypt(string encryptedText, string key, string iv)
        {
#if false //java


            string sr;
            try
            {
                byte[] encryptedBytes = Base64.getDecoder().decode(encryptedText);
                GCMBlockCipher cipher = new GCMBlockCipher(new AESFastEngine());
                AEADParameters parameters = new AEADParameters(new KeyParameter(key), MAC_BIT_SIZE, iv, null);

                cipher.init(false, parameters); 

                byte[] plainBytes = new byte[cipher.getOutputSize(encryptedBytes.length)]; 

                int retLen = cipher.processBytes(encryptedBytes, 0, encryptedBytes.length, plainBytes, 0); 
                cipher.doFinal(plainBytes, retLen);
                sr = new string(plainBytes, StandardCharsets.UTF_8);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sr;
#endif
            string sr;
            try
            {
                var encryptedBytes = Convert.FromBase64String(encryptedText);
                var cipher = new GcmBlockCipher(new AesEngine());
                var parameters = new AeadParameters(new KeyParameter(Encoding.UTF8.GetBytes(key)), MAC_BIT_SIZE, Encoding.UTF8.GetBytes(iv), null);
                cipher.Init(false, parameters);
                var plaintext = new byte[cipher.GetOutputSize(encryptedBytes.Length)];
                var length = cipher.ProcessBytes(encryptedBytes, 0, encryptedBytes.Length, plaintext, 0);
                cipher.DoFinal(plaintext, length);
                sr = Encoding.UTF8.GetString(plaintext);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sr;
        }
    }
}
