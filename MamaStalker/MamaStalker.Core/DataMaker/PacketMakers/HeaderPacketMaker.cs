using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MamaStalker.Common.YKDataProtocolMaker.PacketMakers
{
    public class HeaderPacketMaker : IPacketmaker
    {
        private byte[] intToBytesArray(int value)
        {
            byte[] intBytes = BitConverter.GetBytes(value);
            Array.Reverse(intBytes);
            return intBytes;
        }

        private byte[] SerializeToBytes(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            return Encoding.ASCII.GetBytes(json);
        }

        public PacketInfo makePacket(object data)
        {
            var buffer = new List<byte>();
            buffer.Add((byte)PacketType.Header);

            var serializedData = SerializeToBytes(data);
            var lengthInBytesArray = intToBytesArray(serializedData.Length);

            buffer.AddRange(lengthInBytesArray);
            buffer.AddRange(serializedData);

            return new PacketInfo()
            {
                data = buffer.ToArray()
            };
        }
    }
}
