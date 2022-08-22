using System;
using System.Collections.Generic;
using System.Text;

namespace HttpProgramApp
{
    public class clsResponseModel
    {

        public string result { get; set; }
    }


    public class clsTemp
    {
        public List<clsTempModel> lstData { get; set; }

        public clsTemp() { lstData = new List<clsTempModel>(); }
    }

    public class clsTempModel
    {

        /// <summary>
        /// 
        /// </summary>
        public MainTableTemp mainTable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> detail1 { get; set; }
    }


    public class MainTableTemp
    {
        /// <summary>
        /// 实验室/生产区
        /// </summary>
        public string bgqy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string wghyy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cjrqsj { get; set; }
        /// <summary>
        /// 南沙工厂
        /// </summary>
        public string lfdd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cause { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fkkh { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string jkm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fwddgz { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fkkzt { get; set; }
        /// <summary>
        /// 沙多玛（广州）化学有限公司
        /// </summary>
        public string bfrgs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string dfzt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string hcm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string totalnum { get; set; }
        /// <summary>
        /// 本人承诺所填信息的真实性
        /// </summary>
        public string grc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string dzyx { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string company { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 处理中
        /// </summary>
        public string state { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string lcid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string openid { get; set; }
        /// <summary>
        /// 男
        /// </summary>
        public string sex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sfyc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string visitdate { get; set; }
        /// <summary>
        /// 广钢气体（广州）有限公司
        /// </summary>
        public string gscbs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string endtime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string phonenum { get; set; }
        /// <summary>
        /// 广州/Guangzhou
        /// </summary>
        public string bgdd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string czlx { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string bfr { get; set; }
        /// <summary>
        /// 泛微测试003
        /// </summary>
        public string bfrllk { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string zjycxxrq { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sfzh { get; set; }
        /// <summary>
        /// 自驾
        /// </summary>
        public string lffs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string contactinfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string arrivaltime { get; set; }
        /// <summary>
        /// 贛4512365
        /// </summary>
        public string lfzcph { get; set; }
        /// <summary>
        /// 沙多玛承包商证件信息测试002
        /// </summary>
        public string visitor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string jzrq { get; set; }
        /// <summary>
        /// 承包商
        /// </summary>
        public string fklx { get; set; }
    }

}
