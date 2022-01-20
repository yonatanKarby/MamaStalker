using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using MamaStalker.Common.MessageProtocol.PacketMakers;

namespace MamaStalker.Common.MessageProtocol
{
    public enum PacketType
    {
        Header = 0,
        data = 1
    }
    public class PacketMaker
    {
        IDictionary<PacketType, IPacketmaker> makers;
        public PacketInfo CreatePacket(PacketType type, object data)
        {
            if(makers.TryGetValue(type, out var maker))
            {
                return maker.makePacket(data);
            }
            else
            {
                throw new Exception("Unrecognized packet type");
            }
        }

        private byte[] GetDataPacket(byte[] data)
        {
            throw new NotImplementedException();
        }

        private byte[] intToBytes(int value)
        {
            byte[] intBytes = BitConverter.GetBytes(value);
            Array.Reverse(intBytes);
            return intBytes;
        }
        private byte[] GetHeader(object data)
        {
            var buffer = new List<byte>();
            buffer.Add((byte)PacketType.Header);
            var json = JsonConvert.SerializeObject(data);
            var serializedData = Encoding.ASCII.GetBytes(json);
            var length = intToBytes(serializedData.Length);

            buffer.AddRange(length);
            buffer.AddRange(serializedData);

            return buffer.ToArray();
        }
    }
}
