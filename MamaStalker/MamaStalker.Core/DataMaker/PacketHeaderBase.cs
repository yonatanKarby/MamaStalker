namespace MamaStalker.Common.DataMaker
{
    public enum MessageType
    {
        image = 0,
    }
    public class PacketHeaderBase
    {
        public MessageType type { get; set; }
    }
    public class ImagePacketHeader : PacketHeaderBase
    {
        public int NumberOfPackets { get; set; }
        public string fileName { get; set; }
    }
}
