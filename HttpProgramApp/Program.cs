using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HttpProgramApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Console.WriteLine("Hello World!");




                ////HttpProgram.GetData2();
                //while (true)
                //{
                //    SendPeopleRealTimeData();
                //    Thread.Sleep(1000);
                //}

                //Console.ReadLine();


                string url = "http://test.e-arkema.com.cn:8081/api/cube/restful/interface/getModeDataPageList/SDMvisitlist";
                string data = "{\"operationinfo\":{\"operator\":\"1\"},\"mainTable\":{},\"pageInfo\":{\"pageNo\":\"1\",\"pageSize\":\"10\"},\"header\":{\"systemid\":\"SDMvisit\",\"currentDateTime\":\"20220706114954\",\"Md5\":\"9de956b866143634477472efb9711743\"}}";
                Dictionary<string, string> dic = new Dictionary<string, string>();

                dic.Add("datajson", data);
                //PostUrlencodedAsync(url,dic);

                //var ssss = PostUrlencodedAsync(url, dic);
                //Console.WriteLine(ssss);

                //string paramData = "datajson:{\"operationinfo\":{\"operator\":\"1\"},\"mainTable\":{},\"pageInfo\":{\"pageNo\":\"1\",\"pageSize\":\"10\"},\"header\":{\"systemid\":\"SDMvisit\",\"currentDateTime\":\"1657008591242\",\"Md5\":\"035ec587a58ea3c838956b4a4cea7fdd\"}}";
                //Console.WriteLine(PostUrl(url, paramData));






                #region

                string res = "{\"result\":\"[{\\\"mainTable\\\":{\\\"bgqy\\\":\\\"办公区\\\",\\\"wghyy\\\":\\\"\\\",\\\"cjrqsj\\\":\\\"\\\",\\\"lfdd\\\":\\\"南沙工厂\\\",\\\"cause\\\":\\\"内部测试\\\",\\\"fkkh\\\":\\\"\\\",\\\"jkm\\\":\\\"\\\",\\\"fwddgz\\\":\\\"\\\",\\\"fkkzt\\\":\\\"\\\",\\\"bfrgs\\\":\\\"沙多玛（广州）化学有限公司\\\",\\\"dfzt\\\":\\\"\\\",\\\"hcm\\\":\\\"\\\",\\\"totalnum\\\":\\\"1\\\",\\\"grc\\\":\\\"本人承诺所填信息的真实性\\\",\\\"dzyx\\\":\\\"tony.feng@arkema.com\\\",\\\"company\\\":\\\"\\\",\\\"id\\\":\\\"1\\\",\\\"state\\\":\\\"处理中\\\",\\\"lcid\\\":\\\"105121\\\",\\\"openid\\\":\\\"oi6Ztwm6zHhed46W7UDVKjNEb8GQ\\\",\\\"sex\\\":\\\"男\\\",\\\"sfyc\\\":\\\"\\\",\\\"visitdate\\\":\\\"2022-04-21\\\",\\\"gscbs\\\":\\\"广州市南沙区南沙长丰江电器机电经营部\\\",\\\"endtime\\\":\\\"\\\",\\\"phonenum\\\":\\\"13916813325\\\",\\\"bgdd\\\":\\\"广州/Guangzhou\\\",\\\"czlx\\\":\\\"\\\",\\\"bfr\\\":\\\"\\\",\\\"bfrllk\\\":\\\"冯建忠\\\",\\\"zjycxxrq\\\":\\\"\\\",\\\"sfzh\\\":\\\"undefined\\\",\\\"lffs\\\":\\\"自驾\\\",\\\"contactinfo\\\":\\\"18162260774\\\",\\\"arrivaltime\\\":\\\"\\\",\\\"lfzcph\\\":\\\"\\\",\\\"visitor\\\":\\\"沙多玛登记页优化后流程测试\\\",\\\"jzrq\\\":\\\"\\\",\\\"fklx\\\":\\\"承包商\\\"},\\\"detail1\\\":[]},{\\\"mainTable\\\":{\\\"bgqy\\\":\\\"实验室/生产区\\\",\\\"wghyy\\\":\\\"\\\",\\\"cjrqsj\\\":\\\"\\\",\\\"lfdd\\\":\\\"南沙工厂\\\",\\\"cause\\\":\\\"内部测试\\\",\\\"fkkh\\\":\\\"\\\",\\\"jkm\\\":\\\"\\\",\\\"fwddgz\\\":\\\"\\\",\\\"fkkzt\\\":\\\"\\\",\\\"bfrgs\\\":\\\"沙多玛（广州）化学有限公司\\\",\\\"dfzt\\\":\\\"\\\",\\\"hcm\\\":\\\"\\\",\\\"totalnum\\\":\\\"1\\\",\\\"grc\\\":\\\"本人承诺所填信息的真实性\\\",\\\"dzyx\\\":\\\"tony.feng@arkema.com\\\",\\\"company\\\":\\\"\\\",\\\"id\\\":\\\"2\\\",\\\"state\\\":\\\"处理中\\\",\\\"lcid\\\":\\\"105122\\\",\\\"openid\\\":\\\"oi6Ztwm6zHhed46W7UDVKjNEb8GQ\\\",\\\"sex\\\":\\\"男\\\",\\\"sfyc\\\":\\\"\\\",\\\"visitdate\\\":\\\"2022-04-21\\\",\\\"gscbs\\\":\\\"广钢气体（广州）有限公司\\\",\\\"endtime\\\":\\\"\\\",\\\"phonenum\\\":\\\"13916813325\\\",\\\"bgdd\\\":\\\"广州/Guangzhou\\\",\\\"czlx\\\":\\\"\\\",\\\"bfr\\\":\\\"\\\",\\\"bfrllk\\\":\\\"冯建忠\\\",\\\"zjycxxrq\\\":\\\"\\\",\\\"sfzh\\\":\\\"360225200002240215\\\",\\\"lffs\\\":\\\"自驾\\\",\\\"contactinfo\\\":\\\"18162260771\\\",\\\"arrivaltime\\\":\\\"\\\",\\\"lfzcph\\\":\\\"\\\",\\\"visitor\\\":\\\"沙多玛登记页优化测试01\\\",\\\"jzrq\\\":\\\"\\\",\\\"fklx\\\":\\\"承包商\\\"},\\\"detail1\\\":[]},{\\\"mainTable\\\":{\\\"bgqy\\\":\\\"办公区\\\",\\\"wghyy\\\":\\\"\\\",\\\"cjrqsj\\\":\\\"\\\",\\\"lfdd\\\":\\\"南沙工厂\\\",\\\"cause\\\":\\\"3\\\",\\\"fkkh\\\":\\\"\\\",\\\"jkm\\\":\\\"\\\",\\\"fwddgz\\\":\\\"\\\",\\\"fkkzt\\\":\\\"\\\",\\\"bfrgs\\\":\\\"沙多玛（广州）化学有限公司\\\",\\\"dfzt\\\":\\\"\\\",\\\"hcm\\\":\\\"\\\",\\\"totalnum\\\":\\\"1\\\",\\\"grc\\\":\\\"本人承诺所填信息的真实性\\\",\\\"dzyx\\\":\\\"tony.feng@arkema.com\\\",\\\"company\\\":\\\"\\\",\\\"id\\\":\\\"6\\\",\\\"state\\\":\\\"处理中\\\",\\\"lcid\\\":\\\"105240\\\",\\\"openid\\\":\\\"\\\",\\\"sex\\\":\\\"男\\\",\\\"sfyc\\\":\\\"\\\",\\\"visitdate\\\":\\\"2022-04-27\\\",\\\"gscbs\\\":\\\"广钢气体（广州）有限公司\\\",\\\"endtime\\\":\\\"\\\",\\\"phonenum\\\":\\\"13916813325\\\",\\\"bgdd\\\":\\\"广州/Guangzhou\\\",\\\"czlx\\\":\\\"\\\",\\\"bfr\\\":\\\"\\\",\\\"bfrllk\\\":\\\"冯建忠\\\",\\\"zjycxxrq\\\":\\\"\\\",\\\"sfzh\\\":\\\"314741258369369369\\\",\\\"lffs\\\":\\\"步行\\\",\\\"contactinfo\\\":\\\"15122233333\\\",\\\"arrivaltime\\\":\\\"\\\",\\\"lfzcph\\\":\\\"\\\",\\\"visitor\\\":\\\"汤\\\",\\\"jzrq\\\":\\\"\\\",\\\"fklx\\\":\\\"承包商\\\"},\\\"detail1\\\":[]},{\\\"mainTable\\\":{\\\"bgqy\\\":\\\"办公区\\\",\\\"wghyy\\\":\\\"\\\",\\\"cjrqsj\\\":\\\"\\\",\\\"lfdd\\\":\\\"南沙工厂\\\",\\\"cause\\\":\\\"测试\\\",\\\"fkkh\\\":\\\"\\\",\\\"jkm\\\":\\\"\\\",\\\"fwddgz\\\":\\\"\\\",\\\"fkkzt\\\":\\\"\\\",\\\"bfrgs\\\":\\\"沙多玛（广州）化学有限公司\\\",\\\"dfzt\\\":\\\"未到访\\\",\\\"hcm\\\":\\\"\\\",\\\"totalnum\\\":\\\"1\\\",\\\"grc\\\":\\\"本人承诺所填信息的真实性\\\",\\\"dzyx\\\":\\\"tony.feng@arkema.com\\\",\\\"company\\\":\\\"\\\",\\\"id\\\":\\\"10\\\",\\\"state\\\":\\\"已通过\\\",\\\"lcid\\\":\\\"105260\\\",\\\"openid\\\":\\\"oi6ZtwhPfXdcd1211A8EwhstW50o\\\",\\\"sex\\\":\\\"男\\\",\\\"sfyc\\\":\\\"\\\",\\\"visitdate\\\":\\\"2022-04-27\\\",\\\"gscbs\\\":\\\"广东省天洋建设集团有限公司\\\",\\\"endtime\\\":\\\"\\\",\\\"phonenum\\\":\\\"13916813325\\\",\\\"bgdd\\\":\\\"广州/Guangzhou\\\",\\\"czlx\\\":\\\"\\\",\\\"bfr\\\":\\\"\\\",\\\"bfrllk\\\":\\\"冯建忠\\\",\\\"zjycxxrq\\\":\\\"\\\",\\\"sfzh\\\":\\\"111111111111111111\\\",\\\"lffs\\\":\\\"步行\\\",\\\"contactinfo\\\":\\\"18111111111\\\",\\\"arrivaltime\\\":\\\"\\\",\\\"lfzcph\\\":\\\"\\\",\\\"visitor\\\":\\\"沙多玛-南沙工厂-承包商\\\",\\\"jzrq\\\":\\\"\\\",\\\"fklx\\\":\\\"承包商\\\"},\\\"detail1\\\":[]},{\\\"mainTable\\\":{\\\"bgqy\\\":\\\"办公区\\\",\\\"wghyy\\\":\\\"\\\",\\\"cjrqsj\\\":\\\"\\\",\\\"lfdd\\\":\\\"南沙工厂\\\",\\\"cause\\\":\\\"tes\\\",\\\"fkkh\\\":\\\"\\\",\\\"jkm\\\":\\\"\\\",\\\"fwddgz\\\":\\\"\\\",\\\"fkkzt\\\":\\\"\\\",\\\"bfrgs\\\":\\\"沙多玛（广州）化学有限公司\\\",\\\"dfzt\\\":\\\"\\\",\\\"hcm\\\":\\\"\\\",\\\"totalnum\\\":\\\"1\\\",\\\"grc\\\":\\\"本人承诺所填信息的真实性\\\",\\\"dzyx\\\":\\\"tony.feng@arkema.com\\\",\\\"company\\\":\\\"\\\",\\\"id\\\":\\\"12\\\",\\\"state\\\":\\\"处理中\\\",\\\"lcid\\\":\\\"105269\\\",\\\"openid\\\":\\\"oi6ZtwhjRFJBVTSLbP8ppvtO7w5U\\\",\\\"sex\\\":\\\"女\\\",\\\"sfyc\\\":\\\"\\\",\\\"visitdate\\\":\\\"2022-04-27\\\",\\\"gscbs\\\":\\\"广钢气体（广州）有限公司\\\",\\\"endtime\\\":\\\"\\\",\\\"phonenum\\\":\\\"13916813325\\\",\\\"bgdd\\\":\\\"广州/Guangzhou\\\",\\\"czlx\\\":\\\"\\\",\\\"bfr\\\":\\\"\\\",\\\"bfrllk\\\":\\\"冯建忠\\\",\\\"zjycxxrq\\\":\\\"\\\",\\\"sfzh\\\":\\\"undefined\\\",\\\"lffs\\\":\\\"步行\\\",\\\"contactinfo\\\":\\\"12345678900\\\",\\\"arrivaltime\\\":\\\"\\\",\\\"lfzcph\\\":\\\"\\\",\\\"visitor\\\":\\\"广州沙多码南沙工厂承包商办公室\\\",\\\"jzrq\\\":\\\"\\\",\\\"fklx\\\":\\\"承包商\\\"},\\\"detail1\\\":[]},{\\\"mainTable\\\":{\\\"bgqy\\\":\\\"实验室/生产区\\\",\\\"wghyy\\\":\\\"\\\",\\\"cjrqsj\\\":\\\"\\\",\\\"lfdd\\\":\\\"南沙工厂\\\",\\\"cause\\\":\\\"21\\\",\\\"fkkh\\\":\\\"\\\",\\\"jkm\\\":\\\"移动建模图片附件-1652843451815.jpg,移动建模图片附件-1652843456174.jpg\\\",\\\"fwddgz\\\":\\\"\\\",\\\"fkkzt\\\":\\\"\\\",\\\"bfrgs\\\":\\\"沙多玛（广州）化学有限公司\\\",\\\"dfzt\\\":\\\"\\\",\\\"hcm\\\":\\\"移动建模图片附件-1652843460555.jpg,移动建模图片附件-1652843463842.jpg\\\",\\\"totalnum\\\":\\\"1\\\",\\\"grc\\\":\\\"本人承诺所填信息的真实性\\\",\\\"dzyx\\\":\\\"wenjun.huang@weaver.com.cn\\\",\\\"company\\\":\\\"\\\",\\\"id\\\":\\\"23\\\",\\\"state\\\":\\\"处理中\\\",\\\"lcid\\\":\\\"112177\\\",\\\"openid\\\":\\\"oi6Ztwm6zHhed46W7UDVKjNEb8GQ\\\",\\\"sex\\\":\\\"男\\\",\\\"sfyc\\\":\\\"\\\",\\\"visitdate\\\":\\\"2022-05-18\\\",\\\"gscbs\\\":\\\"广钢气体（广州）有限公司\\\",\\\"endtime\\\":\\\"\\\",\\\"phonenum\\\":\\\"15199996666\\\",\\\"bgdd\\\":\\\"广州/Guangzhou\\\",\\\"czlx\\\":\\\"\\\",\\\"bfr\\\":\\\"\\\",\\\"bfrllk\\\":\\\"泛微测试003\\\",\\\"zjycxxrq\\\":\\\"2022-05-18\\\",\\\"sfzh\\\":\\\"369258333366665555\\\",\\\"lffs\\\":\\\"自驾\\\",\\\"contactinfo\\\":\\\"15166663333\\\",\\\"arrivaltime\\\":\\\"\\\",\\\"lfzcph\\\":\\\"贛4512365\\\",\\\"visitor\\\":\\\"沙多玛承包商证件信息测试\\\",\\\"jzrq\\\":\\\"2023-05-18\\\",\\\"fklx\\\":\\\"承包商\\\"},\\\"detail1\\\":[]},{\\\"mainTable\\\":{\\\"bgqy\\\":\\\"实验室/生产区\\\",\\\"wghyy\\\":\\\"\\\",\\\"cjrqsj\\\":\\\"\\\",\\\"lfdd\\\":\\\"南沙工厂\\\",\\\"cause\\\":\\\"21\\\",\\\"fkkh\\\":\\\"\\\",\\\"jkm\\\":\\\"移动建模图片附件-1652844091488.jpg,移动建模图片附件-1652844095669.jpg\\\",\\\"fwddgz\\\":\\\"\\\",\\\"fkkzt\\\":\\\"\\\",\\\"bfrgs\\\":\\\"沙多玛（广州）化学有限公司\\\",\\\"dfzt\\\":\\\"\\\",\\\"hcm\\\":\\\"移动建模图片附件-1652844102462.jpg,移动建模图片附件-1652844106780.jpg\\\",\\\"totalnum\\\":\\\"1\\\",\\\"grc\\\":\\\"本人承诺所填信息的真实性\\\",\\\"dzyx\\\":\\\"wenjun.huang@weaver.com.cn\\\",\\\"company\\\":\\\"\\\",\\\"id\\\":\\\"24\\\",\\\"state\\\":\\\"处理中\\\",\\\"lcid\\\":\\\"112179\\\",\\\"openid\\\":\\\"oi6Ztwm6zHhed46W7UDVKjNEb8GQ\\\",\\\"sex\\\":\\\"男\\\",\\\"sfyc\\\":\\\"\\\",\\\"visitdate\\\":\\\"2022-05-18\\\",\\\"gscbs\\\":\\\"广钢气体（广州）有限公司\\\",\\\"endtime\\\":\\\"\\\",\\\"phonenum\\\":\\\"15199996666\\\",\\\"bgdd\\\":\\\"广州/Guangzhou\\\",\\\"czlx\\\":\\\"\\\",\\\"bfr\\\":\\\"\\\",\\\"bfrllk\\\":\\\"泛微测试003\\\",\\\"zjycxxrq\\\":\\\"\\\",\\\"sfzh\\\":\\\"369258333366665555\\\",\\\"lffs\\\":\\\"自驾\\\",\\\"contactinfo\\\":\\\"15166663333\\\",\\\"arrivaltime\\\":\\\"\\\",\\\"lfzcph\\\":\\\"贛4512365\\\",\\\"visitor\\\":\\\"沙多玛承包商证件信息测试\\\",\\\"jzrq\\\":\\\"2023-05-18\\\",\\\"fklx\\\":\\\"承包商\\\"},\\\"detail1\\\":[]},{\\\"mainTable\\\":{\\\"bgqy\\\":\\\"实验室/生产区\\\",\\\"wghyy\\\":\\\"\\\",\\\"cjrqsj\\\":\\\"\\\",\\\"lfdd\\\":\\\"南沙工厂\\\",\\\"cause\\\":\\\"21\\\",\\\"fkkh\\\":\\\"\\\",\\\"jkm\\\":\\\"移动建模图片附件-1652845135767.jpg,移动建模图片附件-1652845140510.jpg\\\",\\\"fwddgz\\\":\\\"\\\",\\\"fkkzt\\\":\\\"\\\",\\\"bfrgs\\\":\\\"沙多玛（广州）化学有限公司\\\",\\\"dfzt\\\":\\\"\\\",\\\"hcm\\\":\\\"移动建模图片附件-1652845145338.jpg\\\",\\\"totalnum\\\":\\\"1\\\",\\\"grc\\\":\\\"本人承诺所填信息的真实性\\\",\\\"dzyx\\\":\\\"wenjun.huang@weaver.com.cn\\\",\\\"company\\\":\\\"\\\",\\\"id\\\":\\\"25\\\",\\\"state\\\":\\\"处理中\\\",\\\"lcid\\\":\\\"112181\\\",\\\"openid\\\":\\\"oi6Ztwm6zHhed46W7UDVKjNEb8GQ\\\",\\\"sex\\\":\\\"男\\\",\\\"sfyc\\\":\\\"\\\",\\\"visitdate\\\":\\\"2022-05-18\\\",\\\"gscbs\\\":\\\"广钢气体（广州）有限公司\\\",\\\"endtime\\\":\\\"\\\",\\\"phonenum\\\":\\\"15199996666\\\",\\\"bgdd\\\":\\\"广州/Guangzhou\\\",\\\"czlx\\\":\\\"\\\",\\\"bfr\\\":\\\"\\\",\\\"bfrllk\\\":\\\"泛微测试003\\\",\\\"zjycxxrq\\\":\\\"\\\",\\\"sfzh\\\":\\\"369258333366665555\\\",\\\"lffs\\\":\\\"自驾\\\",\\\"contactinfo\\\":\\\"15166663333\\\",\\\"arrivaltime\\\":\\\"\\\",\\\"lfzcph\\\":\\\"贛4512365\\\",\\\"visitor\\\":\\\"沙多玛承包商证件信息测试001\\\",\\\"jzrq\\\":\\\"2023-05-18\\\",\\\"fklx\\\":\\\"承包商\\\"},\\\"detail1\\\":[]},{\\\"mainTable\\\":{\\\"bgqy\\\":\\\"实验室/生产区\\\",\\\"wghyy\\\":\\\"\\\",\\\"cjrqsj\\\":\\\"\\\",\\\"lfdd\\\":\\\"南沙工厂\\\",\\\"cause\\\":\\\"21\\\",\\\"fkkh\\\":\\\"\\\",\\\"jkm\\\":\\\"\\\",\\\"fwddgz\\\":\\\"\\\",\\\"fkkzt\\\":\\\"\\\",\\\"bfrgs\\\":\\\"沙多玛（广州）化学有限公司\\\",\\\"dfzt\\\":\\\"\\\",\\\"hcm\\\":\\\"\\\",\\\"totalnum\\\":\\\"1\\\",\\\"grc\\\":\\\"本人承诺所填信息的真实性\\\",\\\"dzyx\\\":\\\"wenjun.huang@weaver.com.cn\\\",\\\"company\\\":\\\"\\\",\\\"id\\\":\\\"26\\\",\\\"state\\\":\\\"处理中\\\",\\\"lcid\\\":\\\"114119\\\",\\\"openid\\\":\\\"oi6Ztwm6zHhed46W7UDVKjNEb8GQ\\\",\\\"sex\\\":\\\"男\\\",\\\"sfyc\\\":\\\"\\\",\\\"visitdate\\\":\\\"2022-05-19\\\",\\\"gscbs\\\":\\\"广钢气体（广州）有限公司\\\",\\\"endtime\\\":\\\"\\\",\\\"phonenum\\\":\\\"15199996666\\\",\\\"bgdd\\\":\\\"广州/Guangzhou\\\",\\\"czlx\\\":\\\"\\\",\\\"bfr\\\":\\\"\\\",\\\"bfrllk\\\":\\\"泛微测试003\\\",\\\"zjycxxrq\\\":\\\"\\\",\\\"sfzh\\\":\\\"369258333366665555\\\",\\\"lffs\\\":\\\"自驾\\\",\\\"contactinfo\\\":\\\"15166663333\\\",\\\"arrivaltime\\\":\\\"\\\",\\\"lfzcph\\\":\\\"贛4512365\\\",\\\"visitor\\\":\\\"沙多玛承包商证件信息测试001\\\",\\\"jzrq\\\":\\\"2023-05-18\\\",\\\"fklx\\\":\\\"承包商\\\"},\\\"detail1\\\":[]},{\\\"mainTable\\\":{\\\"bgqy\\\":\\\"实验室/生产区\\\",\\\"wghyy\\\":\\\"\\\",\\\"cjrqsj\\\":\\\"\\\",\\\"lfdd\\\":\\\"南沙工厂\\\",\\\"cause\\\":\\\"21\\\",\\\"fkkh\\\":\\\"\\\",\\\"jkm\\\":\\\"\\\",\\\"fwddgz\\\":\\\"\\\",\\\"fkkzt\\\":\\\"\\\",\\\"bfrgs\\\":\\\"沙多玛（广州）化学有限公司\\\",\\\"dfzt\\\":\\\"\\\",\\\"hcm\\\":\\\"\\\",\\\"totalnum\\\":\\\"1\\\",\\\"grc\\\":\\\"本人承诺所填信息的真实性\\\",\\\"dzyx\\\":\\\"wenjun.huang@weaver.com.cn\\\",\\\"company\\\":\\\"\\\",\\\"id\\\":\\\"27\\\",\\\"state\\\":\\\"处理中\\\",\\\"lcid\\\":\\\"114120\\\",\\\"openid\\\":\\\"oi6Ztwm6zHhed46W7UDVKjNEb8GQ\\\",\\\"sex\\\":\\\"男\\\",\\\"sfyc\\\":\\\"\\\",\\\"visitdate\\\":\\\"2022-05-18\\\",\\\"gscbs\\\":\\\"广钢气体（广州）有限公司\\\",\\\"endtime\\\":\\\"\\\",\\\"phonenum\\\":\\\"15199996666\\\",\\\"bgdd\\\":\\\"广州/Guangzhou\\\",\\\"czlx\\\":\\\"\\\",\\\"bfr\\\":\\\"\\\",\\\"bfrllk\\\":\\\"泛微测试003\\\",\\\"zjycxxrq\\\":\\\"\\\",\\\"sfzh\\\":\\\"369258333366665555\\\",\\\"lffs\\\":\\\"自驾\\\",\\\"contactinfo\\\":\\\"15166663333\\\",\\\"arrivaltime\\\":\\\"\\\",\\\"lfzcph\\\":\\\"贛4512365\\\",\\\"visitor\\\":\\\"沙多玛承包商证件信息测试002\\\",\\\"jzrq\\\":\\\"2023-05-18\\\",\\\"fklx\\\":\\\"承包商\\\"},\\\"detail1\\\":[]}]\"}";
                #endregion
                var entityDto = new clsResponseModel();
                entityDto = (clsResponseModel)JObject.Parse(res).ToObject(entityDto.GetType());
                var lstData = new List<clsTempModel>();
                object obj = Newtonsoft.Json.JsonConvert.DeserializeObject(entityDto.result, typeof(List<clsTempModel>));
                lstData = (List<clsTempModel>)obj;
                foreach (var item in lstData)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(item.mainTable));
                }



                // //var sssj = EIPAS.eCommonLibrary.JsonHelper.StringJson(entityDto.result);
                // //EIPAS.eCommonLibrary.JsonHelper.ListToJson(sssj,"fdafdas");
                // var sdfadsfads = JsonHelper.JsonTool.JsonTo<clsTemp>(entityDto.result);
                //var  lstData = new List<clsTempModel>();
                // foreach (var item in sdfadsfads.lstData)
                // {
                //     lstData.Add(item);
                // }
                //var entity = JsonConvert.DeserializeObject<clsResponseModel>(res);
                //var ssss = new clsTemp();


                //ssss = (clsTemp)JObject.Parse(entityDto.result).ToObject(ssss.GetType());
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();


        }

        public static async Task<string> PostUrlencodedAsync(string url, Dictionary<string, string> dic)
        {
            string ssss = string.Empty;
            try
            {
                using (HttpClient _httpClient = new HttpClient())
                {
                    HttpContent httpContent = new FormUrlEncodedContent(dic);
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                    var response = await _httpClient.PostAsync(url, httpContent);

                    ssss = await response.Content.ReadAsStringAsync();

                    // await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return ssss;

        }

        /// <summary>
        /// Post提交数据
        /// </summary>
        /// <param name="postUrl">URL</param>
        /// <param name="paramData">参数</param>
        /// <returns></returns>
        static string PostWebRequest(string postUrl, string paramData)
        {
            string ret = string.Empty;
            try
            {
                if (!postUrl.StartsWith("http://"))
                    return "";

                byte[] byteArray = Encoding.Default.GetBytes(paramData); //转化 /
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
                webReq.Method = "POST";
                webReq.ContentType = "application/x-www-form-urlencoded";

                webReq.ContentLength = byteArray.Length;
                Stream newStream = webReq.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length);//写入参数
                newStream.Close();
                HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                ret = sr.ReadToEnd();
                sr.Close();
                response.Close();
                newStream.Close();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return ret;
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">为请求地址</param>
        /// <param name="postData">请求内容例如："key1=value1&key2=value2&key3=value3"</param>
        /// <returns></returns>
        public static string PostUrl(string url, string postData)
        {
            string result = "";
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

                req.Method = "POST";

                req.ContentType = "application/x-www-form-urlencoded";

                req.Timeout = 800;//请求超时时间

                byte[] data = Encoding.UTF8.GetBytes(postData);

                req.ContentLength = data.Length;

                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);

                    reqStream.Close();
                }

                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

                Stream stream = resp.GetResponseStream();

                //获取响应内容
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }
            }
            catch (Exception e) { }

            return result;
        }



        //public static string PostUrlencodedAsync(string url, Dictionary<string, string> dic)
        //{
        //    using (HttpClient _httpClient = new HttpClient())
        //    {
        //        HttpContent httpContent = new FormUrlEncodedContent(dic);
        //        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
        //        var response = _httpClient.PostAsync(url, httpContent);
        //        return response.Result.RequestMessage.Content.ToString();
        //    }
        //}

        public static void SendPeopleRealTimeData()
        {
            string postData = "{\"type\":\"location\",\"data\":{\"buildId\":\"200625\",\"floorNo\":\"Floor1\",\"userId\":\"1918E0018DCD\",\"timestampMillisecond\":1637163958267,\"xMillimeter\":233147,\"yMillimeter\":185383,\"locationType\":1,\"status\":0,\"src\":0,\"longitude\":121.07399572092073,\"latitude\":32.54572593355835},\"time\":1637163958269}";

            List<string> lstRandomData = new List<string> { "1918E0018DCD", "1918E002A56F", "1918E0013100", "1918E0013163", "1918E0013135", "1918E0013169", "1918E002A583", "1918E002A552", "1918E0013132", "1918E002A454", "1918E001307E", "1918E0013170", "1918E0013094", "1918E0013164", "1918E001311D", "1918E002A5AD", "1918E002A54B", "1918E0037B05", "1918E002A572" };

            //lstRandomData = new List<string>() { "1918E0018DCD", "1918E002A56F", "1918E0013100", "1918E0037B05", "1918E002A572" };

            for (int i = 1; i <= 10; i++)
            {

                postData = "{\"type\":\"location\",\"data\":{\"buildId\":\"200625\",\"floorNo\":\"Floor1\",\"userId\":\"" + i + "\",\"timestampMillisecond\":1637163958267,\"xMillimeter\":233147,\"yMillimeter\":185383,\"locationType\":1,\"status\":0,\"src\":0,\"longitude\":121.07399572092073,\"latitude\":32.54572593355835},\"time\":1637163958269}";


                string url = "https://localhost:5001/webSocketApi/localtion/ZQPersonnelRealTime";
                string result = "";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "POST";
                //req.Timeout = 800;//设置请求超时时间，单位为毫秒
                req.ContentType = "application/json";
                byte[] data = Encoding.UTF8.GetBytes(postData);
                req.ContentLength = data.Length;
                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);
                    reqStream.Close();
                }
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                Stream stream = resp.GetResponseStream();
                //获取响应内容
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }

                Console.Write(i + "\t");
            }
            Console.WriteLine();

            //foreach (var item in lstRandomData)
            //{
            //    postData = "{\"type\":\"location\",\"data\":{\"buildId\":\"200625\",\"floorNo\":\"Floor1\",\"userId\":\"" + item + "\",\"timestampMillisecond\":1637163958267,\"xMillimeter\":233147,\"yMillimeter\":185383,\"locationType\":1,\"status\":0,\"src\":0,\"longitude\":121.07399572092073,\"latitude\":32.54572593355835},\"time\":1637163958269}";


            //    string url = "http://163.53.170.58:8117/webSocketApi/localtion/ZQPersonnelRealTime";
            //    string result = "";
            //    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            //    req.Method = "POST";
            //    //req.Timeout = 800;//设置请求超时时间，单位为毫秒
            //    req.ContentType = "application/json";
            //    byte[] data = Encoding.UTF8.GetBytes(postData);
            //    req.ContentLength = data.Length;
            //    using (Stream reqStream = req.GetRequestStream())
            //    {
            //        reqStream.Write(data, 0, data.Length);
            //        reqStream.Close();
            //    }
            //    HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            //    Stream stream = resp.GetResponseStream();
            //    //获取响应内容
            //    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            //    {
            //        result = reader.ReadToEnd();
            //    }

            //    Console.WriteLine(result);

            //}

        }

    }

}
