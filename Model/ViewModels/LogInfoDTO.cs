using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModels
{
    /// <summary>
    /// 日志信息
    /// </summary>
    public class LogInfoDTO : RootEntity
    {

        /// <summary>
        /// 日志内容
        /// </summary>
        public string LogContent { get; set; }
        public string lang { get; set; }
    }
}
