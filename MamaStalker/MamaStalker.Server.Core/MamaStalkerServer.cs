using MamaStalker.Server.Core.Functionality;
using MamaStalker.Server.Core.Sessions;

namespace MamaStalker.Server.Core
{
    public class MamaStalkerServer
    {
        private readonly IServerFunctionality _functionality;
        private readonly ISessionManager _sessionManager;
        private readonly int _port;
        public void Start()
        {
            _functionality.Register(_sessionManager.SendAll);
            _functionality.Start();
            _sessionManager.Start(_port);
        }
    }
}
