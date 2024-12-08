using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Protocols
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Task.Run(() =>
            {
                Tcp_server server = new Tcp_server("", 5000); // specify ip  of your pc
                server.server();
            });

            System.Threading.Thread.Sleep(2000);
            Console.ReadLine();

            // Tcp_client client = new Tcp_client("127.0.0.1", 5000);
            // NetworkStream clientStream = client.Connect();

            // Video_capture_client video_client = new Video_capture_client(clientStream);
            // video_client.show_captures();

            // Console.WriteLine("Press any key to stop...");
            // Console.ReadKey();

            // uncomment above code and then comment server code on dif pc and connect to the server.


            // works for ip con server - this pc 
            // client connects to this ip on the same network

        }
    }
}
