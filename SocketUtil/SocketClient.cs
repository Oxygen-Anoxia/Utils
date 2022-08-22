using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SocketUtil
{
    class SocketClient
    {
        private string _ip = string.Empty;
        private int _port = 0;
        private Socket _socket = null;
        private byte[] buffer = new byte[1024 * 1024];

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ip">连接服务器的IP</param>
        /// <param name="port">连接服务器的端口</param>
        public SocketClient(string ip, int port)
        {
            this._ip = ip;
            this._port = port;
        }
        public SocketClient(int port)
        {
            this._ip = "111.0.125.219";
            this._port = port;
        }

        /// <summary>
        /// 开启服务,连接服务端
        /// </summary>
        public void StartClient()
        {
            using TcpClient client = new TcpClient(_ip, _port);
            using NetworkStream stream = client.GetStream();
            {
                try
                {
                    string str = "{\"districtCode\":\"3212\",\"dataId\":\"1844076f589e464c95401e2a67241739\",\"appId\":\"9d609714ee7311ea9006d4ae52635598\",\"keyid\":\"a3f2c0b2b4f811eaa30dd4ae52635598\",\"serviceId\":\"APP_ID\"}@@";
                    byte[] reportData = Encoding.UTF8.GetBytes(str + "@@}");
                    // 发送数据
                    Console.WriteLine("发送数据:" + reportData);
                    stream.Write(reportData, 0, reportData.Length);
                    // 返回结果
                    var dataR = new byte[1024 * 1024];
                    var bytes = stream.Read(dataR, 0, dataR.Length);
                    string ResponseData = Encoding.UTF8.GetString(dataR, 0, bytes);
                    Console.WriteLine("返回结果:" + ResponseData);

                }
                catch (Exception ex)
                {
                    //NLogWebExtension.Error("【Inroad.ParkButtJoint.NanTong/Socket/TcpDataSendExecutiveService/TcpDataSendExecutive】TCP发送异常: " + ex.StackTrace, ex);
                    // TODO : TCP发送异常
                    return;
                }
            }


            //try
            //{
            //    //1.0 实例化套接字(IP4寻址地址,流式传输,TCP协议)
            //    _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //    //2.0 创建IP对象
            //    IPAddress address = IPAddress.Parse(_ip);
            //    //3.0 创建网络端口包括ip和端口
            //    IPEndPoint endPoint = new IPEndPoint(address, _port);
            //    //4.0 建立连接
            //    _socket.Connect(endPoint);
            //    Console.WriteLine("连接服务器成功");
            //    //5.0 接收数据
            //    int length = _socket.Receive(buffer);
            //    Console.WriteLine("接收服务器{0},消息:{1}", _socket.RemoteEndPoint.ToString(), Encoding.UTF8.GetString(buffer, 0, length));
            //    //6.0 像服务器发送消息
            //    for (int i = 0; i < 10; i++)
            //    {
            //        Thread.Sleep(2000);
            //        string sendMessage = string.Format("客户端发送的消息,当前时间{0}", DateTime.Now.ToString());
            //        sendMessage = "{\"districtCode\":\"3212\",\"dataId\":\"1844076f589e464c95401e2a67241739\",\"appId\":\"9d609714ee7311ea9006d4ae52635598\",\"keyid\":\"a3f2c0b2b4f811eaa30dd4ae52635598\",\"serviceId\":\"APP_ID\"}@@";
            //        _socket.Send(Encoding.UTF8.GetBytes(sendMessage));
            //        Console.WriteLine("向服务发送的消息:{0}", sendMessage);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    _socket.Shutdown(SocketShutdown.Both);
            //    _socket.Close();
            //    Console.WriteLine(ex.Message);
            //}
            //Console.WriteLine("发送消息结束");
            //Console.ReadKey();
        }


    }
}
