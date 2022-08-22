using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ClassToXmlLibrary
{
    /// <summary>
    /// 用户信息类
    /// </summary>
    public class clsUserInfo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }


        /// <summary>
        /// 将List与XML相互转换
        /// </summary>
        public virtual void ListToXmlTest()
        {
            //获取用户列表
            List<clsUserInfo> userList = GetUserList();

            //将实体对象转换成XML
            string xmlResult = XmlSerializeHelper.XmlSerialize(userList);

            //将XML转换成实体对象
            List<clsUserInfo> deResult = XmlSerializeHelper.DESerializer<List<clsUserInfo>>(xmlResult);
        }

        /// <summary>
        /// 获取用户信息列表
        /// </summary>
        public virtual List<clsUserInfo> GetUserList()
        {
            List<clsUserInfo> userList = new List<clsUserInfo>();
            userList.Add(new clsUserInfo() { ID = 1, Name = "张三", CreateTime = DateTime.Now });
            userList.Add(new clsUserInfo() { ID = 2, Name = "李四", CreateTime = DateTime.Now });
            userList.Add(new clsUserInfo() { ID = 2, Name = "王五" });
            return userList;
        }


        /// <summary>
        /// 将DataTable与XML相互转换
        /// </summary>
        public static void DataTableToXmlTest()
        {
            //创建DataTable对象
            DataTable dt = CreateDataTable();

            //将DataTable转换成XML
            string xmlResult = XmlSerializeHelper.XmlSerialize(dt);

            //将XML转换成DataTable
            DataTable deResult = XmlSerializeHelper.DESerializer<DataTable>(xmlResult);
        }

        /// <summary>
        /// 创建DataTable对象
        /// </summary>
        public static DataTable CreateDataTable()
        {
            //创建DataTable
            DataTable dt = new DataTable("NewDt");

            //创建自增长的ID列
            DataColumn dc = dt.Columns.Add("ID", Type.GetType("System.Int32"));
            dt.Columns.Add(new DataColumn("Name", Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("CreateTime", Type.GetType("System.DateTime")));

            //创建数据
            DataRow dr = dt.NewRow();
            dr["ID"] = 1;
            dr["Name"] = "张三";
            dr["CreateTime"] = DateTime.Now;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["ID"] = 2;
            dr["Name"] = "李四";
            dr["CreateTime"] = DateTime.Now;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["ID"] = 3;
            dr["Name"] = "王五";
            dr["CreateTime"] = DateTime.Now;
            dt.Rows.Add(dr);

            return dt;
        }



    }
}
