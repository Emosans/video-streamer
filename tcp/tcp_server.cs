using System;
using System.Net;
using System.Net.Sockets;

namespace Protocols
{
    public class Tcp_server
    {
        private readonly string _ipAddress;
        private readonly int _port;
        public Tcp_server(string ip,int port){
            _ipAddress = ip;
            _port = port;
        }
        public void server()
        {

            var _ipEndpoint = new System.Net.IPEndPoint(IPAddress.Parse(_ipAddress), _port);
            TcpListener _tcpServer = new TcpListener(_ipEndpoint);

            try
            {
                _tcpServer.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                _tcpServer.Start();
                Console.WriteLine($"Server started on {_ipAddress}:{_port}, waiting for client connection...");

                using TcpClient handler = _tcpServer.AcceptTcpClient();
                Console.WriteLine("Client connected!");

                NetworkStream stream = handler.GetStream();
                Video_capture_server _serverObj = new Video_capture_server(stream);
                _serverObj.start_capture();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Server encountered an error: {ex.Message}");
            }
            finally
            {
                _tcpServer.Stop();
                Console.WriteLine("Server stopped.");
            }
        }
    }
}
