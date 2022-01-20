using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MamaStalker.Common.MessageProtocol.PacketMakers
{
    public class HeaderPacketMaker : IPacketmaker
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
            buffer.Add((byte)PacketType.Header);
            var json = JsonConvert.SerializeObject(data);
            var serializedData = Encoding.ASCII.GetBytes(json);
            var length = intToBytes(serializedData.Length);

            buffer.AddRange(length);
            buffer.AddRange(serializedData);

            return new PacketInfo()
            {
                data = buffer.ToArray(),
                length = buffer.Count
            };
        }
    }
}
