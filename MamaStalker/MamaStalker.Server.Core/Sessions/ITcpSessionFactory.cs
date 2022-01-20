using System;
using System.Net.Sockets;

namespace MamaStalker.Server.Core.Sessions
{
    public interface ITcpSessionFactory
    {
        public TcpSession Create(TcpClient client)
        {
            return new TcpSession(client, Guid.NewGuid());
        }
    }
}
