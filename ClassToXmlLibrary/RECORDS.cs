using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ClassToXmlLibrary
{
    [XmlType("RECORDS")]
    public class RECORDS : List<object>
    {

        //public List<RECORD> RECORD { get; set; }

        //public RECORDS()
        //{
        //    RECORD = new List<RECORD>();
        //}

        //public object RECORD { get; set; }


    }

    public class RECORD
    {

        ///// <summary>
        ///// 编号
        ///// </summary>
        //public int ID { get; set; }

        ///// <summary>
        ///// 名称
        ///// </summary>
        //public string Name { get; set; }

        ///// <summary>
        ///// 创建时间
        ///// </summary>
        //public DateTime? CreateTime { get; set; }

        //public List<RECORD> GetUserList()
        //{
        //    List<RECORD> userList = new List<RECORD>();
        //    userList.Add(new RECORD() { ID = 1, Name = "张三", CreateTime = DateTime.Now });
        //    userList.Add(new RECORD() { ID = 2, Name = "李四", CreateTime = DateTime.Now });
        //    userList.Add(new RECORD() { ID = 2, Name = "王五" });
        //    return userList;
        //}

        /// <summary>
        /// 风险分析对象标识
        /// </summary>
        public string RISK_OBJECT_ID { get; set; } = "D074DA75-1EA8-466B-A64E-DF3E0B6AD5C2".Replace("-", "");

        /// <summary>
        /// 风险分析对象编码
        /// </summary>
        public string RISKOBJECT_CODE { get; set; } = "411710011007";

        /// <summary>
        /// 企业标识
        /// </summary>
        public string ENTERPRISE_ID { get; set; } = "1c1d8421d31e11e79deffefcfe9b7f94";
        /// <summary>
        /// 风险分析对象名称
        /// </summary>
        public string RISK_OBJECT_NAME { get; set; } = "中间罐区";
        /// <summary>
        /// 责任部门
        /// </summary>
        public string DUTY_DEPT_NAME { get; set; } = "中间罐区";
        /// <summary>
        /// 责任人
        /// </summary>
        public string DUTY_PSN_NAME { get; set; } = "张三";
        /// <summary>
        /// 责任人手机号
        /// </summary>
        public string DUTY_PSN_TEL { get; set; } = "13458765411";
        /// <summary>
        /// 企业编码
        /// </summary>
        public string COMPANY_CODE { get; set; } = "411710011";
        /// <summary>
        /// 记录创建时间
        /// </summary>
        public string CREATE_TIME { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmss");
        /// <summary>
        /// 创建人
        /// </summary>
        public string CREATOR { get; set; } = "张三";
        /// <summary>
        /// 记录状态
        /// </summary>
        public string RECORD_STATUS { get; set; } = "I";
        /// <summary>
        /// 是否测试数据
        /// </summary>
        public string IS_TEST { get; set; } = "1";

        /// <summary>  
        /// 根据GUID获取16位的唯一字符串  
        /// </summary>  
        /// <param name=\"guid\"></param>  
        /// <returns></returns>  
        public static string GuidTo16String()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
                i *= ((int)b + 1);
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }

    }

}
