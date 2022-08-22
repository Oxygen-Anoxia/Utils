using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMqCommon
{
    public class RabbitMQHelper
    {
        public static IConnection GetConnection()
        {
            try
            {
                var factory = new ConnectionFactory()
                {
                    HostName = config.HostName,//ip
                    Port = config.Port,//端口
                    UserName = config.UserName,//账号
                    Password = config.Password,//密码
                    VirtualHost = config.VirtualHost,//虚拟主机
                    RequestedHeartbeat = TimeSpan.FromSeconds(5),
                    AutomaticRecoveryEnabled = true
                };

                var va = factory.CreateConnection();
                return va;
            }
            catch (Exception ex)
            {
                var str = ex.Message;
                return null;
            }
        }


        private static readonly string configPath = "mqConfig.json";
        public static RabbitmqConfig config = new RabbitmqConfig();

        static RabbitMQHelper()
        {
            string configJson = string.Empty;
            using (System.IO.StreamReader file = System.IO.File.OpenText(configPath))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o = (JObject)JToken.ReadFrom(reader);
                    configJson = o.ToString();
                }
            }
            RabbitmqConfig realTimeLocationConfig = new RabbitmqConfig();
            realTimeLocationConfig = (RabbitmqConfig)JsonConvert.DeserializeObject(configJson, typeof(RabbitmqConfig));
            config = realTimeLocationConfig;
        }

    }
}
