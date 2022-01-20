namespace MamaStalker.Server.Core.Sessions
{
    public interface ISessionManager
    {
        void Start(int portNumber);
        void SendAll(byte[] buffer);
    }
}
