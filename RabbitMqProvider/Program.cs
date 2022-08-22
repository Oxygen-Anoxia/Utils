using RabbitMQ.Client;
using RabbitMqCommon;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RabbitMqProvider
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=============Provider=============");
            SendMessage();

        }

        public static void SendMessage()
        {
            //string queueName = "normal";
            string queueName = RabbitMQHelper.config.QueueName;

            using (var connection = RabbitMQHelper.GetConnection())
            {
                //创建信道
                using (var channel = connection.CreateModel())
                {
                    //创建队列
                    Dictionary<string, object> arguments = new Dictionary<string, object>();
                    arguments.Add("x-message-ttl", 600000);
                    //channel.QueueDeclare(queueName, true, false, false, arguments);
                    //channel.QueueDeclare(queueName, true, false, false, null);

                    while (true)
                    {
                        string id = Guid.NewGuid().ToString();

                        List<string> lst = new List<string>();

                        lst.Add("BTT38304706");
                        lst.Add("BTT38304730");
                        lst.Add("BTT38304671");
                        lst.Add("BTT38304718");
                        lst.Add("BTT38304661");
                        lst.Add("BTT38304617");
                        lst.Add("BTT38304689");
                        //for (int i = 5; i < 6; i++)
                        foreach (var item in lst)
                        {
                            id = item.ToString();

                            string message = "Hello RabbitMQ Message" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            message = "{\"method\":\"position\",\"params\":{\"absolute\":true,\"altitude\":5.9,\"areaId\":2,\"beacons\":\"BTI24007112(3600),BTI24007111(4525),BTI24007110(4975)\",\"entityType\":\"staff\",\"floor\":1,\"inDoor\":1641428620698,\"labId\":0,\"labInTime\":0,\"latitude\":32.26412828387988,\"locationTime\":1641435846703,\"longitude\":119.10907212564243,\"out\":false,\"rootAreaId\":1,\"silent\":false,\"speed\":0,\"tagId\":\"BTT32003823\",\"volt\":4000,\"voltUnit\":\"mV\",\"x\":79.628,\"y\":177.458,\"z\":0}}";

                            message = "{\"method\":\"position\",\"params\":{\"absolute\":true,\"altitude\":5.9,\"areaId\":2,\"beacons\":\"BTI24007112(3600),BTI24007111(4525),BTI24007110(4975)\",\"entityType\":\"staff\",\"floor\":1,\"inDoor\":1641428620698,\"labId\":0,\"labInTime\":0,\"latitude\":32.26412828387988,\"locationTime\":1641435846703,\"longitude\":119.10907212564243,\"out\":false,\"rootAreaId\":1,\"silent\":false,\"speed\":0,\"tagId\":\"" + id + "\",\"volt\":4000,\"voltUnit\":\"mV\",\"x\":79.628,\"y\":177.458,\"z\":0}}";
                            var body = Encoding.UTF8.GetBytes(message);
                            //发送消息到rabbitmq,使用rabbitmq 默认提供的交换机，默认的路由key和队列名称完全一致
                            channel.BasicPublish(exchange: "", routingKey: queueName, null, body);
                            //
                            Console.WriteLine("send normal message--" + message);
                            //Thread.Sleep(1000);

                        }



                    }

                }
            }
        }

    }
}
