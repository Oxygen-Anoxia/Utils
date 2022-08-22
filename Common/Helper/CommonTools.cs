using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Common.Helper
{
    public class CommonTools
    {
        public static string GetMD5(string sDataIn)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytValue, bytHash;
            bytValue = System.Text.Encoding.UTF8.GetBytes(sDataIn);
            bytHash = md5.ComputeHash(bytValue);
            md5.Clear();
            string sTemp = "";
            for (int i = 0; i < bytHash.Length; i++)
            {
                sTemp += bytHash[i].ToString("X").PadLeft(2, '0');
            }
            return sTemp.ToLower();
        }

        //反转字符串
        public static string ReverseString(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return input;
            }

            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new String(charArray);
        }
        public static string DesEncrypt(string message, string key, string iv)
        {
            var result = string.Empty;

            try
            {
                var ms = new MemoryStream();
                var des = new TripleDESCryptoServiceProvider();
                var cs = new CryptoStream(ms, des.CreateEncryptor(Encoding.UTF8.GetBytes(key), Encoding.UTF8.GetBytes(iv)),
                    CryptoStreamMode.Write);
                var sw = new StreamWriter(cs, Encoding.UTF8);
                sw.Write(message);
                sw.Close();
                cs.Close();
                ms.Close();

                result = Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                result = ex.Message + ex.StackTrace;
            }
            return result;
        }
        public static string DesDecrypt(string message, string key, string iv)
        {
            var result = string.Empty;
            try
            {
                var ms = new MemoryStream(Convert.FromBase64String(message));
                var des = new TripleDESCryptoServiceProvider();
                var cs = new CryptoStream(ms, des.CreateDecryptor(Encoding.UTF8.GetBytes(key), Encoding.UTF8.GetBytes(iv)),
                    CryptoStreamMode.Read);
                var sr = new StreamReader(cs, Encoding.UTF8);
                result = sr.ReadToEnd();

                sr.Close();
                cs.Close();
                ms.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        //哈希加密密码 
        public static string HashPassword(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] salt;
            byte[] bytes;
            using (Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, 16, 1000))
            {
                salt = rfc2898DeriveBytes.Salt;
                bytes = rfc2898DeriveBytes.GetBytes(32);
            }
            byte[] array = new byte[49];
            Buffer.BlockCopy(salt, 0, array, 1, 16);
            Buffer.BlockCopy(bytes, 0, array, 17, 32);
            return Convert.ToBase64String(array);
        }

        //哈希验证密码 
        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] array = Convert.FromBase64String(hashedPassword);
            if (array.Length != 49 || array[0] != 0)
            {
                return false;
            }
            byte[] array2 = new byte[16];
            Buffer.BlockCopy(array, 1, array2, 0, 16);
            byte[] array3 = new byte[32];
            Buffer.BlockCopy(array, 17, array3, 0, 32);
            byte[] bytes;
            using (Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, array2, 1000))
            {
                bytes = rfc2898DeriveBytes.GetBytes(32);
            }
            return ByteArraysEqual(array3, bytes);
        }


        private static bool ByteArraysEqual(byte[] a, byte[] b)
        {
            if (object.ReferenceEquals(a, b))
            {
                return true;
            }
            if (a == null || b == null || a.Length != b.Length)
            {
                return false;
            }
            bool flag = true;
            for (int i = 0; i < a.Length; i++)
            {
                flag &= (a[i] == b[i]);
            }
            return flag;
        }
    }
}
