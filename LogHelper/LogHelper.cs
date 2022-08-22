using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace LogHelper
{
    public class LogHelper
    {
        public static void WriteLog(string log)
        {
            StackTrace stackTrace = new StackTrace();
            StackFrame frame = stackTrace.GetFrame(1);
            MethodBase method = frame.GetMethod();
            string name = method.ReflectedType.Name;
            log = "ClassName:" + name + "\nMethodName:" + method.Name + ",Log:" + log;
            WriteLogText("BusinessLog", log);
        }

        private static void WriteLogText(string logType, string log)
        {
            try
            {
                string text = AppDomain.CurrentDomain.BaseDirectory + "Log\\" + logType;
                string str = text;
                DateTime now = DateTime.Now;
                string text2 = str + "\\" + now.ToString("yyyy-MM-dd");
                string str2 = text2;
                now = DateTime.Now;
                string text3 = str2 + "\\" + now.ToString("yyyyMMddHH") + ".txt";
                if (!Directory.Exists(text))
                {
                    Directory.CreateDirectory(text);
                }
                if (!Directory.Exists(text2))
                {
                    Directory.CreateDirectory(text2);
                }
                string path = text3;
                now = DateTime.Now;
                File.AppendAllText(path, now.ToString() + " : " + log + "\r\n");
            }
            catch (Exception)
            {
            }
            finally
            {
            }
        }

        public static void WriteLog(string logType, string log)
        {
            StackTrace stackTrace = new StackTrace();
            StackFrame frame = stackTrace.GetFrame(1);
            MethodBase method = frame.GetMethod();
            string name = method.ReflectedType.Name;
            log = "ClassName:" + name + "\nMethodName:" + method.Name + ",Log:" + log;
            WriteLogText(logType, log);
        }

        public static void WriteEventLog(string log)
        {
            EventLog.WriteEntry("ProjecDev", log, EventLogEntryType.Error);
        }

    }
}
