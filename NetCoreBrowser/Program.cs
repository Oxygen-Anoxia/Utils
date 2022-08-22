using System;
using System.Diagnostics;

namespace NetCoreBrowser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Process.Start("explorer", "https://www.baidu.com");

            //Process.Start("explorer", "https://99.in-road.com/vweb/#/Gateway/home");
            //System.Diagnostics.Process.Start("https://99.in-road.com/vweb/#/Gateway/home?userCode=18121225109%20&clientToken=eyJhbGciOiJSUzI1NiIsImtpZCI6IjNDQ0E4QkE1NUM2MDFBRjY2OENDQUQ1NTg0RDRFNThEIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE2NTgyMTM4MDMsImV4cCI6MTY1ODMwMDIwMywiaXNzIjoiaHR0cDovLzEyNy4wLjAuMTo4MiIsImF1ZCI6WyJPYWFSZXNvdXJjZSIsImh0dHA6Ly8xMjcuMC4wLjE6ODIvcmVzb3VyY2VzIl0sImNsaWVudF9pZCI6Ik9hYUNsaWVudCIsImlhdCI6MTY1ODIxMzgwMywic2NvcGUiOlsiT2FhU2NvcGUiXX0.l3xuf_2NJ56TJmVOsaR-z6UFtMPLwH9aHzgxjB3kgJdgzXZFc6pYm610Aa659JIuG1UQufVwfEboenFBxCdaBHnoj7e2EMDwDMUiuzvdQKlOOtUV35NAD7KwG1pgyNsZbQlb2cIlVhu493It2rQ6-hYV89XYPm1eRU1Z8seKru0NSFGT7j9WNX2AJN3PYC-nUAJ6xJgBl0dQfQJ0Y5mjXmLSjcL5vpQl4nF4E1IdrIxwk2UHv1hSQjgpBfGoELiY4rCvAgp8EQD-0pWm-w0Zl3-Cxrpx8rj2jd5xQ8T37jG6DMSt8dhvDkEWLP6DY2fQT4YsaQzODWahpFwmmHXMzw");


            string url = "https://www.baidu.com/s?wd=what";
            url = "https://99.in-road.com/vweb/#/Gateway/home?userCode=18121225109%20&clientToken=eyJhbGciOiJSUzI1NiIsImtpZCI6IjNDQ0E4QkE1NUM2MDFBRjY2OENDQUQ1NTg0RDRFNThEIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE2NTgyMTM4MDMsImV4cCI6MTY1ODMwMDIwMywiaXNzIjoiaHR0cDovLzEyNy4wLjAuMTo4MiIsImF1ZCI6WyJPYWFSZXNvdXJjZSIsImh0dHA6Ly8xMjcuMC4wLjE6ODIvcmVzb3VyY2VzIl0sImNsaWVudF9pZCI6Ik9hYUNsaWVudCIsImlhdCI6MTY1ODIxMzgwMywic2NvcGUiOlsiT2FhU2NvcGUiXX0.l3xuf_2NJ56TJmVOsaR-z6UFtMPLwH9aHzgxjB3kgJdgzXZFc6pYm610Aa659JIuG1UQufVwfEboenFBxCdaBHnoj7e2EMDwDMUiuzvdQKlOOtUV35NAD7KwG1pgyNsZbQlb2cIlVhu493It2rQ6-hYV89XYPm1eRU1Z8seKru0NSFGT7j9WNX2AJN3PYC-nUAJ6xJgBl0dQfQJ0Y5mjXmLSjcL5vpQl4nF4E1IdrIxwk2UHv1hSQjgpBfGoELiY4rCvAgp8EQD-0pWm-w0Zl3-Cxrpx8rj2jd5xQ8T37jG6DMSt8dhvDkEWLP6DY2fQT4YsaQzODWahpFwmmHXMzw";
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            //不使用shell启动
            p.StartInfo.RedirectStandardInput = true;//喊cmd接受标准输入
            p.StartInfo.RedirectStandardOutput = false;//不想听cmd讲话所以不要他输出
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示窗口
            p.Start();//向cmd窗口发送输入信息 后面的&exit告诉cmd运行好之后就退出
            p.StandardInput.WriteLine("start " + url + "&exit"); p.StandardInput.AutoFlush = true; p.WaitForExit();//等待程序执行完退出进程p.Close();

            Console.ReadLine();


        }
    }
}
