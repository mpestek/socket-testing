using System;
using Tcp = System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using SerializableTypes;

namespace TcpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                using (var client = new Tcp.TcpClient())
                {

                    client.Connect("127.0.0.1", 6400);

                    if (!client.Connected)
                    {
                        continue;
                    }

                    var stream = client.GetStream();

                    var data = System.Text.ASCIIEncoding.ASCII.GetBytes("Moje ime je Mesud! Je li tako ili nije?");
                    var dataObj = new Covjek { Ime = "Mesud", Prezime = "Pestek" };

                    BinaryFormatter serializer = new BinaryFormatter();
                    try
                    {
                        serializer.Serialize(stream, dataObj);
                        serializer.Serialize(stream, dataObj);
                        serializer.Serialize(stream, dataObj);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;
                }
            }
        }
    }
}