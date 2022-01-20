using MamaStalker.Common.DataMaker;

namespace MamaStalker.Server.Core.Functionality
{
    public delegate void OnFunctionalitySend(PacketHeaderBase packet, byte[] buffer);
    public interface IServerFunctionality
    {
        void Register(OnFunctionalitySend callback);
        void Start();
    }
}
