using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LDAP_Winform
{
    public partial class frmAD : Form
    {
        private List<AdModel2> list2 = new List<AdModel2>();

        public frmAD()
        {
            InitializeComponent();
        }

        #region## 同步按钮
        /// <summary>
        /// 功能：同步按钮
        /// 作者：Wilson
        /// 时间：2012-12-15
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSyns_Click(object sender, EventArgs e)
        {
            try
            {
                btnSyns.Enabled = false;
                list2.Clear();
                if (ValidationInput())
                {
                    DirectoryEntry domain;
                    DirectoryEntry rootOU;

                    if (IsConnected(txtDomainName.Text.Trim(), txtUserName.Text.Trim(), txtPwd.Text.Trim(), out domain))
                    {
                        if (IsExistOU(domain, out rootOU))
                        {
                            SyncAll(rootOU);      //同步所有                                         
                        }
                        else
                        {
                            MessageBox.Show("域中不存在此组织结构!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show("不能连接到域,请确认输入是否正确!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("系统异常:" + ex.StackTrace, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                btnSyns.Enabled = true;
            }

        }
        #endregion

        #region## 同步
        /// <summary>
        /// 功能:同步
        /// 创建人:Wilson
        /// 创建时间:2012-12-15
        /// </summary>
        /// <param name="entryOU"></param>
        public void SyncAll(DirectoryEntry entryOU)
        {
            /*
             * 参考：http://msdn.microsoft.com/zh-cn/library/system.directoryservices.directorysearcher.filter(v=vs.80).aspx
             * 
             * -----------------其它------------------------------             
             * 机算机：       (objectCategory=computer)
             * 组：           (objectCategory=group)
             * 联系人：       (objectCategory=contact)
             * 共享文件夹：   (objectCategory=volume)
             * 打印机         (objectCategory=printQueue)
             * ---------------------------------------------------
             */
            DirectorySearcher mySearcher = new DirectorySearcher(entryOU, "(objectclass=organizationalUnit)"); //查询组织单位                 

            DirectoryEntry root = mySearcher.SearchRoot;   //查找根OU

            SyncRootOU(root);



            string json = " 人员 [ ";

            foreach (var item in list2)
            {
                if (item.TypeId == 2)
                {
                    string sb = Newtonsoft.Json.JsonConvert.SerializeObject(item);
                    json += sb + ",";
                }
            }
            json = json.Substring(0, json.Length - 1);
            json += "]";
            LogRecord.WriteLog(json);


            //StringBuilder sb = new StringBuilder();
            //sb.Append("\r\nID\t帐号\t类型\t父ID\r\n");
            //foreach (var item in list)
            //{
            //    sb.AppendFormat("{0}\t{1}\t{2}\t{3}\r\n", item.Id, item.Name, item.TypeId, item.ParentId);
            //}
            //LogRecord.WriteLog(sb.ToString());



            json = " 部门 [ ";

            foreach (var item in list2)
            {
                if (item.TypeId == 1)
                {
                    string sb = Newtonsoft.Json.JsonConvert.SerializeObject(item);
                    json += sb + ",";
                }
            }
            json = json.Substring(0, json.Length - 1);
            json += "]";
            LogRecord.WriteLog(json);

            MessageBox.Show("同步成功," + list2.Count + "=" + list2.Where(p => p.TypeId == 1).Count() + "+" + list2.Where(p => p.TypeId == 2).Count(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            //NLogWebExtension.Info("同步成功！"+ sb.ToString());
            //Application.Exit();
        }
        #endregion

        #region## 同步根组织单位
        /// <summary>
        /// 功能: 同步根组织单位
        /// 创建人:Wilson
        /// 创建时间:2012-12-15
        /// </summary>
        /// <param name="entry"></param>
        private void SyncRootOU(DirectoryEntry entry)
        {
            if (entry.Properties.Contains("ou") && entry.Properties.Contains("objectGUID"))
            {
                string rootOuName = entry.Properties["ou"][0].ToString();

                byte[] bGUID = entry.Properties["objectGUID"][0] as byte[];

                //foreach (var item in entry.Properties)
                //{

                //    //var department = entry.Properties["department"][0].ToString();

                //}

                string id = BitConverter.ToString(bGUID);
                AdModel2 entity = new AdModel2() { Id = id, Name = rootOuName, TypeId = (int)TypeEnum.OU, ParentId = "0" };

                SyncSubOU(entry, id);
            }
        }
        #endregion

        #region## 同步下属组织单位及下属用户
        /// <summary>
        /// 功能: 同步下属组织单位及下属用户
        /// 创建人:Wilson
        /// 创建时间:2012-12-15
        /// </summary>
        /// <param name="entry"></param>
        /// <param name="parentId"></param>
        private void SyncSubOU(DirectoryEntry entry, string parentId)
        {
            string str = "";
            //string strs = "";

            foreach (DirectoryEntry subEntry in entry.Children)
            {
                string entrySchemaClsName = subEntry.SchemaClassName;
                //MessageBox.Show("SchemaClassName:" + entrySchemaClsName);
                str += "_" + entrySchemaClsName;

                string[] arr = subEntry.Name.Split('=');
                string categoryStr = arr[0];
                string nameStr = arr[1];
                string id = string.Empty;

                if (subEntry.Properties.Contains("objectGUID"))   //SID
                {
                    byte[] bGUID = subEntry.Properties["objectGUID"][0] as byte[];
                    id = BitConverter.ToString(bGUID);
                }

                string department = ""; if (subEntry.Properties.Contains("department")) { department = subEntry.Properties["department"][0].ToString(); }// 部门
                string cn = ""; if (subEntry.Properties.Contains("cn")) { cn = subEntry.Properties["cn"][0].ToString(); }// 员工编号
                string description = ""; if (subEntry.Properties.Contains("description")) { description = subEntry.Properties["description"][0].ToString(); }// 员工姓名
                string title = ""; if (subEntry.Properties.Contains("title")) { title = subEntry.Properties["title"][0].ToString(); }// 岗位
                string physicalDeliveryOfficeName = ""; if (subEntry.Properties.Contains("physicalDeliveryOfficeName")) { physicalDeliveryOfficeName = subEntry.Properties["physicalDeliveryOfficeName"][0].ToString(); }// 身份证号
                string mobile = ""; if (subEntry.Properties.Contains("mobile")) { mobile = subEntry.Properties["mobile"][0].ToString(); }// 移动电话

                #region
                string objectClass = ""; if (subEntry.Properties.Contains("objectClass")) { objectClass = subEntry.Properties["objectClass"][0].ToString(); }// objectClass
                string sn = ""; if (subEntry.Properties.Contains("sn")) { sn = subEntry.Properties["sn"][0].ToString(); }// sn
                string distinguishedName = ""; if (subEntry.Properties.Contains("distinguishedName")) { distinguishedName = subEntry.Properties["distinguishedName"][0].ToString(); }// distinguishedName
                string instanceType = ""; if (subEntry.Properties.Contains("instanceType")) { instanceType = subEntry.Properties["instanceType"][0].ToString(); }// instanceType
                string whenCreated = ""; if (subEntry.Properties.Contains("whenCreated")) { whenCreated = subEntry.Properties["whenCreated"][0].ToString(); }// whenCreated
                string whenChanged = ""; if (subEntry.Properties.Contains("whenChanged")) { whenChanged = subEntry.Properties["whenChanged"][0].ToString(); }// whenChanged
                string displayName = ""; if (subEntry.Properties.Contains("displayName")) { displayName = subEntry.Properties["displayName"][0].ToString(); }// displayName
                string uSNCreated = ""; if (subEntry.Properties.Contains("uSNCreated")) { uSNCreated = subEntry.Properties["uSNCreated"][0].ToString(); }// uSNCreated
                string uSNChanged = ""; if (subEntry.Properties.Contains("uSNChanged")) { uSNChanged = subEntry.Properties["uSNChanged"][0].ToString(); }// uSNChanged
                string nTSecurityDescriptor = "";

                {                //if (subEntry.Properties.Contains("nTSecurityDescriptor"))
                    //nTSecurityDescriptor = subEntry.Properties["nTSecurityDescriptor"][0].ToString(); \
                }// nTSecurityDescriptor
                string name = ""; if (subEntry.Properties.Contains("name")) { name = subEntry.Properties["name"][0].ToString(); }// name
                string objectGUID = ""; if (subEntry.Properties.Contains("objectGUID")) { objectGUID = subEntry.Properties["objectGUID"][0].ToString(); }// objectGUID
                string userAccountControl = ""; if (subEntry.Properties.Contains("userAccountControl")) { userAccountControl = subEntry.Properties["userAccountControl"][0].ToString(); }// userAccountControl
                string badPwdCount = ""; if (subEntry.Properties.Contains("badPwdCount")) { badPwdCount = subEntry.Properties["badPwdCount"][0].ToString(); }// badPwdCount
                string codePage = ""; if (subEntry.Properties.Contains("codePage")) { codePage = subEntry.Properties["codePage"][0].ToString(); }// codePage
                string countryCode = ""; if (subEntry.Properties.Contains("countryCode")) { countryCode = subEntry.Properties["countryCode"][0].ToString(); }// countryCode
                string badPasswordTime = ""; if (subEntry.Properties.Contains("badPasswordTime")) { badPasswordTime = subEntry.Properties["badPasswordTime"][0].ToString(); }// badPasswordTime
                string lastLogoff = ""; if (subEntry.Properties.Contains("lastLogoff")) { lastLogoff = subEntry.Properties["lastLogoff"][0].ToString(); }// lastLogoff
                string lastLogon = ""; if (subEntry.Properties.Contains("lastLogon")) { lastLogon = subEntry.Properties["lastLogon"][0].ToString(); }// lastLogon
                string pwdLastSet_ = ""; if (subEntry.Properties.Contains("pwdLastSet_")) { pwdLastSet_ = subEntry.Properties["pwdLastSet_"][0].ToString(); }// pwdLastSet_
                string primaryGroupID = ""; if (subEntry.Properties.Contains("primaryGroupID")) { primaryGroupID = subEntry.Properties["primaryGroupID"][0].ToString(); }// primaryGroupID
                string objectSid = ""; if (subEntry.Properties.Contains("objectSid")) { objectSid = subEntry.Properties["objectSid"][0].ToString(); }// objectSid
                string accountExpires = ""; if (subEntry.Properties.Contains("accountExpires")) { accountExpires = subEntry.Properties["accountExpires"][0].ToString(); }// accountExpires
                string logonCount = ""; if (subEntry.Properties.Contains("logonCount")) { logonCount = subEntry.Properties["logonCount"][0].ToString(); }// logonCount
                string sAMAccountName = ""; if (subEntry.Properties.Contains("sAMAccountName")) { sAMAccountName = subEntry.Properties["sAMAccountName"][0].ToString(); }// sAMAccountName
                string sAMAccountType = ""; if (subEntry.Properties.Contains("sAMAccountType")) { sAMAccountType = subEntry.Properties["sAMAccountType"][0].ToString(); }// sAMAccountType
                string userPrincipalName = ""; if (subEntry.Properties.Contains("userPrincipalName")) { userPrincipalName = subEntry.Properties["userPrincipalName"][0].ToString(); }// 用户登录名(U)
                string objectCategory = ""; if (subEntry.Properties.Contains("objectCategory")) { objectCategory = subEntry.Properties["objectCategory"][0].ToString(); }// objectCategory
                string dSCorePropagationData = ""; if (subEntry.Properties.Contains("dSCorePropagationData")) { dSCorePropagationData = subEntry.Properties["dSCorePropagationData"][0].ToString(); }// dSCorePropagationData

                #endregion


                bool isExist2 = list2.Exists(d => d.Id == id);

                switch (entrySchemaClsName)
                {
                    case "organizationalUnit":

                        if (!isExist2)
                        {
                            AdModel2 ad = new AdModel2()
                            {
                                department = department,
                                cn = cn,
                                description = description,
                                title = title,
                                physicalDeliveryOfficeName = physicalDeliveryOfficeName,
                                mobile = mobile,

                                Id = id,
                                TypeId = (int)TypeEnum.OU,
                                ParentId = parentId

                                ,
                                Name = name,
                                objectClass = objectClass,
                                sn = sn,
                                distinguishedName = distinguishedName,
                                instanceType = instanceType,
                                whenCreated = whenCreated,
                                whenChanged = whenChanged,
                                displayName = displayName,
                                uSNCreated = uSNCreated,
                                uSNChanged = uSNChanged,
                                nTSecurityDescriptor = nTSecurityDescriptor,
                                objectGUID = objectGUID,
                                userAccountControl = userAccountControl,
                                badPwdCount = badPwdCount,
                                codePage = codePage,
                                countryCode = countryCode,
                                badPasswordTime = badPasswordTime,
                                lastLogoff = lastLogoff,
                                lastLogon = lastLogon,
                                pwdLastSet_ = pwdLastSet_,
                                primaryGroupID = primaryGroupID,
                                objectSid = objectSid,
                                accountExpires = accountExpires,
                                logonCount = logonCount,
                                sAMAccountName = sAMAccountName,
                                sAMAccountType = sAMAccountType,
                                userPrincipalName = userPrincipalName,
                                objectCategory = objectCategory,
                                dSCorePropagationData = dSCorePropagationData
                            };
                            list2.Add(ad);
                        }

                        SyncSubOU(subEntry, id);
                        break;
                    case "user":
                        string accountName = string.Empty;

                        if (subEntry.Properties.Contains("samaccountName"))
                        {
                            accountName = subEntry.Properties["samaccountName"][0].ToString();//账号
                            var va = subEntry.Properties;
                        }

                        if (!isExist2)
                        {
                            AdModel2 ad = new AdModel2()
                            {
                                department = department,
                                cn = cn,
                                description = description,
                                title = title,
                                physicalDeliveryOfficeName = physicalDeliveryOfficeName,
                                mobile = mobile,
                                Id = id,
                                TypeId = (int)TypeEnum.USER,
                                ParentId = parentId
                                ,
                                Name = name,
                                objectClass = objectClass,
                                sn = sn,
                                distinguishedName = distinguishedName,
                                instanceType = instanceType,
                                whenCreated = whenCreated,
                                whenChanged = whenChanged,
                                displayName = displayName,
                                uSNCreated = uSNCreated,
                                uSNChanged = uSNChanged,
                                nTSecurityDescriptor = nTSecurityDescriptor,
                                objectGUID = objectGUID,
                                userAccountControl = userAccountControl,
                                badPwdCount = badPwdCount,
                                codePage = codePage,
                                countryCode = countryCode,
                                badPasswordTime = badPasswordTime,
                                lastLogoff = lastLogoff,
                                lastLogon = lastLogon,
                                pwdLastSet_ = pwdLastSet_,
                                primaryGroupID = primaryGroupID,
                                objectSid = objectSid,
                                accountExpires = accountExpires,
                                logonCount = logonCount,
                                sAMAccountName = sAMAccountName,
                                sAMAccountType = sAMAccountType,
                                userPrincipalName = userPrincipalName,
                                objectCategory = objectCategory,
                                dSCorePropagationData = dSCorePropagationData
                            };
                            list2.Add(ad);
                        }
                        break;
                }
            }

            //LogRecord.WriteLog("同步下属组织单位及下属用户parentId:" + parentId + " | " + str);
        }
        #endregion


        //foreach (string property in subEntry.Properties.PropertyNames)
        //{
        //    LogRecord.WriteLog(string.Format("字段名: {0}   字段值：{1}\r\n", property, subEntry.Properties[property][0].ToString()));
        //}

        #region## 是否连接到域
        /// <summary>
        /// 功能：是否连接到域
        /// 作者：Wilson
        /// 时间：2012-12-15
        /// http://msdn.microsoft.com/zh-cn/library/system.directoryservices.directoryentry.path(v=vs.90).aspx
        /// </summary>
        /// <param name="domainName">域名或IP</param>
        /// <param name="userName">用户名</param>
        /// <param name="userPwd">密码</param>
        /// <param name="entry">域</param>
        /// <returns></returns>
        private bool IsConnected(string domainName, string userName, string userPwd, out DirectoryEntry domain)
        {
            domain = new DirectoryEntry();
            try
            {
                domain.Path = string.Format("LDAP://{0}", domainName);
                domain.Username = userName;
                domain.Password = userPwd;
                domain.AuthenticationType = AuthenticationTypes.Secure;
                domain.RefreshCache();

                return true;
            }
            catch (Exception ex)
            {
                LogRecord.WriteLog("[IsConnected方法]错误信息：" + ex.Message);
                return false;
            }
        }
        #endregion

        #region## 域中是否存在组织单位
        /// <summary>
        /// 功能：域中是否存在组织单位
        /// 作者：Wilson
        /// 时间：2012-12-15
        /// </summary>
        /// <param name="entry"></param>
        /// <param name="ou"></param>
        /// <returns></returns>
        private bool IsExistOU(DirectoryEntry entry, out DirectoryEntry ou)
        {
            ou = new DirectoryEntry();
            try
            {
                ou = entry.Children.Find("OU=" + txtRootOU.Text.Trim());

                return (ou != null);
            }
            catch (Exception ex)
            {
                LogRecord.WriteLog("[IsExistOU方法]错误信息：" + ex.Message);
                return false;
            }
        }
        #endregion

        #region## 窗体加载
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAD_Load(object sender, EventArgs e)
        {
            //txtDomainName.Text = "192.168.174.130";
            //txtUserName.Text = "Joyce";
            //txtPwd.Text = "A@2021";
            //txtRootOU.Text = "研发部-test";
            txtDomainName.Text = "10.30.90.121";
            txtUserName.Text = "administrator";
            txtPwd.Text = "admin@123";
            txtRootOU.Text = "zp";
        }
        #endregion

        #region## 验证输入
        /// <summary>
        /// 功能：验证输入
        /// 作者：Wilson
        /// 时间：2012-12-15
        /// </summary>
        /// <returns></returns>
        private bool ValidationInput()
        {
            if (txtDomainName.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入域名!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDomainName.Focus();
                return false;
            }

            if (txtUserName.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入用户名!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return false;
            }

            if (txtPwd.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入密码!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPwd.Focus();
                return false;
            }

            if (txtRootOU.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入根组织单位!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRootOU.Focus();
                return false;
            }
            return true;
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            txtDomainName.Text = "192.168.174.138";
            txtUserName.Text = "Joyce";
            txtPwd.Text = "A@2021";
            txtRootOU.Text = "研发部-test";
        }
    }


    public enum TypeEnum : int
    {
        /// <summary>
        /// 组织单位
        /// </summary>
        OU = 1,

        /// <summary>
        /// 用户
        /// </summary>
        USER = 2
    }

    #region## Ad域实体
    /// <summary>
    /// Ad域实体
    /// </summary>
    public class AdModel
    {
        public AdModel(string id, string name, int typeId, string parentId)
        {
            Id = id;
            Name = name;
            TypeId = typeId;
            ParentId = parentId;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public int TypeId { get; set; }

        public string ParentId { get; set; }

    }


    public class AdModel2
    {
        //public AdModel2(string id, string name, int typeId, string parentId, string objectClass, string cn, string sn, string distinguishedName, string instanceType, string whenCreated, string whenChanged, string displayName, string uSNCreated, string uSNChanged, string nTSecurityDescriptor, string objectGUID, string userAccountControl, string badPwdCount, string codePage, string countryCode, string badPasswordTime, string lastLogoff, string lastLogon, string pwdLastSet_, string primaryGroupID, string objectSid, string accountExpires, string logonCount, string sAMAccountName, string sAMAccountType, string userPrincipalName, string objectCategory, string dSCorePropagationData, string title)
        //{
        //    Id = id;
        //    this.Name = name;
        //    TypeId = typeId;
        //    ParentId = parentId;
        //    this.objectClass = objectClass;
        //    this.cn = cn;
        //    this.sn = sn;
        //    this.distinguishedName = distinguishedName;
        //    this.instanceType = instanceType;
        //    this.whenCreated = whenCreated;
        //    this.whenChanged = whenChanged;
        //    this.displayName = displayName;
        //    this.uSNCreated = uSNCreated;
        //    this.uSNChanged = uSNChanged;
        //    this.nTSecurityDescriptor = nTSecurityDescriptor;
        //    this.objectGUID = objectGUID;
        //    this.userAccountControl = userAccountControl;
        //    this.badPwdCount = badPwdCount;
        //    this.codePage = codePage;
        //    this.countryCode = countryCode;
        //    this.badPasswordTime = badPasswordTime;
        //    this.lastLogoff = lastLogoff;
        //    this.lastLogon = lastLogon;
        //    this.pwdLastSet_ = pwdLastSet_;
        //    this.primaryGroupID = primaryGroupID;
        //    this.objectSid = objectSid;
        //    this.accountExpires = accountExpires;
        //    this.logonCount = logonCount;
        //    this.sAMAccountName = sAMAccountName;
        //    this.sAMAccountType = sAMAccountType;
        //    this.userPrincipalName = userPrincipalName;
        //    this.objectCategory = objectCategory;
        //    this.dSCorePropagationData = dSCorePropagationData;
        //    this.title = title;
        //}
        public string cn { get; set; }
        public string mobile { get; set; }
        public string description { get; set; }
        public string department { get; set; }
        public string physicalDeliveryOfficeName { get; set; }
        public string title { get; set; }




        public string Id { get; set; }

        public string Name { get; set; }

        public int TypeId { get; set; }

        public string ParentId { get; set; }

        public string objectClass { get; set; }
        public string sn { get; set; }
        public string distinguishedName { get; set; }
        public string instanceType { get; set; }
        public string whenCreated { get; set; }
        public string whenChanged { get; set; }
        public string displayName { get; set; }
        public string uSNCreated { get; set; }
        public string uSNChanged { get; set; }
        public string nTSecurityDescriptor { get; set; }
        public string objectGUID { get; set; }
        public string userAccountControl { get; set; }
        public string badPwdCount { get; set; }
        public string codePage { get; set; }
        public string countryCode { get; set; }
        public string badPasswordTime { get; set; }
        public string lastLogoff { get; set; }
        public string lastLogon { get; set; }
        public string pwdLastSet_ { get; set; }
        public string primaryGroupID { get; set; }
        public string objectSid { get; set; }
        public string accountExpires { get; set; }
        public string logonCount { get; set; }
        public string sAMAccountName { get; set; }
        public string sAMAccountType { get; set; }
        public string userPrincipalName { get; set; }
        public string objectCategory { get; set; }
        public string dSCorePropagationData { get; set; }


    }


    #endregion

    #region## 日志
    /// <summary>
    /// 日志
    /// </summary>
    public class LogRecord
    {
        private static DB_MODE DEBUG_MODE = DB_MODE.ENABLE;
        private LogRecord()
        {
        }

        public static DB_MODE Mode
        {
            set { DEBUG_MODE = value; }
            get { return DEBUG_MODE; }
        }
        private static string sLogFile = string.Format(@"c:\log\adlog{0}.log", DateTime.Now.ToString("yyyy-MM-dd"));

        public static void WriteLog(string sMsg)
        {
            if (DEBUG_MODE == DB_MODE.ENABLE)
            {
                EIPAS.eCommonLibrary.LogHelper.WriteLog(sMsg);
                // Write log msg
                try
                {
                    //.WriteLog(sMsg);

                    //using (StreamWriter sr = new StreamWriter(sLogFile, true))
                    //{
                    //    sr.WriteLine(string.Format("{0}:{1}",
                    //        DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss --"), sMsg));
                    //    sr.Flush();
                    //}
                }
                catch { }
            }
        }
    }
    #endregion

    #region## 日志类型（Enum）
    /// <summary>
    /// 日志类型
    /// </summary>
    public enum DB_MODE : int
    {
        DISABLE = 0,
        ENABLE = 1,
    }
    #endregion

}
