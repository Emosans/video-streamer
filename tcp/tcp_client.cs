using System.Net;
using System;
using System.Net.Sockets;
using System.Text;

namespace Protocols{
    public class Tcp_client{
        private readonly string _ipAddress;
        private readonly int _port;
        public Tcp_client(string ipAddress,int port){
            _ipAddress = ipAddress;
            _port = port;

        }

        public NetworkStream Connect(){
            

            // create a client
            var _ipEndPoint = new IPEndPoint(IPAddress.Parse(_ipAddress),_port);
            using TcpClient _tcpClient = new();
            _tcpClient.Connect(_ipEndPoint);
            return _tcpClient.GetStream();

            // create a buffer to send/recieve a message
            // var buffer = new byte[1024];
            // int recieved = await stream.ReadAsync(buffer);
            // var message = Encoding.UTF8.GetString(buffer, 0, recieved);
            // Console.WriteLine($"Message recieved {message}");

        }
    }
}