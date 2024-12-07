using System.Net.Sockets;

namespace Protocols
{
    public class ClientProgram
    {
        public static void Main(string[] args)
        {
            using var client = new Tcp_client("127.0.0.1", 5000);
            NetworkStream clientStream = client.Connect();

            Video_capture_client videoClient = new Video_capture_client(clientStream);
            videoClient.show_captures();
        }
    }
}
