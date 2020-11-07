using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using Tcp = System.Net.Sockets;

namespace TcpListener
{
    class Program
    {
        static void Main(string[] args)
        {
            Tcp.TcpListener listener = null;

            try
            {
                listener = new Tcp.TcpListener(System.Net.IPAddress.Parse("127.0.0.1"), 6400);

                listener.Start();
                Console.WriteLine("Listening for incoming connections...");

                while (true)
                {
                    var client = listener.AcceptTcpClient();

                    var stream = client.GetStream();

                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    var obj1 = binaryFormatter.Deserialize(stream);
                    var obj2 = binaryFormatter.Deserialize(stream);
                    var obj3 = binaryFormatter.Deserialize(stream);

                    Console.WriteLine(obj1.ToString());
                }
            }
            finally
            {
                listener?.Stop();
            }
        }
    }
}
