using MQTTnet.Core.Server;
using MQTTnet.Core.Protocol;
using System;
using MQTTnet;
using MQTTnet.Core.Adapter;
using System.Text;
using System.Threading;

namespace MqttNetServer
{
    class Program
    {

        public static MqttServer mqttServer = null;


        private static async void StartMqttServer()
        {
            if (mqttServer == null)
            {
                try
                {
                    var options = new MqttServerOptions()
                    {
                        ConnectionValidator = p =>
                        {
                            if (p.Username != "tenant" || p.Password != "tenant123")
                            {
                                Console.WriteLine("客户端用户密码错误");
                                return MqttConnectReturnCode.ConnectionRefusedBadUsernameOrPassword;
                            }
                            return MqttConnectReturnCode.ConnectionAccepted;
                        }
                    };

                    //通过工厂类实例化mqttserver
                    mqttServer = new MqttServerFactory().CreateMqttServer(options) as MqttServer;
                    //定义接收消息事件 
                    mqttServer.ApplicationMessageReceived += MqttServer_ApplicationMessageReceived;
                    //定义连接事件
                    mqttServer.ClientConnected += MqttServer_ClientConnected;
                    //定义断开连接事件
                    mqttServer.ClientDisconnected += MqttServer_ClientDisconnected;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

                //开启mqttserver
                await mqttServer.StartAsync();
                Console.WriteLine("MQTT 服务启动成功");
            }
        }

        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MqttServer_ClientConnected(object sender, MqttClientConnectedEventArgs e)
        {
            Console.WriteLine($"客户端{e.Client.ClientId}已连接，协议版本：{e.Client.ProtocolVersion}");
        }


        /// <summary>
        /// 断开连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MqttServer_ClientDisconnected(object sender, MqttClientDisconnectedEventArgs e)
        {
            Console.WriteLine($"客户端{e.Client.ClientId}已断开连接");
        }

        private static void MqttServer_ApplicationMessageReceived(object sender, MqttApplicationMessageReceivedEventArgs e)
        {
            Console.WriteLine($"客户端：{e.ClientId},主题：{e.ApplicationMessage.Topic}，负荷：" +
                $"{Encoding.UTF8.GetString(e.ApplicationMessage.Payload)},QoS:" +
                $"{e.ApplicationMessage.QualityOfServiceLevel}," +
                $"保留：{e.ApplicationMessage.Retain}"
                );
        }


        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            new Thread(StartMqttServer).Start();

            while (true)
            {
                var inputString = Console.ReadLine().ToLower().Trim();

                if (inputString == "exit")
                {
                    mqttServer?.StartAsync();
                    Console.WriteLine("MQTT 服务已停止！");
                    break;
                }
                else if (inputString == "clients")
                {
                    foreach (var item in mqttServer.GetConnectedClients())
                    {
                        Console.WriteLine($"客户端标识：{item.ClientId},协议版本：{item.ProtocolVersion}");
                    }
                }
                else
                {
                    Console.WriteLine($"命令{inputString}无效");
                }

            }
        }
    }
}
