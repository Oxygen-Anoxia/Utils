using LDAPManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LDAP_Winform
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnClick_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw;
            }
            LdapHelper ldapHelper = new LdapHelper();
            string username = ""; //根据上一页的登录信息获取用户帐号，存储在session中。
            DirectoryEntry de = ldapHelper.GetUser(username); //调用LdapHelper中的获取用户信息函数
            if (de != null)
            {
                if (de.Properties["USERID"].Value != null)
                {
                    txtId.Text = de.Properties["USERID"].Value.ToString();
                }
                if (de.Properties["LOGINNAME"].Value != null)
                {
                    txtName.Text = de.Properties["LOGINNAME"].Value.ToString();
                }
                if (de.Properties["LOGINPASSWORD"].Value != null)
                {
                    txtPwd.Text = de.Properties["LOGINPASSWORD"].Value.ToString();
                }
                if (de.Properties["EMAIL"].Value != null)
                {
                    txtEmail.Text = de.Properties["EMAIL"].Value.ToString();
                }
            }
        }
    }

}
