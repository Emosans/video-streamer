using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace Protocols {
    internal static class Tcp_server{
       public static async void server(){
        int port = 12345;
        string ip = "127.0.0.1";

        // create an ip endpoint, tcp listener(Server)
        var _ipEndpoint = new System.Net.IPEndPoint((long)Convert.ToDouble(ip),port);
        TcpListener _tcpServer = new TcpListener(_ipEndpoint);

        try{
            _tcpServer.Start();
            // create a handler
            // create a stream to recieve/send data through the network
            using TcpClient handler = await _tcpServer.AcceptTcpClientAsync();
            await using NetworkStream stream = handler.GetStream();

            var message = $"{DateTime.Now}";
            var messageBytes = Encoding.UTF8.GetBytes(message);
            await stream.WriteAsync(messageBytes);

            Console.WriteLine($"sent msg {message}");

        } finally{
            _tcpServer.Stop();
        }

       }
    }
}