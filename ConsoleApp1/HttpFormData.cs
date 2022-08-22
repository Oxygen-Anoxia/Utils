using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ConsoleApp1
{
    public  class HttpFormData
    {

        /// <summary>
        /// 测试http form-data 类型参数
        /// </summary>
        /// <returns></returns>
        public static string GetCookie()
        {
            string Cookie = string.Empty;
            try
            {
                var httpConfig = "https://99.in-road.com/API/Account/LoginDebug";
                HttpWebRequest request = WebRequest.Create(httpConfig) as HttpWebRequest;
                //创建http请求实例
                request.Method = "post";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                StringBuilder buffer = new StringBuilder();
                //request.Headers.Add("Cookie", cookie);
                buffer.AppendFormat("{0}={1}&", "phonenumber", "18134535974");
                buffer.AppendFormat("{0}={1}", "password", "123456");
                byte[] data = Encoding.UTF8.GetBytes(buffer.ToString());
                Stream stream = request.GetRequestStream();
                stream.Write(data, 0, data.Length);
                stream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Cookie = response.Headers["Set-Cookie"];
            }
            catch (Exception ex)
            {
                Console.WriteLine("登录异常:" + ex.Message);
                return "";
            }

            return Cookie;

        }

    }
}
