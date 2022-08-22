using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace JTokenDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            //var token = GetToken("http://221.229.205.105:8989/scyf/auth/getToken", "320310078");
            //Console.WriteLine(token);
            ApiTest();
            Console.ReadLine();

        }


        void Fun()
        {
            string str = @"{
    ""data"": [
        {
            ""company"": {
                ""ID"": ""12345"",
                ""location"": ""Some Location""
            },
            ""name"": ""Some Name""
        }
    ]
}";





            string strOut = @"{
    ""data"": [
        {
            ""company_ID"": ""12345"",
            ""company_location"": ""Some Location"",
            ""name"": ""Some Name""
        }
]}";

        }

        /// <summary>
        /// 根据公司编码获取token
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="companyCode">公司编码</param>
        /// <returns></returns>
        public static string GetToken(string url, string companyCode)
        {
            var formData = new Dictionary<string, string>();
            formData.Add("code", companyCode);
            var responseMessage = PostDataViaHttpWebRequest(url, null, formData);
            string token = string.Empty;
            if (!string.IsNullOrEmpty(responseMessage))
            {
                var responseMsg = string.Empty;
                var responseCode = string.Empty;
                var responseMsgTranslate = string.Empty;
                var responseCodeTranslate = string.Empty;

                if (!responseMessage.Trim().StartsWith("[") && !responseMessage.Trim().EndsWith("]"))
                    responseMessage = "[" + responseMessage + "]";
                //把返回信息转成json
                Object responseJsonContent = JsonConvert.DeserializeObject(responseMessage);
                Newtonsoft.Json.Linq.JArray responseJsonArray = responseJsonContent as Newtonsoft.Json.Linq.JArray;
                foreach (JObject content in responseJsonArray.Children<JObject>())
                {
                    Newtonsoft.Json.Linq.JObject newJObject = new Newtonsoft.Json.Linq.JObject();
                    foreach (JProperty jsonObject in content.Properties())
                    {
                        switch (jsonObject.Name.ToLower().Trim())
                        {
                            case "data":
                                responseMsgTranslate = jsonObject.Value.ToString();
                                break;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(responseMsgTranslate))
                {
                    if (!responseMsgTranslate.Trim().StartsWith("[") && !responseMsgTranslate.Trim().EndsWith("]"))
                        responseMsgTranslate = "[" + responseMsgTranslate + "]";
                    //把返回信息转成json
                    Object responseJsonContent2 = JsonConvert.DeserializeObject(responseMsgTranslate);
                    Newtonsoft.Json.Linq.JArray responseJsonArray2 = responseJsonContent2 as Newtonsoft.Json.Linq.JArray;
                    foreach (JObject content2 in responseJsonArray2.Children<JObject>())
                    {
                        Newtonsoft.Json.Linq.JObject newJObject2 = new Newtonsoft.Json.Linq.JObject();
                        foreach (JProperty jsonObject in content2.Properties())
                        {
                            switch (jsonObject.Name.ToLower().Trim())
                            {
                                case "token":
                                    token = jsonObject.Value.ToString();
                                    break;
                            }
                        }
                    }
                }

            }

            return token;
        }


        public static void ApiTest()
        {
            var token = GetToken("http://221.229.205.105:8989/scyf/auth/getToken", "321210017");

            Dictionary<string, string> headers = new Dictionary<string, string>();
            var formData = new Dictionary<string, string>();
            //headers.Add("content-type", "multipart/form-data; boundary=<calculated when request is sent>");
            headers.Add("Authorization", token);

            #region
            formData.Add("message", "Ge8tYTrCE/6ovnbvclf4U9hj6bn5QKgNEuh8Df2kLaZgQmdS4FZTCVVx9Au9rpSBUDw3ijPg1jEnsF9fPJd8SIdfFVmC3Fd7aAA+dtyCN3zKBGy84wQMG06C6rHpaDvFDfj3sxzSBu2sM/X4UvEUibn4boN20f68jwatfDuwXDadkGMJNJYn7/gjImcPv5Mya1f1qXYYma0H9AzFCIrZs2Kzhn/eoY4iHdHDQU3W9tE9KeChaCBNH7vC3uyAfpSeDmnvS6J1OgogT0E1O4tMUipvqvTxOa0a/FfTWHjCHD3ePoCOTKbN7wMxofCUUl4cfndjg1cXlloOx6lUJCn5tEpzS3d8csxWri14JtLiD48i2I2bo52pD2Xgk1cZV8ppx0xRUSm4WsxjJjYj6hoMjyHE3aaudz8yMVWY3F0RdLfJhvh/S5d2JINMbfJdthICraZtS2rz9DdyHn7R/S9GcRW9gOqPcMz6CuP2m+wNF49buyrtoYJsvjmzOxredLcMwOcwRUAjspBxsBslBTgaL2DPfJqG8GfSrYqXddZSTFUSp3sm6IvoYGS2HH6OLo1TDO64KCFrbb23dz6bDthKmIdyOO3UX2HopJdZICCUs/zV6Yfb1RBMgHHsw6ueNQwUD3FkudhF4mXTYjJMWzElQEa7ZRlfl+Gxgz7vQK2EIH7HQ/Ry3KczXvFyTFPT6CbykugejZpw6hrtCInM25DFp5/z6LA/eVIV602CEBtNlaM20VVucxeXt6raKDBgi9MkH6IAX55f56MgRly1ZH3t2orMJQE3ZV+k48C0CIu8Mt88xkgxMj3C3bJnKbetOPTH5Toxgg7ri9TfTL6acuOpXAwNTGu+Elt7I/7bYr4YispOw1BVkfu3qNrKjMHvAQNiED05cH+9T16SJHHPTKasztm1pY0SKoQKiYE4ZCqvuHdLuxP/IcTEhURoXbeiBWZJXuArqHqqyyyQc++eqE2Lj41Vdken8dpJ0+HjnyCD1FEmEM6dJpO2J9B3FX37VaTbdSCJiYr4utOXTi8vCZ/eY/3fLIRi93Pw42T6FmaJ4XU8x63cR10JMeTw194cL8WYNEbACiXz2lVP733mpmsKK2cL5fbGIGclW907pDI/ThLnBrcenAq9lzCMvS5IRC3MQoUwl1SoZuxC5uEjoX4cVqqGvRoGe2dkghROw1Hkze3tIy8xDodh+1//KN2MGjHTIy3+POjYKVmOLlISZ+hDRr6FdeEv9n3X0k3RZ9Zr2Oouk6PowDUB2QSNTTzS8MuoSc9qQvek9LqJ58VeRMGSvHN4qblDt0xqH5o2D89aHe7n3ZFtKd4QsaRiFJ+hXfBn+wWFEVTL3MvPwGGbhAu8+fDnrynLxlvFm127bhqY1M2ctoQH6TKUYCAuW9JS3dF+TS2AIOKD33mi0R5mVnn2qA==");

            #endregion

            //http方式 上传园区    
            var sss = PostDataViaHttpWebRequest("http://218.90.225.108:8888/scyf/baseinfo/message", headers, formData);

            Console.WriteLine(sss);

        }

        /// <summary>
        /// post 请求form-data 参数
        /// </summary>
        /// <param name="baseUrl">请求地址</param>
        /// <param name="headers">header</param>
        /// <param name="DicformData">form-data参数</param>
        /// <returns></returns>

        public static string PostDataViaHttpWebRequest(string baseUrl, IReadOnlyDictionary<string, string> headers, Dictionary<string, string> DicformData)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(baseUrl);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";

            if (headers != null)
            {
                if (headers.Keys.Any(p => p.ToLower() == "content-type")) req.ContentType = headers.SingleOrDefault(p => p.Key.ToLower() == "content-type").Value;
                if (headers.Keys.Any(p => p.ToLower() == "accept")) req.Accept = headers.SingleOrDefault(p => p.Key.ToLower() == "accept").Value;
                var keyValuePairs = headers.Where(r => r.Key.ToLower() != "content-type").ToList();
                for (var i = 0; i < keyValuePairs.Count; i++)
                {
                    req.Headers.Add(keyValuePairs[i].Key, keyValuePairs[i].Value);
                }
            }

            #region 添加form-data参数
            StringBuilder builder = new StringBuilder();

            //参数
            int index = 0;
            foreach (var item in DicformData)
            {
                if (index > 0) builder.Append("&");
                builder.AppendFormat("{0}={1}", item.Key, item.Value);
                index++;
            }

            byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                //reqStream.Close();
            }
            #endregion
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

    }
}
