using System.Net;
using System;
using System.Net.Sockets;
using System.Text;

namespace Protocols{
    internal static class Tcp_client{
        public static async void client(){
            int port = 12345;
            string ipAddress = "127.0.0.1";

            var _ipEndPoint = new IPEndPoint((long)Convert.ToDouble(ipAddress),port);

            // create a client
            using TcpClient _tcpClient = new();
            await _tcpClient.ConnectAsync(_ipEndPoint);
            await using NetworkStream stream = _tcpClient.GetStream();

            // create a buffer to send/recieve a message
            var buffer = new byte[1024];
            int recieved = await stream.ReadAsync(buffer);
            var message = Encoding.UTF8.GetString(buffer, 0, recieved);
            Console.WriteLine($"Message recieved {message}");

        }
    }
}