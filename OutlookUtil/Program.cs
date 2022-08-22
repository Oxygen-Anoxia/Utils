using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookUtil
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Send("", "", "");
            Console.ReadLine();
        }

        #region 发送邮件
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="sendusermail"></param>
        /// <param name="mailtitle"></param>
        /// <param name="mailcontent"></param>
        /// <returns></returns>
        public static void Send(string sendusermail, string mailtitle, string mailcontent)
        {
            string smtpServer = "smtp.office365.com";
            int smtpPort = 587;
            string mailFrom = "dotnet_rjj@outlook.com";
            string passWord = "beauty@1314";
            string mailTo = "dotnet_xyk@outlook.com";
            SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
            smtpClient.UseDefaultCredentials = false;//写到这里不报错
            smtpClient.Credentials = new NetworkCredential(mailFrom, passWord);
            smtpClient.EnableSsl = true;
            //smtpClient.UseDefaultCredentials = false;//写到这里会报错,必须在账号密码绑定前写。
            MailAddress mailAddressFrom = new MailAddress(mailFrom);
            MailAddress mailAddressTo = new MailAddress(mailTo, "xx的QQ邮箱");
            MailMessage mailMessage = new MailMessage(mailAddressFrom, mailAddressTo);
            mailMessage.Subject = "用c#测试发送邮件";
            mailMessage.Body = "这是一次测试发送，发送人用的outlook邮箱";
            mailMessage.BodyEncoding = Encoding.UTF8;
            smtpClient.Send(mailMessage);
        }
        #endregion


    }

    public class MailHelper
    {
        public static void SendMail()
        {
            Outlook.Application olApp = new Outlook.Application();
            Outlook.MailItem mailItem = (Outlook.MailItem)olApp.CreateItem(Outlook.OlItemType.olMailItem);
            mailItem.To = "abc@163.com";
            mailItem.Subject = DateTime.Now.ToString("yyyyMMdd") + "_报表";
            mailItem.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;

            string content = "附件为" + DateTime.Now.ToString("yyyyMMdd") + " 数据，请查阅，谢谢！";
            content = "各收件人，<br/> <br/>请重点关注以下内容：<br/> <br/>" + content + "<br/> <br/><br/><br/>此邮件为系统自动邮件通知，请不要直接进行回复！谢谢。";
            content = content + "<br/>\r\n                                    <br/>Best Regards!\r\n                                    <br/>\r\n                                    <br/>          \r\n                                    <br/>==============================================\r\n                               \r\n                                    <br/>\r\n                                    <br/>\r\n                \r\n             ===============================================";


            mailItem.HTMLBody = content;
            mailItem.Attachments.Add(@"c:\test.rar");
            ((Outlook._MailItem)mailItem).Send();
            mailItem = null;
            olApp = null;
        }
    }
}
