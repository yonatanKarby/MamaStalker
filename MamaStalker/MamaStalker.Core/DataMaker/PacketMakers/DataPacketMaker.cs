using System;
using System.Collections.Generic;

namespace MamaStalker.Common.YKDataProtocolMaker.PacketMakers
{
    public class DataPacketMaker : IPacketmaker
    {
        private byte[] intToBytes(int value)
        {
            byte[] intBytes = BitConverter.GetBytes(value);
            Array.Reverse(intBytes);
            return intBytes;
        }
        public PacketInfo makePacket(object data)
        {
            var buffer = new List<byte>();
            buffer.Add((byte)PacketType.data);
            buffer.AddRange(intToBytes(((byte[])data).Length));
            buffer.AddRange((byte[])data);
            return new PacketInfo()
            {
                data = buffer.ToArray(),
                length = buffer.Count
            };
        }
    }
}
