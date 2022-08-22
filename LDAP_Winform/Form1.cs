using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LDAP_Winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string strLDAPFilter = string.Format(txtFilter.Text, txtUserName.Text.Trim());
            //deSearch.Filter = "(&(objectClass=user)(sAMAccountName=" + username + "))";
    
            string TestUserID = txtUserName.Text;
            string TestUserPwd = txtPwd.Text;
            LDAPHelper objldap = new LDAPHelper();
            string strLDAPPath = txtLDAP.Text;
            string strLDAPAdminName = txtLUserName.Text;
            string strLDAPAdminPwd = txtLPwd.Text;
            string strMsg = "";
            bool blRet = objldap.OpenConnection(strLDAPPath, strLDAPAdminName, strLDAPAdminPwd);


            if (blRet)
            {
                blRet = objldap.CheckUidAndPwd(strLDAPFilter, TestUserID, TestUserPwd, ref strMsg);
                if (blRet)
                {
                    strMsg = "检测用户名" + TestUserID + "和密码" + TestUserPwd + "成功";
                }
                else if (!blRet && string.IsNullOrEmpty(strMsg))
                {
                    strMsg = "检测用户名" + TestUserID + "和密码" + TestUserPwd + "失败";
                }
            }
            this.txtLog.Text = System.DateTime.Now.ToString() + ":" + strMsg + "\r\n" + "\r\n" + this.txtLog.Text;
            MessageBox.Show(strMsg);


        }
    }
}
