using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConsoleDataTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string str = "2d5086435705401e9b450abc9e4f23a5";
            
            Console.WriteLine(str);
            // string str = "2d508643-5705-401e-9b450abc9e4f23a5";
            //Console.WriteLine("xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx");
            string res = str.Substring(0, 8) + "-" + str.Substring(8, 4) + "-" + str.Substring(12, 4) + "-" + str.Substring(16, 4) + "-" + str.Substring(20, 12);

            //Console.WriteLine(res);
            //str = "sdfadsfdsa";
            Console.WriteLine(StringToGuid(str));
            Console.ReadLine();


            //clsService _clsService = new clsService();
            //_clsService.Cw();

            var lst = new Dictionary<string, string>();




        }


        public static Guid StringToGuid(string str)
        {
            var res = new Guid();
            if (string.IsNullOrEmpty(str) || str.Length != 32)
                return res;
            var ssk = str.Substring(0, 8) + "-" + str.Substring(8, 4) + "-" + str.Substring(12, 4) + "-" + str.Substring(16, 4) + "-" + str.Substring(20, 12);
            Guid.TryParse(ssk, out res);
            return res;
        }



        private static DataTable getData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("编号", typeof(Int32));
            dt.Columns.Add("姓名", typeof(string));
            dt.Columns.Add("性别", typeof(string));
            dt.Columns.Add("学历", typeof(string));
            dt.Rows.Add(1, "王超", "男", "本科");
            dt.Rows.Add(2, "周丽", "⼥", "专科");
            dt.Rows.Add(3, "李娟", "⼥", "专科");
            dt.Rows.Add(4, "杨明", "男", "硕⼠");
            dt.Rows.Add(5, "张德", "男", "本科");
            return dt;
        }



    }


    public static class clsService
    {
        public static Guid StringToGuid(string str)
        {
            var res = new Guid();
            if (string.IsNullOrEmpty(str) || str.Length != 32)
                return res;
            var ssk = str.Substring(0, 8) + "-" + str.Substring(8, 4) + "-" + str.Substring(12, 4) + "-" + str.Substring(16, 4) + "-" + str.Substring(20, 12);
            Guid.TryParse(ssk, out res);
            return res;
        }
        private static DataTable getData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("编号", typeof(Int32));
            dt.Columns.Add("姓名", typeof(string));
            dt.Columns.Add("性别", typeof(string));
            dt.Columns.Add("学历", typeof(string));
            dt.Rows.Add(1, "王超", "男", "本科");
            dt.Rows.Add(2, "周丽", "⼥", "专科");
            dt.Rows.Add(3, "李娟", "⼥", "专科");
            dt.Rows.Add(4, "杨明", "男", "硕⼠");
            dt.Rows.Add(5, "张德", "男", "本科");
            return dt;
        }


        public static void Cw()
        {

            var dt = getData();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var json = EIPAS.eCommonLibrary.JsonHelper.RowToJson(dt.Rows[i]);
                Console.WriteLine(json);
            }

        }
    }
}
