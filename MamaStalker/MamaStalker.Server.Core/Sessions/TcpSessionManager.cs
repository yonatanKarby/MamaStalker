using System;
using System.Collections.Generic;
using System.Text;

namespace MamaStalker.Server.Core.Sessions
{
    public class TcpSessionManager : ISessionManager
    {
        public TcpSessionManager()
        {

        }
        
        public void SendAll(byte[] buffer)
        {
            throw new NotImplementedException();
        }

        public void Start(int portNumber)
        {
            throw new NotImplementedException();
        }
    }
}
