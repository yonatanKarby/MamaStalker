using MamaStalker.Common.DataMaker;

namespace MamaStalker.Server.Core.Sessions
{
    public interface ISessionManager
    {
        void Start(int portNumber);
        void SendAll(PacketHeaderBase header, byte[] buffer);
    }
}
