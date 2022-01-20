using System;
using System.Net.Sockets;
using MamaStalker.Common.Interfaces;

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
                byte[] buffer = new byte[ServerSettings.Default.DefualtBufferSize];
                _client.GetStream().Read(buffer);
                return buffer;
            }
            catch
            {
                Console.WriteLine($"Session {Id.ToString()} has stopped");
                _isRunning = false;
                return null;
            }
        }

        public void Write(byte[] buffer)
        {
            try
            {
                _client.GetStream().Write(buffer);
            }
            catch
            {
                Console.WriteLine($"Session {Id.ToString()} has stopped");
                _isRunning = false;
            }
        }

        public bool IsRunning()
        {
            return _isRunning;
        }
    }
}
