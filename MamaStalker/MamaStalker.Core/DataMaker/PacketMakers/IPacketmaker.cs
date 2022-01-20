namespace MamaStalker.Common.YKDataProtocolMaker.PacketMakers
{
    public interface IPacketmaker
    {
        PacketInfo makePacket(object data);
    }
}
