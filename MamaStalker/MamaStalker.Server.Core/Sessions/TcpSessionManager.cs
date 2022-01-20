using MamaStalker.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace MamaStalker.Server.Core.Sessions
{
    public class TcpSessionManager : ISessionManager
    {
        private IEnumerable<ITcpConnection> _connections;
        private readonly ITcpSessionFactory _sessionFactory;
        private TcpListener _listner;
        public TcpSessionManager(ITcpSessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
            _connections = new List<ITcpConnection>();
        }
        
        public void SendAll(byte[] buffer)
        {
            throw new NotImplementedException();
        }

        public void Start(int portNumber)
        {
            _listner = new TcpListener(portNumber);
            
        }
    }
}
