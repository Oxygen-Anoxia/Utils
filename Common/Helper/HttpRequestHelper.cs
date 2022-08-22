using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper
{
    public class HttpRequestHelper
    {
        public static CookieContainer Cookies { get; set; }
        public static string Post(string url, string data)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                if (Cookies == null)
                {
                    Cookies = new CookieContainer();
                }
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                //request.Headers.Set("charset", "UTF-8");
                //request.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
                //request.Headers.Add("Accept-Charset", "Accept-Charset");
                var buffer = Encoding.UTF8.GetBytes(data);
                request.ContentLength = buffer.Length;
                request.CookieContainer = Cookies;
                Stream myRequestStream = request.GetRequestStream();
                myRequestStream.Write(buffer, 0, buffer.Length);
                //StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.UTF8);
                //myStreamWriter.Write(data);
                myRequestStream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Cookies = Cookies.GetCookies(response.ResponseUri);
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();

                return retString;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static async Task<string> PostAsync(string url, string data)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            if (Cookies == null)
            {
                Cookies = new CookieContainer();
            }
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            var buffer = Encoding.UTF8.GetBytes(data);
            request.ContentLength = buffer.Length;
            request.CookieContainer = Cookies;
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
        public static async Task<string> PostAsync(string serviceAddress, string strContent, string ContentType)
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


        public static string Postupload(string serviceAddress, string strContent)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);

            request.Method = "POST";
            request.ContentType = "application/json";
            using (StreamWriter dataStream = new StreamWriter(request.GetRequestStream()))
            {
                dataStream.Write(strContent);
                dataStream.Close();
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string encoding = response.ContentEncoding;
            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8"; //默认编码  
            }
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
            return reader.ReadToEnd();

        }




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
        public static string Get(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        public async static Task<string> GetAsync(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        /// <summary>
        /// 获取接口json内容转string
        /// </summary>
        /// <param name="url">请求接口地址</param>
        /// <returns></returns>
        public static string QueryPostparamsService(string url)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "Get";
            //req.Headers.Add()
            try
            {
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                Stream stream = resp.GetResponseStream();
                //获取内容
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    //获取的数据返回值
                    result = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }


    }
}
