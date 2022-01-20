using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace MamaStalker.Server.Core.Sessions
{
    public interface ITcpSessionFactory
    {
        public TcpSession Create(TcpClient client)
        {

        }
    }
}
