using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMqCommon;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace RabbitMqConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=============Consumer=============");

            while (true)
            {
                ReceiveMessage();
                Console.WriteLine("==========================");
                Thread.Sleep(5);
            }

            Console.ReadLine();
        }


        public static void ReceiveMessage()
        {

            try
            {
                //消费者是队列中的消息
                //string queueName = "normal";
                string queueName = RabbitMQHelper.config.QueueName;
                using (var connection = RabbitMQHelper.GetConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        var consumer = new EventingBasicConsumer(channel);
                        channel.BasicConsume(queueName, true, consumer);

                        consumer.Received += (model, ea) =>
                        {
                            Console.WriteLine("开始消费" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss"));

                            var body = ea.Body;
                            var message = Encoding.UTF8.GetString(body.ToArray());
                            //int dots = message.Split('.').Length - 1;
                            //Thread.Sleep(1000);

                            Console.WriteLine("消费数据 {0}", message);

                            //调用接口
                            //DealData(message);

                            Console.WriteLine("Done");
                            //channel.BasicAck(ea.DeliveryTag, false);

                        };
                        //channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);

                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void DealData(string postData)
        {
            //string result = "";
            //HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://localhost:5001/webSocketApi/localtion/DealWithQueueDatas");

            string url = "http://localhost:8011/webSocketApi/localtion/DealWithQueueDatas";
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            //req.Timeout = 800;//设置请求超时时间，单位为毫秒
            req.ContentType = "application/json";
            byte[] data = Encoding.UTF8.GetBytes(postData);
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }

            Console.WriteLine(result);

        }

    }


}
