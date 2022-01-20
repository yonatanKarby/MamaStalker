namespace MamaStalker.Common.DataParser.PacketParsers
{
    public interface IPacketparser
    {
        object Parse(byte[] buffer);
    }
}
