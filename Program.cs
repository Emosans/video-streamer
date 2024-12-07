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
                Tcp_server server = new Tcp_server("127.0.0.1",5000);
                server.server();
            });

            System.Threading.Thread.Sleep(2000);

            Tcp_client client = new Tcp_client("127.0.0.1", 5000);
            NetworkStream clientStream = client.Connect();

            Video_capture_client video_client = new Video_capture_client(clientStream);
            video_client.show_captures();
        }
    }
}
