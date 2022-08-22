using System;

namespace SocketUtil
{
    class Program
    {
        static void Main(string[] args)
        {
            SocketClient client = new SocketClient(19937);
            client.StartClient();
            Console.ReadKey();
        }
    }
}
