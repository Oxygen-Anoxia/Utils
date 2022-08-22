using InroadLinkBasf.Core.Log;
using InroadLinkBasf.Core.Model.Models.Park;
using InroadLinkBasf.Core.Model.Models.Park.DpcAnHui;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Dpc.ChuZhou
{
    public class DpcCzCommonService : IDpcCzCommonService
    {
        private string LogTag = "DpcCzCommonService.";

        /// <summary>
        /// 4.2  隐患排查任务 修改
        /// </summary>
        /// <param name="entity">修改对象</param>
        /// <returns></returns>
        public async Task<clsResponse> UpdateCheckTask(clsCreateCheckTaskModel entity)
        {

            var res = new clsResponse();
            LogDotNetApiService _logService = new LogDotNetApiService();
            try
            {
                string prefix = clsCreateCheckTaskModel.prefix;//参数前缀
                string updateRiskUnitUrl = "http://220.178.10.89:9088/whp/dangerTaskAction!updateCheckTask";

                HttpWebRequest request = WebRequest.Create(updateRiskUnitUrl) as HttpWebRequest;
                //创建http请求实例
                request.Method = "post";
                request.ContentType = "application/x-www-form-urlencoded";
                StringBuilder buffer = new StringBuilder();//使用字典的方式设置入参名与参数 

                //buffer.AppendFormat("{0}={1}&", prefix + "pwd", "1db77f21f1d34757b019a9a1040981ec");//密钥【必填】全椒南大光电材料有限公司
                buffer.AppendFormat("{0}={1}&", prefix + "pwd", "e81ecebb857544ce92a15d238c830ed4");//密钥【必填】安徽金禾实业股份有限公司
                buffer.AppendFormat("{0}={1}&", prefix + "id", entity.id);//隐患排查任务ID【必填】
                buffer.AppendFormat("{0}={1}&", prefix + "riskMeasureId", entity.riskMeasureId);//风险管控ID【必填】
                buffer.AppendFormat("{0}={1}&", prefix + "troubleshootContent", entity.troubleshootContent);//隐患内容 【必填】
                buffer.AppendFormat("{0}={1}&", prefix + "checkCycle", entity.checkCycle);//巡检周期【必填】
                buffer.AppendFormat("{0}={1}&", prefix + "checkCycleUnit", entity.checkCycleUnit);//巡检周期单位【必填】
                buffer.AppendFormat("{0}={1}&", prefix + "investigationDate", entity.investigationDate);//最近排查时间【必填】
                buffer.AppendFormat("{0}={1}&", prefix + "checkStatus", entity.checkStatus);//排查结果【必填】
                buffer.AppendFormat("{0}={1}&", prefix + "checker", entity.checker);//排查结果 
                buffer.AppendFormat("{0}={1}&", prefix + "checkLevel", entity.checkLevel);//巡检级别 
                buffer.AppendFormat("{0}={1}&", prefix + "checkTimesDay", entity.checkTimesDay);//巡检频次(天数/班数) 
                buffer.AppendFormat("{0}={1}&", prefix + "checkTimesNum", entity.checkTimesNum);//巡检频次(次数)
                buffer.AppendFormat("{0}={1}&", prefix + "checkTaskType", entity.checkTaskType);//巡检任务类型
                buffer.AppendFormat("{0}={1}&", prefix + "checkStartDate", entity.checkStartDate);//巡检有效开始时间
                buffer.AppendFormat("{0}={1}", prefix + "checkEndDate", entity.checkEndDate);//巡检有效开始时间

                string parameter = parameter = buffer.ToString();
                byte[] data = Encoding.UTF8.GetBytes(buffer.ToString());
                Stream stream = request.GetRequestStream();
                stream.Write(data, 0, data.Length);
                stream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
                string result = streamReader.ReadToEnd();
                responseStream.Close();
                streamReader.Close();
                if (result == null || result.Equals(""))
                {
                    Console.WriteLine("隐患排查任务修改接口响应为空ip:" + updateRiskUnitUrl);
                    _logService.AddLog(new clsLogDotNetApi()
                    {
                        logtype = "Info",
                        url = "",
                        api = LogTag + "UpdateCheckRecord",
                        apiname = "",
                        parameter = parameter,
                        title = "Park_隐患排查任务修改接口",
                        logcontent = "隐患排查任务 修改接口响应为空 ip:" + updateRiskUnitUrl,
                        currentmethod = "UpdateCheckRecord",
                        currentthread = Thread.CurrentThread.ManagedThreadId
                    });
                }
                else
                {
                    try
                    {
                        var _clsResponse = new clsResponse();
                        _clsResponse = (clsResponse)JObject.Parse(result).ToObject(_clsResponse.GetType());
                        if (_clsResponse.operateSuccess)//修改成功
                            res = _clsResponse;
                        else
                            _logService.AddLog(new clsLogDotNetApi()
                            {
                                logtype = "Warning",
                                url = "",
                                api = LogTag + "UpdateCheckRecord",
                                apiname = "",
                                parameter = parameter,
                                title = "Park_隐患排查任务修改接口",
                                logcontent = "隐患排查任务修改接口失败，接口返回原因：" + _clsResponse.operateMessage,
                                currentmethod = "UpdateCheckRecord",
                                currentthread = Thread.CurrentThread.ManagedThreadId
                            });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("修改隐患排查任务数据响应异常:" + ex.StackTrace);
                        _logService.AddLog(new clsLogDotNetApi()
                        {
                            logtype = "Error",
                            url = "",
                            api = LogTag + "UpdateCheckRecord",
                            apiname = "",
                            parameter = parameter,
                            title = "Park_隐患排查任务修改接口",
                            logcontent = "修改隐患排查任务数据响应异常:" + ex.StackTrace,
                            currentmethod = "UpdateCheckRecord",
                            currentthread = Thread.CurrentThread.ManagedThreadId
                        });
                        return res;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("修改隐患排查任务数据异常:" + ex.StackTrace);
                _logService.AddLog(new clsLogDotNetApi()
                {
                    logtype = "Error",
                    url = "",
                    api = LogTag + "UpdateCheckRecord",
                    apiname = "",
                    parameter = "",
                    title = "Park_隐患排查任务修改接口",
                    logcontent = "修改隐患排查任务数据异常:" + ex.StackTrace,
                    currentmethod = "UpdateCheckRecord",
                    currentthread = Thread.CurrentThread.ManagedThreadId
                });
                return res;
            }

            return res;
        }


        /// <summary>
        /// 5.2  隐患排查记录 修改
        /// </summary>
        /// <param name="entity">修改对象</param>
        /// <returns></returns>
        public async Task<clsResponse> UpdateCheckRecord(clsCreateCheckRecordModel entity)
        {

            var res = new clsResponse();
            LogDotNetApiService _logService = new LogDotNetApiService();
            try
            {
                string prefix = clsCreateCheckRecordModel.prefix;//参数前缀

                string updateRiskUnitUrl = "http://220.178.10.89:9088/syf/dangerNoteAction!updateCheckRecord ";

                HttpWebRequest request = WebRequest.Create(updateRiskUnitUrl) as HttpWebRequest;
                //创建http请求实例
                request.Method = "post";
                request.ContentType = "application/x-www-form-urlencoded";
                StringBuilder buffer = new StringBuilder();//使用字典的方式设置入参名与参数 

                //buffer.AppendFormat("{0}={1}&", prefix + "pwd", "1db77f21f1d34757b019a9a1040981ec");//密钥【必填】全椒南大光电材料有限公司
                buffer.AppendFormat("{0}={1}&", prefix + "pwd", "e81ecebb857544ce92a15d238c830ed4");//密钥【必填】安徽金禾实业股份有限公司

                buffer.AppendFormat("{0}={1}&", prefix + "companyCode", entity.companyCode);//companyCode【必填】
                buffer.AppendFormat("{0}={1}&", prefix + "id", entity.id);//id【必填】
                buffer.AppendFormat("{0}={1}&", prefix + "checkTaskId", entity.checkTaskId);//排查任务ID【必填】
                buffer.AppendFormat("{0}={1}&", prefix + "checkTime", entity.checkTime);//排查时间【必填】
                buffer.AppendFormat("{0}={1}&", prefix + "checkStatus", entity.checkStatus);//排查结果【必填】
                buffer.AppendFormat("{0}={1}&", prefix + "checkRiskName", entity.checkRiskName);//排查结果 
                buffer.AppendFormat("{0}={1}&", prefix + "checkRiskLevel", entity.checkRiskLevel);//排查风险等级 
                buffer.AppendFormat("{0}={1}&", prefix + "checkDep", entity.checkDep);//排查部门 
                buffer.AppendFormat("{0}={1}&", prefix + "checker", entity.checker);//排查人 
                buffer.AppendFormat("{0}={1}&", prefix + "checkerPhoneNo", entity.checkerPhoneNo);//排查人联系电话 
                buffer.AppendFormat("{0}={1}&", prefix + "createByMobile", entity.createByMobile);//创建人手机号 
                buffer.AppendFormat("{0}={1}", prefix + "updateByMobile", entity.updateByMobile);//最后修改人手机号  

                string parameter = buffer.ToString();
                byte[] data = Encoding.UTF8.GetBytes(buffer.ToString());
                Stream stream = request.GetRequestStream();
                stream.Write(data, 0, data.Length);
                stream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
                string result = streamReader.ReadToEnd();
                responseStream.Close();
                streamReader.Close();
                if (result == null || result.Equals(""))
                {
                    Console.WriteLine(" 隐患排查记录修改接口响应为空ip:" + updateRiskUnitUrl);
                    _logService.AddLog(new clsLogDotNetApi()
                    {
                        logtype = "Info",
                        url = "",
                        api = LogTag + "UpdateCheckRecord",
                        apiname = "",
                        parameter = parameter,
                        title = "Park_ 隐患排查记录修改接口",
                        logcontent = " 隐患排查记录 修改接口响应为空 ip:" + updateRiskUnitUrl,
                        currentmethod = "UpdateCheckRecord",
                        currentthread = Thread.CurrentThread.ManagedThreadId
                    });
                }
                else
                {
                    try
                    {
                        var _clsResponse = new clsResponse();
                        _clsResponse = (clsResponse)JObject.Parse(result).ToObject(_clsResponse.GetType());
                        if (_clsResponse.operateSuccess)//修改成功
                            res = _clsResponse;
                        else
                            _logService.AddLog(new clsLogDotNetApi()
                            {
                                logtype = "Warning",
                                url = "",
                                api = LogTag + "UpdateCheckRecord",
                                apiname = "",
                                parameter = parameter,
                                title = "Park_ 隐患排查记录修改接口",
                                logcontent = " 隐患排查记录修改接口失败，接口返回原因：" + _clsResponse.operateMessage,
                                currentmethod = "UpdateCheckRecord",
                                currentthread = Thread.CurrentThread.ManagedThreadId
                            });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("修改 隐患排查记录数据响应异常:" + ex.StackTrace);
                        _logService.AddLog(new clsLogDotNetApi()
                        {
                            logtype = "Error",
                            url = "",
                            api = LogTag + "UpdateCheckRecord",
                            apiname = "",
                            parameter = parameter,
                            title = "Park_ 隐患排查记录修改接口",
                            logcontent = "修改 隐患排查记录数据响应异常:" + ex.StackTrace,
                            currentmethod = "UpdateCheckRecord",
                            currentthread = Thread.CurrentThread.ManagedThreadId
                        });
                        return res;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("修改 隐患排查记录数据异常:" + ex.StackTrace);
                _logService.AddLog(new clsLogDotNetApi()
                {
                    logtype = "Error",
                    url = "",
                    api = LogTag + "UpdateCheckRecord",
                    apiname = "",
                    parameter = "",
                    title = "Park_ 隐患排查记录修改接口",
                    logcontent = "修改 隐患排查记录数据异常:" + ex.StackTrace,
                    currentmethod = "UpdateCheckRecord",
                    currentthread = Thread.CurrentThread.ManagedThreadId
                });
                return res;
            }

            return res;
        }

        public async Task<clsResponse> UpdateRiskUnit(clsCreateRiskUnitModel entity)
        {

            LogDotNetApiService _logService = new LogDotNetApiService();

            string updateRiskUnitUrl = "http://220.178.10.89:9088/whp/riskUnitAction!updateRiskUnit";
            string pwd = "1db77f21f1d34757b019a9a1040981ec";
            var res = new clsResponse();
            try
            {
                string prefix = clsCreateRiskUnitModel.prefix;//参数前缀

                HttpWebRequest request = WebRequest.Create(updateRiskUnitUrl) as HttpWebRequest;
                //创建http请求实例
                request.Method = "post";
                request.ContentType = "application/x-www-form-urlencoded";
                StringBuilder buffer = new StringBuilder();//使用字典的方式设置入参名与参数 

                buffer.AppendFormat("{0}={1}&", prefix + "pwd", pwd);//密钥【必填】
                buffer.AppendFormat("{0}={1}&", prefix + "id", entity.id);//风险分析单元ID【必填】
                buffer.AppendFormat("{0}={1}&", prefix + "isHazard", entity.isHazard);//是否为风险分析对象【必填】
                buffer.AppendFormat("{0}={1}&", prefix + "hazardCode", entity.hazardCode);//风险分析对象编码【必填】
                buffer.AppendFormat("{0}={1}&", prefix + "hazardName", entity.hazardName);//风险分析对象名称 
                buffer.AppendFormat("{0}={1}&", prefix + "riskUnitName", entity.riskUnitName);//风险分析单元名称【必填】
                buffer.AppendFormat("{0}={1}&", prefix + "hazardType", entity.hazardType);//风险分析对象分类
                buffer.AppendFormat("{0}={1}&", prefix + "hazardPoint", entity.hazardPoint);//风险点位置
                buffer.AppendFormat("{0}={1}&", prefix + "establishDate", entity.establishDate);//投用日期
                //buffer.AppendFormat("{0}={1}&", prefix + "hazardRank", entity.hazardRank);//风险分析对象等级
                buffer.AppendFormat("{0}={1}&", prefix + "rvalue", entity.rvalue);//风险分析对象R值
                buffer.AppendFormat("{0}={1}&", prefix + "hazardDesc", entity.hazardDesc);//风险分析对象描述
                buffer.AppendFormat("{0}={1}&", prefix + "hiddenDanger", entity.hiddenDanger);//潜在隐患情况
                buffer.AppendFormat("{0}={1}&", prefix + "emerDeal", entity.emerDeal);//应急处置措施
                buffer.AppendFormat("{0}={1}&", prefix + "hazardDep", entity.hazardDep);//风险分析对象所属责任人部门 【必填】
                buffer.AppendFormat("{0}={1}&", prefix + "hazardLiablePerson", entity.hazardLiablePerson);//风险分析对象所属责任人姓名 【必填】
                buffer.AppendFormat("{0}={1}&", prefix + "controlDeal", entity.controlDeal);//管控措施
                buffer.AppendFormat("{0}={1}", prefix + "controlStatus", entity.controlStatus);//管控状态
                string parameter = parameter = buffer.ToString();
                byte[] data = Encoding.UTF8.GetBytes(buffer.ToString());
                Stream stream = request.GetRequestStream();
                stream.Write(data, 0, data.Length);
                stream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
                string result = streamReader.ReadToEnd();
                responseStream.Close();
                streamReader.Close();
                if (result == null || result.Equals(""))
                {
                    Console.WriteLine("风险分析单元修改接口响应为空ip:" + updateRiskUnitUrl);
                    _logService.AddLog(new clsLogDotNetApi()
                    {
                        logtype = "Info",
                        url = "",
                        api = LogTag + "UpdateRiskUnit",
                        apiname = "",
                        parameter = parameter,
                        title = "Park_风险分析单元修改接口",
                        logcontent = "风险分析单元修改接口响应为空 ip:" + updateRiskUnitUrl,
                        currentmethod = "UpdateRiskUnit",
                        currentthread = Thread.CurrentThread.ManagedThreadId
                    });
                }
                else
                {
                    try
                    {
                        var _clsResponse = new clsResponse();
                        _clsResponse = (clsResponse)JObject.Parse(result).ToObject(_clsResponse.GetType());
                        if (_clsResponse.operateSuccess)//修改成功
                            res = _clsResponse;
                        else
                            _logService.AddLog(new clsLogDotNetApi()
                            {
                                logtype = "Warning",
                                url = "",
                                api = LogTag + "UpdateRiskUnit",
                                apiname = "",
                                parameter = parameter,
                                title = "Park_风险分析单元修改接口",
                                logcontent = "风险分析单元修改接口失败，接口返回原因：" + _clsResponse.operateMessage,
                                currentmethod = "UpdateRiskUnit",
                                currentthread = Thread.CurrentThread.ManagedThreadId
                            });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("修改风险分析单元数据响应异常:" + ex.StackTrace);
                        _logService.AddLog(new clsLogDotNetApi()
                        {
                            logtype = "Error",
                            url = "",
                            api = LogTag + "UpdateRiskUnit",
                            apiname = "",
                            parameter = parameter,
                            title = "Park_风险分析单元修改接口",
                            logcontent = "修改风险分析单元数据响应异常:" + ex.StackTrace,
                            currentmethod = "UpdateRiskUnit",
                            currentthread = Thread.CurrentThread.ManagedThreadId
                        });
                        return res;
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("修改风险分析单元数据异常:" + ex.StackTrace);
                _logService.AddLog(new clsLogDotNetApi()
                {
                    logtype = "Error",
                    url = "",
                    api = LogTag + "UpdateRiskUnit",
                    apiname = "",
                    parameter = "",
                    title = "Park_风险分析单元修改接口",
                    logcontent = "修改风险分析单元数据异常:" + ex.StackTrace,
                    currentmethod = "UpdateRiskUnit",
                    currentthread = Thread.CurrentThread.ManagedThreadId
                });
                return res;
            }

            return res;
        }

        /// <summary>
        /// 1.3 风险分析单元 删除
        /// </summary>
        /// <param name="entity">删除对象</param>
        /// <returns></returns>
        public async Task<clsResponse> DeleteRiskUnit(clsCreateRiskUnitModel entity)
        {

            var res = new clsResponse();
            LogDotNetApiService _logService = new LogDotNetApiService();
            try
            {
                string prefix = clsCreateRiskUnitModel.delPrefix;//参数前缀
                HttpWebRequest request = WebRequest.Create("http://220.178.10.89:9088/syf/riskUnitAction!deleteRiskUnit") as HttpWebRequest;
                //创建http请求实例
                request.Method = "post";
                request.ContentType = "application/x-www-form-urlencoded";
                StringBuilder buffer = new StringBuilder();//使用字典的方式设置入参名与参数 

                //buffer.AppendFormat("{0}={1}&", prefix + "pwd", "e81ecebb857544ce92a15d238c830ed4");//金禾密钥【必填】
                buffer.AppendFormat("{0}={1}&", prefix + "pwd", "1db77f21f1d34757b019a9a1040981ec");//全椒南大密钥【必填】
                buffer.AppendFormat("{0}={1}&", prefix + "riskUnitIds", entity.id);//风险分析单元ID【必填】
                buffer.AppendFormat("{0}={1}&", prefix + "isLinkDelete", "1");//是否级联删除 只向下级联删除，不传值默认非级联删除  1 - 是  2 - 否

                string parameter = parameter = buffer.ToString();
                byte[] data = Encoding.UTF8.GetBytes(buffer.ToString());
                Stream stream = request.GetRequestStream();
                stream.Write(data, 0, data.Length);
                stream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
                string result = streamReader.ReadToEnd();
                responseStream.Close();
                streamReader.Close();
                if (result == null || result.Equals(""))
                {
                    Console.WriteLine("风险分析单元 删除接口响应为空ip:" + "http://220.178.10.89:9088/syf/riskUnitAction!deleteRiskUnit");
                    _logService.AddLog(new clsLogDotNetApi()
                    {
                        logtype = "Info",
                        url = "",
                        api = LogTag + "DeleteRiskUnit",
                        apiname = "",
                        parameter = parameter,
                        title = "Park_风险分析单元删除接口",
                        logcontent = "风险分析单元删除接口响应为空 ip:" + "http://220.178.10.89:9088/syf/riskUnitAction!deleteRiskUnit",
                        currentmethod = "DeleteRiskUnit",
                        currentthread = Thread.CurrentThread.ManagedThreadId
                    });
                }
                else
                {
                    try
                    {
                        var _clsResponse = new clsResponse();
                        _clsResponse.operateObj = res;
                        _clsResponse = (clsResponse)JObject.Parse(result).ToObject(_clsResponse.GetType());

                        if (_clsResponse.operateSuccess)//删除成功
                        {
                            //_logService.AddLog(new clsLogDotNetApi()
                            //{
                            //    logtype = "Info",
                            //    url = "",
                            //    api = LogTag + "DeleteCheck",
                            //    apiname = "",
                            //    parameter = parameter,
                            //    title = "Park_隐患排查信息删除接口",
                            //    logcontent = "隐患排查信息删除接口成功：" + entity.id.ToString(),
                            //    currentmethod = "DeleteCheck",
                            //    currentthread = Thread.CurrentThread.ManagedThreadId
                            //});
                            res = _clsResponse;
                        }
                        else
                            _logService.AddLog(new clsLogDotNetApi()
                            {
                                logtype = "Warning",
                                url = "",
                                api = LogTag + "DeleteCheck",
                                apiname = "",
                                parameter = parameter,
                                title = "Park_隐患排查信息删除接口",
                                logcontent = "隐患排查信息删除接口添加失败，接口返回原因：" + _clsResponse.operateMessage,
                                currentmethod = "DeleteCheck",
                                currentthread = Thread.CurrentThread.ManagedThreadId
                            });


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("删除风险分析单元数据响应异常:" + ex.StackTrace);
                        _logService.AddLog(new clsLogDotNetApi()
                        {
                            logtype = "Error",
                            url = "",
                            api = LogTag + "DeleteRiskUnit",
                            apiname = "",
                            parameter = parameter,
                            title = "Park_风险分析单元 删除接口",
                            logcontent = "删除风险分析单元数据响应异常:" + ex.StackTrace,
                            currentmethod = "DeleteRiskUnit",
                            currentthread = Thread.CurrentThread.ManagedThreadId
                        });
                        return res;
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("修改风险分析单元数据异常:" + ex.StackTrace);
                _logService.AddLog(new clsLogDotNetApi()
                {
                    logtype = "Error",
                    url = "",
                    api = LogTag + "DeleteRiskUnit",
                    apiname = "",
                    parameter = "",
                    title = "Park_风险分析单元 删除接口",
                    logcontent = "删除风险分析单元数据异常:" + ex.StackTrace,
                    currentmethod = "DeleteRiskUnit",
                    currentthread = Thread.CurrentThread.ManagedThreadId
                });
                return res;
            }

            return res;
        }


        /// <summary>
        /// 6.3 隐患排查信息 删除
        /// </summary>
        /// <param name="entity">删除对象</param>
        /// <returns></returns>
        public async Task<clsResponse> DeleteCheck(clsCreateCheckModel entity)
        {

            LogDotNetApiService _logService = new LogDotNetApiService();
            var res = new clsResponse();
            try
            {
                string prefix = clsCreateCheckModel.delPrefix;//参数前缀
                HttpWebRequest request = WebRequest.Create("http://220.178.10.89:9088/syf/dangerInfoAction!deleteCheck") as HttpWebRequest;
                //创建http请求实例
                request.Method = "post";
                request.ContentType = "application/x-www-form-urlencoded";
                StringBuilder buffer = new StringBuilder();//使用字典的方式设置入参名与参数 

                //buffer.AppendFormat("{0}={1}&", prefix + "pwd", "1db77f21f1d34757b019a9a1040981ec");//密钥【必填】全椒南大
                buffer.AppendFormat("{0}={1}&", prefix + "pwd", "e81ecebb857544ce92a15d238c830ed4");//密钥【必填】金禾实业
                buffer.AppendFormat("{0}={1}", prefix + "checkIds", entity.id);//排查记录ID集合【必填】

                string parameter = parameter = buffer.ToString();
                byte[] data = Encoding.UTF8.GetBytes(buffer.ToString());
                Stream stream = request.GetRequestStream();
                stream.Write(data, 0, data.Length);
                stream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
                string result = streamReader.ReadToEnd();
                responseStream.Close();
                streamReader.Close();
                if (result == null || result.Equals(""))
                {
                    Console.WriteLine("隐患排查信息 删除接口响应为空ip:http://220.178.10.89:9088/syf/dangerInfoAction!deleteCheck");
                    _logService.AddLog(new clsLogDotNetApi()
                    {
                        logtype = "Info",
                        url = "",
                        api = LogTag + "DeleteCheck",
                        apiname = "",
                        parameter = parameter,
                        title = "Park_隐患排查信息删除接口",
                        logcontent = "隐患排查信息删除接口响应为空 ip:http://220.178.10.89:9088/syf/dangerInfoAction!deleteCheck",
                        currentmethod = "DeleteCheck",
                        currentthread = Thread.CurrentThread.ManagedThreadId
                    });
                }
                else
                {
                    try
                    {
                        var _clsResponse = new clsResponse();
                        _clsResponse.operateObj = res;
                        _clsResponse = (clsResponse)JObject.Parse(result).ToObject(_clsResponse.GetType());
                        if (_clsResponse.operateSuccess)//删除成功
                            res = _clsResponse;
                        else
                            _logService.AddLog(new clsLogDotNetApi()
                            {
                                logtype = "Warning",
                                url = "",
                                api = LogTag + "DeleteCheck",
                                apiname = "",
                                parameter = parameter,
                                title = "Park_隐患排查信息删除接口",
                                logcontent = "隐患排查信息删除接口添加失败，接口返回原因：" + _clsResponse.operateMessage,
                                currentmethod = "DeleteCheck",
                                currentthread = Thread.CurrentThread.ManagedThreadId
                            });

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("删除隐患排查信息数据响应异常:" + ex.StackTrace);

                        return res;
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("修改隐患排查信息数据异常:" + ex.StackTrace);

                return res;
            }

            return res;
        }


        /// <summary>
        /// 4.2 定时同步修改隐患排查任务数据
        /// Author：Joyce.ren 2022-02-23
        /// </summary>
        /// <returns></returns>
        public async Task<string> SyncUpdateCheckTaskData()
        {

            var linOrm = new Common.Helper.DapperHelper();
            string sql = @"select 
id,riskMeasureId,troubleshootContent,checkCycle,checkCycleUnit, 
   convert(varchar(100),convert(datetime,investigationDate) , 25)investigationDate,
checkStatus,checker,checkLevel,checkTimesDay,checkTimesNum,checkTaskType,
checkStartDate,checkEndDate,riskMeasure_inroadCid,
SafeInspectionItemInroadCid,SafeInspectionPlanInroadCid,
c_createtime,c_backtime,isDelete,updatetime
from Park_CheckTask                  ";
            var lstData = linOrm.Query<clsCreateCheckTaskModel>(sql);
            string res = "";
            int iSuccess = 0, ifailure = 0;

            foreach (var item in lstData)
            {
                item.checkStatus = "0";
                var response = await UpdateCheckTask(item);

                if (response.operateSuccess)
                {
                    iSuccess++;
                }
                else
                {
                    ifailure++;
                }
            }
            res = @$"修改总数{lstData.Count},成功：{iSuccess},失败{ifailure}";

            return res;

        }

        /// <summary>
        /// 6.2 定时同步删除隐患排查信息数据
        /// Author：Joyce.ren 2022-02-23
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public async Task<string> SyncDelCheckData(string res)
        {
            try
            {
                var linkOrm = new Common.Helper.DapperHelper();
                //1、 查询台账与自荐表更新时间不同的数据 

                string sql = @"
select dangerState,a.checkAcceptTime,* from Park_Check a 
where a.dangerState<>9
order by a.dangerState ";

                var lstData = linkOrm.Query<clsCreateCheckModel>(sql);
                int iSuccess = 0, ifailure = 0;

                foreach (var item in lstData)
                {
                    item.dangerState = "0";
                    var response = await DeleteCheck(item);

                    if (response.operateSuccess)
                    {
                        iSuccess++;
                    }
                    else
                    {
                        ifailure++;
                    }
                }
                res = @$"修改总数{lstData.Count},成功：{iSuccess},失败{ifailure}";


            }
            catch (Exception ex)
            {
                res = "程序异常：" + ex.Message;
                Console.WriteLine(res);

                return res;
            }

            return res;
        }

        /// <summary>
        /// 清空上传双预控数据
        /// </summary>
        /// <returns></returns>
        public async Task<string> InitDpcData()
        {
            var linOrm = new Common.Helper.DapperHelper();
            string sql = @"select * from Park_RiskUnit  ";
            var lstData = linOrm.Query<clsCreateRiskUnitModel>(sql);
            string res = "";
            int iSuccess = 0, ifailure = 0;

            foreach (var item in lstData)
            {
                var response = await DeleteRiskUnit(item);

                if (response.operateSuccess)
                {
                    iSuccess++;
                }
                else
                {
                    ifailure++;
                }
            }
            res = @$"删除总数{lstData.Count},成功：{iSuccess},失败{ifailure}";

            return res;

        }



        /// <summary>
        /// 修改风险分析单元重大危险源标识
        /// </summary>
        /// <returns></returns>
        public async Task<string> InitRikUnitisHazardValue()
        {

            var linOrm = new Common.Helper.DapperHelper();
            string sql = @"select * from Park_RiskUnit where  hazardName in('成品及周转瓶仓库' ,'甲类仓库三' )  ";
            var lstData = linOrm.Query<clsCreateRiskUnitModel>(sql);
            string res = "";
            int iSuccess = 0, ifailure = 0;

            foreach (var item in lstData)
            {
                item.isHazard = "0";

                //if (item.isHazard == "0") item.isHazard = "1";
                //else item.isHazard = "0";
                var response = await UpdateRiskUnit(item);

                if (response.operateSuccess)
                {
                    iSuccess++;
                }
                else
                {
                    ifailure++;
                }
            }
            res = @$"修改总数{lstData.Count},成功：{iSuccess},失败{ifailure}";

            return res;
        }

    }
}
