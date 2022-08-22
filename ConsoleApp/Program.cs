using ClassToXmlLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //test();
            //Console.WriteLine("--------------------------------------------------------------");
            //test2();
            //test3();

            aa();


            Console.ReadLine();
        }


        public static void test()
        {
            //var entity = new RECORD();
            //var lst = entity.GetUserList();
            //var sss = XmlSerializeHelper.XmlSerialize(lst);
            //Console.WriteLine(sss);
        }



        public static void test2()
        {
            //var entity = new RECORD() { ID =1 ,Name="张三",CreateTime=DateTime.Now};
            //var sss = XmlSerializeHelper.XmlSerialize(entity);
            //Console.WriteLine(sss);
        }

        public static void test3()
        {
            var lst = new RECORDS();
            var entity = new RECORD();
            lst.Add(entity);

            var sss = XmlSerializeHelper.XmlSerialize(lst);

            Console.WriteLine(sss);
        }

        public static void aa()
        {
            List<Department> list = new List<Department>()
            {
                //new Department(){ Id=123,employees=new Employee[1] { new Employee() { Id = 123 } }  },
                //new Department(){ Id=123,employees=new Employee[1] { new Employee() { Id = 123 } }},
                //new Department(){ Id=123,employees=new Employee[1] { new Employee() { Id = 123 } }}
                new Department()
            };


            Departments departments1 = new Departments() {
                //new Department(){ Id=123,employees=new Employee[1] { new Employee() { Id = 123 } }  },
                //new Department(){ Id=123,employees=new Employee[1] { new Employee() { Id = 123 } }},
                //new Department(){ Id=123,employees=new Employee[1] { new Employee() { Id = 123 } }}
                new Department(),
                new Department(),
                new Department()
            };

            var ssss = new Departments() { };
            ssss.Add(new Department());

            //第一种结果xml的根节点会是ArrayOf...
            string xmlString = XmlSerializeHelper.XmlSerialize(list);
            //第二种结果xml的根节点是自定义的
            string xmlString1 = XmlSerialize(departments1);

            List<Department> department = XmlSerializeHelper.DESerializer<List<Department>>(xmlString);
            //Departments departments = XmlSerializeHelper.DESerializer<Departments>(xmlString1);

        }
        public static string XmlSerialize<T>(T obj)
        {
            string xmlString = string.Empty;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (MemoryStream ms = new MemoryStream())
            {
                xmlSerializer.Serialize(ms, obj);
                xmlString = Encoding.UTF8.GetString(ms.ToArray());
            }
            return xmlString;
        }
    }


    [XmlType("RECORD")]
    public class Department
    {

        public Department() { }
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

    [XmlType("employee")]
    public class Employee
    {
        public Employee() { }

        public long? Id { get; set; }
        public string Name { get; set; }
    }

    [XmlType("RECORDS")]
    public class Departments : List<Department>
    {
    }

}
