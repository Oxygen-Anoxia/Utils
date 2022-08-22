using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    /// <summary>
    /// 日志信息
    /// </summary>
    public class LogInfo : RootEntity
    {

        /// <summary>
        /// 日志内容
        /// </summary>
        public string LogContent { get; set; }
        /// <summary>
        /// 日志级别：1 debug 2 info 3 warning 4 error
        /// </summary>
        public int LogLevel { get; set; }
        public LogInfo()
        {
            LogLevel = 1;
        }
    }
}