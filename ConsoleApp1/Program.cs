using ConsoleApp1.LonLat;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    static class Program
    {

        /// <summary>
        /// 13位时间戳转成时间类型
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        static DateTime GetDateTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }

        /// <summary>From:www.uzhanbao.com
        /// DateTime转换为13位时间戳（单位：毫秒）
        /// </summary>
        /// <param name="dateTime"> DateTime</param>
        /// <returns>13位时间戳（单位：毫秒）</returns>
        public static long DateTimeToLongTimeStamp(DateTime dateTime)
        {
            DateTime timeStampStartTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)(dateTime.ToUniversalTime() - timeStampStartTime).TotalMilliseconds;
        }

        public class AAA
        {
            public int a { get; set; }
            public int b { get; set; }
            public int c { get; set; }
        }

        /// <summary>
        /// 时间戳反转为时间，有很多中翻转方法，但是，请不要使用过字符串（string）进行操作，大家都知道字符串会很慢！
        /// </summary>
        /// <param name="TimeStamp">时间戳</param>
        /// <param name="AccurateToMilliseconds">是否精确到毫秒</param>
        /// <returns>返回一个日期时间</returns>
        public static DateTime GetTime(long TimeStamp, bool AccurateToMilliseconds = false)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
            if (AccurateToMilliseconds)
            {
                return startTime.AddTicks(TimeStamp * 10000);
            }
            else
            {
                return startTime.AddTicks(TimeStamp * 10000000);
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmss"));
            Console.WriteLine(Guid.NewGuid());
            long time = 1643932287250;
            Console.WriteLine(GetTime(time, true).ToString());
            int a = 465 / 50;

            Console.WriteLine(a);
            int b = 34 / 50;
            Console.WriteLine(b);

            var aAAs = new List<AAA>();
            aAAs.Add(new AAA { a = 0, b = 0, c = 0 });
            aAAs.Add(new AAA { a = 1, b = 1, c = 1 });
            aAAs.Add(new AAA { a = 2, b = 2, c = 2 });
            aAAs.Add(new AAA { a = 3, b = 3, c = 3 });
            string abc = JsonConvert.SerializeObject(aAAs);
            Console.WriteLine(abc);
            int bb = 250 % 50;
            Console.WriteLine(bb);
            Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmm"));
            Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmss"));
            //Time();
            string sss = "bear ssdasfd";
            var c = sss.IndexOf(' ');
            var ss = sss.Length;
            var dd = sss.Substring(c, sss.Length - c);

            Console.WriteLine(sss.Substring(sss.IndexOf(' '), sss.Length - sss.IndexOf(' ')));
            Console.ReadLine();

            //var va = clsLonLatUtil.ComputeLonLat(postX: 349.48, postY: 99.279);

            //Console.WriteLine("x=" + 349.48);
            //Console.WriteLine("y=" + 99.279);

            //Console.WriteLine("lon=" + va.lon);
            //Console.WriteLine("lat=" + va.lat);

            //Console.ReadLine();
            //var startTime = DateTimeToLongTimeStamp(DateTime.Parse("2021-01-27 09:04:02"));
            //var endTime = DateTimeToLongTimeStamp(DateTime.Now);



            //var sstartTime = GetDateTime(startTime.ToString());

            //Console.WriteLine(startTime);
            //Console.WriteLine(sstartTime);

            //var sendTime = GetDateTime(endTime.ToString());
            //Console.WriteLine(endTime);
            //Console.WriteLine(sendTime);


            //clsDelegateEvent.Mains(args);

            //HttpFormData.GetCookie();


            //Console.WriteLine(DateTime.Now.ToLongTimeString());

            //Console.WriteLine("Hello World!");

            #region
            //string secretKey = "a3f2c0b2b4f811eaa30dd4ae52635598";
            //string str = "Ve9JPnOyySzmtyWtugKiJ64vUEZpJJRVBPXSbY3WlIHp1ceAOoBwwFbE92LhJcMX/evRooRCCmlk9OWdw9SllIRtMHWoIXZiAXJUmq68H0OevkR6vxpgUAUGB+cshoqbZedAZp9p4+4XL3yfDsvpkh1RUbO7MkvACkweCbsDIZBUxn+f6TscrPA217hXbDp621tsae5nugzkCItolP9EWrG7jbzD2yUn4rWxb4cJH0VOSKmYukTes3MKzFQ5x6e/";
            //var mode = CipherMode.CBC;
            //var padding = PaddingMode.PKCS7;

            ////string res = ToDecryptAes(str, secretKey, mode, padding);

            //str = AesEncryptor_Base64(str, secretKey);
            //Console.WriteLine("加密：");
            //Console.WriteLine(str);

            //string jiami = "123456";
            //jiami = AesEncryptor_Base64(jiami, secretKey);
            //Console.WriteLine("加密：");
            //Console.WriteLine(jiami);
            //string jiemi = AesDecryptor_Base64(jiami, secretKey);
            //Console.WriteLine("解密：");
            //Console.WriteLine(jiemi);
            #endregion

            //Console.ReadLine();

        }


        public static void Time()
        {
            DateTime dtone = Convert.ToDateTime(DateTime.Now);

            DateTime dtwo = Convert.ToDateTime("2022-1-1 00:00:00");

            TimeSpan span = dtone.Subtract(dtwo);

            Console.WriteLine(span.Days + "天" + span.Hours + "小时" + span.Minutes + "分钟" + span.Seconds + "秒");
            Console.WriteLine($"早上好，来自2022的第{span.Days + 1}份早安");
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
            if (string.IsNullOrWhiteSpace(str)) return null;
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
            if (string.IsNullOrWhiteSpace(str)) return null;
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

        /// <summary>
        /// AES 算法加密(ECB模式) 将明文加密，加密后进行base64编码，返回密文
        /// </summary>
        /// <param name="EncryptStr">明文</param>
        /// <param name="Key">密钥</param>
        /// <returns>加密后base64编码的密文</returns>
        public static string AesEncryptor_Base64(string EncryptStr, string Key)
        {
            try
            {
                //byte[] keyArray = Encoding.UTF8.GetBytes(Key);
                byte[] keyArray = Convert.FromBase64String(Key);
                byte[] toEncryptArray = Encoding.UTF8.GetBytes(EncryptStr);

                RijndaelManaged rDel = new RijndaelManaged
                {
                    //IV=keyArray,
                    Key = keyArray,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };

                ICryptoTransform cTransform = rDel.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// AES 算法解密(ECB模式) 将密文base64解码进行解密，返回明文
        /// </summary>
        /// <param name="DecryptStr">密文</param>
        /// <param name="Key">密钥</param>
        /// <returns>明文</returns>
        public static string AesDecryptor_Base64(string DecryptStr, string Key)
        {
            try
            {
                //byte[] keyArray = Encoding.UTF8.GetBytes(Key);
                byte[] keyArray = Convert.FromBase64String(Key);
                byte[] toEncryptArray = Convert.FromBase64String(DecryptStr);

                RijndaelManaged rDel = new RijndaelManaged
                {
                    //IV= keyArray,
                    Key = keyArray,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };

                ICryptoTransform cTransform = rDel.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                return Encoding.UTF8.GetString(resultArray);//  UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception ex)
            {
                return null;
            }
        }



    }
}
