﻿using MamaStalker.Common.Interfaces;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Linq;
using System.Threading.Tasks;

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
            Parallel.ForEach(_connections, (connection) =>
            {
                connection.Write(buffer);
            });
        }

        private void RegisterNewClient(TcpClient client)
        {
            var newSession = _sessionFactory.Create(client);
            _connections.Append(newSession);
        }

        public void Start(int portNumber)
        {
            _listner = new TcpListener(portNumber);
            _listner.Start();
            while (true)
            {
                var newClient = _listner.AcceptTcpClient();
                RegisterNewClient(newClient);
            }
        }
    }
}
