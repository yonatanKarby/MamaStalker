namespace MamaStalker.Common.MessageProtocol.PacketMakers
{
    public interface IPacketmaker
    {
        PacketInfo makePacket(object data);
    }
}
