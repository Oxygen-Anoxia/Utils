using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Text;

namespace LDAPManagement
{
    public class LdapHelper
    {
        //#region 创建AD连接
        ///// <summary>
        ///// 创建AD连接
        ///// </summary>
        ///// <returns></returns>
        //public static DirectoryEntry GetDirectoryEntry()
        //{
        //    DirectoryEntry de = new DirectoryEntry();
        //    de.Path = "LDAP://testhr.com/CN=Users,DC=testhr,DC=com";
        //    de.Username = @"administrator";
        //    de.Password = "litb20!!";
        //    return de;

        //    //DirectoryEntry entry = new DirectoryEntry("LDAP://testhr.com", "administrator", "litb20!!", AuthenticationTypes.Secure);
        //    //return entry;

        //}
        //#endregion



        //string ldapUrl = "LDAP://***.***.48.110:389/dc=***,dc=com";
        //string ldapUserName = "cn=root,dc=***,dc=com";
        //string ldapPassword = "pw";
        //public LdapHelper(string ldap_url, string ldap_user, string ldap_pwd)
        //{
        //    ldapUrl = ldap_url;
        //    ldapUserName = ldap_user;
        //    ldapPassword = ldap_pwd;
        //}

        //public bool login()
        //{
        //    DirectoryEntry root = null;
        //    try
        //    {
        //        root = new DirectoryEntry(ldapUrl, ldapUserName, ldapPassword, AuthenticationTypes.None);
        //        string strName = root.Name;//失败，会抛出异常
        //        root.Close();
        //        root = null;
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }

        //}


        /// <summary>
        /// 按照用户Id查找用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DirectoryEntry GetUser(string username)
        {


            //配置文件信息
            //<connectionStrings>
            //  <add name = "path"   connectionString = "LDAP://192.168.1.1/OU=123,DC=123,DC=COM" />
            //  <add name = "pname"   connectionString = "123" />
            //  <add name = "pwd"       connectionString = "123" />
            // </ connectionStrings >

            string path = System.Configuration.ConfigurationManager.ConnectionStrings["path"].ConnectionString;
            string pname = System.Configuration.ConfigurationManager.ConnectionStrings["pname"].ConnectionString;
            string pwd = System.Configuration.ConfigurationManager.ConnectionStrings["pwd"].ConnectionString;

            // 3个连接数据库的信息写在配置文件里
            DirectoryEntry deuser;  //定义变量
            try
            {
                DirectoryEntry de = new DirectoryEntry(path, pname, pwd, AuthenticationTypes.Secure);
                DirectorySearcher deSearch = new DirectorySearcher(de); //连接LDAP数据库
                
                deSearch.Filter = "(&(objectClass=userinfo)(LOGINNAME=" + username + "))";  //筛选比对

                //上面这句话修改为：mySearcher.Filter = "(&(objectClass=userinfo)(&(LOGINNAME=" + txtUserId.Text + ")(LOGINPASSWORD=" + txtUserPwd.Text + ")))";//作为登录是用户帐号和密码认证

                deSearch.SearchScope = SearchScope.Subtree;

                SearchResult result = deSearch.FindOne(); //筛选比对得出一个结果，存储在result中

                if (result != null)
                {
                    deuser = result.GetDirectoryEntry(); //得到筛选结果，并赋值给deuser中
                    return deuser;
                }
                else
                {
                    return null;
                }
            }

            catch (Exception ex)
            {
                // LogManage.SaveInfo(ex.ToString());
                return null;
            }

        }

    }
}
