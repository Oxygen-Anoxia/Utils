using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HttpProgramApp
{
    public class HttpProgram
    {
        /// <summary>
        /// 测试http form-data 类型参数
        /// </summary>
        /// <returns></returns>
        public static string GetData()
        {
            string Cookie = string.Empty;
            try
            {

                var httpConfig = System.Configuration.ConfigurationManager.AppSettings["HttpUrl"];
                var timeOut = System.Configuration.ConfigurationManager.AppSettings["TimeOut"];
                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);
                var req = (HttpWebRequest)WebRequest.Create(httpConfig);
                req.Method = "GET";
                req.ContentType = "application/json";
                //req.Timeout = int.Parse(timeOut);
                var response = (HttpWebResponse)req.GetResponse();
                var resuleJson = string.Empty;
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.GetEncoding("UTF-8")))
                    {
                        resuleJson = reader.ReadToEnd();
                    }
                }
                Console.WriteLine(resuleJson);

            }
            catch (Exception ex)
            {
                Console.WriteLine("登录异常:" + ex.Message);
                return "";
            }

            return Cookie;
        }

        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            //直接确认，否则打不开
            return true;
        }

        public static string GetData2()
        {
            string Cookie = string.Empty;
            try
            {

                var httpConfig = System.Configuration.ConfigurationManager.AppSettings["HttpUrl"];
                var timeOut = System.Configuration.ConfigurationManager.AppSettings["TimeOut"];
                //ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);
                //var req = (HttpWebRequest)WebRequest.Create(httpConfig);
                //req.Method = "GET";
                //req.ContentType = "application/json";
                ////req.Timeout = int.Parse(timeOut);
                //var response = (HttpWebResponse)req.GetResponse();
                //var resuleJson = string.Empty;
                //using (Stream stream = response.GetResponseStream())
                //{
                //    using (StreamReader reader = new StreamReader(stream, Encoding.GetEncoding("UTF-8")))
                //    {
                //        resuleJson = reader.ReadToEnd();
                //    }
                //}

                var resuleJson = string.Empty;
                resuleJson = Inroad.Foundation.Common.HttpHelper.GetDataViaHttpWebRequest(httpConfig, null, null, null);
                Console.WriteLine(resuleJson);
                Cookie = resuleJson;
            }
            catch (Exception ex)
            {
                Console.WriteLine("系统异常:" + ex.Message);
                return "";
            }

            return Cookie;
        }


    }
}
