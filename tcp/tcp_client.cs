using System.Net;
using System;
using System.Net.Sockets;
using System.Text;

namespace Protocols{
    public class Tcp_client : IDisposable
    {
        private readonly string _ipAddress;
        private readonly int _port;
        private TcpClient? _tcpClient;

        public Tcp_client(string ipAddress, int port)
        {
            _ipAddress = ipAddress;
            _port = port;
        }

        public NetworkStream Connect()
        {
            var _ipEndPoint = new IPEndPoint(IPAddress.Parse(_ipAddress), _port);
            _tcpClient = new TcpClient();
            _tcpClient.Connect(_ipEndPoint);
            return _tcpClient.GetStream();
        }

        public void Dispose()
        {
            if (_tcpClient != null)
            {
                _tcpClient.Dispose();
                _tcpClient = null;
            }
        }
    }
}