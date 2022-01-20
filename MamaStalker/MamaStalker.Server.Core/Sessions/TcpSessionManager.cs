using MamaStalker.Common.Interfaces;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Linq;
using System.Threading.Tasks;
using MamaStalker.Common.YKDataProtocolMaker;
using MamaStalker.Common.DataMaker;

namespace MamaStalker.Server.Core.Sessions
{
    public class TcpSessionManager : ISessionManager
    {
        private IEnumerable<ITcpConnection> _connections;
        private readonly ITcpSessionFactory _sessionFactory;
        private readonly object _locker = new object();
        private TcpListener _listner;
        public TcpSessionManager(ITcpSessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
            _connections = new List<ITcpConnection>();
        }
        
        public void SendAll(PacketHeaderBase header, byte[] buffer)
        {
            IEnumerable<ITcpConnection> copy;
            lock (_locker)
            {
                copy = _connections.ToArray();
            }
            Parallel.ForEach(copy, (connection) =>
            {
                var messageSender = new LargeMessageSender(connection);
                messageSender.SendMessage(header, buffer);
            });
        }

        private void RegisterNewClient(TcpClient client)
        {
            var newSession = _sessionFactory.Create(client);
            lock(_locker)
            {
               _connections.Append(newSession);
            }
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
