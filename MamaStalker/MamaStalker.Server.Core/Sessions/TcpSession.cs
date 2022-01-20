using MamaStalker.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace MamaStalker.Server.Core.Sessions
{
    public class TcpSession : ITcpConnection
    {
        public readonly Guid Id;
        
        private bool _isRunning = true;
        private readonly TcpClient _client;
        public byte[] Read()
        {
            try
            {
                byte[] buffer = new byte[]
                _client.GetStream().Read()
            }
        }

        public void Write(byte[] buffer)
        {
            throw new NotImplementedException();
        }
    }
}
