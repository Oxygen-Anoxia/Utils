using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMqCommon
{
    /// <summary>
    /// rabbitmq 配置信息
    /// </summary>
    public class RabbitmqConfig
    {
        /// <summary>
        /// IP地址
        /// </summary>
        public string HostName { get; set; }
        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 虚拟主机
        /// </summary>
        public string VirtualHost { get; set; }
        /// <summary>
        /// 队列名称
        /// </summary>
        public string QueueName { get; set; }

    }

}
